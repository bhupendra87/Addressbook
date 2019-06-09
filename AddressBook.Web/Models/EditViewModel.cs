﻿using AddressBook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Web.Models
{
    public class EditViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public int User_Id { get; set; }
    }
}