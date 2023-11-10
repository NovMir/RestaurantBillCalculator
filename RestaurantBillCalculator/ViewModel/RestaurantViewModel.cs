using RestaurantBillCalculator.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantBillCalculator.ViewModel
{
    public class RestaurantViewModel : INotifyPropertyChanged
    {
        //define properties
        public ObservableCollection<MenuItem> Beverages { get; private set; }
        
        public ObservableCollection<MenuItem> Appetizers { get; private set; }
        public ObservableCollection<MenuItem> MainCourses { get; private set; }
        public ObservableCollection<MenuItem> Desserts { get; private set; }
        public ObservableCollection<MenuItem> BillItems { get; private set; }

        public MenuItem _selectedBeverage;
        public MenuItem _selectedAppetizer;
        public MenuItem _selectedMainCourse;
        public MenuItem _selectedDessert;
        public MenuItem SelectedBeverage
        {
            get { return _selectedBeverage; }
            set
            {
                _selectedBeverage = value;
                OnPropertyChanged(nameof(SelectedBeverage));
            
            }
        }
        public MenuItem SelectedAppetizer
        {
            get { return _selectedAppetizer; ; }
            set
            {
                _selectedAppetizer = value;
                OnPropertyChanged(nameof(SelectedAppetizer));

            }
        }
        public MenuItem SelectedMainCourse
        {
        
            get { return _selectedMainCourse; }
            set
            {
                _selectedMainCourse = value;
                OnPropertyChanged(nameof(SelectedMainCourse));

            }
        }
        public MenuItem SelectedDessert
        {
            get { return _selectedDessert; }
            set
            {
                _selectedDessert = value;

                OnPropertyChanged(nameof(SelectedDessert));

            }
        }


        public ICommand AddItemToBillCommand { get; private set; }
        public ICommand RemoveItemCommand { get; private set; }
        public ICommand ClearBillCommand { get; private set; }

        private decimal _subtotal;
        public decimal Subtotal
        {
            get { return _subtotal; }
            set
            {
                _subtotal = value;
                OnPropertyChanged(nameof(Subtotal));
                CalculateTotal();
            }
        }

        private void CalculateTotal()
        {
            throw new NotImplementedException();
        }

        private decimal _tax;
        public decimal Tax
        {
            get { return _tax; }
            set
            {
                _tax = value;
                OnPropertyChanged(nameof(Tax));
            }
        }

        private decimal _total;
        public decimal Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));
            }
        }
        // Constructor
        public RestaurantViewModel()
        {
            Beverages = new ObservableCollection<MenuItem>();
            Appetizers = new ObservableCollection<MenuItem>();
            MainCourses = new ObservableCollection<MenuItem>();
            Desserts = new ObservableCollection<MenuItem>();
            BillItems = new ObservableCollection<MenuItem>();
            AddItemToBillCommand = new RelayCommand(AddItemToBill);

            // Load the items for each category
            LoadMenuItems();
        }

        //initialize menu items from model 
        public void LoadMenuItems()
        {
           
            Beverages.Add(new MenuItem { Name = "Coffee", Price = 1.25m });
            Beverages.Add(new MenuItem { Name = "Tea", Price = 1.50m });
            Beverages.Add(new MenuItem { Name = "Soda", Price = 1.95m });
            Beverages.Add(new MenuItem { Name = "Water", Price = 2.95m });
            Beverages.Add(new MenuItem { Name = "Juice", Price = 2.50m });
            Beverages.Add(new MenuItem { Name = "Milk", Price = 1.55m });

            Appetizers.Add(new MenuItem { Name = "Nachos", Price = 5.00m });
            Appetizers.Add(new MenuItem { Name = "Buffalo Wings", Price = 5.95m });
            Appetizers.Add(new MenuItem { Name = "Buffalo Fingers", Price = 6.95m });
            Appetizers.Add(new MenuItem { Name = "Potato Skins", Price = 8.95m });
            Appetizers.Add(new MenuItem { Name = "Mushroom Caps", Price = 10.95m });
            Appetizers.Add(new MenuItem { Name = "chips and Salsa", Price = 6.95m });
            Appetizers.Add(new MenuItem { Name = "shrimp Cocktail", Price = 12.90m });


            MainCourses.Add(new MenuItem { Name = "Seafood alfredo", Price = 15.95m });
            MainCourses.Add(new MenuItem { Name = "Chicken alfredo", Price = 13.95m });
            MainCourses.Add(new MenuItem { Name = "chicken Picatta", Price = 13.95m });
            MainCourses.Add(new MenuItem { Name = "Turkey Club", Price = 11.95m });
            MainCourses.Add(new MenuItem { Name = "Lobster Pie", Price = 19.95m });
            MainCourses.Add(new MenuItem { Name = "Prime Rib", Price = 20.95m });
            MainCourses.Add(new MenuItem { Name = "shrimp scampi", Price = 18.95m });
            MainCourses.Add(new MenuItem { Name = "turkey dinner", Price = 13.95m });
            MainCourses.Add(new MenuItem { Name = "Stuffed chicken", Price = 14.95m });
            
            Desserts.Add(new MenuItem { Name = "apple pie", Price = 5.95m });
            Desserts.Add(new MenuItem { Name = "sundae", Price = 3.95m });
            Desserts.Add(new MenuItem { Name = "Carrot cake", Price = 5.95m });
            Desserts.Add(new MenuItem { Name = "mud pie", Price = 4.95m });
            Desserts.Add(new MenuItem { Name = "apple crisp", Price = 5.95m });
        }
        public void AddItemToBill(object parameter)
        {
            if (parameter is MenuItem item)
            {
                // Check if the item is already in the bill
                var existingItem = BillItems.FirstOrDefault(i => i.Name == item.Name);
                if (existingItem != null)
                {
                    // If the item exists, increase the quantity
                    existingItem.Quantity++;
                }
                else
                {
                    // If the item is new, add it to the bill with a quantity of 1
                    BillItems.Add(new MenuItem
                    {
                        Name = item.Name,
                        Price = item.Price,
                        
                    });
                }

                // Update the subtotal
                UpdateSubtotal();
            }
        }

        private void UpdateSubtotal()
        {
            Subtotal = BillItems.Sum(i => i.Price * i.Quantity);
            OnPropertyChanged(nameof(Subtotal));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

