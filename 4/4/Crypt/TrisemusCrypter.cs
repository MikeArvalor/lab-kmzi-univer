using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace _4.Crypt
{
    class TrisemusCrypter : Crypter
    {
        string m_line1;
        string m_line2;

        public TrisemusCrypter()
        {
            m_line1 = "ENIGMABCDFHJK".ToLower();
            m_line2 = "LOPQRSTUVWXYZ".ToLower();
        }

        public string decrypt(string source)
        {
            return encrypt(source);
        }

        public string encrypt(string source)
        {
            string updatedSource = source.ToLower();
            StringBuilder result = new StringBuilder();
            foreach (char ch in updatedSource)
            {
                if (Char.IsLetter(ch))
                {
                    int index = m_line1.IndexOf(ch);
                    if (index != -1)
                    {
                        result.Append(m_line2[index]);
                    }
                    else
                    {
                        index = m_line2.IndexOf(ch);
                        result.Append(m_line1[index]);
                    }
                } 
                else
                {
                    result.Append(ch);
                }
            }
            return result.ToString();
        }
    }
}
