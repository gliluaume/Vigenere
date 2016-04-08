using System;

namespace Vigenere
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Parrot");

            Crypter crypter = new Crypter();
            crypter.SetKey("BEBOP");
            crypter.SetAlphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZ. :/");

            string clearText = crypter.Decode("GIMWRJXBDXPRTLCEZ:CFSBIDEQCANCFGSEEFAQOCSSUKRPQAQ/OKSOET");
            Console.WriteLine(clearText);



            Console.ReadLine();
        }
    }
}
