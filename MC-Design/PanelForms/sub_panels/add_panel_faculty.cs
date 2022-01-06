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
    public partial class add_panel_faculty : Form
    {
        public add_panel_faculty()
        {
            InitializeComponent();
        }      

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to add new data?",
                     "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    //add validation
                    API api = new API();
                    String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/InsertNewFaculty.php";

                    String TID = HttpUtility.UrlEncode("" + tb_id.Text.ToString());
                    String Fname = HttpUtility.UrlEncode("" + tb_fname.Text.ToString());
                    String Mname = HttpUtility.UrlEncode("" + tb_mname.Text.ToString());
                    String Lname = HttpUtility.UrlEncode("" + tb_lname.Text.ToString());
                    String name = HttpUtility.UrlEncode(tb_fname.Text.ToString() + " " + tb_mname.Text.ToString() + " " + tb_lname.Text.ToString());

                     String result = api.SendPost(req, String.Format("TID={0}&Fname={1}&Mname={2}&Lname={3}&name={4}", TID, Fname, Mname, Lname, name));
                     var details = JObject.Parse(result);
                      Console.WriteLine(result);
                    //  Console.WriteLine(details);
                    //MessageBox.Show("" + details["success"]);
                    //MessageBox.Show("Faculty Registered!");
                    onCheckValidation(tb_id.Text, tb_fname.Text, tb_lname.Text, tb_mname.Text);

                    //onTerminateRegister();

                }
                catch (Exception err)
                {
                    Console.WriteLine("MC CS ERROR: ", err);
                    MessageBox.Show("500 Internal Error");
                }
            }
            else if (dr == DialogResult.No)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void onClearText()
        {
            tb_id.Text = "";
            tb_fname.Text = "";
            tb_mname.Text = "";
            tb_lname.Text = "";
        }

        public void onCheckValidation(String TID, String fname, String lname, String mname)
        {
            if (TID == "" || fname == "" || mname == "" || lname == "")
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
    }
}
