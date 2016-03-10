using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;

namespace iTextSharpAssembly
{
    public class ITextEvents : PdfPageEventHelper
    {

        // This is the contentbyte object of the writer
        PdfContentByte cb;

        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;

        // This keeps track of the creation time
        DateTime printTime = DateTime.Now;

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                printTime = DateTime.Now;
                bf = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);

            String page = writer.PageNumber.ToString();

            Rectangle mediabox = document.PageSize;

            float docWidth = mediabox.Width;

            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.ShowTextAligned(1, page, document.PageSize.GetRight(docWidth / 2), document.PageSize.GetBottom(40), 0);
                cb.EndText();
            }

            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.ShowTextAligned(0, printTime.ToLongDateString(), document.PageSize.GetLeft(50), document.PageSize.GetBottom(40), 0);
                cb.EndText();
            }

            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.ShowTextAligned(2, "ReliaCoat Technologies", document.PageSize.GetRight(50), document.PageSize.GetBottom(40), 0);
                cb.EndText();
            }
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
        }
    }
}
