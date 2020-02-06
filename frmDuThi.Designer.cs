namespace CSDLPT
{
    partial class frmDuThi
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
            System.Windows.Forms.Label mAMHLabel;
            System.Windows.Forms.Label nGAYTHILabel;
            System.Windows.Forms.Label lANLabel;
            this.dataSet = new CSDLPT.TN_CSDLPTDataSet();
            this.bdsSV = new System.Windows.Forms.BindingSource(this.components);
            this.TASV = new CSDLPT.TN_CSDLPTDataSetTableAdapters.SINHVIENTableAdapter();
            this.tableAdapterManager = new CSDLPT.TN_CSDLPTDataSetTableAdapters.TableAdapterManager();
            this.bdsGVDK = new System.Windows.Forms.BindingSource(this.components);
            this.TAGVDK = new CSDLPT.TN_CSDLPTDataSetTableAdapters.GIAOVIEN_DANGKYTableAdapter();
            this.bdsMH = new System.Windows.Forms.BindingSource(this.components);
            this.TAMH = new CSDLPT.TN_CSDLPTDataSetTableAdapters.MONHOCTableAdapter();
            this.cbMAMH = new System.Windows.Forms.ComboBox();
            this.deNGAYTHI = new DevExpress.XtraEditors.DateEdit();
            this.seLAN = new DevExpress.XtraEditors.SpinEdit();
            this.btnTHI = new System.Windows.Forms.Button();
            this.btnEXIST = new System.Windows.Forms.Button();
            this.lb = new System.Windows.Forms.Label();
            this.lbHoTen = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMaLop = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTenLop = new System.Windows.Forms.Label();
            mAMHLabel = new System.Windows.Forms.Label();
            nGAYTHILabel = new System.Windows.Forms.Label();
            lANLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsGVDK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNGAYTHI.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNGAYTHI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLAN.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mAMHLabel
            // 
            mAMHLabel.AutoSize = true;
            mAMHLabel.Location = new System.Drawing.Point(32, 142);
            mAMHLabel.Name = "mAMHLabel";
            mAMHLabel.Size = new System.Drawing.Size(42, 13);
            mAMHLabel.TabIndex = 3;
            mAMHLabel.Text = "Mã MH";
            // 
            // nGAYTHILabel
            // 
            nGAYTHILabel.AutoSize = true;
            nGAYTHILabel.Location = new System.Drawing.Point(275, 143);
            nGAYTHILabel.Name = "nGAYTHILabel";
            nGAYTHILabel.Size = new System.Drawing.Size(50, 13);
            nGAYTHILabel.TabIndex = 5;
            nGAYTHILabel.Text = "Ngày Thi";
            // 
            // lANLabel
            // 
            lANLabel.AutoSize = true;
            lANLabel.Location = new System.Drawing.Point(533, 143);
            lANLabel.Name = "lANLabel";
            lANLabel.Size = new System.Drawing.Size(25, 13);
            lANLabel.TabIndex = 7;
            lANLabel.Text = "Lần";
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "TN_CSDLPTDataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsSV
            // 
            this.bdsSV.DataMember = "SINHVIEN";
            this.bdsSV.DataSource = this.dataSet;
            // 
            // TASV
            // 
            this.TASV.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANGDIEMTableAdapter = null;
            this.tableAdapterManager.BODETableAdapter = null;
            this.tableAdapterManager.COSOTableAdapter = null;
            this.tableAdapterManager.GIAOVIEN_DANGKYTableAdapter = null;
            this.tableAdapterManager.GIAOVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = this.TASV;
            this.tableAdapterManager.UpdateOrder = CSDLPT.TN_CSDLPTDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // bdsGVDK
            // 
            this.bdsGVDK.DataMember = "GIAOVIEN_DANGKY";
            this.bdsGVDK.DataSource = this.dataSet;
            // 
            // TAGVDK
            // 
            this.TAGVDK.ClearBeforeFill = true;
            // 
            // bdsMH
            // 
            this.bdsMH.DataMember = "MONHOC";
            this.bdsMH.DataSource = this.dataSet;
            // 
            // TAMH
            // 
            this.TAMH.ClearBeforeFill = true;
            // 
            // cbMAMH
            // 
            this.cbMAMH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsGVDK, "MAMH", true));
            this.cbMAMH.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsGVDK, "MAMH", true));
            this.cbMAMH.DataSource = this.bdsMH;
            this.cbMAMH.DisplayMember = "MAMH";
            this.cbMAMH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMAMH.FormattingEnabled = true;
            this.cbMAMH.Location = new System.Drawing.Point(81, 139);
            this.cbMAMH.Name = "cbMAMH";
            this.cbMAMH.Size = new System.Drawing.Size(121, 21);
            this.cbMAMH.TabIndex = 4;
            this.cbMAMH.ValueMember = "MAMH";
            this.cbMAMH.SelectedIndexChanged += new System.EventHandler(this.cbMAMH_SelectedIndexChanged);
            // 
            // deNGAYTHI
            // 
            this.deNGAYTHI.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsGVDK, "NGAYTHI", true));
            this.deNGAYTHI.EditValue = null;
            this.deNGAYTHI.Location = new System.Drawing.Point(339, 140);
            this.deNGAYTHI.Name = "deNGAYTHI";
            this.deNGAYTHI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deNGAYTHI.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deNGAYTHI.Size = new System.Drawing.Size(109, 20);
            this.deNGAYTHI.TabIndex = 6;
            // 
            // seLAN
            // 
            this.seLAN.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsGVDK, "LAN", true));
            this.seLAN.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seLAN.Location = new System.Drawing.Point(564, 136);
            this.seLAN.Name = "seLAN";
            this.seLAN.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seLAN.Properties.MaxValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.seLAN.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seLAN.Properties.ReadOnly = true;
            this.seLAN.Size = new System.Drawing.Size(100, 20);
            this.seLAN.TabIndex = 8;
            this.seLAN.EditValueChanged += new System.EventHandler(this.seLAN_EditValueChanged);
            // 
            // btnTHI
            // 
            this.btnTHI.Location = new System.Drawing.Point(202, 218);
            this.btnTHI.Name = "btnTHI";
            this.btnTHI.Size = new System.Drawing.Size(90, 29);
            this.btnTHI.TabIndex = 9;
            this.btnTHI.Text = "Thi";
            this.btnTHI.UseVisualStyleBackColor = true;
            this.btnTHI.Click += new System.EventHandler(this.btnTHI_Click);
            // 
            // btnEXIST
            // 
            this.btnEXIST.Location = new System.Drawing.Point(412, 218);
            this.btnEXIST.Name = "btnEXIST";
            this.btnEXIST.Size = new System.Drawing.Size(89, 29);
            this.btnEXIST.TabIndex = 10;
            this.btnEXIST.Text = "Thoát";
            this.btnEXIST.UseVisualStyleBackColor = true;
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Location = new System.Drawing.Point(33, 24);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(58, 13);
            this.lb.TabIndex = 11;
            this.lb.Text = "Họ và Tên";
            // 
            // lbHoTen
            // 
            this.lbHoTen.AutoSize = true;
            this.lbHoTen.Location = new System.Drawing.Point(108, 24);
            this.lbHoTen.Name = "lbHoTen";
            this.lbHoTen.Size = new System.Drawing.Size(0, 13);
            this.lbHoTen.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Mã lớp";
            // 
            // lbMaLop
            // 
            this.lbMaLop.AutoSize = true;
            this.lbMaLop.Location = new System.Drawing.Point(107, 54);
            this.lbMaLop.Name = "lbMaLop";
            this.lbMaLop.Size = new System.Drawing.Size(0, 13);
            this.lbMaLop.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tên Lớp";
            // 
            // lbTenLop
            // 
            this.lbTenLop.AutoSize = true;
            this.lbTenLop.Location = new System.Drawing.Point(107, 83);
            this.lbTenLop.Name = "lbTenLop";
            this.lbTenLop.Size = new System.Drawing.Size(0, 13);
            this.lbTenLop.TabIndex = 16;
            // 
            // frmDuThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbTenLop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbMaLop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbHoTen);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.btnEXIST);
            this.Controls.Add(this.btnTHI);
            this.Controls.Add(lANLabel);
            this.Controls.Add(this.seLAN);
            this.Controls.Add(nGAYTHILabel);
            this.Controls.Add(this.deNGAYTHI);
            this.Controls.Add(mAMHLabel);
            this.Controls.Add(this.cbMAMH);
            this.Name = "frmDuThi";
            this.Text = "DỰ THI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDuThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsGVDK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNGAYTHI.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNGAYTHI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLAN.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TN_CSDLPTDataSet dataSet;
        private System.Windows.Forms.BindingSource bdsSV;
        private TN_CSDLPTDataSetTableAdapters.SINHVIENTableAdapter TASV;
        private TN_CSDLPTDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource bdsGVDK;
        private TN_CSDLPTDataSetTableAdapters.GIAOVIEN_DANGKYTableAdapter TAGVDK;
        private System.Windows.Forms.BindingSource bdsMH;
        private TN_CSDLPTDataSetTableAdapters.MONHOCTableAdapter TAMH;
        private System.Windows.Forms.ComboBox cbMAMH;
        private DevExpress.XtraEditors.DateEdit deNGAYTHI;
        private DevExpress.XtraEditors.SpinEdit seLAN;
        private System.Windows.Forms.Button btnTHI;
        private System.Windows.Forms.Button btnEXIST;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.Label lbHoTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMaLop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTenLop;
    }
}