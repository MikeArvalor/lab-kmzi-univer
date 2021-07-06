using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Enigma
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
         }

        private void EncrypyionButton_Click(object sender, RoutedEventArgs e)
        {
             //textBox4.Text= Enigmaaa.Encryption(Convert.ToChar(textBox3.Text)).ToString();

        }

      
        private void CheckLabel(char res)
        {
            LabelA.Foreground = Brushes.Black;
            LabelB.Foreground = Brushes.Black;
            LabelC.Foreground = Brushes.Black;
            LabelD.Foreground = Brushes.Black;
            LabelE.Foreground = Brushes.Black;
            LabelF.Foreground = Brushes.Black;
            LabelG.Foreground = Brushes.Black;
            LabelH.Foreground = Brushes.Black;
            LabelI.Foreground = Brushes.Black;
            LabelJ.Foreground = Brushes.Black;
            LabelK.Foreground = Brushes.Black;
            LabelL.Foreground = Brushes.Black;
            LabelM.Foreground = Brushes.Black;
            LabelN.Foreground = Brushes.Black;
            LabelO.Foreground = Brushes.Black;
            LabelP.Foreground = Brushes.Black;
            LabelQ.Foreground = Brushes.Black;
            LabelR.Foreground = Brushes.Black;
            LabelS.Foreground = Brushes.Black;
            LabelT.Foreground = Brushes.Black;
            LabelU.Foreground = Brushes.Black;
            LabelV.Foreground = Brushes.Black;
            LabelW.Foreground = Brushes.Black;
            LabelX.Foreground = Brushes.Black;
            LabelY.Foreground = Brushes.Black;
            LabelZ.Foreground = Brushes.Black;
            if (res == 'A')
            {
                LabelA.Foreground = Brushes.Red;
            }
            if (res == 'B')
            {
                LabelB.Foreground = Brushes.Red;
            }
            if (res == 'C')
            {
                LabelC.Foreground = Brushes.Red;
            }
            if (res == 'D')
            {
                LabelD.Foreground = Brushes.Red;
            }
            if (res == 'E')
            {
                LabelE.Foreground = Brushes.Red;
            }
            if (res == 'F')
            {
                LabelF.Foreground = Brushes.Red;
            }
            if (res == 'G')
            {
                LabelG.Foreground = Brushes.Red;
            }
            if (res == 'H')
            {
                LabelH.Foreground = Brushes.Red;
            }
            if (res == 'I')
            {
                LabelI.Foreground = Brushes.Red;
            }
            if (res == 'J')
            {
                LabelJ.Foreground = Brushes.Red;
            }
            if (res == 'K')
            {
                LabelK.Foreground = Brushes.Red;
            }
            if (res == 'L')
            {
                LabelL.Foreground = Brushes.Red;
            }
            if (res == 'M')
            {
                LabelM.Foreground = Brushes.Red;
            }
            if (res == 'N')
            {
                LabelN.Foreground = Brushes.Red;
            }
            if (res == 'O')
            {
                LabelO.Foreground = Brushes.Red;
            }
            if (res == 'P')
            {
                LabelP.Foreground = Brushes.Red;
            }
            if (res == 'Q')
            {
                LabelQ.Foreground = Brushes.Red;
            }
            if (res == 'R')
            {
                LabelR.Foreground = Brushes.Red;
            }
            if (res == 'S')
            {
                LabelS.Foreground = Brushes.Red;
            }
            if (res == 'T')
            {
                LabelT.Foreground = Brushes.Red;
            }
            if (res == 'U')
            {
                LabelU.Foreground = Brushes.Red;
            }
            if (res == 'V')
            {
                LabelV.Foreground = Brushes.Red;
            }
            if (res == 'W')
            {
                LabelW.Foreground = Brushes.Red;
            }
            if (res == 'X')
            {
                LabelX.Foreground = Brushes.Red;
            }
            if (res == 'Y')
            {
                LabelY.Foreground = Brushes.Red;
            }
            if (res == 'Z')
            {
                LabelZ.Foreground = Brushes.Red;
            }
        }
        private void InputA_Click(object sender, RoutedEventArgs e)
        {
            //InputA.Background = Brushes.White;
            char res = Convert.ToChar(Enigmaaa.Encryption('A'));
            CheckLabel(res);
        }

        private void InputB_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('B'));
            CheckLabel(res);
        }

        private void InputC_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('C'));
            CheckLabel(res);
        }

        private void InputD_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('D'));
            CheckLabel(res);
        }

        private void InputE_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('E'));
            CheckLabel(res);
        }

        private void InputF_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('F'));
            CheckLabel(res);
        }

        private void InputG_Click(object sender, RoutedEventArgs e)
        {

            char res = Convert.ToChar(Enigmaaa.Encryption('G'));
            CheckLabel(res);
        }

        private void InputH_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('H'));
            CheckLabel(res);
        }

        private void InputI_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('I'));
            CheckLabel(res);
        }

        private void InputJ_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('J'));
            CheckLabel(res);
        }

        private void InputK_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('K'));
            CheckLabel(res);
        }

        private void InputL_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('L'));
            CheckLabel(res);
        }

        private void InputM_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('M'));
            CheckLabel(res);
        }

        private void InputN_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('N'));
            CheckLabel(res);
        }

        private void InputO_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('O'));
            CheckLabel(res);
        }

        private void InputP_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('P'));
            CheckLabel(res);
        }

        private void InputQ_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('Q'));
            CheckLabel(res);
        }

        private void InputR_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('R'));
            CheckLabel(res);
        }

        private void InputS_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('S'));
            CheckLabel(res);
        }

        private void InputU_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('U'));
            CheckLabel(res);
        }

        private void InputT_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('T'));
            CheckLabel(res);
        }

        private void InputV_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('V'));
            CheckLabel(res);
        }

        private void InputW_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('W'));
            CheckLabel(res);
        }

        private void InputX_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('X'));
            CheckLabel(res);
        }

        private void InputY_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('Y'));
            CheckLabel(res);
        }

        private void InputZ_Click(object sender, RoutedEventArgs e)
        {
            char res = Convert.ToChar(Enigmaaa.Encryption('Z'));
            CheckLabel(res);
        }
    }
}
