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

        private async void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to add new data?",
                     "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    string param = "teacher";
                    string TID = tb_id.Text; 
                    string Fname = tb_fname.Text;
                    string Mname = tb_mname.Text;
                    string Lname = tb_lname.Text;                                     
                    object mydata = new
                    {
                        TID = TID,
                        Fname = Fname,
                        Mname = Mname,
                        Lname = Lname                      
                     
                    };

                    var res = await RESTHelper.Post(param, mydata);                    
                    var details = JObject.Parse(res);
                     Console.WriteLine(res);
                    //  Console.WriteLine(details);
                    //MessageBox.Show("" + details["success"]);
                    //MessageBox.Show("Faculty Registered!");
                    onCheckValidation(tb_id.Text, tb_fname.Text, tb_lname.Text);

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

        public void onCheckValidation(String TID, String fname, String lname)
        {
            if (TID == "" || fname == "" ||  lname == "")
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
