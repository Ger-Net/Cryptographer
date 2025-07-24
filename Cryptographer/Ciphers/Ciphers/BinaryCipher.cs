using Cryptographer.Ciphers.SettingsDTO;
using System.Text;

namespace Cryptographer.Ciphers.Ciphers
{
    public class BinaryCipher : BaseCipher
    {
        public override string Name => "Binary";
        public override string Encrypt(string source, ISettignsDTO? settigns = null)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in source)
            {
                if(c == ' ')
                    stringBuilder.Append('-');
                else
                    stringBuilder.Append(Convert.ToString(c, 2));

                stringBuilder.Append(' ');
            }
            return stringBuilder.ToString();
        }
        
        //TODO Fix Decrypt
        public override string Decrypt(string source, ISettignsDTO? settigns = null)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] strings = source.Split(' ');
            foreach (string s in strings)
            {
                if (string.IsNullOrEmpty(s))
                    continue;
                if (s == "-")
                {
                    stringBuilder.Append(' ');
                    continue;
                }
                int charCode = Convert.ToInt32(s, 2);
                stringBuilder.Append(Convert.ToChar(charCode));
            }
            return stringBuilder.ToString();
        }

        
    }
}
