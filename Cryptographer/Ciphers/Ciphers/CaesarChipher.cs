using Cryptographer.Ciphers.SettingsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cryptographer.Ciphers.Ciphers
{
    public class CaesarChipher : BaseCipher
    {
        public override string Name => "Caesar";
        public override string Encrypt(string source, ISettignsDTO? settigns)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in source)
            {
                if (char.IsLetter(c))
                {
                    var offset = char.IsUpper(c) ? 'A' : 'a';

                    int charCode = (c - offset + ((CaesarSettingDTO)settigns).Shift) % 26;
                    if (charCode < 0) // Если результат отрицательный, добавляем 26
                    {
                        charCode += 26;
                    }
                    stringBuilder.Append((char)(charCode + offset));
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString();
        }

        public override string Decrypt(string source, ISettignsDTO? settigns)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in source)
            {
                if (char.IsLetter(c))
                {
                    var offset = char.IsUpper(c) ? 'A' : 'a';
                    int charCode = (c - offset - ((CaesarSettingDTO)settigns).Shift) % 26;
                    if (charCode < 0) // Если результат отрицательный, добавляем 26
                    {
                        charCode += 26;
                    }
                    stringBuilder.Append((char)(charCode + offset));
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
