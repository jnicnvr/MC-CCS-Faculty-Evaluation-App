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

        private async void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to add new data?",
                      "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    const string param = "class_list";
                    string curriculum = tb_curriculum.Text;
                    string year_level = cmb_year_level.Text;
                    string section = cmb_section.Text;
                    string _class = curriculum + year_level + section;
                    object mydata = new
                    {
                        curriculum = curriculum,
                        year_level = year_level,
                        section = section,
                        _class = _class

                    };
                    var res = await RESTHelper.Post(param, mydata);
                  
                    var data = JObject.Parse(res);
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
