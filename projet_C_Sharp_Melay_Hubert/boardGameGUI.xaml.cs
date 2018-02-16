using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<int> numberOfSeedsinPit { get; set; }
        public List<Canvas> canvas { get; set; }
        public List<Label> labels { get; set; }
        public int nbSeeds { get; set; }

        public boardGameGUI()
        {

            numberOfSeedsinPit = new ObservableCollection<int>();
            for (int i = 0; i < 12; i++)
            {
                numberOfSeedsinPit.Add(4);
            }

            InitializeComponent();

            // Array des Canvas à MAJ en fonction des graines dedans
            this.canvas = new List<Canvas>(12);
            canvas.Add(Col0Row0); canvas.Add(Col1Row0); canvas.Add(Col2Row0); canvas.Add(Col3Row0); canvas.Add(Col4Row0); canvas.Add(Col5Row0);
            canvas.Add(Col0Row1); canvas.Add(Col1Row1); canvas.Add(Col2Row1); canvas.Add(Col3Row1); canvas.Add(Col4Row1); canvas.Add(Col5Row1);

            // Array des Labels à MAJ en fonction des graines dans les Canvas
            this.labels = new List<Label>(12);
            labels.Add(Col0Row0Count); labels.Add(Col1Row0Count); labels.Add(Col2Row0Count); labels.Add(Col3Row0Count); labels.Add(Col4Row0Count); labels.Add(Col5Row0Count);
            labels.Add(Col0Row1Count); labels.Add(Col1Row1Count); labels.Add(Col2Row1Count); labels.Add(Col3Row1Count); labels.Add(Col4Row1Count); labels.Add(Col5Row1Count);

            this.DataContext = this;
        }

        public void updateGUI(BoardGame boardgame)
        {

            for (int k = 0; k < boardgame.Players.Count; k++) // On boucle sur les joueurs
            {
                List<Pit> pits = boardgame.Players[k].Pits;
                for (int i = 0; i < pits.Count; i++)            // On boucle sur les pits de chaque joueurs
                {
                    if (k > 0) // joueur 2
                    {
                        numberOfSeedsinPit[i + pits.Count] = pits[i].Seeds;      // On affiche le nombre de graine dans un label avec le Binding
                    }
                    else // joueur 1
                    {
                        numberOfSeedsinPit[i] = pits[i].Seeds;      // On affiche le nombre de graine dans un label avec le Binding
                    }

                    for (int j = 1; j < pits[i].Seeds+1 ; j++)      // On boucle sur le nombre de graines de chaque pit
                    {
                        DependencyObject child;
                        if (k > 0) // les graines à colorer des pits du joueur 2
                        {
                        
                            child = VisualTreeHelper.GetChild(canvas[i + pits.Count], j);
                        }
                        else // les graines à colorer des pits du joueur 1
                        {

                            child = VisualTreeHelper.GetChild(canvas[i], j);
                        }
                        Ellipse e = (Ellipse)child;
                        e.Visibility = System.Windows.Visibility.Visible; 
                    }
                    /*DependencyObject labelCount;
                    if (k > 0)
                    {
                        labelCount = VisualTreeHelper.GetChild(canvas[i + pits.Count], 16);
                    }
                    else
                    {
                        labelCount = VisualTreeHelper.GetChild(canvas[i], 16);
                    }
                    Label l = (Label)labelCount;
                    Console.WriteLine(pits[i].Seeds);
                    l.Content = pits[i].Seeds;*/
                }
             
            }
        }
    }
}
