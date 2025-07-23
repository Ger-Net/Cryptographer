using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptographer.Ciphers.SettingsDTO
{
    public struct VigenereSettingsDTO : ISettignsDTO
    {
        public string Key { get; init; }
        public int Shift { get; init; }
        public VigenereSettingsDTO(string key, int shift)
        {
            Key = key;
            Shift = shift;
        }
    }
}
