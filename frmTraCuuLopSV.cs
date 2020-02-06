using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDLPT
{
    public partial class frmTraCuuLopSV : Form
    {
        public frmTraCuuLopSV()
        {
            InitializeComponent();
        }


        private void frmTraCuuLopSV_Load(object sender, EventArgs e)
        {
            tN_CSDLPTDataSet.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.tN_CSDLPTDataSet.SINHVIEN);
            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.tN_CSDLPTDataSet.LOP);

        }

        private void lOPGridControl_Click(object sender, EventArgs e)
        {

        }
    }
}
