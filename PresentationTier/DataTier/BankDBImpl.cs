using System;
using System.ServiceModel;

namespace DataTier
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    class BankDBImpl : IBankDB
    {
        public void ProcessAllTransactions()
        {
            try
            {
                BankStaticObj.bankDB.ProcessAllTransactions();  /* Handling no Transaction selected Exception */
            }
            catch (Exception e) {
                Console.WriteLine(e.GetType().Name + e.GetType().Attributes); //this will print in the business tier console if a exception is thrown
            }

        }

        public void SavetoDisk()
        {
            BankStaticObj.bankDB.SaveToDisk();
        }
    }
}
