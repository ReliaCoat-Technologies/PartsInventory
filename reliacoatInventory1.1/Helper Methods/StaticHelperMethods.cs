using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Inventory
{
    class StaticHelperMethods
    {
        public static void ExportToCSV(string savePath, DataGrid dataGrid)
        {
            dataGrid.SelectAllCells();
            dataGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dataGrid);
            dataGrid.UnselectAllCells();
            string result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);

            try { File.WriteAllText(savePath, result, UnicodeEncoding.UTF8); }

            catch
            {
                MessageBox.Show("Current file is open. Please close and try again");
                return;
            }

            Process.Start(savePath);
        }
    }
}