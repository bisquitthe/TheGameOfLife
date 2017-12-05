using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TheGameOfLife
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new CellViewModel();
        }

        private void Board_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < CellViewModel.RowsCount; i++)
            {
                Board.ColumnDefinitions.Add(new ColumnDefinition());
                Board.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < CellViewModel.RowsCount; i++)
            {
                for (int j = 0; j < CellViewModel.ColumnsCount; j++)
                {
                    Border border = new Border();
                    Button commandHandler = new Button();
              
                    border.Child = commandHandler;
                    border.BorderBrush = Brushes.Black;
                    border.BorderThickness = new Thickness(0.08, 0.08, 0.08, 0.08);

                    commandHandler.Opacity = 1;
                    commandHandler.Background = Brushes.Aqua;
                    
                    Grid.SetRow(border,i);
                    Grid.SetColumn(border, j);

                    Board.Children.Add(border);

                    commandHandler.SetBinding(Button.CommandProperty, "CellClickCommand");
                    commandHandler.SetBinding(Button.OpacityProperty, String.Format("Board[{0}].State", i*CellViewModel.RowsCount+j));
                    commandHandler.CommandParameter = border;
                }
            }
        }
    }
}
