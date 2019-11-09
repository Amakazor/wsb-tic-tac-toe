﻿using System;
using System.Diagnostics;
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

namespace tic_tac_toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool current_turn = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Grid mygrid = myGrid;
            int rowIndex = Grid.GetRow(button);
            TextBlock title = titlebar;

            if (button.Background != Brushes.Red as Brush && button.Background != Brushes.Green as Brush)
            {
                if (current_turn)
                {
                    button.Background = Brushes.Red as Brush;
                }
                else
                {
                    button.Background = Brushes.Green as Brush;
                }

                current_turn = !current_turn;

                if (Check_For_Win())
                {
                    title.Text = "XD";
                }
            }
        }

        private bool Check_For_Win()
        {
            Grid mygrid = myGrid;

            UIElementCollection children = mygrid.Children;

            for (int i = 0; i < children.Count; i++)
            {
                var child = children[i];

                Button button = child as Button;

                if (button != null)
                {
                    int row = Grid.GetRow(button);
                    int column = Grid.GetColumn(button);

                    Brush color = button.Background;

                    if (color == Brushes.Red as Brush || color == Brushes.Green as Brush)
                    {
                        if (row == 0)
                        {
                            if ((children[i + 3] as Button).Background == color && (children[i + 6] as Button).Background == color)
                            {
                                return true;
                            }
                        }

                        if (column == 0)
                        {
                            if ((children[i + 1] as Button).Background == color && (children[i + 2] as Button).Background == color)
                            {
                                return true;
                            }
                        }

                        if (column == 0 && row == 0)
                        {
                            if ((children[4] as Button).Background == color && (children[8] as Button).Background == color)
                            {
                                return true;
                            }
                        }

                        if (column == 2 && row == 0)
                        {
                            if ((children[4] as Button).Background == color && (children[6] as Button).Background == color)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
