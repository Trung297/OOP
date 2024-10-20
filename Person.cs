﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public abstract class Person
    {
        private string Name { get; }
        private string Email { get; }
        private DateTime DateOfBirth { get; }
        public string Phone_num { get; set; }
        public string Address { get; set; }

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
