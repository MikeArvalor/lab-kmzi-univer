using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _4.Crypt
{
    class RatioCrypter : Crypter
    {
        private int k = 7;

        private int Mod(int par, int mod)
        {
            if (par >= 0)
                return par % mod;
            else
            {
                while (par < 0)
                {
                    par += mod;
                }
                return par;
            }
        }

        private string crypt(string source, bool isEncrypt)
        {
            string newSource = source.ToLower();
            StringBuilder sb = new StringBuilder();
            foreach (char symb in newSource)
            {
                if (Char.IsLetter(symb))
                {
                    int val = (int)symb - (int)'a';
                    int newVal = (isEncrypt) ? Mod((val + k), 26) : Mod((val - k), 26);
                    sb.Append((char)((int)'a' + newVal));
                }
                else
                {
                    sb.Append(symb);
                }
            }
            return sb.ToString();
        }

        public string decrypt(string source)
        {
            return crypt(source, false);
        }

        public string encrypt(string source)
        {
            return crypt(source, true);
        }
    }
}
