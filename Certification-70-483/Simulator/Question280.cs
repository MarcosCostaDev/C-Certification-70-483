using Certification_70_483.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Certification_70_483.Simulator
{
    public class Question280 : Starting
    {
        public Question280(params string[] args) : base(args)
        {
        }

        public override void Start(params string[] args)
        {
            var customers = new Customers
            {
                new Customer{Name = "Neil", Age = 45},
                new Customer{Name = "eil", Age = 5},
                new Customer{Name = "il", Age = 54}
            };
        }


        public class Customer
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class Customers : IEnumerable<Customer>
        {
            private List<Customer> customers = new List<Customer>();

            public void AddCustomer(Customer c)
            {
                this.customers.Add(c);
            }

            public IEnumerator<Customer> GetEnumerator()
            {
                return ((IEnumerable<Customer>)this.customers).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<Customer>)this.customers).GetEnumerator();
            }
        }

        
    }

    public static class CustomersExtensions
    {
        public static void Add(this Question280.Customers cs, Question280.Customer c)
        {
            cs.AddCustomer(c);
        }
    }
}
