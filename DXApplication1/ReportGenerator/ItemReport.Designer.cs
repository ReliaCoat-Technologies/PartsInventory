namespace ReportGenerator
{
    partial class ItemReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.ItemTable = new DevExpress.XtraReports.UI.XRTable();
            this.ItemHeader = new DevExpress.XtraReports.UI.XRTableRow();
            this.ItemIDHeader = new DevExpress.XtraReports.UI.XRTableCell();
            this.DescriptionHeader = new DevExpress.XtraReports.UI.XRTableCell();
            this.QuantityHeader = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.HeightF = 0F;
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
            this.BottomMargin.HeightF = 47.91667F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrRichText1,
            this.xrPictureBox1});
            this.ReportHeader.HeightF = 143.75F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(231.7884F, 1.589457E-05F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(290.5417F, 99.99999F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // xrRichText1
            // 
            this.xrRichText1.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrRichText1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100F);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.SerializableRtfString = resources.GetString("xrRichText1.SerializableRtfString");
            this.xrRichText1.SizeF = new System.Drawing.SizeF(752F, 43.75F);
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ItemTable});
            this.PageHeader.HeightF = 23.95833F;
            this.PageHeader.Name = "PageHeader";
            // 
            // ItemTable
            // 
            this.ItemTable.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.ItemTable.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.ItemTable.Name = "ItemTable";
            this.ItemTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.ItemHeader});
            this.ItemTable.SizeF = new System.Drawing.SizeF(752F, 23.95833F);
            this.ItemTable.StylePriority.UseBorders = false;
            this.ItemTable.StylePriority.UseTextAlignment = false;
            this.ItemTable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ItemHeader
            // 
            this.ItemHeader.BorderColor = System.Drawing.Color.Black;
            this.ItemHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.ItemHeader.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.ItemIDHeader,
            this.DescriptionHeader,
            this.QuantityHeader});
            this.ItemHeader.Name = "ItemHeader";
            this.ItemHeader.StylePriority.UseBorderColor = false;
            this.ItemHeader.StylePriority.UseBorders = false;
            this.ItemHeader.Weight = 1D;
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
            this.ItemIDHeader.Weight = 0.56730759208725279D;
            // 
            // DescriptionHeader
            // 
            this.DescriptionHeader.BackColor = System.Drawing.Color.Black;
            this.DescriptionHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DescriptionHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.DescriptionHeader.ForeColor = System.Drawing.Color.White;
            this.DescriptionHeader.Name = "DescriptionHeader";
            this.DescriptionHeader.StylePriority.UseBackColor = false;
            this.DescriptionHeader.StylePriority.UseBorders = false;
            this.DescriptionHeader.StylePriority.UseFont = false;
            this.DescriptionHeader.StylePriority.UseForeColor = false;
            this.DescriptionHeader.StylePriority.UseTextAlignment = false;
            this.DescriptionHeader.Text = "Description";
            this.DescriptionHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.DescriptionHeader.Weight = 2.1247639341918441D;
            // 
            // QuantityHeader
            // 
            this.QuantityHeader.BackColor = System.Drawing.Color.Black;
            this.QuantityHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.QuantityHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.QuantityHeader.ForeColor = System.Drawing.Color.White;
            this.QuantityHeader.Name = "QuantityHeader";
            this.QuantityHeader.StylePriority.UseBackColor = false;
            this.QuantityHeader.StylePriority.UseBorders = false;
            this.QuantityHeader.StylePriority.UseFont = false;
            this.QuantityHeader.StylePriority.UseForeColor = false;
            this.QuantityHeader.StylePriority.UseTextAlignment = false;
            this.QuantityHeader.Text = "Quantity";
            this.QuantityHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.QuantityHeader.Weight = 0.30792847372090321D;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(752.0001F, 23F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ItemReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader});
            this.Margins = new System.Drawing.Printing.Margins(47, 51, 50, 48);
            this.Version = "15.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRRichText xrRichText1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRTable ItemTable;
        private DevExpress.XtraReports.UI.XRTableRow ItemHeader;
        private DevExpress.XtraReports.UI.XRTableCell ItemIDHeader;
        private DevExpress.XtraReports.UI.XRTableCell DescriptionHeader;
        private DevExpress.XtraReports.UI.XRTableCell QuantityHeader;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
    }
}
