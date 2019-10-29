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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pizzeria
{
    /// <summary>
    /// Interaction logic for UserControlLogin.xaml
    /// </summary>
    public partial class UserControlLogin : UserControl
    {
        public UserControlLogin()
        {
            InitializeComponent();
        }

        

        private void ButtonPower_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

       

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);
            switch (index)
            {

                case 0:
                    GridPrinicipal.Children.Clear();
                    GridPrinicipal.Children.Add(new UserControlHome());
                    break;
                case 1:
                    GridPrinicipal.Children.Clear();
                    GridPrinicipal.Children.Add(new UserControlEatin());

                    break;
                case 2:
                    GridPrinicipal.Children.Clear();
                    GridPrinicipal.Children.Add(new UserControlDelivery());

                    break;
                case 3:
                    GridPrinicipal.Children.Clear();
                    GridPrinicipal.Children.Add(new UserControlReciept());

                    break;
                default:
                    break;
            }
                
        }
        private void MoveCursorMenu(int index)
        {
            TransitioningContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }

        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
