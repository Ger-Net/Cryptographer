using Cryptographer.Ciphers.SettingsDTO;

namespace Cryptographer.Ciphers.Ciphers
{
    public abstract class BaseCipher
    {

        public abstract string Name { get; }

        /// <summary>
        /// Encrypts the provided string using a specific algorithm.
        /// </summary>
        /// <param name="source">The string to encrypt</param>
        /// <param name="settigns">Optional settings for the encryption process. If null, no settings is needed</param>
        /// <returns>The encrypted string.</returns>
        public abstract string Encrypt(string source, ISettignsDTO? settigns = null);
        /// <summary>
        /// Encrypts the provided string using a specific algorithm.
        /// </summary>
        /// <param name="source">The string to decrypt</param>
        /// <param name="settigns">Optional settings for the encryption process. If null, no settings is needed</param>
        /// <returns>The decrypted string.</returns>
        public abstract string Decrypt(string source, ISettignsDTO? settigns = null);

        
    }
}
