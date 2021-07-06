using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Crypt
{
    interface Crypter
    {
        public string encrypt(string source);
        public string decrypt(string source);
    }
}
