﻿using System;
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
    /// Logique d'interaction pour Game.xaml
    /// </summary>
    public partial class Game : Window
    {


        public Game()
        {
            InitializeComponent();
        }

        public void updateGUI(BoardGame boardgame)
        {
            //DependencyObject child = VisualTreeHelper.GetChild(GridGame, );

            for (int k = 0; k < boardgame.Players.Count; k++)
            {
                List<Pit> pits = boardgame.Players[k].Pits;
                for (int i = 0; i < pits.Count; i++)
                {
                    for (int j = 1; j < pits[i].Seeds.Count + 1; j++)
                    {
                        DependencyObject child = VisualTreeHelper.GetChild(Col0Row0, j);
                        Ellipse e = (Ellipse)child;
                        Console.WriteLine(e.Fill);
                        e.Visibility = System.Windows.Visibility.Visible;
                    }
                }
            }
        }
         
    }
}
