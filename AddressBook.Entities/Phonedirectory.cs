﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Entities
{
    public class Phonedirectory
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string  Mobile { get; set; }
        public string  Email  { get; set; }
        public string  Website{ get; set; }
        public string Address { get; set; }
        public UserLogin UserLogin { get; set; }
    }
}
