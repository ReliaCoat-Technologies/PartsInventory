namespace ReportGenerator
{
    partial class LogReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.LogTable = new DevExpress.XtraReports.UI.XRTable();
            this.LogHeader = new DevExpress.XtraReports.UI.XRTableRow();
            this.DateTimeHeader = new DevExpress.XtraReports.UI.XRTableCell();
            this.ItemIDHeader = new DevExpress.XtraReports.UI.XRTableCell();
            this.DescriptionHeader = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.UserHeader = new DevExpress.XtraReports.UI.XRTableCell();
            this.AccountHeader = new DevExpress.XtraReports.UI.XRTableCell();
            this.qtyHeader = new DevExpress.XtraReports.UI.XRTableCell();
            this.qtyBeforeHeader = new DevExpress.XtraReports.UI.XRTableCell();
            this.qtyAfterHeader = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.LogTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.HeightF = 2.450989F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 50F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            this.BottomMargin.HeightF = 49.01962F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1,
            this.xrLabel1});
            this.ReportHeader.HeightF = 143.75F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(980.3578F, 99.99999F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(998.7745F, 43.74999F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Log Report";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.LogTable});
            this.PageHeader.HeightF = 23.95833F;
            this.PageHeader.Name = "PageHeader";
            // 
            // LogTable
            // 
            this.LogTable.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.LogTable.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.LogTable.Name = "LogTable";
            this.LogTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.LogHeader});
            this.LogTable.SizeF = new System.Drawing.SizeF(998.7745F, 23.95833F);
            this.LogTable.StylePriority.UseBorders = false;
            this.LogTable.StylePriority.UseTextAlignment = false;
            this.LogTable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // LogHeader
            // 
            this.LogHeader.BorderColor = System.Drawing.Color.Black;
            this.LogHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.LogHeader.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.DateTimeHeader,
            this.UserHeader,
            this.AccountHeader,
            this.ItemIDHeader,
            this.DescriptionHeader,
            this.qtyBeforeHeader,
            this.qtyHeader,
            this.qtyAfterHeader});
            this.LogHeader.Name = "LogHeader";
            this.LogHeader.StylePriority.UseBorderColor = false;
            this.LogHeader.StylePriority.UseBorders = false;
            this.LogHeader.Weight = 1D;
            // 
            // DateTimeHeader
            // 
            this.DateTimeHeader.BackColor = System.Drawing.Color.Black;
            this.DateTimeHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DateTimeHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.DateTimeHeader.ForeColor = System.Drawing.Color.White;
            this.DateTimeHeader.Name = "DateTimeHeader";
            this.DateTimeHeader.StylePriority.UseBackColor = false;
            this.DateTimeHeader.StylePriority.UseBorders = false;
            this.DateTimeHeader.StylePriority.UseFont = false;
            this.DateTimeHeader.StylePriority.UseForeColor = false;
            this.DateTimeHeader.StylePriority.UseTextAlignment = false;
            this.DateTimeHeader.Text = "Date/Time";
            this.DateTimeHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.DateTimeHeader.Weight = 0.40742813092860258D;
            // 
            // ItemIDHeader
            // 
            this.ItemIDHeader.BackColor = System.Drawing.Color.Black;
            this.ItemIDHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ItemIDHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.ItemIDHeader.ForeColor = System.Drawing.Color.White;
            this.ItemIDHeader.Name = "ItemIDHeader";
            this.ItemIDHeader.StylePriority.UseBackColor = false;
            this.ItemIDHeader.StylePriority.UseBorders = false;
            this.ItemIDHeader.StylePriority.UseFont = false;
            this.ItemIDHeader.StylePriority.UseForeColor = false;
            this.ItemIDHeader.StylePriority.UseTextAlignment = false;
            this.ItemIDHeader.Text = "Item ID";
            this.ItemIDHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.ItemIDHeader.Weight = 0.30943873837565417D;
            // 
            // DescriptionHeader
            // 
            this.DescriptionHeader.BackColor = System.Drawing.Color.Black;
            this.DescriptionHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DescriptionHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.DescriptionHeader.ForeColor = System.Drawing.Color.White;
            this.DescriptionHeader.Multiline = true;
            this.DescriptionHeader.Name = "DescriptionHeader";
            this.DescriptionHeader.StylePriority.UseBackColor = false;
            this.DescriptionHeader.StylePriority.UseBorders = false;
            this.DescriptionHeader.StylePriority.UseFont = false;
            this.DescriptionHeader.StylePriority.UseForeColor = false;
            this.DescriptionHeader.StylePriority.UseTextAlignment = false;
            this.DescriptionHeader.Text = "Description\r\n";
            this.DescriptionHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.DescriptionHeader.Weight = 1.1863631350125805D;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(998.7745F, 23F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // UserHeader
            // 
            this.UserHeader.BackColor = System.Drawing.Color.Black;
            this.UserHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.UserHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.UserHeader.ForeColor = System.Drawing.Color.White;
            this.UserHeader.Name = "UserHeader";
            this.UserHeader.StylePriority.UseBackColor = false;
            this.UserHeader.StylePriority.UseBorders = false;
            this.UserHeader.StylePriority.UseFont = false;
            this.UserHeader.StylePriority.UseForeColor = false;
            this.UserHeader.StylePriority.UseTextAlignment = false;
            this.UserHeader.Text = "User";
            this.UserHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.UserHeader.Weight = 0.27333414468016937D;
            // 
            // AccountHeader
            // 
            this.AccountHeader.BackColor = System.Drawing.Color.Black;
            this.AccountHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.AccountHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.AccountHeader.ForeColor = System.Drawing.Color.White;
            this.AccountHeader.Name = "AccountHeader";
            this.AccountHeader.StylePriority.UseBackColor = false;
            this.AccountHeader.StylePriority.UseBorders = false;
            this.AccountHeader.StylePriority.UseFont = false;
            this.AccountHeader.StylePriority.UseForeColor = false;
            this.AccountHeader.StylePriority.UseTextAlignment = false;
            this.AccountHeader.Text = "Account";
            this.AccountHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.AccountHeader.Weight = 0.28426282680629472D;
            // 
            // qtyHeader
            // 
            this.qtyHeader.BackColor = System.Drawing.Color.Black;
            this.qtyHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.qtyHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.qtyHeader.ForeColor = System.Drawing.Color.White;
            this.qtyHeader.Name = "qtyHeader";
            this.qtyHeader.StylePriority.UseBackColor = false;
            this.qtyHeader.StylePriority.UseBorders = false;
            this.qtyHeader.StylePriority.UseFont = false;
            this.qtyHeader.StylePriority.UseForeColor = false;
            this.qtyHeader.StylePriority.UseTextAlignment = false;
            this.qtyHeader.Text = "+/-";
            this.qtyHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.qtyHeader.Weight = 0.12036319376355312D;
            // 
            // qtyBeforeHeader
            // 
            this.qtyBeforeHeader.BackColor = System.Drawing.Color.Black;
            this.qtyBeforeHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.qtyBeforeHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.qtyBeforeHeader.ForeColor = System.Drawing.Color.White;
            this.qtyBeforeHeader.Name = "qtyBeforeHeader";
            this.qtyBeforeHeader.StylePriority.UseBackColor = false;
            this.qtyBeforeHeader.StylePriority.UseBorders = false;
            this.qtyBeforeHeader.StylePriority.UseFont = false;
            this.qtyBeforeHeader.StylePriority.UseForeColor = false;
            this.qtyBeforeHeader.StylePriority.UseTextAlignment = false;
            this.qtyBeforeHeader.Text = "Before";
            this.qtyBeforeHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.qtyBeforeHeader.Weight = 0.12036251270412494D;
            // 
            // qtyAfterHeader
            // 
            this.qtyAfterHeader.BackColor = System.Drawing.Color.Black;
            this.qtyAfterHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.qtyAfterHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.qtyAfterHeader.ForeColor = System.Drawing.Color.White;
            this.qtyAfterHeader.Multiline = true;
            this.qtyAfterHeader.Name = "qtyAfterHeader";
            this.qtyAfterHeader.StylePriority.UseBackColor = false;
            this.qtyAfterHeader.StylePriority.UseBorders = false;
            this.qtyAfterHeader.StylePriority.UseFont = false;
            this.qtyAfterHeader.StylePriority.UseForeColor = false;
            this.qtyAfterHeader.StylePriority.UseTextAlignment = false;
            this.qtyAfterHeader.Text = "After\r\n";
            this.qtyAfterHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.qtyAfterHeader.Weight = 0.10663719900872132D;
            // 
            // LogReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 49);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "15.2";
            ((System.ComponentModel.ISupportInitialize)(this.LogTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRTable LogTable;
        private DevExpress.XtraReports.UI.XRTableRow LogHeader;
        private DevExpress.XtraReports.UI.XRTableCell DateTimeHeader;
        private DevExpress.XtraReports.UI.XRTableCell ItemIDHeader;
        private DevExpress.XtraReports.UI.XRTableCell DescriptionHeader;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRTableCell UserHeader;
        private DevExpress.XtraReports.UI.XRTableCell AccountHeader;
        private DevExpress.XtraReports.UI.XRTableCell qtyHeader;
        private DevExpress.XtraReports.UI.XRTableCell qtyBeforeHeader;
        private DevExpress.XtraReports.UI.XRTableCell qtyAfterHeader;
    }
}
