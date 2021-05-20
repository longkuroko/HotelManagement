namespace QuanLyNhaNghi
{
    partial class Report
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PhieuThueRPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCTHD = new System.Windows.Forms.ComboBox();
            this.radioCTHD = new System.Windows.Forms.RadioButton();
            this.dateTimePickerHDthang = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerHD2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerHD1 = new System.Windows.Forms.DateTimePicker();
            this.radioHDNgay = new System.Windows.Forms.RadioButton();
            this.btnBack = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.radioHDThang = new System.Windows.Forms.RadioButton();
            this.cmbPhieuDV = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioHoaDon = new System.Windows.Forms.RadioButton();
            this.radioPhieuDichVu = new System.Windows.Forms.RadioButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PhieuThueRPBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PhieuThueRPBindingSource
            // 
            this.PhieuThueRPBindingSource.DataSource = typeof(QuanLyNhaNghi.phieureport.PhieuThueRP);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCTHD);
            this.groupBox1.Controls.Add(this.radioCTHD);
            this.groupBox1.Controls.Add(this.dateTimePickerHDthang);
            this.groupBox1.Controls.Add(this.dateTimePickerHD2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePickerHD1);
            this.groupBox1.Controls.Add(this.radioHDNgay);
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.radioHDThang);
            this.groupBox1.Controls.Add(this.cmbPhieuDV);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioHoaDon);
            this.groupBox1.Controls.Add(this.radioPhieuDichVu);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(891, 154);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmbCTHD
            // 
            this.cmbCTHD.Enabled = false;
            this.cmbCTHD.FormattingEnabled = true;
            this.cmbCTHD.Location = new System.Drawing.Point(414, 105);
            this.cmbCTHD.Name = "cmbCTHD";
            this.cmbCTHD.Size = new System.Drawing.Size(118, 21);
            this.cmbCTHD.TabIndex = 14;
            // 
            // radioCTHD
            // 
            this.radioCTHD.AutoSize = true;
            this.radioCTHD.Enabled = false;
            this.radioCTHD.Location = new System.Drawing.Point(353, 109);
            this.radioCTHD.Name = "radioCTHD";
            this.radioCTHD.Size = new System.Drawing.Size(55, 17);
            this.radioCTHD.TabIndex = 13;
            this.radioCTHD.TabStop = true;
            this.radioCTHD.Text = "CTHĐ";
            this.radioCTHD.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerHDthang
            // 
            this.dateTimePickerHDthang.CustomFormat = "MM-yyyy";
            this.dateTimePickerHDthang.Enabled = false;
            this.dateTimePickerHDthang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerHDthang.Location = new System.Drawing.Point(469, 39);
            this.dateTimePickerHDthang.Name = "dateTimePickerHDthang";
            this.dateTimePickerHDthang.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePickerHDthang.Size = new System.Drawing.Size(89, 20);
            this.dateTimePickerHDthang.TabIndex = 12;
            // 
            // dateTimePickerHD2
            // 
            this.dateTimePickerHD2.CustomFormat = "dd-MM-yyyy";
            this.dateTimePickerHD2.Enabled = false;
            this.dateTimePickerHD2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerHD2.Location = new System.Drawing.Point(585, 71);
            this.dateTimePickerHD2.Name = "dateTimePickerHD2";
            this.dateTimePickerHD2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePickerHD2.Size = new System.Drawing.Size(89, 20);
            this.dateTimePickerHD2.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(564, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "~";
            // 
            // dateTimePickerHD1
            // 
            this.dateTimePickerHD1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePickerHD1.Enabled = false;
            this.dateTimePickerHD1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerHD1.Location = new System.Drawing.Point(469, 70);
            this.dateTimePickerHD1.Name = "dateTimePickerHD1";
            this.dateTimePickerHD1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePickerHD1.Size = new System.Drawing.Size(89, 20);
            this.dateTimePickerHD1.TabIndex = 9;
            // 
            // radioHDNgay
            // 
            this.radioHDNgay.AutoSize = true;
            this.radioHDNgay.Enabled = false;
            this.radioHDNgay.Location = new System.Drawing.Point(353, 73);
            this.radioHDNgay.Name = "radioHDNgay";
            this.radioHDNgay.Size = new System.Drawing.Size(96, 17);
            this.radioHDNgay.TabIndex = 8;
            this.radioHDNgay.TabStop = true;
            this.radioHDNgay.Text = "Xem theo ngày";
            this.radioHDNgay.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(810, 112);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 34);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Trở lại";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(720, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Xem";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioHDThang
            // 
            this.radioHDThang.AutoSize = true;
            this.radioHDThang.Enabled = false;
            this.radioHDThang.Location = new System.Drawing.Point(353, 42);
            this.radioHDThang.Name = "radioHDThang";
            this.radioHDThang.Size = new System.Drawing.Size(100, 17);
            this.radioHDThang.TabIndex = 6;
            this.radioHDThang.TabStop = true;
            this.radioHDThang.Text = "Xem theo tháng";
            this.radioHDThang.UseVisualStyleBackColor = true;
            // 
            // cmbPhieuDV
            // 
            this.cmbPhieuDV.Enabled = false;
            this.cmbPhieuDV.FormattingEnabled = true;
            this.cmbPhieuDV.Location = new System.Drawing.Point(104, 75);
            this.cmbPhieuDV.Name = "cmbPhieuDV";
            this.cmbPhieuDV.Size = new System.Drawing.Size(118, 21);
            this.cmbPhieuDV.TabIndex = 5;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(18, 82);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(80, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "Xem chi tiết";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(18, 52);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(97, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.Text = "Xem tổng quan";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioHoaDon
            // 
            this.radioHoaDon.AutoSize = true;
            this.radioHoaDon.Location = new System.Drawing.Point(353, 19);
            this.radioHoaDon.Name = "radioHoaDon";
            this.radioHoaDon.Size = new System.Drawing.Size(122, 17);
            this.radioHoaDon.TabIndex = 2;
            this.radioHoaDon.Text = "Danh sách Hóa đơn";
            this.radioHoaDon.UseVisualStyleBackColor = true;
            this.radioHoaDon.CheckedChanged += new System.EventHandler(this.radioHoaDon_CheckedChanged);
            // 
            // radioPhieuDichVu
            // 
            this.radioPhieuDichVu.AutoSize = true;
            this.radioPhieuDichVu.Location = new System.Drawing.Point(18, 26);
            this.radioPhieuDichVu.Name = "radioPhieuDichVu";
            this.radioPhieuDichVu.Size = new System.Drawing.Size(145, 17);
            this.radioPhieuDichVu.TabIndex = 1;
            this.radioPhieuDichVu.Text = "Danh sách Phiếu dịch vụ";
            this.radioPhieuDichVu.UseVisualStyleBackColor = true;
            this.radioPhieuDichVu.CheckedChanged += new System.EventHandler(this.radioPhieuDichVu_CheckedChanged);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataThuePhong";
            reportDataSource1.Value = this.PhieuThueRPBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyNhaNghi.PhieuThuePhong.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 196);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(891, 443);
            this.reportViewer1.TabIndex = 3;
            this.reportViewer1.Visible = false;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 651);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PhieuThueRPBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerHDthang;
        private System.Windows.Forms.DateTimePicker dateTimePickerHD2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerHD1;
        private System.Windows.Forms.RadioButton radioHDNgay;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioHDThang;
        private System.Windows.Forms.ComboBox cmbPhieuDV;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioHoaDon;
        private System.Windows.Forms.RadioButton radioPhieuDichVu;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PhieuThueRPBindingSource;
        private System.Windows.Forms.ComboBox cmbCTHD;
        private System.Windows.Forms.RadioButton radioCTHD;
    }
}