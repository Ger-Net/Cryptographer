using Cryptographer.Ciphers.SettingsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptographer.Ciphers.Ciphers
{
    public class A1Z26Cipher : BaseCipher
    {
        public override string Name => "A1Z26";

        public override string Encrypt(string source, ISettignsDTO? settigns = null)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(char c in source)
            {
                if (char.IsLetter(c))
                {
                    stringBuilder.Append(((int)c).ToString());
                }

                else if (c == ' ')
                    stringBuilder.Append('-');
                else
                    stringBuilder.Append(c);
                stringBuilder.Append(' ');
            }
            return stringBuilder.ToString();
        }

        public override string Decrypt(string source, ISettignsDTO? settigns = null)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] strings = source.Split(' ');
            foreach(string s in strings)
            {
                if(s == "-")
                {
                    stringBuilder.Append(' ');
                    continue;
                }   
                stringBuilder.Append((char)int.Parse(s));
            }
            return stringBuilder.ToString();
        }
    }
}
