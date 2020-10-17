using System.Collections.Generic;
using System.ServiceModel;

namespace DataTier
{

    [ServiceContract]
    public interface IAccountAccess
    {
        [OperationContract]
        void SelectAccount(uint accountID);

        [OperationContract]
        List<uint> GetAccountIDsByUser(uint userID);

        [OperationContract]
        uint CreateAccount(uint userID);

        [OperationContract]
        string Deposit(uint amount);

        [OperationContract]
        string Withdraw(uint amount);

        [OperationContract]
        uint GetBalance();

        [OperationContract]
        uint GetOwner();

    }
}
