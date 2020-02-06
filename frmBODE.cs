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
    public partial class frmBODE : Form
    {
        private int vitri;
        private string magv;
        public frmBODE()
        {
            InitializeComponent();
        }

        private void bODEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsBODE.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet);

        }

        private void frmBODE_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.GIAOVIEN' table. You can move, or remove it, as needed.


            dataSet.EnforceConstraints = true;
            this.TABODE.Connection.ConnectionString = Program.connstr;
            this.TABODE.Fill(this.dataSet.BODE);
            this.TAMH.Connection.ConnectionString = Program.connstr;
            this.TAMH.Fill(this.dataSet.MONHOC);
            this.TAGV.Connection.ConnectionString = Program.connstr;
            this.TAGV.Fill(this.dataSet.GIAOVIEN);
            cbTrinhDo.Items.Add("A");
            cbTrinhDo.Items.Add("B");
            cbTrinhDo.Items.Add("C");
            cbDapAn.Items.Add("A");
            cbDapAn.Items.Add("B");
            cbDapAn.Items.Add("C");
            cbDapAn.Items.Add("D");

        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsBODE.Position;
            bdsBODE.AddNew();
            //cbMAMH.SelectedValue = mamh;
            txtMAGV.Text = Program.username;
            getCauHoi();
        }

        private void gbBODE_Enter(object sender, EventArgs e)
        {

        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MessageBox.Show("Ghi thành công!!!", string.Empty, MessageBoxButtons.OK);
                bdsBODE.EndEdit();
                bdsBODE.ResetCurrentItem();
                this.TABODE.Connection.ConnectionString = Program.connstr;
                this.TABODE.Update(this.dataSet.BODE);
            }
            catch
            {
                MessageBox.Show("Lỗi ghi!!!", string.Empty, MessageBoxButtons.OK);
                return;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự có muốn xóa???", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    bdsBODE.RemoveCurrent();
                    this.TABODE.Connection.ConnectionString = Program.connstr;
                    this.TABODE.Update(this.dataSet.BODE);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa", string.Empty, MessageBoxButtons.OK);
                }
            }
        }
        private void getCauHoi()
        {
            using (var connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                using (var command = new SqlCommand("select MAX(CAUHOI) from dbo.BODE", connection))
                {
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int result = reader.GetInt32(0) + 1;
                            seCauHoi.Text = result.ToString();

                        }
                    }
                }
            }
        }
    }
}
