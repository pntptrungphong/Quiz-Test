using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDLPT
{
    public partial class frmTaoLogin : Form
    {
        private string mLogin,mPass,mRole,mUsername;
        public frmTaoLogin()
        {
            InitializeComponent();
        }

        private void cbROLE_SelectedIndexChanged(object sender, EventArgs e)
        {
            mRole = cbROLE.SelectedItem.ToString();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if(CreateLogin(txtLOGIN.Text, txtPASS.Text, txtMAGV.Text, cbROLE.Text) == true)
            {
                MessageBox.Show("Ghi Thành công!!!", string.Empty, MessageBoxButtons.OK);
            }
            if (txtLOGIN.Text.Trim() == string.Empty)
            {
                MessageBox.Show("LoginName không được thiếu !", "", MessageBoxButtons.OK);
                txtLOGIN.Focus();
                return;
            }
            if (txtLOGIN.Text.Contains(" "))
            {
                MessageBox.Show("LoginName không được có khoảng trống !", "", MessageBoxButtons.OK);
                txtLOGIN.Focus();
                return;
            }
            if (ktraTrungTenLogin(txtLOGIN.Text))
            {
                MessageBox.Show("LoginName bị trùng. Vui lòng chọn LoginName khác !", "", MessageBoxButtons.OK);
                txtLOGIN.Focus();
                return;
            }
            if (ktraTonTaiLogin(txtMAGV.Text))
            {
                MessageBox.Show("USER này đã có Login, Vui lòng chọn user khác!", "", MessageBoxButtons.OK);
                txtMAGV.Focus();
                return;
            }
            if (txtPASS.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Password không được thiếu !", "", MessageBoxButtons.OK);
                txtPASS.Focus();
                return;
            }
            try
            {
                
                CreateLogin(txtLOGIN.Text, txtPASS.Text, txtMAGV.Text, cbROLE.Text);
                MessageBox.Show("Tạo Login thành công!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi.\n" + ex.Message);
                return;
            }

        }


        private void frmTaoLogin_Load(object sender, EventArgs e)
        { 
            dataSet.EnforceConstraints = false;
            this.TAKH.Connection.ConnectionString = Program.connstr;
            this.TAKH.Fill(this.dataSet.KHOA);
            this.TAGVCS.Connection.ConnectionString = Program.connstr;
            this.TAGVCS.Fill(this.dataSet.sp_giaovienCoso);
            //this.bdsGV.Filter = "MAKH ='CNTT' or MAKH='MK'" ;
            cbROLE.Items.Add("CoSo");
            cbROLE.Items.Add("GiaoVien");
         
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private bool CreateLogin(string login, string pass,string username,string role)
        {
            bool result = true;
            string strLenh = string.Format("EXEC sp_createlogin {0},{1},{2},{3}", login, pass, username,role);
            using (SqlConnection connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                SqlCommand sqlcmd = new SqlCommand(strLenh, connection);
                sqlcmd.CommandType = CommandType.Text;
                try
                {
                    sqlcmd.ExecuteNonQuery();
                }catch(Exception ex)
                {
                    result = false;
                }
            }
            return result;
        }
        private bool ktraTrungTenLogin(string loginName)
        {
            bool result = true;
            string strLenh = string.Format("EXEC sp_ktratrungLoginName {0}", loginName);
            using (SqlConnection connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(strLenh, connection);
                sqlCommand.CommandType = CommandType.Text;
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    result = false;
                }
                return result;
            }
        }

        private bool ktraTonTaiLogin(string userName)
        {
            bool result = true;
            string strLenh = string.Format("EXEC sp_ktraTonTaiLogin {0}", userName);
            using (SqlConnection connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(strLenh, connection);
                sqlCommand.CommandType = CommandType.Text;
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    result = false;
                }
                return result;
            }
        }
    }
}
