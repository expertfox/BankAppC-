using System;
using System.ServiceModel;

namespace DataTier
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Data Tier Server.");

                ServiceHost host, host2, host3, host4;
                NetTcpBinding tcpBinding = new NetTcpBinding();

                host = new ServiceHost(typeof(BankDBImpl));
                host.AddServiceEndpoint(typeof(IBankDB), tcpBinding, "net.tcp://localhost:8005/BankDB");
                host.Open();

                host2 = new ServiceHost(typeof(AccountAccessImpl));
                host2.AddServiceEndpoint(typeof(IAccountAccess), tcpBinding, "net.tcp://localhost:8005/AccountAccess");
                host2.Open();


                host3 = new ServiceHost(typeof(TransactionAccessImpl));
                host3.AddServiceEndpoint(typeof(ITransactionAccess), tcpBinding, "net.tcp://localhost:8005/TransactionAccess");
                host3.Open();

                host4 = new ServiceHost(typeof(UserAccessImpl));
                host4.AddServiceEndpoint(typeof(IUserAccess), tcpBinding, "net.tcp://localhost:8005/UserAccess");
                host4.Open();

                Console.WriteLine("Data tier online!");
                Console.ReadLine();

                host.Close();
                host2.Close();
                host3.Close();
                host4.Close();
            }
            catch (FaultException e)
            {
                Console.WriteLine("Error", e);
            }
        }
    }
}
