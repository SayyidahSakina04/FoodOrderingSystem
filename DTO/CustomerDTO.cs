using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerDTO
    {
        string name;
        string phoneNo;
        string address;

        public CustomerDTO(string name, string phoneNo, string address)
        {
            this.Name = name;
            this.PhoneNo = phoneNo;
            this.Address = address;
        }
        public CustomerDTO() { }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public override string ToString()
        {
            return $"{name},{phoneNo},{address}";
        }
    }
}
