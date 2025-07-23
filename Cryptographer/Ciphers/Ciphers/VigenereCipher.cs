using Cryptographer.Ciphers.SettingsDTO;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Cryptographer.Ciphers.Ciphers
{
    public class VigenereCipher : BaseCipher
    {
        public override string Name => "Vigenere";
        private VigenereSettingsDTO _settings;

        public override string Decrypt(string source, ISettignsDTO? settigns = null)
        {
            _settings = (VigenereSettingsDTO)settigns;
            string result = "";
            string key = _settings.Key.ToUpper();
            int keyIndex = 0;

            foreach (char c in source)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    int charCode = ((c - offset) - (key[keyIndex % key.Length] - 'A')) % 26;
                    result += (char)(charCode + offset);
                    keyIndex++;
                }
                else
                {
                    result += c; // Символы, не являющиеся буквами, остаются без изменений
                }
            }
            return result;
        }

        public override string Encrypt(string source, ISettignsDTO? settigns = null)
        {
            _settings = (VigenereSettingsDTO)settigns;

            throw new NotImplementedException();
        }
    }
}
