using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDB
{
    class Customer : Entity<int>, IEquatable<Customer>
    {
        public static event Action<string> CreateCustomer;
        public string CustomerName { get; set; }

        public string CustomerSurname { get; set; }

        public Customer(int id, string name, string surname ) 
        {
            base.Id = id;
            this.CustomerName = name;
            this.CustomerSurname = surname;

            CreateCustomer?.Invoke($"{DateTime.Now.ToString()} - Клиент {this.CustomerSurname}  {this.CustomerName} создан.");
        }

        public bool Equals(Customer other)
        {
            return this.Id == other.Id;
        }

    }
}
