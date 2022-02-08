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

namespace MC_Design.PanelForms.sub_panels
{
    public partial class show_evaluation_restriction : Form
    {
        API api = new API();
        public show_evaluation_restriction()
        {
            InitializeComponent();
            onLoadEvaluationRestriction();
        }
        private async void onLoadEvaluationRestriction()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "Faculty";
            dataGridView1.Columns[1].Name = "Department";
            dataGridView1.Columns[2].Name = "Class";
            dataGridView1.Columns[3].Name = "Subject Code";
            dataGridView1.Columns[4].Name = "Subject";
            dataGridView1.Columns[5].Name = "School Year";
            dataGridView1.Columns[6].Name = "Semester";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            try
            {
                string param = "evaluation_restriction";
                var res = await RESTHelper.GetAll(param);

                var response = JArray.Parse(res);

                foreach (JObject data in response)
                {
                    string faculty;
                    string Department;
                    string _class;
                    string code;
                    string subject;
                    string sy;
                    string semester;

                    faculty = data["name"].ToString();
                    Department = data["Department"].ToString();
                    _class = data["_class"].ToString();
                    code = data["code"].ToString();
                    subject = data["subject"].ToString();
                    sy = data["year"].ToString();
                    semester = data["semester"].ToString();

                    dataGridView1.Rows.Add(faculty, Department, _class, code, subject, sy, semester);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Request: 500 Internal Error: ", err);
                MessageBox.Show("Request: 500 Internal Error");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
