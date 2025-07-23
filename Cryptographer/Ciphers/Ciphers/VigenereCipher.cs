using Cryptographer.Ciphers.SettingsDTO;
using System.Text;

namespace Cryptographer.Ciphers.Ciphers
{
    public class VigenereCipher : BaseCipher
    {
        public override string Name => "Vigenere";
        private VigenereSettingsDTO _settings;

        public override string Decrypt(string source, ISettignsDTO? settigns = null)
        {
            _settings = (VigenereSettingsDTO)settigns;
            StringBuilder stringBuilder = new StringBuilder();
            string key = _settings.Key.ToUpper();
            int keyIndex = 0;

            foreach (char c in source)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    int charCode = ((c - offset) - (key[keyIndex % key.Length] - 'A') + 26) % 26;
                    stringBuilder.Append((char)(charCode + offset));
                    keyIndex++;
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString();
        }

        public override string Encrypt(string source, ISettignsDTO? settigns = null)
        {
            _settings = (VigenereSettingsDTO)settigns;
            StringBuilder stringBuilder = new StringBuilder();
            string key = _settings.Key.ToUpper();
            int keyIndex = 0;

            foreach (char c in source)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    int charCode = ((c - offset) + (key[keyIndex % key.Length] - 'A')) % 26;
                    stringBuilder.Append((char)(charCode + offset));
                    keyIndex++;
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString();
        }
    }
}
