using DevExpress.XtraReports.UI;
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
    public partial class frmMainGV : Form
    {
        public frmMainGV()
        {
            InitializeComponent();
        }

        private void btnBODE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IsMdiContainer = true;
            Form frm = this.CheckExists(typeof(frmBODE));
            if (frm != null)  frm.Activate();
            else
            {
                frmBODE f = new frmBODE();
                f.MdiParent = this;
                f.Show();
            }

        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void btnDKTHI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IsMdiContainer = true;
            Form frm = this.CheckExists(typeof(frmDKTHI));
            if (frm != null) frm.Activate();
            else
            {
                frmDKTHI f = new frmDKTHI();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            IsMdiContainer = true;
            Form frm = this.CheckExists(typeof(frmNhapThongTinBaoCao));
            if (frm != null) frm.Activate();
            else
            {
                frmNhapThongTinBaoCao f = new frmNhapThongTinBaoCao();
                f.MdiParent = this;
                f.Show();
            }
        }

   
    }
}
