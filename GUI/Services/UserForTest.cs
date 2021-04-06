using lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Services
{
    public class UserForTest
    {
        Customer customer;
        public UserForTest()
        {
            customer = new Customer("Mariia","B","mariia.barabukha@gmail.com");
        }

        public Customer Customer { get => customer; }
    }
}
