
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
        //API api = new API();
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

        private async void button1_Click(object sender, EventArgs e)
        {                     
            //string username = tb_username.Text.ToString();
            //string password = tb_password.Text.ToString();
            //String username1 = HttpUtility.UrlEncode(""+username);
            //String password1 = HttpUtility.UrlEncode(""+password);
            //MessageBox.Show("This", username1 + password1);
            try
            {
                //String result = api.SendPost("http://fundamental-winches.000webhostapp.com/MCFE/userslogin1.php", String.Format("username={0}&password={1}", username1, password1));
                string param = "auth/login_admin";
                string username = tb_username.Text;
                string password = tb_password.Text;
              
                object mydata = new
                {
                    username = username,
                    password = password               
                };
                var res = await RESTHelper.Post(param, mydata);
               

                // var details1 = JArray.Parse(result);
                // MessageBox.Show(result);

                var details = JObject.Parse(res);
               // MessageBox.Show("" + details);
                string l = details["success"].ToString();

                MessageBox.Show(l);
                if (l == "true" || l == "True")
                {
                    MessageBox.Show("Successfully Login");
                    tb_username.Text = "";
                    tb_password.Text = "";

                    Program.globalString = username;
                    onAddLogs(username, "Login", "admin");
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
       
        private async void onAddLogs(string name, string activity, string user_level)
        {
            string param = "admin_logs";          
            object mydata = new
            {
                name = name,
                activity = activity,
                user_level = user_level
            };
            var res = await RESTHelper.Post(param, mydata);
            var details = JObject.Parse(res);

            Console.WriteLine("Logs",details);

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
