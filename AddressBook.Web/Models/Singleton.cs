using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AddressBook.Entities;
using AddressBook.Service;
using System.Web.Security;

namespace AddressBook.Web.Models
{
    public sealed class Singleton
    {

        public UserLogin obUserLogIn = null;

        private Singleton()
        {
      
            obUserLogIn = UserLoginService.getLoggedInUser();
        }
        private static Singleton instance = null;
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
           
        }

        public static UserLogin createNewInstance()
        {
            UserLogin obUserLogIn = UserLoginService.getLoggedInUser();
            return obUserLogIn;

        }

    }
}