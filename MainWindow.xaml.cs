using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BankDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel viewModel = new ViewModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void CustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer selectedCustomer = (Customer)CustomerList.SelectedItem;

            AccountList.ItemsSource = viewModel.Accounts.Where(c => c.CustomerID == selectedCustomer.Id);

            create_account.IsEnabled = true;
            createAccountIMG.Visibility = Visibility.Visible;

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer selectedCustomer = (Customer)customer_transfer.SelectedItem;

            account_transfer.ItemsSource = viewModel.Accounts.Where(c => c.CustomerID == selectedCustomer.Id);
        }

        private void send_money(object sender, RoutedEventArgs e)
        {
            if ((CustomerBalance.Text == "") || (amount_value.Text == "")) return;


            Account accountFrom = (Account)AccountList.SelectedItem;
            Account accountTo = (Account)account_transfer.SelectedItem;
            Double amount = Convert.ToDouble(amount_value.Text);

           
            if(accountFrom.GetBalance() >= amount)
            viewModel.TransferPayment(accountFrom, accountTo, amount);
            else
            {
                MessageBox.Show("Недостаточно средств");
            }
                

        }

        private void account_selected(object sender, SelectionChangedEventArgs e)
        {
            send_monay.IsEnabled = true;
        }

        /// <summary>
        /// Создание нового счета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Create_Account(object sender, RoutedEventArgs e)
        {
            Customer selectedCustomer = (Customer)CustomerList.SelectedItem;
            Random random = new Random();

            viewModel.AddAccount(random.Next(2254455,4558844), selectedCustomer.Id, random.Next(0, 1000));

            AccountList.ItemsSource = viewModel.Accounts.Where(c => c.CustomerID == selectedCustomer.Id);

        }

        private void Create_Customer(object sender, RoutedEventArgs e)
        {
            viewModel.AddCustomer($"Имя", $"Фамилия");
        }
    }
}
