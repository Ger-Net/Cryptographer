using Cryptographer.Ciphers.SettingsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptographer.Ciphers.Ciphers
{
    public abstract class BaseCipher
    {
        public abstract string Name { get; }

        public abstract string Decrypt(string source, ISettignsDTO? settigns = null);

        public abstract string Encrypt(string source, ISettignsDTO? settigns = null);
    }
}
