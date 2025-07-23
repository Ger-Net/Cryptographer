using Cryptographer.Ciphers.SettingsDTO;
using System.Windows.Controls;

namespace Cryptographer.Ciphers.Controls
{
    public partial class VigenereCipherSettings : UserControl, ICipherSettings
    {
        private string _key;
        private int _shift;
        public VigenereCipherSettings()
        {
            InitializeComponent();
        }

        public ISettignsDTO GetSettigns()
        {
            return new VigenereSettingsDTO(_key, _shift);
        }
    }
}
