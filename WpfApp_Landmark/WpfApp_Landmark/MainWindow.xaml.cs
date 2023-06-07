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
using Npgsql;
using System.Windows.Media;

namespace WpfApp_Landmark
{
    public partial class MainWindow : Window
    {
        public static Base landmark1;
        public MainWindow()
        {
            InitializeComponent();
            string? myPass1 = Environment.GetEnvironmentVariable("MY_PASSWORD"); // переменная окружения

            // Подключение бд к приложению
            var con = new NpgsqlConnection(connectionString: $"Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password={myPass1}");
            con.Open();
        }

        private void Button_Auto_Click(object sender, RoutedEventArgs e) // Кнопка авторизации Админа
        {
            string login = text_login.Text; // логин
            string myPass = adminpass.Password; // пароль
            string? myPass1 = Environment.GetEnvironmentVariable("MY_PASSWORD"); // подтверждение пароля
            string login1 = "admin2023"; // чему должен был равен логин
            if (login != login1)
            {
                text_login.ToolTip = "Неверный логин";
                text_login.Background = Brushes.Red;
                adminpass.Background = Brushes.Transparent;
            }
            else if (myPass1 != myPass)
            {
                adminpass.ToolTip = "Неверный пароль";
                adminpass.Background = Brushes.Red;
                text_login.Background = Brushes.Transparent;
            }
            else
            {
                adminpass.Background = Brushes.Transparent;
                text_login.Background = Brushes.Transparent;
                var secondWindow = new Base();
                secondWindow.Show();
                Close();
            }

        }
        private void text_login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}


