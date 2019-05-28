using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Entities;

namespace AddressBook.Database
{
    public class AddressBookContext:DbContext
    {
        public AddressBookContext():base("AddressBookConnection")
        {

        }
        public DbSet<Phonedirectory> Phonedirectories { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
    }
}
