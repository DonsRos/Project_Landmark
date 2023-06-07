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

namespace WpfApp_Landmark
{
    /// <summary>
    /// Логика взаимодействия для del1.xaml
    /// </summary>
    public partial class del1 : Window
    {
        public del1()
        {
            InitializeComponent();
        }
        static string? myPass1 = Environment.GetEnvironmentVariable("MY_PASSWORD");
        readonly string conString = $"Host=127.0.0.1;Port=5432;Database=Landmarks;Username=postgres;Password={myPass1};Include Error Detail=true;";

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            Table_Landmark getback = new Table_Landmark();
            getback.Show();
            Close();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection con = new(conString))
                {
                    con.Open();

                    using NpgsqlCommand cmd = new();
                    cmd.Connection = con;
                    cmd.CommandText = "DELETE FROM public.\"sightseeing\" WHERE s_id = @id;";
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
    }
}
