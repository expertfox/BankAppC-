using System.ServiceModel;

namespace DataTier
{
    [ServiceContract]
    public interface IBankDB
    {
        [OperationContract]
        void SavetoDisk();

        [OperationContract]
        void ProcessAllTransactions();
    }
}

