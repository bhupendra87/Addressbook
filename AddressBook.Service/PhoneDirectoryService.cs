using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                return db.Phonedirectories.Where(a => a.UserLogin.UserId == userid).OrderByDescending(a=>a.id).ToList();
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
                db.Entry(ob.UserLogin).State = EntityState.Unchanged;
                db.Phonedirectories.Add(ob);
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public Phonedirectory getDetails(int userId,int phoneDirectoryId)
        {
            try
            {
                return db.Phonedirectories.Where(a => a.UserLogin.UserId == userId && a.id== phoneDirectoryId).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public bool Edit(Phonedirectory ob)
        {
            try
            {
                db.Entry(ob.UserLogin).State = EntityState.Unchanged;
                db.Entry(ob).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Phonedirectory ob)
        {
            try
            {
                db.Phonedirectories.Remove(ob);
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
