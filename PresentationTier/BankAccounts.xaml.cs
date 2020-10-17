using BusinessTier;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;

namespace PresentationTier
{
    /// <summary>
    /// Interaction logic for BankAccounts.xaml
    /// </summary>
    public partial class BankAccounts : Window
    {
        private BIAccountAccess iAccountAccess;
        public List<uint> AccountIDs = new List<uint>();
        private uint selectedAccountID;

        public BankAccounts()
        {
            InitializeComponent();
            //UserID
            UserIDHolder.Text = "UserID:" + App.UID.ToString();


            //connection to the backend
            ChannelFactory<BIAccountAccess> AccountAccessFactory;
            NetTcpBinding tcpBinding = new NetTcpBinding();
            AccountAccessFactory = new ChannelFactory<BIAccountAccess>(tcpBinding, "net.tcp://localhost:8006/BusinessAccount");
            this.iAccountAccess = AccountAccessFactory.CreateChannel();

           


            //loads accoint list
            loadList();
        }

        private void loadList()
        {

            AccountIDs = iAccountAccess.GetAccountIDsByUser(App.UID);
            DataContext = AccountIDs;
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
            Transactions transWindow = new Transactions(selectedAccountID);
            this.Hide();
            transWindow.Left = App.GetWindowLeft(this);
            transWindow.Top = App.GetWindowTop(this);
            transWindow.Show();

        }

        private void Create_Account_Button_Click_3(object sender, RoutedEventArgs e)
        {

            this.iAccountAccess.CreateAccount(App.UID);

            loadList();

        }

        private void AccountsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedAccountID = Convert.ToUInt32(AccountsListView.SelectedItem);
            iAccountAccess.SelectAccount(selectedAccountID);
            TxtSelectedAccount.Text = Convert.ToString(selectedAccountID);
            TxtBalance.Text = getBal();
            transButton.IsEnabled = true;
        }

        private string getBal()
        {
            uint val =  iAccountAccess.GetBalance();                /* getting exception details from the business tier and handling the result */

            if (val != 4000000000) // Assuming an account will never have 4,000,000,000 :(
                return "$" + Convert.ToString(val);
            else
                return "Select Account"; //AUD

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DepositButtonClick(object sender, RoutedEventArgs e)
        {
            if (txtDepAmount.Text == "")
            {
                MessageBox.Show("Enter amount please");

            }
            else {

                string res = iAccountAccess.Deposit(Convert.ToUInt32(txtDepAmount.Text));           /* getting exception details from the business tier and handling the result */

                if (res == "No account selected") {                 
                    MessageBox.Show(res);
                }

                TxtBalance.Text = getBal();
                txtDepAmount.Text = "";
            }
        }

        private void WithdrawButtonClick(object sender, RoutedEventArgs e)
        {

            if (txtWithAamount.Text == "")
            {
                MessageBox.Show("Enter Amount Please ");

            }
            else
            {
                string res = iAccountAccess.Withdraw(Convert.ToUInt32(txtWithAamount.Text));        /* getting exception details from the business tier and handling the result */
                if (res == "No account selected")
                {
                    MessageBox.Show(res);
                }
                else if (res == "")
                {
                    MessageBox.Show(res);
                }
                TxtBalance.Text = getBal();
                txtWithAamount.Text = "";
            }


           
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            iAccountAccess.CurrentStateSaveToDisk();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            iAccountAccess.CurrentStateSaveToDisk();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            iAccountAccess.CurrentStateSaveToDisk();
        }
    }
}
