using Npgsql;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfApp_Landmark
{
    /// <summary>
    /// Логика взаимодействия для del2.xaml
    /// </summary>
    public partial class del2 : Window
    {
        public del2()
        {
            InitializeComponent();
        }

        static string? myPass1 = Environment.GetEnvironmentVariable("MY_PASSWORD");
        readonly string conString = $"Host=127.0.0.1;Port=5432;Database=Landmarks;Username=postgres;Password={myPass1};Include Error Detail=true;";

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection con = new(conString))
                {
                    con.Open();

                    using NpgsqlCommand cmd = new();
                    cmd.Connection = con;
                    cmd.CommandText = "DELETE FROM public.\"category\" WHERE c_id = @id;";
                    cmd.Parameters.AddWithValue("id", Int32.Parse(id.Text));
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                MessageBox.Show("Строка удалена успешно.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Ошибка удаления строки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            Table_Category getback = new Table_Category();
            getback.Show();
            Close();
        }
    }
}
