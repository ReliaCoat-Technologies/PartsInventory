using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace reliacoatInventory.ViewModels
{
    [POCOViewModel]
    public class ReliacoatInventoryViewModel
    {
        // Properties
        public virtual ItemInventoryViewModel inventoryViewModel { get; set; }
        public virtual InventoryLogViewModel inventoryLogViewModel { get; set; }

        //Constructor
        public ReliacoatInventoryViewModel()
        {
            inventoryViewModel = ItemInventoryViewModel.Create();
            inventoryLogViewModel = InventoryLogViewModel.Create();
        }

        public static ReliacoatInventoryViewModel Create()
        {
            return ViewModelSource.Create(() => new ReliacoatInventoryViewModel());
        }
    }
}