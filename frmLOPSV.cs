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
    public partial class frmLOPSV : Form
    {
        private int vitri;
        private string makh;
        private int malop;
     
        public frmLOPSV()
        {
            InitializeComponent();
       
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLOP.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet);

        }

        private void frmLOPSV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
           



            dataSet.EnforceConstraints = false;
            this.TASV.Connection.ConnectionString = Program.connstr;
            this.TASV.Fill(this.dataSet.SINHVIEN);
            this.TALOP.Connection.ConnectionString = Program.connstr;
            this.TALOP.Fill(this.dataSet.LOP);
            this.TAKH.Connection.ConnectionString = Program.connstr;
            this.TAKH.Fill(this.dataSet.KHOA);
            this.TABANGDIEM.Connection.ConnectionString = Program.connstr;
            this.TABANGDIEM.Fill(this.dataSet.BANGDIEM);
            this.TAGVDK.Connection.ConnectionString = Program.connstr;
            this.TAGVDK.Fill(this.dataSet.GIAOVIEN_DANGKY);
            loadTable();
        }
        private void loadTable()
        {
            try
            {
                makh = ((DataRowView)bdsLOP[0])["MAKH"].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLOP.Position;
            bdsLOP.AddNew();
            cbMAKH.SelectedValue = makh;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMALOP.Text.Trim() == null && txtTENLOP.Text.Trim()==null)
            {
                MessageBox.Show("Không được để trống !!!", string.Empty, MessageBoxButtons.OK);
                txtMALOP.Focus();
                return;
            }
            if (checkExist(txtMALOP.Text) == true)
            {
                MessageBox.Show("Mã lớp bị trùng, vui lòng nhập lại!!!", string.Empty, MessageBoxButtons.OK);
                txtMALOP.Focus();
                return;
            }
            try
            {
                bdsLOP.EndEdit();
                bdsKH.ResetCurrentItem();
                dgvSV.Refresh();
                this.TALOP.Update(this.dataSet.LOP);
                MessageBox.Show("Ghi dữ liệu thành công!!!", string.Empty, MessageBoxButtons.OK);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool checkExist(string id)
        {
            string strLenh = string.Format("EXEC sp_timlop '" + id + "'");
            bool exist = false;
            using (SqlConnection connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                SqlCommand sqlcmd = new SqlCommand(strLenh, connection);
                sqlcmd.CommandType = CommandType.Text;
                try
                {
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    exist = true;
                }
                catch (SqlException)
                {
                    exist = false;
                }
            }
            return exist;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (bdsSV.Count != 0 ||bdsGVDK.Count!=0)
            {
                MessageBox.Show("Không thể xóa vì trong lớp tồn tại sinh viên hoặc giáo viên đã đăng kí thi!!!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Bạn thật sự có muốn xóa???", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        malop = int.Parse(((DataRowView)bdsLOP[bdsLOP.Position])["MALOP"].ToString());
                        bdsLOP.RemoveCurrent();
                        this.TALOP.Connection.ConnectionString = Program.connstr;
                        this.TALOP.Update(this.dataSet.LOP);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa", string.Empty, MessageBoxButtons.OK);
                    }
                }
        }
            
}

        private void dgvSV_ContextMenuStripChanged(object sender, EventArgs e)
        {

        }
        private bool IsExist1(string id)
        {
            string strLenh = string.Format("EXEC sp_timSV '" + id + "'");
            bool exist = false;
            using (SqlConnection connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                SqlCommand sqlcmd = new SqlCommand(strLenh, connection);
                sqlcmd.CommandType = CommandType.Text;
                try
                {
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    exist = true;
                }
                catch (SqlException)

                {
                    exist = false;
                }
            }
            return exist;
        }

        private void validateStringField(String field, int condition, DataGridViewCellValidatingEventArgs e, bool isNullable = true)
        {
            //Cell is not empty
            if (!isNullable && string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                dgvSV.Rows[e.RowIndex].ErrorText = $"{field} không được rỗng!";
                MessageBox.Show($"{field} không được rỗng!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {
            vitri = bdsSV.Position;
            bdsSV.AddNew();
        }

        private void btnXoaSV_Click(object sender, EventArgs e)
        {
         
            try
            {
                DataRowView current = (DataRowView)bdsSV.Current;
                if (bdsBANGDIEM.Count != 0)
                {
                    MessageBox.Show("khong xoa duoc", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show(
                        current.Row.ItemArray.ToString(), "xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            bdsSV.RemoveCurrent();
                            dgvSV.Refresh();
                            this.TASV.Update(this.dataSet.SINHVIEN);
                            MessageBox.Show("xoa duoc", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("khong xoa duoc", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnGhiSV_Click(object sender, EventArgs e)
        {
            string Text1 = dgvSV.CurrentRow.Cells[0].Value.ToString();
            if (IsExist1(Text1))
            {
                MessageBox.Show("Mã sinh viên bị trùng !", string.Empty, MessageBoxButtons.OK);
                return;
            }
            try
            {
                MessageBox.Show("Ghi dư liệu thành công.");
                bdsSV.EndEdit();
                dgvSV.Refresh();
                this.TASV.Update(this.dataSet.SINHVIEN);               
            }
            catch (Exception ex)
            {
                    MessageBox.Show("Lỗi ghi " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

      

        private void dgvSV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dgvSV.Columns[e.ColumnIndex].HeaderText;

            if (headerText.Equals("MASV"))
            {
                validateStringField("MASV", 10, e, false);
            }

            if (headerText.Equals("HO"))
            {
                validateStringField("HO", 40, e, false);
            }

            if (headerText.Equals("TEN"))
            {
                validateStringField("TEN", 10, e, false);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.dataSet.EnforceConstraints = false;
            this.TASV.Connection.ConnectionString = Program.connstr;
            this.TASV.Fill(this.dataSet.SINHVIEN);
            this.TALOP.Connection.ConnectionString = Program.connstr;
            this.TALOP.Fill(this.dataSet.LOP);
            this.TAKH.Connection.ConnectionString = Program.connstr;
            this.TAKH.Fill(this.dataSet.KHOA);
            this.TABANGDIEM.Connection.ConnectionString = Program.connstr;
            this.TABANGDIEM.Fill(this.dataSet.BANGDIEM);
            this.TAGVDK.Connection.ConnectionString = Program.connstr;
            this.TAGVDK.Fill(this.dataSet.GIAOVIEN_DANGKY);

        }
    }
}
