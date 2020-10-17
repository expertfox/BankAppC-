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
    public interface BIUserAccess 
    {
        [OperationContract]
        void SelectUser(uint userID);

        [OperationContract]
        List<uint> GetUsers();

        [OperationContract]
        uint CreateUser();

        [OperationContract]
        string GetUserName(out string firstName, out string lastName);

        [OperationContract]
        void SetUserName(string fname, string lname);

        [OperationContract]
        void CurrentStateSaveToDisk();
    }
}
