using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace FoodOrderingSystem
{
    public class CustomerDAL
    {
        public void AddCustomer(CustomerDTO customer)
        {
            // add customer to file
            FileStream fin = new FileStream("Customers.txt", FileMode.Append);
            StreamWriter finW = new StreamWriter(fin);
            string data = $"{customer.Name},{customer.PhoneNo},{customer.Address}";
            finW.WriteLine(data);
            finW.Close();
            fin.Close();
        }
        public List<CustomerDTO> GetAll()
        {
            // get customer data from file, make customer object and add it in the list
            List<CustomerDTO> list = new List<CustomerDTO>();

            FileStream fout = new FileStream("Customers.txt", FileMode.Open);
            StreamReader foutR = new StreamReader(fout);

            string customerData = foutR.ReadLine();

            while (customerData != null)
            {
                string[] data = customerData.Split(',');
                CustomerDTO customer = new CustomerDTO();
                customer.Name = data[0];
                customer.Address = data[1];
                customer.PhoneNo = data[2];
                list.Add(customer);
                customerData = foutR.ReadLine();
            }

            fout.Close();
            foutR.Close();
            return list;
        }
    }
}
