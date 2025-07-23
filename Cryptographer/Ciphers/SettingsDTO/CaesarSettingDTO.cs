namespace Cryptographer.Ciphers.SettingsDTO
{
    public struct CaesarSettingDTO : ISettignsDTO
    {
        public int Shift { get; init; }
        public CaesarSettingDTO(int shift)
        {
            Shift = shift;
        }
    }
}
