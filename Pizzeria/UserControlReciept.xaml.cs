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
    /// Interaction logic for UserControlReciept.xaml
    /// </summary>
    public partial class UserControlReciept : UserControl
    {
        public UserControlReciept()
        {
            InitializeComponent();
            fillDataGrid();
        }
        void price()
        {
            /**
                        string menu_string = Properties.Settings.Default.dbPizzeriaConnectionString;
                        SqlConnection menu_connection = new SqlConnection(menu_string);
                        try
                        {
                            if (menu_connection.State != System.Data.ConnectionState.Open) menu_connection.Open();

                            String sql_text = "select Item_Name, Price from _Order";


                            SqlDataAdapter Adpt = new SqlDataAdapter(sql_text, menu_connection);
                            DataSet menu = new DataSet();
                            Adpt.Fill(menu);


                            string item_name1 = menu.Tables[0].Rows[0]["Item_Name"].ToString();
                            string item_name2 = menu.Tables[0].Rows[1]["Item_Name"].ToString();
                            string item_name3 = menu.Tables[0].Rows[2]["Item_Name"].ToString();

                            float Item_Price = menu.Tables[0].Rows[0]["Price"];
                            Item_Price2.Text = menu.Tables[0].Rows[1]["Price"];
                            Item_Price3.Text = menu.Tables[0].Rows[2]["Price"];


                            menu_connection.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }






                        menu_connection.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }




                **/
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            float sum = 0;
            foreach (DataRowView row in grdOrder.ItemsSource)
                {
                    sum += float.Parse((row["Price"].ToString()));
                    
            }
                
                total_price.Text = sum.ToString();


            
         
            
            
            
        }
       
        void fillDataGrid()
        {

            string menu_string = Properties.Settings.Default.dbPizzeriaConnectionString;
            SqlConnection menu_connection = new SqlConnection(menu_string);
            try
            {
                grdOrder.Items.Refresh();
                if (menu_connection.State != System.Data.ConnectionState.Open) menu_connection.Open();

                String retOrders = "select Item_Name, Price from _Order";
                SqlCommand cmd = new SqlCommand(retOrders, menu_connection);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("_Order");
                sda.Fill(dt);
                grdOrder.ItemsSource = dt.DefaultView;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            menu_connection.Close();



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string menu_string = @" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\sam\source\repos\Pizzeria\Pizzeria\dbPizzeria.mdf; Integrated Security = True; ";
            SqlConnection menu_connection = new SqlConnection(menu_string);
            try
            {
                if (menu_connection.State != System.Data.ConnectionState.Open) menu_connection.Open();

                String sql_text = "delete from _Order;";
                SqlCommand createCommand = new SqlCommand(sql_text, menu_connection);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted");
                








                menu_connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
