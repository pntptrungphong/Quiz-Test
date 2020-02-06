using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace CSDLPT
{
    public partial class frmNhapThongTinBaoCao : Form
    {

        public frmNhapThongTinBaoCao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XtraReport1 report = new XtraReport1(dateEdit1.Text, dateEdit2.Text);
            ReportPrintTool print = new ReportPrintTool(report);
            print.ShowPreviewDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
