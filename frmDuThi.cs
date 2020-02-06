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
    public partial class frmDuThi : Form
    {
        BindingSource source = new BindingSource();
        public frmDuThi()
        {
            InitializeComponent();
        }

       

        private void frmDuThi_Load(object sender, EventArgs e)
        {
            dataSet.EnforceConstraints = false;
            this.TAMH.Connection.ConnectionString = Program.connstr;
            this.TAMH.Fill(this.dataSet.MONHOC);
            this.TAGVDK.Connection.ConnectionString = Program.connstr;
            this.TAGVDK.Fill(this.dataSet.GIAOVIEN_DANGKY);
            this.TASV.Connection.ConnectionString = Program.connstr;
            this.TASV.Fill(this.dataSet.SINHVIEN);
            getSinhVien(Program.mlogin);

        }
        private void getSinhVien(string id)
        {
            using (var connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                string strLenh = string.Format("EXEC sp_timmalop '" + id + "'");
                using (var command = new SqlCommand(strLenh, connection))
                {
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string result = reader.GetString(0);
                            lbHoTen.Text = result;
                            string result1 = reader.GetString(1);
                            lbMaLop.Text = result1;
                            string result2 = reader.GetString(2);
                            lbTenLop.Text = result2;

                        }
                    }
                }
                connection.Close();
            }
        }
        private bool checkGVDK(string malop, string mamh, string ngaythi, string lan)
        {
            string strLenh = string.Format("EXEC sp_timbode '{0}', '{1}',{2},'{3}'", mamh, ngaythi, lan, malop);

            bool exist = false;
            using (SqlConnection connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                SqlCommand sqlcmd = new SqlCommand(strLenh, connection);
                sqlcmd.CommandType = CommandType.Text;
                try
                {
                    SqlDataReader myreader = sqlcmd.ExecuteReader();
                    using (myreader)
                    {
                        while (myreader.Read())
                        {
                            string result = myreader.GetString(1);
                            int result1 = myreader.GetInt16(2);
                            Program.tongSoCauThi = result1;
                            Program.soCauThi1= Convert.ToInt32(result1 * 0.7);
                            Program.soCauThi2 = result1 - Program.soCauThi1;
                            Program.trinhdo1 = result;
                            int result2 = myreader.GetInt16(3);
                            Program.thoiGian = result2;
                            if (Program.trinhdo1 == "A")
                            {
                                Program.trinhdo2 = "B";
                            }
                            else if (Program.trinhdo1 == "B")
                            {
                                Program.trinhdo2 = "C";
                            }
                            else
                            {
                                Program.trinhdo2 = "C";
                            }
      
                        }
                    }
                    exist = true;
                }
                catch (SqlException)
                {
                    exist = false;
                }
            }
            return exist;
        }

        private void btnTHI_Click(object sender, EventArgs e)
        {
        
          

                if (checkGVDK(lbMaLop.Text, cbMAMH.SelectedValue.ToString(), deNGAYTHI.Text, Convert.ToString(seLAN.Value)) == true)
            {
                if (SoLanThi(cbMAMH.SelectedValue.ToString(), Program.username) == 2)
                {
                    MessageBox.Show("Bạn đã thi hết 2 lần đăng kí", string.Empty, MessageBoxButtons.OK);
                    return;
                }
                else if (SoLanThi(cbMAMH.SelectedValue.ToString(), Program.username) == 0)
                {
                    IsMdiContainer = true;
                    Form frm = this.CheckExists(typeof(frmThi));
                    if (frm != null) frm.Activate();
                    else
                    {
                        IsMdiContainer = true;
                        frmThi f = new frmThi();
                        f.mamh = cbMAMH.SelectedValue.ToString();
                        f.masv = Program.username;
                        f.lan = Int32.Parse(seLAN.Value.ToString());
                        f.ngaythi = deNGAYTHI.DateTime.ToShortDateString();
                        f.Show();
                        this.Hide();
                        f.FormClosed += (o, w) => this.Show();

                    }
                }
                else
                {
                    seLAN.Text = "2";
                    MessageBox.Show("Bạn đã thi 1 lần!!!", string.Empty, MessageBoxButtons.OK);
                    if(checkGVDK(lbMaLop.Text, cbMAMH.SelectedValue.ToString(), deNGAYTHI.Text, Convert.ToString(seLAN.Value)) == true)
                    {
                        IsMdiContainer = true;
                        frmThi f = new frmThi();
                        f.mamh = cbMAMH.SelectedValue.ToString();
                        f.masv = Program.username;
                        f.lan = Int32.Parse(seLAN.Value.ToString());
                        f.ngaythi = deNGAYTHI.DateTime.ToShortDateString();
                        f.Show();
                        this.Hide();
                        f.FormClosed += (o, w) => this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa được đăng kí thi lần 2!!!", string.Empty, MessageBoxButtons.OK);
                        return;

                    }


                }

            }
            else
            {
                MessageBox.Show("Bạn chưa được đăng kí thi!!! Vui lòng kiểm tra lại", string.Empty, MessageBoxButtons.OK);
                return;
            }

        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void cbMAMH_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private int SoLanThi(string maMH, string masv)
        {
            using (var connection = new SqlConnection(Program.connstr))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT COUNT(*) from BANGDIEM where mamh=@mamh and masv=@masv", connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@mamh", maMH);
                    command.Parameters.AddWithValue("@masv", masv);

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

        private void seLAN_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
