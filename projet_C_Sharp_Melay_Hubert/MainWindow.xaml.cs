using System;
using System.Collections.Generic;
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

namespace projet_C_Sharp_Melay_Hubert
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static String nameUser;
        public MainWindow()
        {
            InitializeComponent();
        }

        void EnterClicked(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                nameUser = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text;
                label1.Content += " " + nameUser;
                Console.Write(nameUser);
                e.Handled = true;
            }
        }

    }
}
