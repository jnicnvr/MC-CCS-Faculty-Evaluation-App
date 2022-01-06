﻿
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
    public partial class Login : Form
    {
        API api = new API();
        public Login()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //this.Dispose();
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {                     
            string username = tb_username.Text.ToString();
            string password = tb_password.Text.ToString();
            String username1 = HttpUtility.UrlEncode(""+username);
            String password1 = HttpUtility.UrlEncode(""+password);
            //MessageBox.Show("This", username1 + password1);
            try
            {              
                String result = api.SendPost("http://fundamental-winches.000webhostapp.com/MCFE/userslogin1.php", String.Format("username={0}&password={1}", username1, password1));
                // var details1 = JArray.Parse(result);
               // MessageBox.Show(result);
                var details = JObject.Parse(result);
               // MessageBox.Show("" + details);
                string l = details["success"].ToString();

                MessageBox.Show(l);
                if (l == "True")
                {
                    MessageBox.Show("Successfully Login");
                    tb_username.Text = "";
                    tb_password.Text = "";

                    Program.globalString = username;
                    api.onAddLogs(username, "Login", "admin");
                    Form1 home = new Form1();
                    home.Show();
                    onTerminateForm();
                }
                else
                {
                    MessageBox.Show("404 not found!");
                    tb_username.Text = "";
                    tb_password.Text = "";
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("Request: 500 Internal Error: ", err);
                MessageBox.Show("Request: 500 Internal Error");
            }        

        }
       
        private void onTerminateForm()
        {
            Login login = new Login();
            this.Visible = false;
            login.Dispose();
        }
     
        private void label5_Click(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Show();
            onTerminateForm();
        }
    }

}