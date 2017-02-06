using System.Windows;
using DataModel;
using DevExpress.Xpf.Core;

namespace ReliacoatInventory
{
    /// <summary>
    /// Interaction logic for InventoryWindow.xaml
    /// </summary>
    public partial class InventoryWindow : DXTabbedWindow
    {
        public InventoryWindow()
        {
            DXSplashScreen.Show<InventorySplash>();

            var connectionTest = MongoDBServer<Item>.pingMongoServer();

            DXSplashScreen.Close();

            if (!connectionTest)
                MessageBox.Show("Server connection not established.");
            else
                InitializeComponent();
        }
    }
}
