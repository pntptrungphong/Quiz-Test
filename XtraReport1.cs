using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CSDLPT
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1(string TUNGAY, string DENNGAY)
        {
            InitializeComponent();
            tN_CSDLPTDataSet1.EnforceConstraints = false;
            this.sP_DANHSACHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_DANHSACHTableAdapter.Fill(tN_CSDLPTDataSet1.SP_DANHSACH, TUNGAY, DENNGAY);
            lbNgay1.Text = TUNGAY;
            lbNgay2.Text = DENNGAY;
            if(Program.servername== "DESKTOP-FC1GMR5\\PHONGPHAM1")
            {
                lbCOSO.Text = "CƠ SỞ 1";
            }
            if (Program.servername == "DESKTOP-FC1GMR5\\PHONGPHAM2")
            {
                lbCOSO.Text = "CƠ SỞ 2";
            }
        }

    }
}
