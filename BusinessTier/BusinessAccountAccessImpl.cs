using DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTier
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
   public  class BusinessAccountAccessImpl : BIAccountAccess
    {
        //Datatier AccountAccees interface reference
        IAccountAccess iAccountAccess;
        public BusinessAccountAccessImpl()
        {
                                                                                                /* Connecting to AccountAccees interface in datatier  */
            ChannelFactory<IAccountAccess> AccountAccessFactory;
            NetTcpBinding tcpBinding = new NetTcpBinding();
            AccountAccessFactory = new ChannelFactory<IAccountAccess>(tcpBinding, "net.tcp://localhost:8005/AccountAccess");
            iAccountAccess = AccountAccessFactory.CreateChannel();
        }

        public uint CreateAccount(uint userID)
        {
            uint id = iAccountAccess.CreateAccount(userID); //returning the new account ID recived from Datatier
            CurrentStateSaveToDisk(); //saving the current state
            return id;
        }

        public string Deposit(uint amount)
        {   
            string res = iAccountAccess.Deposit(amount);
            CurrentStateSaveToDisk();
            return res;
        }

        public List<uint> GetAccountIDsByUser(uint userID)
        {
            return iAccountAccess.GetAccountIDsByUser(userID);
        }

        public uint GetBalance()
        {
            return iAccountAccess.GetBalance();
        }

        public uint GetOwner()
        {
            return iAccountAccess.GetOwner();
        }

        public void SelectAccount(uint accountID)
        {
            iAccountAccess.SelectAccount(accountID);
        }

        public string Withdraw(uint amount)
        {  
            string n = iAccountAccess.Withdraw(amount);
            CurrentStateSaveToDisk();
            return n;
            
        }

        public void CurrentStateSaveToDisk() 
        {
            // to call SAVE TO DISK FUNCTION
            IBankDB iBankDB;
            ChannelFactory<IBankDB> BankDBFactory;       /*connecting to IBankDB interface in datatier*/
            NetTcpBinding tcpBinding2 = new NetTcpBinding();
            BankDBFactory = new ChannelFactory<IBankDB>(tcpBinding2, "net.tcp://localhost:8005/BankDB");
            iBankDB = BankDBFactory.CreateChannel();
            iBankDB.SavetoDisk();
        }
    }
}
