using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataTier;

namespace BusinessTier
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class BusinessUserAccessImpl : BIUserAccess
    {

        IUserAccess iUserAccess;
        public BusinessUserAccessImpl()
        {
            ChannelFactory<IUserAccess> UserAccessFactory;
            NetTcpBinding tcpBinding = new NetTcpBinding();                   /*  Connecting to User Access Interface in Data Tier  */
            UserAccessFactory = new ChannelFactory<IUserAccess>(tcpBinding, "net.tcp://localhost:8005/UserAccess");
            iUserAccess = UserAccessFactory.CreateChannel();

        }
        
        //creating a new user for the system and returning 
        public uint CreateUser()
        {
            uint id = iUserAccess.CreateUser();
            Console.WriteLine("SDJASLDJAKLSDJAKLDJALSDJLASJDKLASDJASJDKLAJSDKL");
            CurrentStateSaveToDisk();
            return id;
        }

        public string GetUserName(out string firstName, out string lastName)
        {
           return iUserAccess.GetUserName(out firstName, out lastName);
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
            CurrentStateSaveToDisk();
        }


        public void CurrentStateSaveToDisk() {
            // to call SAVE TO DISK FUNCTION
            IBankDB iBankDB;
            ChannelFactory<IBankDB> BankDBFactory;
            NetTcpBinding tcpBinding2 = new NetTcpBinding();
            BankDBFactory = new ChannelFactory<IBankDB>(tcpBinding2, "net.tcp://localhost:8005/BankDB");
            iBankDB = BankDBFactory.CreateChannel();
            iBankDB.SavetoDisk();
        }
    }
}
