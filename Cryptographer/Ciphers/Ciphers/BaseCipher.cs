using Cryptographer.Ciphers.SettingsDTO;

namespace Cryptographer.Ciphers.Ciphers
{
    public abstract class BaseCipher
    {
        public abstract string Name { get; }

        public abstract string Encrypt(string source, ISettignsDTO? settigns = null);

        public abstract string Decrypt(string source, ISettignsDTO? settigns = null);

        
    }
}
