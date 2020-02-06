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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnKhoaGV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IsMdiContainer = true;
            Form frm = this.CheckExists(typeof( frmKHGV));
            if (frm != null) frm.Activate();
            else
            {
                frmKHGV f = new frmKHGV();
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IsMdiContainer = true;
            Form frm = this.CheckExists(typeof(frmLOPSV));
            if (frm != null) frm.Activate();
            else
            {
                frmLOPSV f = new frmLOPSV();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IsMdiContainer = true;
            Form frm = this.CheckExists(typeof(frmTaoLogin));
            if (frm != null) frm.Activate();
            else
            {
                frmTaoLogin f = new frmTaoLogin();
                f.MdiParent = this;
                f.Show();
            }
        }

       
    }
}
