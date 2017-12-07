using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TheGameOfLife.VM;

namespace TheGameOfLife.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Board_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
