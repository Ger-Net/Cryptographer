using Cryptographer.Ciphers.Ciphers;
using Cryptographer.Ciphers.Controls;
using System.Windows;
using System.Windows.Controls;

namespace Cryptographer
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, ICipherSettings> _cipherSettingsControls = new();
        private Dictionary<string, BaseCipher> _ciphers = new();

        private BaseCipher _selectedChipher;
        public MainWindow()
        {
            InitializeComponent();
            InitializeCipherSettings();
            InitializeCiphers();
        }
        private void InitializeCipherSettings()
        {
            _cipherSettingsControls["Caesar"] = new CaesarCipherSettings();
            _cipherSettingsControls["Vigenere"] = new VigenereCipherSettings(); 

            CipherBox.Items.Add("Caesar");
            CipherBox.Items.Add("Vigenere");
        }
        private void InitializeCiphers()
        {
            _ciphers["Caesar"] = new CaesarChipher();
            _ciphers["Vigenere"] = new VigenereCipher();
        }
        private void CipherBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string selectedChipher = CipherBox.SelectedItem as string;

            if (!_cipherSettingsControls.ContainsKey(selectedChipher) || !_ciphers.ContainsKey(selectedChipher))
            {
                throw new Exception("Cipher error");
            }
            var settingsControl = _cipherSettingsControls[selectedChipher];
            _selectedChipher = _ciphers[selectedChipher];
            StackPanel settingsPanel = FindName("SettingsPanel") as StackPanel;
            if (settingsPanel == null)
            {
                settingsPanel = new StackPanel() { Name = "SettingsPanel", Orientation = Orientation.Vertical };
            }
            settingsPanel.Children.Clear();

            settingsPanel.Children.Add((UserControl)settingsControl);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedChipher == null)
                return;
            switch (ModeBox.SelectedItem)
            {
                case "Encrypt":
                    ResultTextBox.Text = _selectedChipher.Encrypt(SourceTextBox.Text,_cipherSettingsControls[_selectedChipher.Name].GetSettigns());
                    break;
                case "Decrypt":
                    ResultTextBox.Text = _selectedChipher.Decrypt(SourceTextBox.Text, _cipherSettingsControls[_selectedChipher.Name].GetSettigns());
                    break;
            }
        }
    }
}