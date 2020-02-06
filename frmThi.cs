using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace CSDLPT
{
    public partial class frmThi : Form
    {
        public List<String> cauhoi = new List<String>();
        public List<String> dapan = new List<String>();
        private int vitri;
        private int a, b, c;
        public int lan;
        public string mamh,masv,ngaythi;
        public int socauthi, thoigian;
        BindingSource source = new BindingSource();

        public frmThi()
        {
            InitializeComponent();
        }



        private void frmThi_Load(object sender, EventArgs e)
        {
            

            dataSet.EnforceConstraints = false;
            this.TABD.Connection.ConnectionString = Program.connstr;
            this.TABD.Fill(this.dataSet.BODE);
            label3.Text = Program.thoiGian.ToString();
            getBoDe(Program.trinhdo1, Program.trinhdo2, mamh, Program.soCauThi1, Program.soCauThi2);


        }


        private void getBoDe(string trinhdo1, string trinhdo2, string mamh,int cauhoi1,int cauhoi2)
        {
            timer1.Start();

            string strLenh = string.Format("EXEC sp_timcauhoi '{0}','{1}','{2}',{3},{4}", trinhdo1, trinhdo2, mamh,cauhoi1,cauhoi2);
            source.DataSource = Program.ExecSqlDataTable(strLenh);
            vitri = source.Position;
            
            string result = ((DataRowView)source[vitri])["nd"].ToString();
            lbND.Text = result;
            string result1 = ((DataRowView)source[vitri])["a"].ToString();
            radioA.Text = result1;
            string result2 = ((DataRowView)source[vitri])["b"].ToString();
            radioB.Text = result2;
            string result3 = ((DataRowView)source[vitri])["c"].ToString();
            radioC.Text = result3;
            string result4 = ((DataRowView)source[vitri])["d"].ToString();
            radioD.Text = result4;
            if(Convert.ToInt32(source.Count.ToString())==Program.tongSoCauThi)
            {
                for (int i = 0; i < Program.tongSoCauThi; i++)
                {
                    string result5 = ((DataRowView)source[i])["DAP_AN"].ToString();
                    cauhoi.Add("");
                    dapan.Add(result5);
                }
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Câu hỏi của chương trình này trong bộ đề không đủ, vui lòng liên hệ giáo viện kiểm tra lại!!", "Lỗi thiếu câu hỏi", MessageBoxButtons.OK);
                this.Close();
            }



        }

        private void btnCAUSAU_Click(object sender, EventArgs e)
        {
            if (radioA.Checked == true)
            {
                cauhoi[vitri] = "A";

            }
            else if (radioB.Checked == true)
            {
                cauhoi[vitri] = "B";
            }
            else if (radioC.Checked == true)
            {
                cauhoi[vitri] = "C";
            }
            else if (radioD.Checked == true)
            {
                cauhoi[vitri] = "D";
            }
            else
            {
                cauhoi[vitri] = "";
            }
            source.MoveNext();
            vitri = source.Position;
            string result = ((DataRowView)source[vitri])["nd"].ToString();
            lbND.Text = result;
            string result1 = ((DataRowView)source[vitri])["a"].ToString();
            radioA.Text = result1;
            string result2 = ((DataRowView)source[vitri])["b"].ToString();
            radioB.Text = result2;
            string result3 = ((DataRowView)source[vitri])["c"].ToString();
            radioC.Text = result3;
            string result4 = ((DataRowView)source[vitri])["d"].ToString();
            radioD.Text = result4;
            string result5 = ((DataRowView)source[vitri])["DAP_AN"].ToString();
            String result6 = cauhoi[vitri];
            if (result6.Equals("A"))
            {
                radioA.Checked = true;
            }
            else if (result6.Equals("B"))
            {
                radioB.Checked = true;
            }
            else if (result6.Equals("C"))
            {
                radioC.Checked = true;
            }
            else if (result6.Equals("D"))
            {
                radioD.Checked = true;
            }
            else
            {
                //cauhoi.Add("");
                radioA.Checked = radioB.Checked = radioC.Checked = radioD.Checked = false;
            }
        }

        private void btnCAUTRUOC_Click(object sender, EventArgs e)
        {
            if (radioA.Checked == true)
            {
                cauhoi[vitri] = "A";
            }
            else if (radioB.Checked == true)
            {
                cauhoi[vitri] = "B";
            }
            else if (radioC.Checked == true)
            {
                cauhoi[vitri] = "C";
            }
            else if (radioD.Checked == true)
            {
                cauhoi[vitri] = "D";
            }
            else
            {
                cauhoi[vitri] = "";
            }
            source.MovePrevious();
            vitri = source.Position;
            string result = ((DataRowView)source[vitri])["nd"].ToString();
            lbND.Text = result;
            string result1 = ((DataRowView)source[vitri])["a"].ToString();
            radioA.Text = result1;
            string result2 = ((DataRowView)source[vitri])["b"].ToString();
            radioB.Text = result2;
            string result3 = ((DataRowView)source[vitri])["c"].ToString();
            radioC.Text = result3;
            string result4 = ((DataRowView)source[vitri])["d"].ToString();
            radioD.Text = result4;
            String result6 = cauhoi[vitri];

            if (result6.Equals("A"))
            {
                radioA.Checked = true;
            }
            else if (result6.Equals("B"))
            {
                radioB.Checked = true;
            }
            else if (result6.Equals("C"))
            {
                radioC.Checked = true;
            }
            else if (result6.Equals("D"))
            {
                radioD.Checked = true;
            }
            else
            {
                //cauhoi.Add("");
                radioA.Checked = radioB.Checked = radioC.Checked = radioD.Checked = false;
            }

        }

    

        private void luuDiem(string masv,string mamh,int lan,string ngaythi,float diem)
        {
            string cmd = string.Format("EXEC sp_luudiem N'{0}',N'{1}',{2},N'{3}',{4}", mamh, masv, lan, ngaythi, diem);
            SqlDataReader reader = Program.ExecSqlDataReader(cmd);
            Program.conn.Close();

        }

        private void gbCauHoi_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tinhDiem();
            timer1.Stop();
            this.Close();

        }
        private void tinhDiem()
        {
            float diem = 0;
            for (int i = 0; i < Program.tongSoCauThi; i++)
            {
                if (cauhoi[i] == dapan[i])
                {
                    diem = diem + Convert.ToSingle((double)10 / (double)Program.tongSoCauThi);
                }
            }
            MessageBox.Show("Điểm số thi của bạn là: "+diem.ToString(), string.Empty, MessageBoxButtons.OK);

            luuDiem(masv, mamh, lan, ngaythi, diem);


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            a = int.Parse(label2.Text); //miligiay
            b = int.Parse(label1.Text); //giay
            c = int.Parse(label3.Text); //phut
            a--;
            if (a < 0)
            {
                a = 60;
                b--;
                if (b < 0)
                {
                    b = 59;
                    c--;
                }
            }
            if (a < 10)
            {
                label2.Text = "0" + a;
            }
            else
                label2.Text = a + "";
            if (b < 10)
            {
                label1.Text = "0" + b;
            }
            else
                label1.Text = b + "";
            if (c < 10)
            {
                label3.Text = "0" + c;
            }
            else
                label3.Text = c + "";

            if (a == 0 && b == 0 && c == 0)
            {
                timer1.Stop();
                //SoundPlayer sound = new SoundPlayer(@".\reng.wav");
                //sound.Play(); // can also use soundPlayer.PlaySync()
                MessageBox.Show("Hết giờ");
                tinhDiem();
                this.Close();
                
            }
        }
    }
}
