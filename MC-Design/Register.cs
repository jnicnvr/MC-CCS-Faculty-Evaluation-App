using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace MC_Design
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            Environment.Exit(0);
        }

        private void onClearText()
        {
            string clearedtext = "";
            tb_id.Text = clearedtext;
            tb_firstname.Text = clearedtext;
            tb_lastname.Text = clearedtext;
            tb_position.Text = clearedtext;
            tb_username.Text = clearedtext;
            tb_password.Text = clearedtext;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            API api = new API();
            try
            {
                //add validation
                String TID = HttpUtility.UrlEncode("" + tb_id.Text.ToString());
                String Fname = HttpUtility.UrlEncode("" + tb_firstname.Text.ToString());
                String Lname = HttpUtility.UrlEncode("" + tb_lastname.Text.ToString());
                String Position = HttpUtility.UrlEncode("" + tb_position.Text.ToString());
                String username = HttpUtility.UrlEncode("" + tb_username.Text.ToString());
                String password = HttpUtility.UrlEncode("" + tb_password.Text.ToString());
                
                String result = api.SendPost("http://fundamental-winches.000webhostapp.com/MCFE/FacultyRegister1.php", String.Format("TID={0}&Fname={1}&Lname={2}&username={3}&password={4}&position={5}", TID, Fname, Lname, username, password, Position));
                var details = JObject.Parse(result);

                MessageBox.Show("" + details["success"]);
                MessageBox.Show("Welcome to Faculty Evaluation System");
                onClearText();
                Form1 home = new Form1();
                home.Show();
                onTerminateRegister();

            }
            catch(Exception err)
            {
                Console.WriteLine("Request: 500 Internal Error: ", err);
                MessageBox.Show("Request: 500 Internal Error");
            }           
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            //dispose register
            onTerminateRegister();

        }
        private void onTerminateRegister()
        {
            Register r = new Register();
            this.Visible = false;
            r.Dispose();
        }
    }
}
