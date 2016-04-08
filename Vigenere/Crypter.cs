using System;

namespace Vigenere
{
    public class Crypter
    {
        private string _key;
        private char[] _alphabet;

        public void SetKey(string key)
        {
            this._key = key;
        }

        public void SetAlphabet(string alphabet)
        {
            if (String.IsNullOrWhiteSpace(alphabet))
                throw new ArgumentNullException("alphabet");

            this._alphabet = alphabet.ToUpper().ToCharArray();
        }

        public void SetAlphabet(char[] alphabet)
        {
            SetAlphabet(string.Concat(alphabet));
        }

        public string Encode(string text)
        {
            return RunProcedure(text, (textCharRank, keyCharRank) => (keyCharRank + textCharRank) % _alphabet.Length);
        }

        public string Decode(string cipherText)
        {
            // le calcul compliqué sert à avoir un modulo positif
            return RunProcedure(cipherText, (textCharRank, keyCharRank) => (((- keyCharRank + textCharRank) % _alphabet.Length) + _alphabet.Length) % _alphabet.Length);
        }
        /// <summary>
        /// Joue l'algorithme de chiffrement / dechiffrement. 
        /// La distinction entre les deux se joue uniquement sur le calcul de l'index de la lettre chiffrée.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="indexCalculator">fonction lambda permettant de calculer l'index de la lettre chiffrée (ou déchiffrée)</param>
        /// <returns></returns>
        private string RunProcedure(string text, Func<int, int, int> indexCalculator)
        {
            CheckKeyAndUpperizeIt();
            int keyIndexSkipUnknown = 0;

            string upperText = text.ToUpper();
            char[] cipherArray = new char[upperText.Length];

            for (int textCharIndex = 0; textCharIndex < upperText.Length; textCharIndex++)
            {
                int textCharRank = GetCharRankInAplhabet(upperText[textCharIndex]);
                if (textCharRank >= 0)
                {
                    int keyCharIndex = keyIndexSkipUnknown % _key.Length;
                    int keyCharRank = GetCharRankInAplhabet(_key[keyCharIndex]);

                    int cipherIndex = indexCalculator(textCharRank, keyCharRank);
                    cipherArray[textCharIndex] = _alphabet[cipherIndex];

                    keyIndexSkipUnknown++;
                }
                else
                {
                    cipherArray[textCharIndex] = upperText[textCharIndex];
                }
            }

            return string.Concat(cipherArray);
        }

        private int GetCharRankInAplhabet(char c)
        {
            int charRank = -1;

            for (int i = 0; i < _alphabet.Length; i++)
            {
                if (c == _alphabet[i])
                {
                    charRank = i;
                    break;
                }
            }

            return charRank;
        }

        private void CheckKeyAndUpperizeIt()
        {
            if (string.IsNullOrWhiteSpace(_key))
            {
                throw new ArgumentException("Key is null or white space !");
            }

            this._key = this._key.ToUpper();
            for (int i = 0; i < _key.Length; i++)
            {
                if (GetCharRankInAplhabet(_key[i]) < 0)
                {
                    throw new ArgumentException("Key contains char that does not exist in alphabet !");
                }
            }
        }
    }
}
