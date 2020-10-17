using BusinessTier;
using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;

namespace PresentationTier
{
    /// <summary>
    /// Interaction logic for UserAccount.xaml
    /// </summary>
    public partial class UserAccount : Window
    {
        BIUserAccess iUserAccess;

        public UserAccount()
        {
            InitializeComponent();

            //displaying the userID
            UserIDHolder.Text = "UserID:" + App.UID.ToString();

            ChannelFactory<BIUserAccess> UserAccessFactory;                 /* Connecting to the business tier */
            NetTcpBinding tcpBinding = new NetTcpBinding();
            UserAccessFactory = new ChannelFactory<BIUserAccess>(tcpBinding, "net.tcp://localhost:8006/BusinessUser");
            this.iUserAccess = UserAccessFactory.CreateChannel();

            //Selecting the user
            this.iUserAccess.SelectUser(App.UID);
           
            this.loadNames();



        }

        private void loadNames()    //custom method to load all the transactions
        {
            //initializing values to fname and lname
            string fname;
            string lname;

            //exception handling done restarts the application if no user is selected

            string name = this.iUserAccess.GetUserName(out fname, out lname);
            if (name == "Login Unsuccessful") {     /* getting exception details from the business tier and handling the result */
                MessageBox.Show(name + "Invalid User ID");

                System.Windows.Forms.Application.Restart();
                System.Windows.Application.Current.Shutdown();
            }
            txtFname.Text = fname;
            txtLname.Text = lname;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BankAccounts bAccWindow = new BankAccounts();
            this.Hide();
            bAccWindow.Left = App.GetWindowLeft(this);
            bAccWindow.Top = App.GetWindowTop(this);
            bAccWindow.Show();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Clear_Click_3(object sender, RoutedEventArgs e)
        {
            txtFname.Text = "";
            txtLname.Text = "";
        }

        private void Button_Update_Click_4(object sender, RoutedEventArgs e) //updating the user data
        {
            if (txtFname.Text == "" || txtLname.Text == "")
                MessageBox.Show("Enter Both First Name and Last Name"); 
            else
                iUserAccess.SetUserName(txtFname.Text, txtLname.Text);

            this.loadNames();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            iUserAccess.CurrentStateSaveToDisk();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            iUserAccess.CurrentStateSaveToDisk();
        }

        private void Window_ContentRendered(object sender, System.EventArgs e)
        {
            iUserAccess.CurrentStateSaveToDisk();
        }
    }
}
