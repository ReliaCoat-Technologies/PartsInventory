using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace Inventory.ViewModels
{
    [POCOViewModel]
    public class ReliacoatInventoryViewModel
    {
        // Properties
        public virtual ItemInventoryViewModel inventoryViewModel { get; set; }
        public virtual InventoryLogViewModel inventoryLogViewModel { get; set; }
        public virtual InventoryManagerViewModel inventoryManagerViewModel { get; set; }
        public virtual UsersAccountsViewModel userAccountsViewModel { get; set; }
        public virtual ItemKitsViewModel itemKitsViewModel { get; set; }

        //Constructor
        public ReliacoatInventoryViewModel()
        {
            inventoryViewModel = ItemInventoryViewModel.Create();
            inventoryLogViewModel = InventoryLogViewModel.Create();
            inventoryManagerViewModel = InventoryManagerViewModel.Create();
            userAccountsViewModel = UsersAccountsViewModel.Create();
            itemKitsViewModel = ItemKitsViewModel.Create();
        }

        public static ReliacoatInventoryViewModel Create()
        {
            return ViewModelSource.Create(() => new ReliacoatInventoryViewModel());
        }

        public void grandRefreshUI()
        {
            inventoryViewModel.refreshUIAsync();
            inventoryLogViewModel.refreshUIAsync();
            inventoryManagerViewModel.refreshUIAsync();
            userAccountsViewModel.refreshUIAsync();
            itemKitsViewModel.refreshUIAsync();
        }
    }
}