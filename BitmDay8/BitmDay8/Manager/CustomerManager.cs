using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitmDay8.Repository;
using System.Data;

namespace BitmDay8.Manager
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();

        public string CanBeAdded(Customer.AllInfo allInfo)
        {

            return _customerRepository.CanBeAdded(allInfo);
        }

        public string AddToRepository(Customer.AllInfo allInfo)
        {
            return _customerRepository.AddToRepository(allInfo);
        }

        public DataTable ShowAll()
        {
            return _customerRepository.ShowAll();
        }

        public string Update(Customer.AllInfo allInfo)
        {
            return _customerRepository.Update(allInfo);
        }

        public string Delete(Customer.AllInfo allInfo)
        {
            return _customerRepository.Delete(allInfo);
        }

        public DataTable Search(Customer.AllInfo allInfo)
        {
            return _customerRepository.Search(allInfo);
        }
    }
}
