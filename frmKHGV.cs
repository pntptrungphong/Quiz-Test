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
   
    public partial class frmKHGV : Form
    {
        private int vitri;
        private string macs;
        private int makh;
        public frmKHGV()
        {
            InitializeComponent();
        }

        private void kHOABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet);
            btnGhi.Enabled = false;
            gbKH.Enabled = false;
        }

        private void frmKHGV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.LOP' table. You can move, or remove it, as needed.
            this.TALOP.Fill(this.dataSet.LOP);
            dataSet.EnforceConstraints = false;
            this.TAGV.Connection.ConnectionString = Program.connstr;
            this.TAGV.Fill(this.dataSet.GIAOVIEN);
            this.TAKH.Connection.ConnectionString = Program.connstr;
            this.TAKH.Fill(this.dataSet.KHOA);
            this.TABODE.Connection.ConnectionString = Program.connstr;
            this.TABODE.Fill(this.dataSet.BODE);
            loadTable();
            
        }
        private void loadTable()
        {
            try
            {
                macs = ((DataRowView)bdsKH[0])["MACS"].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsKH.Position;
            btnXoa.Enabled = false;
            gbKH.Enabled = true;
            bdsKH.AddNew();
            txtMACS.Text = macs;

        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXoa.Enabled = true;
            if (txtMAKH.Text.Trim() == null)
            {
                MessageBox.Show("Mã khoa không được thiếu!!!", string.Empty, MessageBoxButtons.OK);
                txtMAKH.Focus();
                return;
            }
            if (txtTENKH.Text.Trim() == null)
            {
                MessageBox.Show("Tên Khoa không được thiếu!!!", string.Empty, MessageBoxButtons.OK);
                txtTENKH.Focus();
                return;
            }
            if (checkIsExist(txtMAKH.Text) == true)
            {
                MessageBox.Show("Mã khoa đã tồn tại, vui lòng nhập lại!!!", string.Empty, MessageBoxButtons.OK);
                txtMAKH.Focus();
                return;
            }
            try
            {
                MessageBox.Show("Thêm thành công!!!", string.Empty, MessageBoxButtons.OK);
                bdsKH.EndEdit();
                bdsKH.ResetCurrentItem();
                this.TAKH.Connection.ConnectionString = Program.connstr;
                this.TAKH.Update(this.dataSet.KHOA);
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi Ghi " + ex.Message);
                return;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(bdsGV.Count > 0 || bdsLOP.Count > 0)
            {
                MessageBox.Show("Trong Khoa đang tồn tại giáo viên hoặc lớp, vui lòng không được xóa!!!", string.Empty, MessageBoxButtons.OK);
                return;
            }
            else
            {
                if(MessageBox.Show("Bạn thật sự có muốn xóa???","Xác nhận",MessageBoxButtons.OKCancel)==DialogResult.OK)
                {
                    try
                    {
                        makh = int.Parse(((DataRowView)bdsKH[bdsKH.Position])["MAKH"].ToString());
                        bdsKH.RemoveCurrent();
                        this.TAKH.Connection.ConnectionString = Program.connstr;
                        this.TAKH.Update(this.dataSet.KHOA);
                        MessageBox.Show("Xóa thành công!!!", string.Empty, MessageBoxButtons.OK);
                    }catch(Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa", string.Empty, MessageBoxButtons.OK);
                    }

                }       
            }
        }
        private bool checkIsExist(string id)
        {
            string strLenh = string.Format("EXEC sp_timkhoa '" + id + "'");
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
                catch ( SqlException)
                
                {
                    exist = false;
                }
            }
            return exist;
        }

        private void cmsGV_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnTHEMGV_Click(object sender, EventArgs e)
        {
            bdsGV.AddNew();
        }

        private void btnGhiGV_Click(object sender, EventArgs e)
        {
            string Text1 = dgvGV.CurrentRow.Cells[0].Value.ToString();
            if (IsExist1(Text1))
            {
                MessageBox.Show("Tên mã giáo viên bị trùng !", string.Empty, MessageBoxButtons.OK);
                return;
            }
            try
            {
                bdsGV.EndEdit();
                dgvGV.Refresh();
                this.TAGV.Update(this.dataSet.GIAOVIEN);

                MessageBox.Show("Ghi dư liệu thành công.");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MALOP"))
                    MessageBox.Show("Mã lop không được trùng", "", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Lỗi ghi Lopn học. " + ex.Message, "", MessageBoxButtons.OK);
            }
        }


      
      
        private bool IsExist1(string id)
        {
            string strLenh = string.Format("EXEC sp_timgiaovien '" + id + "'");
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

        private void btnXoaGV_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView current = (DataRowView)bdsGV.Current;
                if (bdsBODE.Count != 0)
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
                            bdsGV.RemoveCurrent();
                            dgvGV.Refresh();
                            this.TAGV.Update(this.dataSet.GIAOVIEN);
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

        private void dgvGV_CellValidating_1(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dgvGV.Columns[e.ColumnIndex].HeaderText;

            if (headerText.Equals("MAGV"))
            {
                validateStringField("MAGV", 10, e, false);
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
        private void validateStringField(String field, int condition, DataGridViewCellValidatingEventArgs e, bool isNullable = true)
        {
            //Cell is not empty
            if (!isNullable && string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                dgvGV.Rows[e.RowIndex].ErrorText = $"{field} không được rỗng!";
                MessageBox.Show($"{field} không được rỗng!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }
    }
}
