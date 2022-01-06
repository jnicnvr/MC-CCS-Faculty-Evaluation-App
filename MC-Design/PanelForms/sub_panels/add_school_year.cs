using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace MC_Design.PanelForms.sub_panels
{
    public partial class add_school_year : Form
    {
        public add_school_year()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to add new data?",
                     "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                API api = new API();
                try
                {
                    //add validation
                    String year = HttpUtility.UrlEncode("" + tb_year.Text.ToString());
                    String semester = HttpUtility.UrlEncode("" + cmb_semester.Text.ToString());
                    String result = api.SendPost("http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/InsertSchoolYear.php", String.Format("year={0}&semester={1}", year, semester));
                    Console.WriteLine(result);
                    //var details = JObject.Parse(result);
                    //Console.WriteLine(details);

                    //MessageBox.Show("" + details["success"]);
                    //MessageBox.Show("Added New Academic Year!");

                    onCheckValidation(tb_year.Text, cmb_semester.Text, "Added New Academic Year!");
                }
                catch (Exception err)
                {
                    MessageBox.Show("500 Internal Error" + err);
                    MessageBox.Show("500 Internal Error");
                }
            }
            else if (dr == DialogResult.No) { }
        }
        public void onCheckValidation(String year, String semester, String message)
        {
            if (year == "" || semester == "")
            {
                MessageBox.Show("Fill the Require fields!", "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(message, "Success",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
                onClearText();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void onClearText()
        {
            tb_year.Text = "";
            cmb_semester.SelectedIndex = -1;
        }
    }
}
