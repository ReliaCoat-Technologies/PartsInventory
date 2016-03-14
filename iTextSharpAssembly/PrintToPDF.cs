using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DataModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace iTextSharpAssembly
{
    public sealed class PrintToPDF
    {
        public static void PrintLogToPDF(List<InventoryLog> logList)
        {
            Font arial16 = FontFactory.GetFont("Arial", 16);
            Paragraph header = new Paragraph("Inventory Log Report", arial16);
            header.Alignment = Element.ALIGN_CENTER;
            header.SpacingAfter = 20;

            // Setting the headers to the PDF table
            PdfPTable table = new PdfPTable(8);
            float[] widths = new float[] { 70f, 25f, 25f, 25f, 125f, 20f, 20f, 20f };
            table.SetWidths(widths);
            table.WidthPercentage = 100f;

            bool isGray = true;

            AddToPDFTable(table, "Date/Time", isGray);
            AddToPDFTable(table, "User", isGray);
            AddToPDFTable(table, "Account", isGray);
            AddToPDFTable(table, "Item ID", isGray);
            AddToPDFTable(table, "Description", isGray);
            AddToPDFTable(table, "Qty. Before", isGray);
            AddToPDFTable(table, "Qty. +/-", isGray);
            AddToPDFTable(table, "Qty. After", isGray);

            foreach (var docItem in logList)
            {
                isGray = !isGray;

                AddToPDFTable(table, docItem.dateTime.ToString(), isGray);
                AddToPDFTable(table, docItem.user, isGray);
                AddToPDFTable(table, docItem.account, isGray);
                AddToPDFTable(table, docItem.itemID, isGray);
                AddToPDFTable(table, docItem.description, isGray);
                AddToPDFTable(table, docItem.quantityBefore.ToString(), isGray);
                AddToPDFTable(table, docItem.quantityChanged.ToString(), isGray);
                AddToPDFTable(table, docItem.quantityAfter.ToString(), isGray);
            }

            Document doc = new Document(PageSize.LETTER, 50, 50, 50, 70);

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("RCTsplashLogo.jpg");
            logo.ScalePercent(20f);
            logo.Alignment = 1;

            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string saveFile = Path.Combine(path, "log.pdf");

                FileStream fs = new FileStream(saveFile, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                writer.PageEvent = new ITextEvents();

                doc.Open();
                doc.Add(logo);
                doc.Add(header);
                doc.Add(table);
                doc.Close();

                Process.Start(saveFile); // Automatically opens the log report PDF for printing.
            }

            catch
            {
                MessageBox.Show("File is in use. Please close and try again.");
                return;
            }
        }

        public static void PrintItemsToPDF(List<Item> itemList)
        {
            Font arial16 = FontFactory.GetFont("Arial", 16);
            Paragraph header = new Paragraph("Equipment Inventory", arial16);
            header.Alignment = Element.ALIGN_CENTER;
            header.SpacingAfter = 20;

            // Setting the headers to the PDF table
            PdfPTable table = new PdfPTable(3);
            float[] widths = new float[] { 25f, 150f, 20f };
            table.SetWidths(widths);
            table.WidthPercentage = 100f;

            // The boolean used for setting gray table rows
            bool isGray = true;

            AddToPDFTable(table, "Item ID", isGray);
            AddToPDFTable(table, "Description", isGray);
            AddToPDFTable(table, "Quantity", isGray);

            foreach (var docItem in itemList)
            {
                isGray = !isGray; // Switching form gray to white in each row

                AddToPDFTable(table, docItem.item, isGray);
                AddToPDFTable(table, docItem.description, isGray);
                AddToPDFTable(table, docItem.quantity.ToString(), isGray);
            }

            Document doc = new Document(PageSize.LETTER, 50, 50, 50, 70);

            Image logo = Image.GetInstance("RCTsplashLogo.jpg");
            logo.ScalePercent(20f);
            logo.Alignment = 1; // 1 = center

            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string saveFile = Path.Combine(path, "inventory.pdf");

                FileStream fs = new FileStream(saveFile, FileMode.Create);

                PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                writer.PageEvent = new ITextEvents();

                doc.Open();
                doc.Add(logo);
                doc.Add(header);
                doc.Add(table);
                doc.Close();

                Process.Start(saveFile);
            }

            catch
            {
                MessageBox.Show("File is in use. Please close and try again.");
                return;
            }
        }

        public static void AddToPDFTable(PdfPTable table, string text, bool rowgray)
        {
            Font arial = FontFactory.GetFont("Arial", 6);
            PdfPCell cell = new PdfPCell(new Phrase(text, arial));
            if (rowgray == true)
            {
                cell.BackgroundColor = new BaseColor(220, 220, 220);
            }
            cell.HorizontalAlignment = 1; // Center Horizontal Alignment (1 = center)
            cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            table.AddCell(cell);
        }
    }
}
