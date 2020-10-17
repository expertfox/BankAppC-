using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace DataTier
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    internal class AccountAccessImpl : IAccountAccess
    {
        BankDB.AccountAccessInterface iAccountAccess = BankStaticObj.bankDB.GetAccountInterface();

        public uint CreateAccount(uint userID)
        {
            return iAccountAccess.CreateAccount(userID);
        }

        public string Deposit(uint amount)      //String is passed to send the exception details to Business Tier then to Presentation tier
        {
            try
            {
                iAccountAccess.Deposit(amount);           /* Handling all  Exceptions */
                return "successful";
            }
            catch (Exception er)
            {
                if (er.GetType().Name == "No account selected")
                    return "No account selected";
                else
                    return "Unsuccessful";
            }
        }

        public List<uint> GetAccountIDsByUser(uint userID)
        {
            return iAccountAccess.GetAccountIDsByUser(userID);
        }

        public uint GetBalance()
        {
            try
            {
                return iAccountAccess.GetBalance();
            }
            catch (Exception er) {
                Console.WriteLine(er.GetType().Name);
                return 4000000000;
            }
        }
        
        public uint GetOwner()
        {
            return iAccountAccess.GetOwner();
        }

        public void SelectAccount(uint userID)
        {
            iAccountAccess.SelectAccount(userID);
        }

        public string Withdraw(uint amount)     //String is passed to send the exception details to Business Tier then to Presentation tier
        {
            try
            {
                iAccountAccess.Withdraw(amount);
                return "Sucessfull";
            }
            catch (Exception er)
            {                                   /* Handling all  Exceptions */
                if (er.GetType().Name == "No account selected")
                    return "No account selected";
                else if (er.GetType().Name == "Not enough funds")
                    return "Not enough funds";
                else
                    return "Some other Error which Even I dont know :(";
            }
        }
    }
}
