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
    public partial class frmDKTHI : Form
    {
        private int vitri;
        public frmDKTHI()
        {
            InitializeComponent();
        }

        private void frmDKTHI_Load(object sender, EventArgs e)
        {
            this.dataSet.EnforceConstraints = false;
            this.TAMH.Connection.ConnectionString = TAMH.Connection.ConnectionString = Program.connstr;
            this.TAMH.Fill(this.dataSet.MONHOC);
            this.TALOP.Connection.ConnectionString = TALOP.Connection.ConnectionString = Program.connstr;
            this.TALOP.Fill(this.dataSet.LOP);
            this.TAGVDK.Connection.ConnectionString = TAGVDK.Connection.ConnectionString = Program.connstr;
            this.TAGVDK.Fill(this.dataSet.GIAOVIEN_DANGKY);
            cbTRINHDO.Items.Add("A");
            cbTRINHDO.Items.Add("B");
            cbTRINHDO.Items.Add("C");

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsGVDK.Position;
            bdsGVDK.AddNew();
            txtMAGV.Text = Program.username;

        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (String.Compare(deNgayThi.DateTime.ToShortTimeString(), DateTime.Now.ToString("dd/MM/yyyy"), true) < 0)
            {
                MessageBox.Show("Đăng kí ngày thi không được nhỏ hơn ngày hiện tại!!!", string.Empty, MessageBoxButtons.OK);
                return;
            }
            else
            {

                if (SoLanThi(cbMAMH.SelectedValue.ToString(), cbMALOP.SelectedValue.ToString(), deNgayThi.Text) == 2)
                {
                    MessageBox.Show("Bạn đã đăng kí môn thi này cho lớp này 2 lần, Vui lòng không đăng kí nữa!!!", string.Empty, MessageBoxButtons.OK);
                    return;
                }
                else if (SoLanThi(cbMAMH.SelectedValue.ToString(), cbMALOP.SelectedValue.ToString(), deNgayThi.Text) == 1)
                {
                    seLAN.Text = "2";
                    if (MessageBox.Show("Bạn đã đăng kí 1 lần. Bấm OK để đăng kí lần 2!!!", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                         try
                    {
                        bdsGVDK.EndEdit();
                        bdsGVDK.ResetCurrentItem();
                        this.TAGVDK.Update(this.dataSet.GIAOVIEN_DANGKY);
                        MessageBox.Show("Đăng kí thành công lần 2!!!", string.Empty, MessageBoxButtons.OK);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi!!!", string.Empty, MessageBoxButtons.OK);
                    }

                    }
                  
                    return;
                }
                else
                {
                    MessageBox.Show("Lớp chưa đăng kí lần nào, đăng kí thành công", string.Empty, MessageBoxButtons.OK);
                    try
                    {
                        bdsGVDK.EndEdit();
                        bdsGVDK.ResetCurrentItem();
                        this.TAGVDK.Update(this.dataSet.GIAOVIEN_DANGKY);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi!!!", string.Empty, MessageBoxButtons.OK);
                    }
                    return;

                }
            }

           
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự có muốn xóa???", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    bdsGVDK.RemoveCurrent();
                    this.TAGVDK.Connection.ConnectionString = Program.connstr;
                    this.TAGVDK.Update(this.dataSet.GIAOVIEN_DANGKY);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa", string.Empty, MessageBoxButtons.OK);
                }
            }
        }
        private int SoLanThi(string maMH, string maLop,string ngaythi)
        {
            using (var connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT COUNT(*) from GIAOVIEN_DANGKY where MAMH=@mamh and MALOP=@malop", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@mamh", maMH);
                    command.Parameters.AddWithValue("@malop", maLop);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int a = reader.GetInt32(0);
                            return a;
                        }
                        return 0;
                    }
                }
            }
        }

        private void gbGVDK_Enter(object sender, EventArgs e)
        {

        }

        private void cbTRINHDO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
