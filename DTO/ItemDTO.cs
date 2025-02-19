using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ItemDTO
    {
        string name;
        string price;

        public ItemDTO(string name, string price)
        {
            this.name = name;
            this.price = price;
        }
        public ItemDTO() { }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        public override string ToString()
        {
            return $"{name},{price}";
        }
    }
}
