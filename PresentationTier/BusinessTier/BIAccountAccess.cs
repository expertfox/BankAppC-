using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


//INTERFACE IN THE BUSINESS TIER FOR THE ACCOUNT ACCESS FUNCTIONALITIES
namespace BusinessTier
{
    [ServiceContract]
    public interface BIAccountAccess
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

        [OperationContract]
        void CurrentStateSaveToDisk();

    }
}

