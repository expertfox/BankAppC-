
using BusinessTier;
using System;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;


namespace PresentationTier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BIUserAccess iUserAccess;

        public MainWindow()
        {
            InitializeComponent();

                                                                                        /* Connecting to the business tier */
            ChannelFactory<BIUserAccess> UserAccessFactory;
            NetTcpBinding tcpBinding = new NetTcpBinding();
            UserAccessFactory = new ChannelFactory<BIUserAccess>(tcpBinding, "net.tcp://localhost:8006/BusinessUser");
            iUserAccess = UserAccessFactory.CreateChannel();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //call the create user function here
            App.UID = iUserAccess.CreateUser();


            //show the useraccount window
            UserAccount win2 = new UserAccount();
            this.Hide();
            win2.Left = App.GetWindowLeft(this);
            win2.Top = App.GetWindowTop(this);
            win2.Show();




        }




        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //get the entered userID and send it to the business tier

            try //handling any exceptions from front end
            {
                if (Convert.ToUInt32(txtuserID.Text) > 0)          
                {
                    
                    App.UID = Convert.ToUInt32(txtuserID.Text);

                    UserAccount win2 = new UserAccount();
                    this.Hide();
                    win2.Left = App.GetWindowLeft(this);
                    win2.Top = App.GetWindowTop(this);
                    win2.Show();
                }

                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType());
            }

            //show the useraccount window



        }

        private void txtuserID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
