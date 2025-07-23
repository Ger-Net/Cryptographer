using Cryptographer.Ciphers.SettingsDTO;
using System.Windows.Controls;

namespace Cryptographer.Ciphers.Controls
{
    public partial class CaesarCipherSettings : UserControl, ICipherSettings
    {
        public CaesarCipherSettings()
        {
            InitializeComponent();
        }

        public int Shift { get; set; } 

        private void ShiftTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(ShiftTextBox.Text, out int shift))
            {
                Shift = shift; 
            }
            else
            {
                //TODO Red text
            }
        }
        public ISettignsDTO GetSettigns()
        {
            return new CaesarSettingDTO(Shift);
        }
    }
}
