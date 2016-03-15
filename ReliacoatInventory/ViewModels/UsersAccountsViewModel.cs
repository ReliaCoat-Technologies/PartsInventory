using DevExpress.Mvvm.DataAnnotations;
using System.Collections.ObjectModel;
using DataModel;
using DevExpress.Mvvm.POCO;

namespace ReliacoatInventory.ViewModels
{
    [POCOViewModel]
    public class UsersAccountsViewModel
    {
        // Properties
        public virtual ObservableCollection<string> userList { get; set; }
        public virtual ObservableCollection<string> accountList { get; set; }
        public virtual int userIndex { get; set; }
        public virtual int accountIndex { get; set; }
        public virtual string user { get; set; }
        public virtual string account { get; set; }

        // Constructor
        public UsersAccountsViewModel()
        {
            refreshUIAsync();
        }

        public static UsersAccountsViewModel Create()
        {
            return ViewModelSource.Create(() => new UsersAccountsViewModel());
        }

        // Methods

        public async void refreshUIAsync()
        {
            userIndex = -1;
            accountIndex = -1;
            userList = await SimpleID.getIDListMongoDBAsync("Users");
            accountList = await SimpleID.getIDListMongoDBAsync("Accounts");
        }

        public async void addUserAsync()
        {
            var userToAdd = new SimpleID { value = user };
            await userToAdd.addIDMongoDBAsync("Users");
            refreshUIAsync();
        }

        public async void removeUserAsync()
        {
            if (userIndex >= 0)
            {
                await SimpleID.removeIDmongoDBAsync("Users", userList[userIndex]);
                refreshUIAsync();
            }
        }

        public async void addAccountAsync()
        {
            var userToAdd = new SimpleID { value = account };
            await userToAdd.addIDMongoDBAsync("Accounts");
            refreshUIAsync();
        }

        public async void removeAccountAsync()
        {
            if (accountIndex >= 0)
            {
                await SimpleID.removeIDmongoDBAsync("Accounts", accountList[accountIndex]);
                refreshUIAsync();
            }
        }
    }
}