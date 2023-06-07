using System;
using System.Windows;
using Npgsql;

namespace WpfApp_Landmark
{
    /// <summary>
    /// Логика взаимодействия для add1.xaml
    /// </summary>
    public partial class add1 : Window
    {
        public add1()
        {
            InitializeComponent();
        }
        static string? myPass1 = Environment.GetEnvironmentVariable("MY_PASSWORD");
        readonly string conString = $"Host=127.0.0.1;Port=5432;Database=Landmarks;Username=postgres;Password={myPass1};Include Error Detail=true;";
        readonly string sql_client = "INSERT INTO public.\"sightseeing\" " +
            "(s_name, s_description, c_id) " +
            "VALUES (@value1, @value2, @value3);";


        private void Button_Close(object sender, RoutedEventArgs e)
        {
            var GetBack = new Table_Landmark();
            GetBack.Show();
            Close();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(name.Text)
                    || string.IsNullOrEmpty(s_description.Text)
                    || string.IsNullOrEmpty(c_id.Text)))
                {
                    using (NpgsqlConnection con = new(conString))
                    {
                        con.Open();

                        using NpgsqlCommand cmd = new(sql_client, con);
                        cmd.Parameters.AddWithValue("value1", name.Text);
                        cmd.Parameters.AddWithValue("value2", s_description.Text);
                        cmd.Parameters.AddWithValue("value3", Int32.Parse(c_id.Text));
                        cmd.ExecuteNonQuery();

                        con.Close();
                    }
                    Table_Landmark LandmarkList = new();
                    LandmarkList.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Заполните данные.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception)
            {;
                MessageBox.Show("Ошибка добавления строки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
