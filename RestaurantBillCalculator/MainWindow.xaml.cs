using RestaurantBillCalculator.ViewModel;
using RestaurantBillCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace RestaurantBillCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           this.DataContext = new RestaurantViewModel();
        }
        // Temporary list to hold items before confirming to bill
        private List<MenuItem> tempBillItems = new List<MenuItem>();

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem is MenuItem selectedItem)
            {
                // Check if the item is already in the temp bill
                var existingItem = tempBillItems.FirstOrDefault(i => i.Name == selectedItem.Name);
                if (existingItem != null)
                {
                    // If the item exists, increase the quantity
                    existingItem.Quantity++;
                }
                else
                {
                    // If the item is new, add it to the temp bill with a quantity of 1
                    tempBillItems.Add(new MenuItem
                    {
                        Name = selectedItem.Name,
                        Price = selectedItem.Price,
                        Quantity = 1
                    });
                }

                // Update the DataGrid
                dgBill.ItemsSource = null;
                dgBill.ItemsSource = tempBillItems;
            }
        }


        private void dgBill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
