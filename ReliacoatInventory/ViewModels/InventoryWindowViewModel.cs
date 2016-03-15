using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace ReliacoatInventory.ViewModels
{
    [POCOViewModel]
    public class InventoryWindowViewModel
    {
        // Properties
        public virtual ItemInventoryViewModel inventoryViewModel { get; set; }
        public virtual LogViewModel logViewModel { get; set; }
        public virtual ItemManagerViewModel itemManagerViewModel { get; set; }
        public virtual UsersAccountsViewModel userAccountsViewModel { get; set; }
        public virtual KitManagerViewModel kitManagerViewModel { get; set; }

        //Constructor
        public InventoryWindowViewModel()
        {
            inventoryViewModel = ItemInventoryViewModel.Create();
            logViewModel = LogViewModel.Create();
            itemManagerViewModel = ItemManagerViewModel.Create();
            userAccountsViewModel = UsersAccountsViewModel.Create();
            kitManagerViewModel = KitManagerViewModel.Create();
        }

        public static InventoryWindowViewModel Create()
        {
            return ViewModelSource.Create(() => new InventoryWindowViewModel());
        }

        public void grandRefreshUI()
        {
            inventoryViewModel.refreshUIAsync();
            logViewModel.refreshUIAsync();
            itemManagerViewModel.refreshUIAsync();
            userAccountsViewModel.refreshUIAsync();
            kitManagerViewModel.refreshUIAsync();
        }
    }
}