namespace CSDLPT
{
    partial class frmThi
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
            this.dataSet = new CSDLPT.TN_CSDLPTDataSet();
            this.bdsBD = new System.Windows.Forms.BindingSource(this.components);
            this.TABD = new CSDLPT.TN_CSDLPTDataSetTableAdapters.BODETableAdapter();
            this.tableAdapterManager = new CSDLPT.TN_CSDLPTDataSetTableAdapters.TableAdapterManager();
            this.gbCauHoi = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbND = new System.Windows.Forms.Label();
            this.radioD = new System.Windows.Forms.RadioButton();
            this.radioB = new System.Windows.Forms.RadioButton();
            this.radioC = new System.Windows.Forms.RadioButton();
            this.radioA = new System.Windows.Forms.RadioButton();
            this.btnCAUTRUOC = new System.Windows.Forms.Button();
            this.btnCAUSAU = new System.Windows.Forms.Button();
            this.btnTinhDiem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBD)).BeginInit();
            this.gbCauHoi.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "TN_CSDLPTDataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsBD
            // 
            this.bdsBD.DataMember = "BODE";
            this.bdsBD.DataSource = this.dataSet;
            // 
            // TABD
            // 
            this.TABD.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANGDIEMTableAdapter = null;
            this.tableAdapterManager.BODETableAdapter = this.TABD;
            this.tableAdapterManager.COSOTableAdapter = null;
            this.tableAdapterManager.GIAOVIEN_DANGKYTableAdapter = null;
            this.tableAdapterManager.GIAOVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = CSDLPT.TN_CSDLPTDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gbCauHoi
            // 
            this.gbCauHoi.Controls.Add(this.label7);
            this.gbCauHoi.Controls.Add(this.label6);
            this.gbCauHoi.Controls.Add(this.label5);
            this.gbCauHoi.Controls.Add(this.label4);
            this.gbCauHoi.Controls.Add(this.lbND);
            this.gbCauHoi.Controls.Add(this.radioD);
            this.gbCauHoi.Controls.Add(this.radioB);
            this.gbCauHoi.Controls.Add(this.radioC);
            this.gbCauHoi.Controls.Add(this.radioA);
            this.gbCauHoi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbCauHoi.Location = new System.Drawing.Point(0, 155);
            this.gbCauHoi.Name = "gbCauHoi";
            this.gbCauHoi.Size = new System.Drawing.Size(711, 214);
            this.gbCauHoi.TabIndex = 0;
            this.gbCauHoi.TabStop = false;
            this.gbCauHoi.Text = "CÂU HỎI";
            this.gbCauHoi.Enter += new System.EventHandler(this.gbCauHoi_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(509, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Câu D";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Câu C";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(510, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Câu B";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Câu A";
            // 
            // lbND
            // 
            this.lbND.AutoSize = true;
            this.lbND.Location = new System.Drawing.Point(56, 20);
            this.lbND.Name = "lbND";
            this.lbND.Size = new System.Drawing.Size(0, 13);
            this.lbND.TabIndex = 4;
            // 
            // radioD
            // 
            this.radioD.AutoSize = true;
            this.radioD.Location = new System.Drawing.Point(581, 137);
            this.radioD.Name = "radioD";
            this.radioD.Size = new System.Drawing.Size(14, 13);
            this.radioD.TabIndex = 3;
            this.radioD.UseVisualStyleBackColor = true;
            // 
            // radioB
            // 
            this.radioB.AutoSize = true;
            this.radioB.Location = new System.Drawing.Point(582, 64);
            this.radioB.Name = "radioB";
            this.radioB.Size = new System.Drawing.Size(14, 13);
            this.radioB.TabIndex = 2;
            this.radioB.UseVisualStyleBackColor = true;
            // 
            // radioC
            // 
            this.radioC.AutoSize = true;
            this.radioC.Location = new System.Drawing.Point(154, 137);
            this.radioC.Name = "radioC";
            this.radioC.Size = new System.Drawing.Size(14, 13);
            this.radioC.TabIndex = 1;
            this.radioC.UseVisualStyleBackColor = true;
            // 
            // radioA
            // 
            this.radioA.AutoSize = true;
            this.radioA.Location = new System.Drawing.Point(155, 64);
            this.radioA.Name = "radioA";
            this.radioA.Size = new System.Drawing.Size(14, 13);
            this.radioA.TabIndex = 0;
            this.radioA.UseVisualStyleBackColor = true;
            // 
            // btnCAUTRUOC
            // 
            this.btnCAUTRUOC.Location = new System.Drawing.Point(68, 112);
            this.btnCAUTRUOC.Name = "btnCAUTRUOC";
            this.btnCAUTRUOC.Size = new System.Drawing.Size(75, 23);
            this.btnCAUTRUOC.TabIndex = 3;
            this.btnCAUTRUOC.Text = "Câu trước";
            this.btnCAUTRUOC.UseVisualStyleBackColor = true;
            this.btnCAUTRUOC.Click += new System.EventHandler(this.btnCAUTRUOC_Click);
            // 
            // btnCAUSAU
            // 
            this.btnCAUSAU.Location = new System.Drawing.Point(521, 112);
            this.btnCAUSAU.Name = "btnCAUSAU";
            this.btnCAUSAU.Size = new System.Drawing.Size(75, 23);
            this.btnCAUSAU.TabIndex = 4;
            this.btnCAUSAU.Text = "Câu sau";
            this.btnCAUSAU.UseVisualStyleBackColor = true;
            this.btnCAUSAU.Click += new System.EventHandler(this.btnCAUSAU_Click);
            // 
            // btnTinhDiem
            // 
            this.btnTinhDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhDiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTinhDiem.Location = new System.Drawing.Point(521, 19);
            this.btnTinhDiem.Name = "btnTinhDiem";
            this.btnTinhDiem.Size = new System.Drawing.Size(98, 40);
            this.btnTinhDiem.TabIndex = 5;
            this.btnTinhDiem.Text = "NỘP BÀI ";
            this.btnTinhDiem.UseVisualStyleBackColor = true;
            this.btnTinhDiem.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(86, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(162, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "00";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(21, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 35);
            this.label3.TabIndex = 8;
            this.label3.Text = "00";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 369);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTinhDiem);
            this.Controls.Add(this.gbCauHoi);
            this.Controls.Add(this.btnCAUTRUOC);
            this.Controls.Add(this.btnCAUSAU);
            this.Name = "frmThi";
            this.Text = "THI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBD)).EndInit();
            this.gbCauHoi.ResumeLayout(false);
            this.gbCauHoi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TN_CSDLPTDataSet dataSet;
        private System.Windows.Forms.BindingSource bdsBD;
        private TN_CSDLPTDataSetTableAdapters.BODETableAdapter TABD;
        private TN_CSDLPTDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.GroupBox gbCauHoi;
        private System.Windows.Forms.RadioButton radioD;
        private System.Windows.Forms.RadioButton radioB;
        private System.Windows.Forms.RadioButton radioC;
        private System.Windows.Forms.RadioButton radioA;
        private System.Windows.Forms.Button btnCAUTRUOC;
        private System.Windows.Forms.Button btnCAUSAU;
        private System.Windows.Forms.Label lbND;
        private System.Windows.Forms.Button btnTinhDiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}