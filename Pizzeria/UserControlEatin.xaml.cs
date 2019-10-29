using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for UserControlEatin.xaml
    /// </summary>
    public partial class UserControlEatin : UserControl
    {
        public UserControlEatin()
        {
            InitializeComponent();
            load_db();
            
        }

        public void load_db()

        {
            string menu_string = Properties.Settings.Default.dbPizzeriaConnectionString;
            SqlConnection menu_connection = new SqlConnection(menu_string);
            try
            {
                if (menu_connection.State != System.Data.ConnectionState.Open) menu_connection.Open();

                String sql_text = "select Item_Name, Item_Price from Menu";

               
                SqlDataAdapter Adpt = new SqlDataAdapter(sql_text, menu_connection);
                DataSet menu = new DataSet();
                Adpt.Fill(menu);

                    
                
                    Item_Name1.Text = menu.Tables[0].Rows[0]["Item_Name"].ToString();
                    Item_Name2.Text = menu.Tables[0].Rows[1]["Item_Name"].ToString();
                    Item_Name3.Text = menu.Tables[0].Rows[2]["Item_Name"].ToString();

                    Item_Price1.Text += menu.Tables[0].Rows[0]["Item_Price"].ToString();
                    Item_Price2.Text += menu.Tables[0].Rows[1]["Item_Price"].ToString();
                    Item_Price3.Text += menu.Tables[0].Rows[2]["Item_Price"].ToString();
                
            
                menu_connection.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
            

            

        }
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection menu_connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sam\source\repos\Pizzeria\Pizzeria\dbPizzeria.mdf;Integrated Security=True; ");
            try
            {
                string pricee = Item_Price1.Text.Trim('$');
               
                float price = float.Parse(pricee);
                if (menu_connection.State != System.Data.ConnectionState.Open) menu_connection.Open();
                
                String sql_tex = "Insert into _Order(Item_Name, Price) values ('" + Item_Name1.Text + "','" + price + "');";






                SqlCommand createCommande = new SqlCommand(sql_tex, menu_connection);

                createCommande.ExecuteNonQuery();
                MessageBox.Show("Successfully Ordered");


                menu_connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        private void Button_Click3_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection menu_connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sam\source\repos\Pizzeria\Pizzeria\dbPizzeria.mdf;Integrated Security=True; ");
            try
            {
                string pricee = Item_Price3.Text.Trim('$');

                float price = float.Parse(pricee);
                if (menu_connection.State != System.Data.ConnectionState.Open) menu_connection.Open();

                String sql_tex = "Insert into _Order(Item_Name, Price) values ('" + Item_Name3.Text + "','" + price + "');";






                SqlCommand createCommande = new SqlCommand(sql_tex, menu_connection);

                createCommande.ExecuteNonQuery();
                MessageBox.Show("Successfully Ordered");


                menu_connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void Button_Click2_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection menu_connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sam\source\repos\Pizzeria\Pizzeria\dbPizzeria.mdf;Integrated Security=True; ");
            try
            {
                string pricee = Item_Price2.Text.Trim('$');

                float price = float.Parse(pricee);
                if (menu_connection.State != System.Data.ConnectionState.Open) menu_connection.Open();

                String sql_tex = "Insert into _Order(Item_Name, Price) values ('" + Item_Name2.Text + "','" + price + "');";






                SqlCommand createCommande = new SqlCommand(sql_tex, menu_connection);

                createCommande.ExecuteNonQuery();
                MessageBox.Show("Successfully Ordered");


                menu_connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }

}
