using GMap.NET.MapProviders;
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
    /// Interaction logic for UserControlMap.xaml
    /// </summary>
    public partial class UserControlMap : UserControl
    {
        public UserControlMap()
        {
            InitializeComponent();
            fill_combo();
        }


        void fill_combo()
        {
            string menu_string = Properties.Settings.Default.dbPizzeriaConnectionString;
            SqlConnection menu_connection = new SqlConnection(menu_string);
            try
            {
                if (menu_connection.State != System.Data.ConnectionState.Open) menu_connection.Open();

                String sql_text = "select * from menu";
                SqlCommand createCommand = new SqlCommand(sql_text, menu_connection);


                SqlDataReader dr = createCommand.ExecuteReader();
                while (dr.Read()) {
                    string name = dr.GetString(1);
                    food_items.Items.Add(name);
                     


                }
                 



               


                menu_connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }






        }

        private void delivery_Request_Click(object sender, RoutedEventArgs e)

        {
            SqlConnection menu_connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sam\source\repos\Pizzeria\Pizzeria\dbPizzeria.mdf;Integrated Security=True; ");
            try
            {
                if (menu_connection.State != System.Data.ConnectionState.Open) menu_connection.Open();
                /**string foodItem = food_items.Text.ToString();
                String priceRequest = "Select Distinct Item_Price from Menu where Item_Name = '" + foodItem + "';";
                SqlCommand updatePrice = new SqlCommand(priceRequest, menu_connection);


                SqlDataReader dr = updatePrice.ExecuteReader();
                while (dr.Read()) {
                    float price = dr.GetFloat(2);
                    Margherita	75
Romana	120
Capricciosa	200

                }
    **/
                float price;
                string foodItem = food_items.Text.ToString();
                if (foodItem == "Margherita")
                {
                    price = 75+10;

                }
                else if (foodItem == "Romana")
                {
                    price = 120+10;

                }
                else {
                    price = 200+10;
                }
                String sql_tex = "Insert into _Order(Item_Name, Destination, Cell_Number, Price) values ('"+food_items.Text+"','"+txtDestination.Text+"','"+Cell_Number.Text+ "','"+ price +"');";
                
               
                    
                


                SqlCommand createCommande = new SqlCommand(sql_tex, menu_connection);

                createCommande.ExecuteNonQuery();
                MessageBox.Show("Successfully submitted");


           










                menu_connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}