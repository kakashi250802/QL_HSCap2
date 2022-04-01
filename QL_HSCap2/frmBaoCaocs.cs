using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_HSCap2
{
    public partial class frmBaoCaocs : Form
    {
        public frmBaoCaocs()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        public void ShowReport(string reportFileName, string search, string reportTitle)
        {
            ReportDocument rpt = new ReportDocument();
            string path = string.Format("{0}\\Report\\{1}", Application.StartupPath, reportFileName);
            rpt.Load(path);

            TableLogOnInfo logonInfo = new TableLogOnInfo();
            logonInfo.ConnectionInfo.ServerName = ".\\DESKTOP-6F537P9";
            logonInfo.ConnectionInfo.DatabaseName = "QL_DiemHSCap2";

            foreach (Table t in rpt.Database.Tables)
                t.ApplyLogOnInfo(logonInfo);
            if (!string.IsNullOrEmpty(search))
                rpt.RecordSelectionFormula = search;
            if (!string.IsNullOrEmpty(reportTitle))
                rpt.SummaryInfo.ReportTitle = reportTitle;

            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
