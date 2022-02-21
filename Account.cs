using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDB
{
    class Account : INotifyPropertyChanged
    {
        public static event Action<string> AccountAction;

        public int AccountNumber { get; set; }

        public int CustomerID { get; set; }

       public double balance;
        public double Balance
        {
            get { return this.balance; }
            set
            {
                this.balance = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Balance)));
            }
        }


        public Account(int accountNumber, int customerID, double balance = 0)
        {
            this.AccountNumber = accountNumber;
            this.CustomerID = customerID;
            this.Balance = balance;

            AccountAction?.Invoke($"{DateTime.Now.ToString()} - Счет {this.AccountNumber} создан. Баланс: {this.Balance} руб");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///..Попоплнение счета
        /// </summary>
        /// <param name="amount"></param>
        public void Transfer(double amount)
        {
            this.Balance += amount;
            AccountAction?.Invoke($"{DateTime.Now.ToString()} - Баланс счета {this.AccountNumber} изменен на: {this.Balance} руб.");
        }

        /// <summary>
        /// Получение баланса
        /// </summary>
        /// <returns></returns>
        public double GetBalance()
        {
            return this.Balance;
        }

       

    }
}
