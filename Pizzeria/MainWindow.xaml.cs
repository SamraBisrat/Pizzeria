 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string menu_string = Properties.Settings.Default.dbPizzeriaConnectionString;
            SqlConnection menu_connection = new SqlConnection(menu_string);
            try
            { 
                if (menu_connection.State != System.Data.ConnectionState.Open) menu_connection.Open();

                String sql_text = "select Email, Password from User_Info";


                SqlDataAdapter Adpt = new SqlDataAdapter(sql_text, menu_connection);
                DataSet user_info = new DataSet();
                Adpt.Fill(user_info);

                if (email.Text == user_info.Tables[0].Rows[0]["Email"].ToString() & password.Password == user_info.Tables[0].Rows[0]["Password"].ToString())
                {
                    Window map = new Window();
                    map.Content = new UserControlLogin();
                    map.Show();

                }
                else
                {
                    MessageBox.Show("incorrect password or username");

                }

                menu_connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }
    }
}
