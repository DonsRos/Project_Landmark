using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Table_Landmark.xaml
    /// </summary>
    public partial class Table_Landmark : Window
    {
        private readonly DataSet ds = new();
        private readonly DataTable dt = new();

        static string? myPass1 = Environment.GetEnvironmentVariable("MY_PASSWORD");
        readonly string conString = $"Host=127.0.0.1;Port=5432;Database=Landmarks;Username=postgres;Password={myPass1};Include Error Detail=true;";
        readonly string sql = ("SELECT * FROM public.\"sightseeing\";");
        public Table_Landmark()
        {
            InitializeComponent();

            var con = new NpgsqlConnection(conString);
            con.Open();

            NpgsqlDataAdapter adapter = new(sql, con);
            ds.Reset();
            adapter.Fill(ds);
            dt = ds.Tables[0];
            CategoryList.ItemsSource = dt.DefaultView;

            con.Close();
        }

        private void Button_GetBack(object sender, RoutedEventArgs e)
        {
            var GetBackWindow = new Base();
            GetBackWindow.Show();
            Close();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            var add = new add1();
            add.Show();
            Close();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            del1 delete = new del1();
            delete.Show();
            Close();
        }
    }
}
