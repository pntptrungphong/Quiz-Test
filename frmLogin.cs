using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSDLPT
{
    public partial class frmLogin : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void cbCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = cbCN.SelectedValue.ToString();
            }
            catch(Exception)
            {

            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string chuoiketnoi = "Data Source=DESKTOP-FC1GMR5\\PHONGPHAM;Initial Catalog=TN_CSDLPT;Integrated Security=True";
            Program.conn.ConnectionString = chuoiketnoi;
            Program.conn.Open();
            DataTable dt = new DataTable();
            dt = Program.ExecSqlDataTable("SELECT * FROM V_DS_PHANMANH");
            Program.bds_dspm.DataSource = dt;
            cbCN.DataSource = dt;
            cbCN.DisplayMember = "TENCN";
            cbCN.ValueMember = "TENSERVER";
            cbCN.SelectedIndex = -1;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(txtTenDN.Text.Trim()==" " || txtPw.Text.Trim()==" ")
            {
                MessageBox.Show("Login name và mật mã không đúng", " ", MessageBoxButtons.OK);
                return;
            }
            Program.mlogin = txtTenDN.Text;
            Program.password = txtPw.Text;
            if (Program.KetNoi() == 0)
            {
                return;
            }
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;
            string strLenh = "EXEC sp_Dangnhap '" + Program.mlogin + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();
            //sp_dangnhap trả về 3 cột
            Program.username = Program.myReader.GetString(0);
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username, password", "", MessageBoxButtons.OK);
                return;
            }
            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();
            Program.conn.Close();
            MessageBox.Show("Nhan vien - Nhom : " + Program.mHoten + " - " + Program.mGroup, "", MessageBoxButtons.OK);
            if (Program.mGroup == "CoSo")
            {
              
                    frmMain f = new frmMain();
                    f.Show();
                    this.Hide();
                    f.FormClosed += (o, w) => this.Show();
               
            }
            if (Program.mGroup == "GiaoVien")
            {

                      frmMainGV f = new frmMainGV();
                    f.Show();
                    this.Hide();
                    f.FormClosed += (o, w) => this.Show();
                
               
            }
            if(Program.mGroup == "SinhVien")
            {
                frmDuThi f = new frmDuThi();
                f.Show();
                this.Hide();
                f.FormClosed += (o, w) => this.Show();
            }
        



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
