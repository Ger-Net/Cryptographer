using Cryptographer.Ciphers.Ciphers;
using Cryptographer.Ciphers.Controls;
using Cryptographer.Ciphers.SettingsDTO;
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
            InitializeCipherBox();
            InitializeCiphers();
        }
        private void InitializeCipherSettings()
        {
            _cipherSettingsControls["Caesar"] = new CaesarCipherSettings();
            _cipherSettingsControls["Vigenere"] = new VigenereCipherSettings();


        }
        private void InitializeCipherBox()
        {
            CipherBox.Items.Add("Caesar");
            CipherBox.Items.Add("Vigenere");
            CipherBox.Items.Add("Hex");
            CipherBox.Items.Add("A1Z26");
            CipherBox.Items.Add("Binary");
        }
        private void InitializeCiphers()
        {
            _ciphers["Caesar"] = new CaesarChipher();
            _ciphers["Vigenere"] = new VigenereCipher();
            _ciphers["Hex"] = new HexCipher();
            _ciphers["A1Z26"] = new A1Z26Cipher();
            _ciphers["Binary"] = new BinaryCipher();
        }
        private void CipherBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string selectedChipher = CipherBox.SelectedItem as string;

            ICipherSettings settingsControl = null;
            if (_cipherSettingsControls.ContainsKey(selectedChipher))
                settingsControl = _cipherSettingsControls[selectedChipher];

            _selectedChipher = _ciphers[selectedChipher];

            StackPanel settingsPanel = FindName("SettingsPanel") as StackPanel;
            if (settingsPanel == null)
            {
                settingsPanel = new StackPanel() { Name = "SettingsPanel", Orientation = Orientation.Vertical };
            }
            settingsPanel.Children.Clear();
            if (settingsControl != null)
                settingsPanel.Children.Add((UserControl)settingsControl);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedChipher == null)
                return;

            var settings = _cipherSettingsControls.ContainsKey(_selectedChipher.Name) ?
                           _cipherSettingsControls[_selectedChipher.Name].GetSettigns() :
                           null;

            Func<string, ISettignsDTO?, string> operation = null;

            if (ModeBox.SelectedItem as string == "Encrypt")
                operation = _selectedChipher.Encrypt;
            else if (ModeBox.SelectedItem as string == "Decrypt")
                operation = _selectedChipher.Decrypt;
            else
                return;


            ResultTextBox.Text = operation(SourceTextBox.Text, settings); 
        }
    }
}