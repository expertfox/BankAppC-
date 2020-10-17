using System.Collections.Generic;
using System.ServiceModel;

namespace DataTier
{
    [ServiceContract]
    public interface ITransactionAccess
    {
        [OperationContract]
        void SelectTransaction(uint transactionID);

        [OperationContract]
        List<uint> GetTransactions();

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
    }

}
