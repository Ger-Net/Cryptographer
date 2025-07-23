using Cryptographer.Ciphers.SettingsDTO;
using System.Windows.Controls;

namespace Cryptographer.Ciphers.Controls
{
    public partial class VigenereCipherSettings : UserControl, ICipherSettings
    {
        private string _key;
        public VigenereCipherSettings()
        {
            InitializeComponent();
        }

        public ISettignsDTO GetSettigns()
        {
            return new VigenereSettingsDTO(_key);
        }

        private void KeyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _key = KeyTextBox.Text;
        }
    }
}
