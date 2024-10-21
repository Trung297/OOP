using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public abstract class Person
    {
        public string Name { get; private set; }
        public string Email { get; private set;}
        public DateTime DateOfBirth { get; private set; }
        public string Phone_num { get; private set; }
        public string Address { get; private set; }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }

        protected Person(string name, string email, DateTime dateofbirth, string phone_num, string address)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateofbirth;
            Phone_num = phone_num;
            Address = address;
        }
        public void UpdateContactInfo(string phone_num, string address)
        {
            Phone_num = phone_num;
            Address = address;
        }
    }
}
