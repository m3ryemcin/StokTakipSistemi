namespace StokTakipSistemi
{
    partial class ReportForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlStatsContainer = new System.Windows.Forms.Panel();
            this.pnlLowStock = new System.Windows.Forms.Panel();
            this.lblLowStockCount = new System.Windows.Forms.Label();
            this.pnlSoldProducts = new System.Windows.Forms.Panel();
            this.lblSoldProductCount = new System.Windows.Forms.Label();
            this.pnlTotalCustomer = new System.Windows.Forms.Panel();
            this.lblTotalCustomer = new System.Windows.Forms.Label();
            this.pnlTotalProfit = new System.Windows.Forms.Panel();
            this.lblTotalProfit = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlReportTable = new System.Windows.Forms.Panel();
            this.dgvReportList = new System.Windows.Forms.DataGridView();
            this.pnlReportChart = new System.Windows.Forms.Panel();
            this.chartTopProducts = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblKar = new System.Windows.Forms.Label();
            this.lblMüşteri = new System.Windows.Forms.Label();
            this.lblAdet = new System.Windows.Forms.Label();
            this.lblStok = new System.Windows.Forms.Label();
            this.pnlFilter.SuspendLayout();
            this.pnlStatsContainer.SuspendLayout();
            this.pnlLowStock.SuspendLayout();
            this.pnlSoldProducts.SuspendLayout();
            this.pnlTotalCustomer.SuspendLayout();
            this.pnlTotalProfit.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlReportTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportList)).BeginInit();
            this.pnlReportChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.Navy;
            this.pnlFilter.Controls.Add(this.cmbCategory);
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.btnShowReport);
            this.pnlFilter.Controls.Add(this.dtpEnd);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.dtpStart);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1127, 77);
            this.pnlFilter.TabIndex = 0;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(724, 33);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 24);
            this.cmbCategory.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(641, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kategori:";
            // 
            // btnShowReport
            // 
            this.btnShowReport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnShowReport.FlatAppearance.BorderSize = 0;
            this.btnShowReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowReport.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowReport.ForeColor = System.Drawing.Color.White;
            this.btnShowReport.Location = new System.Drawing.Point(897, 12);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(194, 59);
            this.btnShowReport.TabIndex = 4;
            this.btnShowReport.Text = "Raporu Göster";
            this.btnShowReport.UseVisualStyleBackColor = false;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click_1);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(402, 35);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 22);
            this.dtpEnd.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(346, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bitiş:";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(101, 37);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 22);
            this.dtpStart.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Başlangıç:";
            // 
            // pnlStatsContainer
            // 
            this.pnlStatsContainer.BackColor = System.Drawing.Color.Navy;
            this.pnlStatsContainer.Controls.Add(this.pnlLowStock);
            this.pnlStatsContainer.Controls.Add(this.pnlSoldProducts);
            this.pnlStatsContainer.Controls.Add(this.pnlTotalCustomer);
            this.pnlStatsContainer.Controls.Add(this.pnlTotalProfit);
            this.pnlStatsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatsContainer.Location = new System.Drawing.Point(0, 77);
            this.pnlStatsContainer.Name = "pnlStatsContainer";
            this.pnlStatsContainer.Size = new System.Drawing.Size(1127, 118);
            this.pnlStatsContainer.TabIndex = 1;
            // 
            // pnlLowStock
            // 
            this.pnlLowStock.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlLowStock.Controls.Add(this.lblStok);
            this.pnlLowStock.Controls.Add(this.lblLowStockCount);
            this.pnlLowStock.Location = new System.Drawing.Point(840, 6);
            this.pnlLowStock.Name = "pnlLowStock";
            this.pnlLowStock.Size = new System.Drawing.Size(270, 109);
            this.pnlLowStock.TabIndex = 3;
            // 
            // lblLowStockCount
            // 
            this.lblLowStockCount.AutoSize = true;
            this.lblLowStockCount.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStockCount.ForeColor = System.Drawing.Color.White;
            this.lblLowStockCount.Location = new System.Drawing.Point(89, 39);
            this.lblLowStockCount.Name = "lblLowStockCount";
            this.lblLowStockCount.Size = new System.Drawing.Size(112, 28);
            this.lblLowStockCount.TabIndex = 0;
            this.lblLowStockCount.Text = "Kritik Stok";
            // 
            // pnlSoldProducts
            // 
            this.pnlSoldProducts.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlSoldProducts.Controls.Add(this.lblAdet);
            this.pnlSoldProducts.Controls.Add(this.lblSoldProductCount);
            this.pnlSoldProducts.Location = new System.Drawing.Point(564, 6);
            this.pnlSoldProducts.Name = "pnlSoldProducts";
            this.pnlSoldProducts.Size = new System.Drawing.Size(270, 109);
            this.pnlSoldProducts.TabIndex = 2;
            // 
            // lblSoldProductCount
            // 
            this.lblSoldProductCount.AutoSize = true;
            this.lblSoldProductCount.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoldProductCount.ForeColor = System.Drawing.Color.White;
            this.lblSoldProductCount.Location = new System.Drawing.Point(78, 39);
            this.lblSoldProductCount.Name = "lblSoldProductCount";
            this.lblSoldProductCount.Size = new System.Drawing.Size(118, 28);
            this.lblSoldProductCount.TabIndex = 0;
            this.lblSoldProductCount.Text = "Satış Adedi";
            // 
            // pnlTotalCustomer
            // 
            this.pnlTotalCustomer.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlTotalCustomer.Controls.Add(this.lblMüşteri);
            this.pnlTotalCustomer.Controls.Add(this.lblTotalCustomer);
            this.pnlTotalCustomer.Location = new System.Drawing.Point(288, 6);
            this.pnlTotalCustomer.Name = "pnlTotalCustomer";
            this.pnlTotalCustomer.Size = new System.Drawing.Size(270, 109);
            this.pnlTotalCustomer.TabIndex = 1;
            // 
            // lblTotalCustomer
            // 
            this.lblTotalCustomer.AutoSize = true;
            this.lblTotalCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCustomer.ForeColor = System.Drawing.Color.White;
            this.lblTotalCustomer.Location = new System.Drawing.Point(57, 39);
            this.lblTotalCustomer.Name = "lblTotalCustomer";
            this.lblTotalCustomer.Size = new System.Drawing.Size(151, 28);
            this.lblTotalCustomer.TabIndex = 0;
            this.lblTotalCustomer.Text = " Müşteri Sayısı";
            // 
            // pnlTotalProfit
            // 
            this.pnlTotalProfit.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlTotalProfit.Controls.Add(this.lblKar);
            this.pnlTotalProfit.Controls.Add(this.lblTotalProfit);
            this.pnlTotalProfit.Location = new System.Drawing.Point(12, 6);
            this.pnlTotalProfit.Name = "pnlTotalProfit";
            this.pnlTotalProfit.Size = new System.Drawing.Size(270, 109);
            this.pnlTotalProfit.TabIndex = 0;
            this.pnlTotalProfit.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTotalProfit_Paint);
            // 
            // lblTotalProfit
            // 
            this.lblTotalProfit.AutoSize = true;
            this.lblTotalProfit.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProfit.ForeColor = System.Drawing.Color.White;
            this.lblTotalProfit.Location = new System.Drawing.Point(84, 39);
            this.lblTotalProfit.Name = "lblTotalProfit";
            this.lblTotalProfit.Size = new System.Drawing.Size(103, 28);
            this.lblTotalProfit.TabIndex = 0;
            this.lblTotalProfit.Text = "Kar/Zarar";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tableLayoutPanel1);
            this.pnlMain.Controls.Add(this.pnlStatsContainer);
            this.pnlMain.Controls.Add(this.pnlFilter);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1127, 450);
            this.pnlMain.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pnlReportTable, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlReportChart, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 195);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1127, 255);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // pnlReportTable
            // 
            this.pnlReportTable.Controls.Add(this.dgvReportList);
            this.pnlReportTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReportTable.Location = new System.Drawing.Point(3, 3);
            this.pnlReportTable.Name = "pnlReportTable";
            this.pnlReportTable.Size = new System.Drawing.Size(557, 249);
            this.pnlReportTable.TabIndex = 2;
            // 
            // dgvReportList
            // 
            this.dgvReportList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReportList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReportList.Location = new System.Drawing.Point(0, 0);
            this.dgvReportList.Name = "dgvReportList";
            this.dgvReportList.RowHeadersWidth = 51;
            this.dgvReportList.RowTemplate.Height = 24;
            this.dgvReportList.Size = new System.Drawing.Size(557, 249);
            this.dgvReportList.TabIndex = 0;
            // 
            // pnlReportChart
            // 
            this.pnlReportChart.Controls.Add(this.chartTopProducts);
            this.pnlReportChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReportChart.Location = new System.Drawing.Point(566, 3);
            this.pnlReportChart.Name = "pnlReportChart";
            this.pnlReportChart.Size = new System.Drawing.Size(558, 249);
            this.pnlReportChart.TabIndex = 3;
            // 
            // chartTopProducts
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTopProducts.ChartAreas.Add(chartArea2);
            this.chartTopProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartTopProducts.Legends.Add(legend2);
            this.chartTopProducts.Location = new System.Drawing.Point(0, 0);
            this.chartTopProducts.Name = "chartTopProducts";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Satislar";
            this.chartTopProducts.Series.Add(series2);
            this.chartTopProducts.Size = new System.Drawing.Size(558, 249);
            this.chartTopProducts.TabIndex = 0;
            this.chartTopProducts.Text = "chart1";
            // 
            // lblKar
            // 
            this.lblKar.AutoSize = true;
            this.lblKar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKar.ForeColor = System.Drawing.Color.White;
            this.lblKar.Location = new System.Drawing.Point(104, 77);
            this.lblKar.Name = "lblKar";
            this.lblKar.Size = new System.Drawing.Size(59, 23);
            this.lblKar.TabIndex = 1;
            this.lblKar.Text = "label4";
            // 
            // lblMüşteri
            // 
            this.lblMüşteri.AutoSize = true;
            this.lblMüşteri.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMüşteri.ForeColor = System.Drawing.Color.White;
            this.lblMüşteri.Location = new System.Drawing.Point(100, 77);
            this.lblMüşteri.Name = "lblMüşteri";
            this.lblMüşteri.Size = new System.Drawing.Size(59, 23);
            this.lblMüşteri.TabIndex = 2;
            this.lblMüşteri.Text = "label5";
            // 
            // lblAdet
            // 
            this.lblAdet.AutoSize = true;
            this.lblAdet.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdet.ForeColor = System.Drawing.Color.White;
            this.lblAdet.Location = new System.Drawing.Point(102, 77);
            this.lblAdet.Name = "lblAdet";
            this.lblAdet.Size = new System.Drawing.Size(59, 23);
            this.lblAdet.TabIndex = 3;
            this.lblAdet.Text = "label6";
            // 
            // lblStok
            // 
            this.lblStok.AutoSize = true;
            this.lblStok.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStok.ForeColor = System.Drawing.Color.White;
            this.lblStok.Location = new System.Drawing.Point(116, 77);
            this.lblStok.Name = "lblStok";
            this.lblStok.Size = new System.Drawing.Size(59, 23);
            this.lblStok.TabIndex = 4;
            this.lblStok.Text = "label7";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 450);
            this.Controls.Add(this.pnlMain);
            this.Name = "ReportForm";
            this.Text = "RAPORLAMA ";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlStatsContainer.ResumeLayout(false);
            this.pnlLowStock.ResumeLayout(false);
            this.pnlLowStock.PerformLayout();
            this.pnlSoldProducts.ResumeLayout(false);
            this.pnlSoldProducts.PerformLayout();
            this.pnlTotalCustomer.ResumeLayout(false);
            this.pnlTotalCustomer.PerformLayout();
            this.pnlTotalProfit.ResumeLayout(false);
            this.pnlTotalProfit.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlReportTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportList)).EndInit();
            this.pnlReportChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTopProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlStatsContainer;
        private System.Windows.Forms.Panel pnlLowStock;
        private System.Windows.Forms.Panel pnlSoldProducts;
        private System.Windows.Forms.Panel pnlTotalCustomer;
        private System.Windows.Forms.Panel pnlTotalProfit;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblLowStockCount;
        private System.Windows.Forms.Label lblSoldProductCount;
        private System.Windows.Forms.Label lblTotalCustomer;
        private System.Windows.Forms.Label lblTotalProfit;
        private System.Windows.Forms.Panel pnlReportChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopProducts;
        private System.Windows.Forms.Panel pnlReportTable;
        private System.Windows.Forms.DataGridView dgvReportList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblKar;
        private System.Windows.Forms.Label lblStok;
        private System.Windows.Forms.Label lblAdet;
        private System.Windows.Forms.Label lblMüşteri;
    }
}