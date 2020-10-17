using DataTier;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessTier
{
    class BusinessTier
    {

        static void Main(string[] args)
        {
            ServiceHost host;
            NetTcpBinding tcpBinding = new NetTcpBinding();                          /*  Hosting Transaction Access Interface in Business Tier  */
            host = new ServiceHost(typeof(BusinessTransactionAccessImpl));
            host.AddServiceEndpoint(typeof(BITransactionAccess), tcpBinding, "net.tcp://localhost:8006/BusinessTransaction");
            host.Open();

            ServiceHost host1;
            NetTcpBinding tcpBinding1 = new NetTcpBinding();                        /*  Hosting User Access Interface in Business Tier  */
            host1 = new ServiceHost(typeof(BusinessUserAccessImpl));
            host1.AddServiceEndpoint(typeof(BIUserAccess), tcpBinding1, "net.tcp://localhost:8006/BusinessUser");
            host1.Open();

            ServiceHost host2;
            NetTcpBinding tcpBinding2 = new NetTcpBinding();                        /*  Hosting Account Access Interface in Business Tier  */
            host2 = new ServiceHost(typeof(BusinessAccountAccessImpl));
            host2.AddServiceEndpoint(typeof(BIAccountAccess), tcpBinding2, "net.tcp://localhost:8006/BusinessAccount");
            host2.Open();

            Console.WriteLine("Business Tier Online!");
            Console.ReadLine();


            host.Close();
            host1.Close();
            host2.Close();


            

        }

       


    }
}
