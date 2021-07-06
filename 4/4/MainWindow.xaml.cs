using _4.Crypt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Crypter m_activeCrypter;

        private Dictionary<char, int> Count(string source)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();

            foreach (char ch in source)
            {
                if (Char.IsLetter(ch))
                {
                    if (!result.ContainsKey(ch))
                        result.Add(ch, 0);
                    result[ch] += 1;
                }
            }

            return result;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            m_activeCrypter = new RatioCrypter();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            m_activeCrypter = new TrisemusCrypter();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            using (StreamWriter writer = new StreamWriter("source.csv"))
            {
                var maps = Count(SourceTextBox.Text.ToLower());
                foreach (char key in maps.Keys)
                {
                    writer.WriteLine($"\"{key}\",\"{maps[key]}\"");
                }
            }
            ResultTextBox.Text = m_activeCrypter.encrypt(SourceTextBox.Text);
            using (StreamWriter writer = new StreamWriter("result.csv"))
            {
                var maps = Count(ResultTextBox.Text.ToLower());
                foreach (char key in maps.Keys)
                {
                    writer.WriteLine($"\"{key}\",\"{maps[key]}\"");
                }
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            MessageBox.Show(elapsedMs.ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            SourceTextBox.Text = m_activeCrypter.decrypt(ResultTextBox.Text);

            var elapsedMs = watch.ElapsedMilliseconds;
            MessageBox.Show(elapsedMs.ToString());
        }

        private void Route_Checked(object sender, RoutedEventArgs e)
        {
            m_activeCrypter = new RouteCrypter();
        }

        private void Set_Checked(object sender, RoutedEventArgs e)
        {
            m_activeCrypter = new MultipleCrypter();
        }
    }
}
