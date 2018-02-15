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
using System.Windows.Shapes;

namespace projet_C_Sharp_Melay_Hubert
{
    /// <summary>
    /// Logique d'interaction pour boardGameGUI.xaml
    /// </summary>
    public partial class boardGameGUI : Window
    {
        public boardGameGUI()
        {
            InitializeComponent();
        }

        public void updateGUI(BoardGame boardgame)
        {
            // Array des Canvas à MAJ en fonction des graines dedans
            List<Canvas> canvas = new List<Canvas>(12); 
            canvas.Add(Col0Row0); canvas.Add(Col1Row0); canvas.Add(Col2Row0); canvas.Add(Col3Row0); canvas.Add(Col4Row0); canvas.Add(Col5Row0);
            canvas.Add(Col0Row1); canvas.Add(Col1Row1); canvas.Add(Col2Row1); canvas.Add(Col3Row1); canvas.Add(Col4Row1); canvas.Add(Col5Row1);

            for (int k = 0; k < boardgame.Players.Count; k++)
            {
                List<Pit> pits = boardgame.Players[k].Pits;
                for (int i = 0; i < pits.Count; i++)
                {
                    for (int j = 1; j < pits[i].Seeds+1 ; j++)
                    {
                        DependencyObject child;
                        if (k > 0)
                        {
                            child = VisualTreeHelper.GetChild(canvas[i+pits.Count], j);
                        }
                        else
                        {
                            child = VisualTreeHelper.GetChild(canvas[i], j);
                        }
                        Ellipse e = (Ellipse)child;
                        e.Visibility = System.Windows.Visibility.Visible;
                    }
                    DependencyObject labelCount;
                    if (k > 0)
                    {
                        labelCount = VisualTreeHelper.GetChild(canvas[i + pits.Count], 16);
                    }
                    else
                    {
                        labelCount = VisualTreeHelper.GetChild(canvas[i], 16);
                    }
                    Label l = (Label)labelCount;
                    l.Content = pits[i].Seeds;


                }
            }
        }
    }
}
