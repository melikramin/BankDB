using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankDB
{
    class ViewModel 
    {
        public ObservableCollection<Customer> Customers { get; set; }

        public ObservableCollection<Account> Accounts { get; set; }

        public ObservableCollection<string> Logs { get; set; }


        public ViewModel()
        {
            

            Customers = new ObservableCollection<Customer>();
            Customers.Add(new Customer(11, "Антон", "Иванов"));
            Customers.Add(new Customer(12, "Иван", "Нечаев"));
            Customers.Add(new Customer(13, "Артем", "Донцов"));

            

            Accounts = new ObservableCollection<Account>();
            Accounts.Add(new Account(11222456, 11, 125.25));
            Accounts.Add(new Account(88522457, 12));
            Accounts.Add(new Account(88855667, 12, 10056));
            Accounts.Add(new Account(22444555, 13, 895.25));

            Logs = new ObservableCollection<string>();

            Account.AccountAction += CreateAccountLog;
            Customer.CreateCustomer += CreateAccountLog;
        }

        private void CreateAccountLog(string logMessage)
        {
            Logs.Add(logMessage);
        }



        /// <summary>
        /// Перевод между счетами
        /// </summary>
        /// <param name="accountFrom">Откуда</param>
        /// <param name="accountTo">куда</param>
        /// <param name="amount">сумма</param>
        public void TransferPayment(Account accountFrom, Account accountTo, double amount)
        {
            if (amount <= 0)
            {
                MessageBox.Show("Укажите правильную сумму");
                return;
            }

            accountFrom.Transfer(amount * -1);
            accountTo.Transfer(amount);

        }

        public void AddAccount(int AccountID, int CustomerID, double balance)
        {
            Accounts.Add(new Account(AccountID, CustomerID, balance));
        }


        public void AddCustomer(string name, string surname)
        {
            int customerCount = Customers.Count + 1;
            Customers.Add(new Customer(customerCount, $"{name}_{customerCount}", $"{surname}_{customerCount}"));
        }
    }
}
