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

namespace WpfApp_Landmark
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Base : Window
    {

        public Base()
        {
            InitializeComponent();
        }

        private void Button_GetBack(object sender, RoutedEventArgs e)
        {
            var FirstWindow = new MainWindow();
            FirstWindow.Show();
            Close();
        }

        private void Button_Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данная программа предназначена для добавления и удаления данных.\nРазрабатывалась программа в Microsoft Visual Studio Community 2022.\nТакже основана на СУБД PgAdmin4");
        }

        private void Button_Landmark(object sender, RoutedEventArgs e)
        {
            var Landmarks = new Table_Landmark();
            Landmarks.Show();
            Close();
        }

        private void Button_Category(object sender, RoutedEventArgs e)
        {
            var Category = new Table_Category();
            Category.Show();
            Close();
        }
    }
}
