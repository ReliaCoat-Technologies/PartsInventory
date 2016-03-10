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
using MongoDB.Driver;
using MongoDB.Bson;
using mongoDBassembly;
using static mongoDBassembly.Item;

namespace reliacoatInventory
{
    /// <summary>
    /// Interaction logic for reviseItems.xaml
    /// </summary>
    public partial class reviseItems : Window
    {
        public reviseItems()
        {
            InitializeComponent();
            RefreshRRI();
        }

        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listbox = sender as ListBox;

            var lbIndex = listbox.SelectedIndex;

            itemListBox.SelectedIndex = lbIndex;
            descriptionListBox.SelectedIndex = lbIndex;

            try
            {
                itemEditTextBox.Text = itemListBox.SelectedItem.ToString();
                descriptionEditTextBox.Text = descriptionListBox.SelectedItem.ToString();
            }

            catch
            {
                itemEditTextBox.Text = "";
                itemEditTextBox.Text = "";
            }

        }

        private async void addItem(object sender, RoutedEventArgs e)
        {
            var itemListAll = await getItemListMongoDB();
            var itemList = itemListAll.Select(o => o.item).ToList();
            var descriptionList = itemListAll.Select(o => o.description).ToList();

            if (itemList.Contains(itemEditTextBox.Text))
            {
                MessageBox.Show("This item is already assigned.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (itemList.Contains(descriptionEditTextBox.Text))
            {
                MessageBox.Show("This item is already assigned.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Item doc = new Item
            {
                item = itemEditTextBox.Text,
                description = descriptionEditTextBox.Text,
                quantity = 0
            };

            doc.addItemMongoDB();

            RefreshRRI();

            statusTextBlock.Text = String.Format("Added: {0}: {1}", doc.item, doc.description);
            // statusTextBlock.Text = $"Added: {doc.item}: {doc.description}";
            // C# 6.0
        }

        private async void reviseItem(object sender, RoutedEventArgs e)
        {
            var doc = await getItemMongoDB(itemListBox.SelectedItem.ToString());

            string oldItem = doc.item;
            string oldDescription = doc.description;

            doc.item = itemEditTextBox.Text;
            doc.description = descriptionEditTextBox.Text;

            doc.setItemMongoDB();

            RefreshRRI();

            statusTextBlock.Text = String.Format("Revised: {0}: {1} from {2}: {3}", doc.item, doc.description, oldItem, oldDescription);
            // statusTextBlock.Text = $"Revised: {doc.item}: {doc.description} from {oldItem}: {oldDescription}";
            // C# 6.0
        }

        private async void removeItem(object sender, RoutedEventArgs e)
        {
            var doc = await getItemMongoDB(itemListBox.SelectedItem.ToString());

            doc.deleteItemMongoDB();

            statusTextBlock.Text = String.Format("Removed: {0}: {1}", doc.item, doc.description);
            // statusTextBlock.Text = $"Removed: {doc.item}: {doc.description}";
            // C# 6.0
        }

        // Helper Methods

        private async void RefreshRRI()
        {
            var items = await getItemListMongoDB();

            List<string> itemList = new List<string>(items.Select(o => o.item));
            List<string> descriptionList = new List<string>(items.Select(o => o.description));

            itemListBox.ItemsSource = itemList;
            descriptionListBox.ItemsSource = descriptionList;

            itemEditTextBox.Text = "";
            descriptionEditTextBox.Text = "";
        }
    }
}  