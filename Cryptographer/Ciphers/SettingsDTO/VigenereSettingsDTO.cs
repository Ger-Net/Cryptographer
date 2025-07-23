namespace Cryptographer.Ciphers.SettingsDTO
{
    public struct VigenereSettingsDTO : ISettignsDTO
    {
        public string Key { get; init; }
        public VigenereSettingsDTO(string key)
        {
            Key = key;
        }
    }
}
