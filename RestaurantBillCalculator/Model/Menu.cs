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



namespace RestaurantBillCalculator.Model
{

    public class MenuItem
    {
        public string Category { get; set; } // Beverage, Appetizer, Main Course, Dessert
        public string Name { get; set; } // Name of the food item
        public decimal Price { get; set; } // Price of the food item
        public int Quantity { get; internal set; }
    }


}

