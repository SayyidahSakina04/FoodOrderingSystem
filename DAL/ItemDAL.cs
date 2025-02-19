using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace FoodOrderingSystem
{
    public class ItemDAL
    {
        public void AddItem(ItemDTO item)
        {
            FileStream fin = new FileStream("Items.txt", FileMode.Append);
            StreamWriter finW = new StreamWriter(fin);
            string data = $"{item.Name},{item.Price}";
            finW.WriteLine(data);
            finW.Close();
            fin.Close();

        }
        public List<ItemDTO> GetAll()
        {
            List<ItemDTO> list = new List<ItemDTO>();

            FileStream fout = new FileStream("Items.txt", FileMode.Open);
            StreamReader foutR = new StreamReader(fout);

            string itemData = foutR.ReadLine();

            while (itemData != null)
            {
                string[] data = itemData.Split(',');
                ItemDTO item = new ItemDTO();
                item.Name = data[0];
                item.Price = data[1];

                list.Add(item);
                itemData = foutR.ReadLine();
            }
            fout.Close();
            foutR.Close();
            return list;
        }
        public ItemDTO GetByName(string name)
        {
            FileStream fout = new FileStream("Items.txt", FileMode.Open);
            StreamReader foutR = new StreamReader(fout);

            string itemData = foutR.ReadLine();

            while (itemData != null)
            {
                string[] data = itemData.Split(',');
                ItemDTO item = new ItemDTO();
                item.Name = data[0];
                item.Price = data[1];

                if (item.Name == name)
                {
                    fout.Close();
                    foutR.Close();
                    return item;
                }

                itemData = foutR.ReadLine();
            }
            fout.Close();
            foutR.Close();
            return null;
        }
    }
}
