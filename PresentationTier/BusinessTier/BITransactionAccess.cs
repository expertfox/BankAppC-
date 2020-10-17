using System.Collections.Generic;
using System.ServiceModel;

//INTERFACE IN THE BUSINESS TIER FOR THE ACCOUNT ACCESS FUNCTIONALITIES
namespace BusinessTier
{
    [ServiceContract]
    public interface BITransactionAccess
    {
        [OperationContract]
        List<uint> GetTransactionsForAccountID(uint acID);

        [OperationContract]
        void SelectTransaction(uint transactionID);

        [OperationContract]
        uint CreateTransaction();

        [OperationContract]
        uint GetAmount();

        [OperationContract]
        uint GetSenderAccount();

        [OperationContract]
        uint GetReceiverAccount();

        [OperationContract]
        string SetAmount(uint amount);

        [OperationContract]
        string SetSender(uint accountID);

        [OperationContract]
        string SetReceiver(uint accountID);

        [OperationContract]
        void CurrentStateSaveToDisk();

        [OperationContract]
        void ProcessAll();
    }
}
