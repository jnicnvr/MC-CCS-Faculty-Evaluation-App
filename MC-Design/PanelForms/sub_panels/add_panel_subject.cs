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
    public partial class add_panel_subject : Form
    {
        public add_panel_subject()
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
                    //add validation
                    panel_subjects panel = new panel_subjects();
                    // API api = new API();
                    //String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/InsertSubject.php";
                    //String code = HttpUtility.UrlEncode("" + tb_code.Text.ToString());
                    //String subject = HttpUtility.UrlEncode("" + tb_subject.Text.ToString());
                    //String description = HttpUtility.UrlEncode("" + tb_description.Text.ToString());

                    //String response = api.SendPost(req, String.Format("code={0}&subject={1}&description={2}", code, subject, description));
                    string param = "subject";
                    string code = tb_code.Text;
                    string subject = tb_subject.Text;
                    string description = tb_description.Text;
                    object mydata = new
                    {
                        code = code,
                        subject = subject,
                        description = description                       
                    };
                    var res = await RESTHelper.Post(param, mydata);

                    var data = JObject.Parse(res);
                    Console.WriteLine(data);
                    isValidated(tb_code.Text, tb_subject.Text, tb_description.Text, "Added New Subject!");
                                      
                 
                }
                catch (Exception err)
                {
                    Console.WriteLine("Request: 500 Internal Error: ", err);
                    MessageBox.Show("Request: 500 Internal Error");
                }
             

            }
            else if (dr == DialogResult.No) {}          
        }
        public void isValidated(String code, String subject, String description, String message)
        {
            if (code == "" || subject == "" || description == "")
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
        public void onClearText()
        {
            tb_code.Text = "";
            tb_subject.Text = "";
            tb_description.Text = "";            
        }
    }
}
