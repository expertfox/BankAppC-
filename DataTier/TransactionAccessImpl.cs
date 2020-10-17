using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace DataTier
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    class TransactionAccessImpl : ITransactionAccess
    {
        BankDB.TransactionAccessInterface iTransactionAccess = BankStaticObj.bankDB.GetTransactionInterface();

        public uint CreateTransaction()
        {
            return iTransactionAccess.CreateTransaction();
        }

        public uint GetAmount()
        {
            return iTransactionAccess.GetAmount();
        }

        public List<uint> GetTransactions()
        {
            return iTransactionAccess.GetTransactions();
        }

        public uint GetReceiverAccount()
        {
            return iTransactionAccess.GetRecvrAcct();
        }

        public uint GetSenderAccount()
        {
            return iTransactionAccess.GetSendrAcct();
        }

        public void SelectTransaction(uint transactionID)
        {
            iTransactionAccess.SelectTransaction(transactionID);
        }

        public string SetAmount(uint amount)    //String is passed to send the exception to Business Tier then to Presentation tier
        {
            try
            {
                iTransactionAccess.SetAmount(amount);   /* Handling no Transaction selected Exception */
                return "Sucessfull";
            }
            catch (Exception er) //General Exception class is used as only this exception is passed in all checked combinations
            {
                    return "No Transaction Selected";
            }
            
        }

        public string SetReceiver(uint accountID)   //String is passed to send the exception to Business Tier then to Presentation tier
        {
            try
            {
                iTransactionAccess.SetRecvr(accountID); /* Handling no Transaction selected Exception */
                return "Sucessfull";
            }
            catch (Exception er)    //General Exception class is used as only this exception is passed in all checked combinations
            {
                    return "No Transaction Selected";
            }
            
        }

        public string SetSender(uint accountID) //String is passed to send the exception to Business Tier then to Presentation tier
        {
            try
            {
                iTransactionAccess.SetSendr(accountID); /* Handling no Transaction selected Exception */
                return "Sucessfull";
            }
            catch (Exception er)
            {
                    return "No Transaction Selected";
            }
            
        }
    }
}
