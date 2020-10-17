using System.Collections.Generic;
using System.ServiceModel;

namespace DataTier
{
    [ServiceContract]
    public interface IUserAccess
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
    }
}

