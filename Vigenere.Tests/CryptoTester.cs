using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vigenere.Tests
{
    [TestClass]
    public class CryptoTester
    {
        private string _alphabet;
        private string _key;
        private string _expectedCipherText;
        private string _expectedClearText;

        public CryptoTester()
        {
            _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            _key = "musique";
            _expectedClearText = "j'adore ecouter la radio toute la journee";
            _expectedCipherText = "V'UVWHY IOIMBUL PM LSLYI XAOLM BU NAOJVUY";
        }
        [TestMethod]
        public void ItShouldBePossibleToSetAplhabetWithCharArray()
        {
            Crypter crypter = new Crypter();
            crypter.SetAlphabet(_alphabet.ToCharArray());
            crypter.SetKey(_key);

            string cipherText = crypter.Encode(_expectedClearText);

            Assert.AreEqual(_expectedCipherText, cipherText, true);
        }

        [TestMethod]
        public void EncodingCaseInsensitivelyShouldSuccess()
        {
            Crypter crypter = new Crypter();
            crypter.SetAlphabet(_alphabet);
            crypter.SetKey(_key);
            string cipherText = crypter.Encode("ec");

            Assert.AreEqual("QW", cipherText, true);
        }

        [TestMethod]
        public void DecodingCaseInsensitivelyShouldSuccess()
        {
            Crypter crypter = new Crypter();
            crypter.SetAlphabet(_alphabet);
            crypter.SetKey(_key);

            string clearText = crypter.Decode(_expectedCipherText);

            Assert.AreEqual(_expectedClearText, clearText, true);
        }
        [TestMethod]
        public void EncodingShouldIgnoreCharNotInAlphabet()
        {
            Crypter crypter = new Crypter();
            crypter.SetAlphabet(_alphabet);
            crypter.SetKey(_key);

            string cipherText = crypter.Encode(_expectedClearText);
            Assert.AreEqual(_expectedCipherText, cipherText, true);
        }
        [TestMethod]
        public void EncodingShouldThrowAnExceptionIfKeyIsEmpty()
        {
            Exception exception = null;
            Crypter crypter = new Crypter();
            crypter.SetAlphabet("aze");
            crypter.SetKey(string.Empty);
            try
            {
                string clearText = crypter.Encode(_expectedCipherText);
            }
            catch (ArgumentException e)
            {
                exception = e;
            }
            Assert.IsNotNull(exception);
        }
        [TestMethod]
        public void EncodingShouldThrowAnExceptionIfKeyIsNull()
        {
            Exception exception = null;
            Crypter crypter = new Crypter();
            crypter.SetAlphabet("aze");
            crypter.SetKey(null);
            try
            {
                string clearText = crypter.Encode(_expectedCipherText);
            }
            catch (ArgumentException e)
            {
                exception = e;
            }
            Assert.IsNotNull(exception);
        }
        [TestMethod]
        public void SettingEmptyAlphabetShouldThrowAnArgumentNullException()
        {
            Exception exception = null;
            Crypter crypter = new Crypter();
            
            crypter.SetKey("r");
            try
            {
                crypter.SetAlphabet(string.Empty);
            }
            catch (ArgumentNullException e)
            {
                exception = e;
            }

            Assert.IsNotNull(exception);
        }
    }
}
