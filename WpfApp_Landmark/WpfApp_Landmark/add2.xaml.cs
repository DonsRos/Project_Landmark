using Npgsql;
using System;
using System.Windows;

namespace WpfApp_Landmark
{
    /// <summary>
    /// Логика взаимодействия для add2.xaml
    /// </summary>
    public partial class add2 : Window
    {
        public add2()
        {
            InitializeComponent();
        }
        static string? myPass1 = Environment.GetEnvironmentVariable("MY_PASSWORD");

        readonly string conString = $"Host=127.0.0.1;Port=5432;Database=Landmarks;Username=postgres;Password={myPass1};Include Error Detail=true;";
        readonly string sql_client = "INSERT INTO public.\"category\" " +
            "(c_name, c_description) " +
            "VALUES (@value1, @value2);";

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            Table_Category GetBack = new Table_Category();
            GetBack.Show();
            Close();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(c_name.Text)
                    || string.IsNullOrEmpty(c_description.Text)))
                {
                    using (NpgsqlConnection con = new(conString))
                    {
                        con.Open();

                        using NpgsqlCommand cmd = new(sql_client, con);
                        cmd.Parameters.AddWithValue("value1", c_name.Text);
                        cmd.Parameters.AddWithValue("value2", c_description.Text);
                        cmd.ExecuteNonQuery();

                        con.Close();
                    }
                    Table_Category LandmarkList = new();
                    LandmarkList.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Заполните данные.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                MessageBox.Show("Ошибка добавления строки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
