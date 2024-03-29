﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using AddressBook.Database;
using AddressBook.Entities;

namespace AddressBook.Service
{
    public class UserLoginService
    {

        private AddressBookContext db=null;
        public UserLoginService()
        {
            db = new AddressBookContext(); 
        }
        /// <summary>
        /// Add User Login details to the database
        /// </summary>
        /// <param name="obUserLogin">Pass the object of the Login Class</param>
        /// <returns>True is successfully registered and False if failed to register</returns>
       
        public bool AddUser(UserLogin obUserLogin)
        {
            try
            {
                db.UserLogins.Add(obUserLogin);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public bool authenticationUser(string userName, string userPwd)
        {
            var res = db.UserLogins.Where(a => a.UserName.Equals(userName) && a.UserPwd.Equals(userPwd)).FirstOrDefault();
            if(res !=null)
            {
                FormsAuthentication.SetAuthCookie(res.UserName, false);
                return true;
            }else
            {
                return false;
            }
        }
    }
}
