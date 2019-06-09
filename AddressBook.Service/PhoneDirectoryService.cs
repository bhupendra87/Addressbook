using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Database;
using AddressBook.Entities;

namespace AddressBook.Service
{
    public class PhoneDirectoryService
    {
        private AddressBookContext db = null;
        public PhoneDirectoryService()
        {
            db = new AddressBookContext();
        }

        public List<Phonedirectory> List(int userid)
        {
            try
            {
                return db.Phonedirectories.Where(a => a.UserLogin.UserId == userid).ToList();
            }
            catch 
            {
                return null;
            }
        }


        public bool Add(Phonedirectory ob)
        {
            try
            {
                db.Phonedirectories.Add(ob);
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

    }
}
