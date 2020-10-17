using BusinessTier;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;

namespace PresentationTier
{
    /// <summary>
    /// Interaction logic for Transactions.xaml
    /// </summary>
    public partial class Transactions : Window
    {
        
        private BITransactionAccess BiTransactionAccess;
        private uint selectedAccount;
        private uint selectedTransactionID;
        private List<uint> myTransactions = new List<uint>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedAcc"></param>
        public Transactions(uint selectedAcc)
        {
            InitializeComponent();
            this.selectedAccount = selectedAcc;
            UserIDHolder.Text = "UserID:" + App.UID.ToString();



            //connection to business tier BITransactionAccess interface
            ChannelFactory<BITransactionAccess> BTransactionAccessFactory;  
            NetTcpBinding tcpBinding = new NetTcpBinding();
            BTransactionAccessFactory = new ChannelFactory<BITransactionAccess>(tcpBinding, "net.tcp://localhost:8006/BusinessTransaction");
            this.BiTransactionAccess = BTransactionAccessFactory.CreateChannel();

            //loading transactions 
            loadList();


        }

        private void loadList()
        {
            //loading transactions 
            myTransactions = BiTransactionAccess.GetTransactionsForAccountID(selectedAccount);
            DataContext = myTransactions;
        }



        private void AddTransButtonClick(object sender, RoutedEventArgs e)
        {
            BiTransactionAccess.CreateTransaction();
            loadList();
        }

        private void Button_Update_Click_4(object sender, RoutedEventArgs e)
        {
            uint amntTxt = 0;
            uint recTxt = 0;
            try
            {
                //Frontend validation
                recTxt = Convert.ToUInt32(txtReceiver.Text);
                amntTxt = Convert.ToUInt32(txtAmount.Text);
                if (recTxt == 0 || amntTxt == 0)
                    MessageBox.Show("Value Should not be zero");
            }
            catch (FormatException) {
                MessageBox.Show("Enter Numeric Values");
            }

            string val1 = BiTransactionAccess.SetSender(Convert.ToUInt32(txtSender.Text));      /* getting exception details from the business tier and handling the result */
            string val2 = BiTransactionAccess.SetReceiver(recTxt);
            string val3 = BiTransactionAccess.SetAmount(amntTxt);
            
            //checking if any of these functions throws the No transaction selected exception
            if (val1 == "No Transaction Selected" || val2 == "No Transaction Selected" || val3 == "No Transaction Selected")
                    MessageBox.Show("Select a transaction");
            
            
        }

        private void Button_Clear_Click_3(object sender, RoutedEventArgs e)
        {
            txtAmount.Text = "";
            txtReceiver.Text = "";
        }

        private void TransactionsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //getting data from the list and selecting transaction
            selectedTransactionID = Convert.ToUInt32(TransactionListView.SelectedItem);
            BiTransactionAccess.SelectTransaction(selectedTransactionID);
            transactionIDHolder.Text = Convert.ToString(selectedTransactionID);

            txtReceiver.Text = Convert.ToString(BiTransactionAccess.GetReceiverAccount());
            txtAmount.Text = Convert.ToString(BiTransactionAccess.GetAmount());

            txtSender.Text = Convert.ToString(selectedAccount);

            //enabling buttons
            UpdateButton.IsEnabled = true;
            ClearButton.IsEnabled = true;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserAccount win2 = new UserAccount();
            this.Hide();
            win2.Left = App.GetWindowLeft(this);
            win2.Top = App.GetWindowTop(this);
            win2.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BankAccounts bAccWindow = new BankAccounts();
            this.Hide();
            bAccWindow.Left = App.GetWindowLeft(this);
            bAccWindow.Top = App.GetWindowTop(this);
            bAccWindow.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BiTransactionAccess.ProcessAll();
            BiTransactionAccess.CurrentStateSaveToDisk();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BiTransactionAccess.CurrentStateSaveToDisk();
        }
    }
}
