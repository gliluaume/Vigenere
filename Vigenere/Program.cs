using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            string clearText = crypter.Decode("GIMWRJXBDXPRTLCEZ:CFSBIDEQCANCFGSEEFAQOCSSUKPRQAQ/OKSOET");
            Console.WriteLine(clearText);



            Console.ReadLine();
        }
    }
}
