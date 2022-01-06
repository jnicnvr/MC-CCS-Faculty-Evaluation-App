using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC_Design.PanelForms
{
    public partial class panel_home : Form
    {
        API api = new API();
        public panel_home()
        {
           
            InitializeComponent();
            onLoadDashboard();
        }
           
        private void onLoadDashboard()
        {
            string student_count;
            string evaluated;
            string not_yet_evaluated;
            try
            {              
                String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/FetchAdminDashboard.php";
                String response = api.SendPost(req, "");

                var result = JArray.Parse(response);
                Console.WriteLine(result);
            //    MessageBox.Show(" data ", result.ToString());


                foreach (JObject data in result)
                {
                    student_count = data["students"].ToString();
                    evaluated = data["evaluated"].ToString();
                    not_yet_evaluated = data["total"].ToString();
                    lb_evaluated.Text = evaluated;
                    lb_total_student.Text = student_count;

                    if (Int32.Parse(not_yet_evaluated) <= 0)
                    {
                        not_yet_evaluated = "0";
                        lb_not_evaluted_yet.Text = not_yet_evaluated;
                    }
                    else
                    {
                        lb_not_evaluted_yet.Text = not_yet_evaluated;
                    }                    
                   // MessageBox.Show(" data ", student_count + "" + evaluated + "" + not_yet_evaluated);
                }

               
            }
            catch (Exception err)
            {
                Console.WriteLine("500 Internal Error",err);
                // MessageBox.Show("500 Internal Error");
                MessageBox.Show("Found No Result", "Information",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }        
        }
        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
