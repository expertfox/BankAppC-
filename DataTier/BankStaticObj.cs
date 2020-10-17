using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    //This static class will be used throughout the DataTier to call functions from BankDB.dll
    public static class BankStaticObj
    {
        //BankDB.dll's static object
        public static BankDB.BankDB bankDB = new BankDB.BankDB();
    }
}
