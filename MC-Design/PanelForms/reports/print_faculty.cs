using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC_Design.PanelForms.reports
{
    public partial class print_faculty : Form
    {
        public ReportDocument Report = new ReportDocument();
        public print_faculty()
        {
            InitializeComponent();
        }

        private void crystalOpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void print_faculty_Load(object sender, EventArgs e)
        {
            if (Report != null)
            {
                Report.Close();
                Report.Dispose();
            }
            print_faculties.ReportSource = Report;
        }
    }
}
