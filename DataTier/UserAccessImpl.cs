using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace DataTier
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    class UserAccessImpl : IUserAccess
    {
        
        BankDB.UserAccessInterface iUserAccess = BankStaticObj.bankDB.GetUserAccess();

        public uint CreateUser()
        {
            return iUserAccess.CreateUser();
        }


        public string GetUserName(out string firstName, out string lastName) //String is passed to send the exception details to Business Tier then to Presentation tier
        {
            try
            {
                iUserAccess.GetUserName(out firstName, out lastName);       /* Handling  Exceptions */
                return "Login Successful";
            }
            catch (Exception) {
                firstName = null;
                lastName = null;    
                return "Login Unsuccessful";
            }
        }


        public List<uint> GetUsers()
        {
            return iUserAccess.GetUsers();
        }


        public void SelectUser(uint userID)
        {
                iUserAccess.SelectUser(userID);
        }



        public void SetUserName(string fname, string lname)
        {
            iUserAccess.SetUserName(fname, lname);
        }
    }
}
