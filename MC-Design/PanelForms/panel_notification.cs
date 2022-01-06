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
    public partial class panel_notification : Form
    {
        API api = new API();
        public panel_notification()
        {
            InitializeComponent();
            onLoadLogs();
        }
        private void onLoadLogs()
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "User";
            dataGridView1.Columns[1].Name = "Activity";
            dataGridView1.Columns[2].Name = "User Level";
            dataGridView1.Columns[3].Name = "Created At";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            try
            {
                String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/FetchAdminLogs.php";
                String res = api.SendPost(req, "");

                var response = JArray.Parse(res);

                foreach (JObject data in response)
                {
                    string user;
                    string activity;
                    string user_level;
                    string created_at;

                    user = data["name"].ToString();
                    activity = data["activity"].ToString();
                    user_level = data["user_level"].ToString();
                    created_at = data["created_at"].ToString();

                    dataGridView1.Rows.Add(user, activity, user_level, created_at);

                }

            }
            catch (Exception err)
            {
                Console.WriteLine("Request: 500 Internal Error: ", err);
                MessageBox.Show("Request: 500 Internal Error");
            }
        }

        private void onLoadNofication()
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "SID";
            dataGridView1.Columns[1].Name = "Student";
            dataGridView1.Columns[2].Name = "Class";
            dataGridView1.Columns[3].Name = "Subject Code";
            dataGridView1.Columns[4].Name = "Subject";
            dataGridView1.Columns[5].Name = "Faculty";
            dataGridView1.Columns[6].Name = "Department";
            dataGridView1.Columns[7].Name = "Created At";
            dataGridView1.Columns[8].Name = "Remarks";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            try
            {
                String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/FetchAdminNotification.php";
                String res = api.SendPost(req, "");

              //  MessageBox.Show("RESdata", res);
                var response = JArray.Parse(res);
               
                //if(response == null || response.ToString() == "")
                //{
                //    MessageBox.Show("Found no data");
                //    MessageBox.Show("Response", response.ToString());
                //}
                //else
                //{
                    foreach (JObject data in response)
                    {
                        string SID;
                        string student_name;
                        string course;
                        string code;
                        string subject;
                        string name;
                        string department;
                        string created_at;
                        string evaluated;

                        SID = data["SID"].ToString();
                        student_name = data["student_name"].ToString();
                        course = data["course"].ToString();
                        code = data["code"].ToString();
                        subject = data["subject"].ToString();
                        name = data["name"].ToString();
                        department = data["department"].ToString();
                        created_at = data["created_at"].ToString();
                        evaluated = data["evaluated"].ToString();

                        dataGridView1.Rows.Add(SID, student_name, course, code, subject, name, department, created_at, evaluated);

                    }
               // }

            }
            catch (Exception err)
            {
                Console.WriteLine("Request: 500 Internal Error: ", err);
                // MessageBox.Show("Request: 500 Internal Error");
                MessageBox.Show("Notification is Empty");
            }
        }


         public void onLoadNotEvaluated()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "Student ID";
            dataGridView1.Columns[1].Name = "Student Name";
            dataGridView1.Columns[2].Name = "Age";
            dataGridView1.Columns[3].Name = "Sex";
            dataGridView1.Columns[4].Name = "Course";
            dataGridView1.Columns[5].Name = "Username";
            dataGridView1.Columns[6].Name = "Password";
            dataGridView1.Columns[7].Name = "Created At";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/FetchAdminStudentsNotEvaluated.php";
                String res = api.SendPost(req, "");


                var result = JArray.Parse(res);

                //MessageBox.Show(""+details1[0]["success"]);

                foreach (JObject data in result)
                {
                    string SID;
                    string student_name;
                    string Age;
                    string Sex;
                    string _class;
                    string username;
                    string password;
                    string created_at;

                    SID = data["SID"].ToString();
                    student_name = data["student_name"].ToString();
                    Age = data["Age"].ToString();
                    Sex = data["Sex"].ToString();
                    _class = data["_class"].ToString();
                    username = data["username"].ToString();
                    password = data["password"].ToString();
                    created_at = data["created_at"].ToString();

                    dataGridView1.Rows.Add(SID, student_name, Age, Sex, _class, username, password, created_at);

                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Request: 500 Internal Error: ", err);
                MessageBox.Show("Found No Student", "Information",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void label2_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            onLoadNofication();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            onLoadLogs();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Reviews
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            onLoadNotEvaluated();
        }
    }
}
