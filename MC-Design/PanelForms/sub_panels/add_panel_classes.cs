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
    public partial class add_panel_classes : Form
    {
        public add_panel_classes()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to add new data?",
                      "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    API api = new API();
                    String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/InsertClasses.php";
                    String curriculum = HttpUtility.UrlEncode("" + tb_curriculum.Text.ToString());
                    String year_level = HttpUtility.UrlEncode("" + cmb_year_level.Text.ToString());
                    String section = HttpUtility.UrlEncode("" + cmb_section.Text.ToString());
                    String _class = curriculum + year_level + section+"";

                    String response = api.SendPost(req, String.Format("curriculum={0}&year_level={1}&section={2}&_class={3}", curriculum, year_level, section,_class));           
                      var data = JObject.Parse(response);
                      Console.WriteLine(data);                                          
                    onCheckValidation(tb_curriculum.Text, cmb_year_level.Text, cmb_section.Text, "Added New Class!");
                }
                catch (Exception err)
                {
                    Console.WriteLine("Request: 500 Internal Error: ", err);
                    MessageBox.Show("Request: 500 Internal Error");
                }
                //dataGridView1.Rows.Clear();
                //dataGridView1.Refresh();
              //  panel_classes pc = new panel_classes();
               // pc.dataGridView1.Rows.Clear();
              //  pc.dataGridView1.Refresh();
            }
            else if (dr == DialogResult.No)
            {

            }
            
        }
        public void onCheckValidation(String curriculum, String year_level, String section, String mname)
        {
            if (curriculum == "" || year_level == "" || section == "")
            {
                MessageBox.Show("Fill the Require fields!", "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Faculty Registered!", "Success",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
                onClearText();
            }
        }
        public void onClearText()
        {
            cmb_year_level.SelectedIndex = -1;
            cmb_section.SelectedIndex = -1;
        }
    }
}
