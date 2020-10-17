using DataTier;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessTier
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class BusinessTransactionAccessImpl : BITransactionAccess
    {
        ITransactionAccess iTransactionAccess;
        IBankDB iBankDB;
        public BusinessTransactionAccessImpl()
        {
            ChannelFactory<ITransactionAccess> TransactionAccessFactory;        /*  Connecting to Transaction Interface in Data Tier  */
            NetTcpBinding tcpBinding = new NetTcpBinding();                 
            TransactionAccessFactory = new ChannelFactory<ITransactionAccess>(tcpBinding, "net.tcp://localhost:8005/TransactionAccess");
            iTransactionAccess = TransactionAccessFactory.CreateChannel();

            
            ChannelFactory<IBankDB> BankFactory;
            NetTcpBinding tcpBinding2 = new NetTcpBinding();                    /*  Connecting to Transaction Interface in Data Tier  */
            BankFactory = new ChannelFactory<IBankDB>(tcpBinding2, "net.tcp://localhost:8005/BankDB");
            iBankDB = BankFactory.CreateChannel();

        }

        public uint CreateTransaction()
        {
            return iTransactionAccess.CreateTransaction();
        }

        public uint GetAmount()
        {
            return iTransactionAccess.GetAmount();
        }

        public uint GetReceiverAccount()
        {
            return iTransactionAccess.GetReceiverAccount();
        }

        public uint GetSenderAccount()
        {
            return iTransactionAccess.GetSenderAccount();
        }

        public List<uint> GetTransactionsForAccountID(uint acID)
        {
            return SearchTrans(acID).Result;
        }

        public async Task<List<uint>> SearchTrans(uint acID) {
                                            //arrow function calling
            List<uint> searchedList = await Task.Run(() => 
            {                                                                           /*  ASYNCHRONOUS METHOD CALLING FOR SEARCHING THROUGH TRANSACTIONS LIST  */
                List<uint> filteredList = new List<uint>();

                //for each to iterate throughout the list
                foreach (uint item in iTransactionAccess.GetTransactions())
                {
                    iTransactionAccess.SelectTransaction(item);     
                    if (iTransactionAccess.GetSenderAccount() == acID || iTransactionAccess.GetSenderAccount() == 0)
                        filteredList.Add(item);

                }

                return filteredList; //returning of the arrow function
            });
            return searchedList; //return of the
        }

        public void SelectTransaction(uint transactionID)
        {
            iTransactionAccess.SelectTransaction(transactionID);
        }

        public string SetAmount(uint amount)
        {
            return iTransactionAccess.SetAmount(amount);
        }

        public string SetReceiver(uint accountID)
        {
            return iTransactionAccess.SetReceiver(accountID);
        }

        public string SetSender(uint accountID)
        {
           return iTransactionAccess.SetSender(accountID);
        }

        public async Task ProcessAndSave(IBankDB iBankDB)
        {
            var timer = new System.Threading.Timer((e) =>           /* Setting a timed function on another thread */
            {
                iBankDB.ProcessAllTransactions(); //processing and saving
                iBankDB.SavetoDisk();
            }, null, 0, 30000);

        }


        public void CurrentStateSaveToDisk()
        {
            iBankDB.SavetoDisk();
        }

        public void ProcessAll() {
            ProcessAndSave(iBankDB);
        }
    }
}
