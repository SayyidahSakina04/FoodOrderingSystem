using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DTO;

namespace FoodOrderingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // after manually adding items in file "Items"
            // did not need or use Customer.txt for this poject as the
            // scope did not require much of it


            Console.WriteLine(".....WELCOME TO THE FOOD DELIVERY SYSTEM.....");

            int choice;
            Console.WriteLine("\n\nDo you wish to order something ? Press 1");
            Console.WriteLine("Do you wish to Add an Item ? Press 2");
            choice = int.Parse(Console.ReadLine());

            //****************************************************************************
            while (choice == 1)
            {
                // ask customer name and number and address
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Address: ");
                string address = Console.ReadLine();
                Console.WriteLine("Phone no: ");
                string phoneNo = Console.ReadLine();

                // make customer object 
                CustomerDTO customer = new CustomerDTO(name, phoneNo, address);
                // AddCustomer() at the end after order...


                // print all the items
                ItemDAL itemDAL = new ItemDAL();
                List<ItemDTO> availableItems = itemDAL.GetAll();
                if (availableItems.Count == 0)
                {
                    Console.WriteLine("No items available for ordering.");
                    return;
                }
                // ask user to select the items
                // add selected items to list 
                Console.WriteLine("\nAvailable Items:");
                for (int i = 0; i < availableItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {availableItems[i].Name} - Rs.{availableItems[i].Price}");
                }

                List<ItemDTO> selectedItems = new List<ItemDTO>();
                string selectMore;
                do
                {
                    Console.Write("\nEnter the number of the item you want to order: ");
                    int itemNumber = int.Parse(Console.ReadLine());
                    if (itemNumber > 0 && itemNumber <= availableItems.Count)
                    {
                        selectedItems.Add(availableItems[itemNumber - 1]);
                        Console.WriteLine($"{availableItems[itemNumber - 1].Name} has been added to your order.");
                        Console.WriteLine($"{availableItems[itemNumber - 1].Name} added to your order.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                    }

                    Console.Write("\nDo you want to add more items? (Y/N)");

                    selectMore = Console.ReadLine();
                } while (selectMore == "Y" || selectMore == "y");


                // place order
                OrderProcessing.Order(customer, selectedItems);
                CustomerDAL customerDAL = new CustomerDAL();
                customerDAL.AddCustomer(customer);

                Console.WriteLine("\n\nYour order has been placed....");

                //Console.WriteLine("\nOrder Details:....");
                //List<(Customer, List<Item>)> order = OrderProcessing.ReadOrders();
                //while (order.Count > 0) 
                //{
                    
                //}

                Console.WriteLine("\n\nDo you wish to order something again ? Press 1 for yes 0 for no");
                choice = int.Parse(Console.ReadLine());
            }

            //****************************************************************************
            while (choice == 2)
            {
                Console.WriteLine("Enter Item name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Item price: ");
                string price = Console.ReadLine();

                ItemDTO item = new ItemDTO(name, price);
                ItemDAL itemDAL = new ItemDAL();
                itemDAL.AddItem(item);

                Console.WriteLine($"Item {item.Name} has been added.");
                Console.WriteLine("Do you want to add another item? Press 2 for yes 0 for no...");
                choice = int.Parse(Console.ReadLine());

            }

            Console.WriteLine("Exiting program....");
        }
    }
}
