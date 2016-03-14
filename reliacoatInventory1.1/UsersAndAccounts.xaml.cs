using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataModel;
using static DataModel.SimpleID;

namespace Inventory
{
    /// <summary>
    /// Interaction logic for UsersAndAccounts.xaml
    /// </summary>
    public partial class UsersAndAccounts : Window
    {
        public UsersAndAccounts()
        {
            InitializeComponent();
            RefreshUAA();
        }

        private void addUser(object sender, RoutedEventArgs e)
        {
            addSimpleID("Users", userTextBox);
            statusTextBlock.Text = String.Format("Added User: {0}", userTextBox.Text);
            // statusTextBlock.Text = $"Added User: {userTextBox.Text}";
        }

        private void addAccount(object sender, RoutedEventArgs e)
        {
            addSimpleID("Accounts", accountTextBox);
            statusTextBlock.Text = String.Format("Added Account: {0}", accountTextBox.Text);
            // statusTextBlock.Text = $"Added Account: {accountTextBox.Text}";
        }

        private void removeUser(object sender, RoutedEventArgs e)
        {
            removeSimpleID("Users", userListBox);
            statusTextBlock.Text = String.Format("Removed User: {0}", userListBox.SelectedItem.ToString());
            // statusTextBlock.Text = $"Removed User: {userListBox.SelectedItem.ToString()}";
        }

        private void removeAccount(object sender, RoutedEventArgs e)
        {
            removeSimpleID("Accounts", accountListBox);
            statusTextBlock.Text = String.Format("Removed Account: {0}", accountListBox.SelectedItem.ToString());
            // statusTextBlock.Text = $"Removed Account: {accountListBox.SelectedItem.ToString()}";
        }

        private async void RefreshUAA()
        {
            var userList = await getIDListMongoDB("Users");
            var accountList = await getIDListMongoDB("Accounts");
            
            // userListBox.ItemsSource = userList.Select(o => o.value);
            // accountListBox.ItemsSource = accountList.Select(o => o.value);

            userTextBox.Text = "";
            accountTextBox.Text = "";
        }

        private void addSimpleID(string collection, TextBox textbox)
        {
            var simpleID = new SimpleID { value = textbox.Text };
            simpleID.addIDMongoDB(collection);
            RefreshUAA();
        }

        private async void removeSimpleID(string collection, ListBox listbox)
        {
            var simpleID = await getIDMongoDB(listbox.SelectedItem.ToString(), collection);
            simpleID.removeIDmongoDB(collection);
            RefreshUAA();
        }
    }
}
