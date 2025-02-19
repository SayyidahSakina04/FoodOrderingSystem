using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DTO;


namespace FoodOrderingSystem
{
    public class OrderProcessing
    {
        static public void Order(CustomerDTO customer, List<ItemDTO> items)
        {
            FileStream fin = new FileStream("Orders.txt", FileMode.Append);
            StreamWriter finW = new StreamWriter(fin);

            string data = $"{customer.Name},{customer.PhoneNo},{customer.Address}";

            foreach (ItemDTO item in items)
            {
                data += $",{item.Name},{item.Price}";
            }
            finW.WriteLine(data);
            finW.Close();
            fin.Close();
        }
        static public List<(CustomerDTO, List<ItemDTO>)> ReadOrders()
        {
            // list to return
            List<(CustomerDTO, List<ItemDTO>)> orders = new List<(CustomerDTO, List<ItemDTO>)>();

            FileStream fout = new FileStream("Orders.txt", FileMode.Open);
            StreamReader foutR = new StreamReader(fout);
            // one complete order
            string orderData = foutR.ReadLine();

            while (orderData != null)
            {
                // index 0,1,2 are customer then every 2 indexes will be item.Name and item.Price
                string[] data = orderData.Split(',');
                CustomerDTO customer = new CustomerDTO();
                customer.Name = data[0];
                customer.Address = data[1];
                customer.PhoneNo = data[2];

                List<ItemDTO> items = new List<ItemDTO>();
                for (int i = 3; i < data.Length; i += 2)
                {
                    ItemDTO readItem = new ItemDTO();
                    readItem.Name = data[i];
                    readItem.Price = data[i + 1];
                    items.Add(readItem);
                }

                orders.Add((customer, items));
                orderData = foutR.ReadLine();
            }

            string customerData = foutR.ReadLine();

            return orders;
        }
    }
}
