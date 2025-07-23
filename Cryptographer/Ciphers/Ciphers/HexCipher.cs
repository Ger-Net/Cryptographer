using Cryptographer.Ciphers.SettingsDTO;
using System.Text;

namespace Cryptographer.Ciphers.Ciphers
{
    public class HexCipher : BaseCipher
    {
        public override string Name => "Hex";
        public override string Encrypt(string source, ISettignsDTO? settigns = null)
        {
            byte[] bytes = Encoding.Default.GetBytes(source);
            var result = BitConverter.ToString(bytes);
            result = result.Replace('-', ' ');
            return result;
        }
        public override string Decrypt(string source, ISettignsDTO? settigns = null)
        {
            source = source.Replace(" ", "");

            int NumberChars = source.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(source.Substring(i, 2), 16);
            return Encoding.ASCII.GetString(bytes);

        }

        
    }
}
