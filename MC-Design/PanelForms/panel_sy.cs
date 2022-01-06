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
    public partial class panel_sy : Form
    {
        public panel_sy()
        {
            InitializeComponent();
            onLoadSy();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PanelForms.sub_panels.add_school_year add_sy = new PanelForms.sub_panels.add_school_year();
            add_sy.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PanelForms.sub_panels.manage_sy manage_sy = new PanelForms.sub_panels.manage_sy();
            manage_sy.Show();
        }

        private void onLoadSy()
        {
            API api = new API();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "School Year";
            dataGridView1.Columns[1].Name = "Semester";
            dataGridView1.Columns[2].Name = "Status";
            dataGridView1.Columns[3].Name = "System Default";
            dataGridView1.Columns[4].Name = "Created At";
            dataGridView1.Columns[5].Name = "Updated At";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            try
            {
                String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/FetchSy.php";
                String res = api.SendPost(req, "");


                var details1 = JArray.Parse(res);

                //MessageBox.Show(""+details1[0]["success"]);

                foreach (JObject data in details1)
                {
                    string year;
                    string semester;
                    string status;
                    string isActive;
                    string created_at;
                    string updated_at;

                    year = data["year"].ToString();
                    semester = data["semester"].ToString();
                    status = data["status"].ToString();
                    isActive = data["isActive"].ToString();
                    created_at = data["created_at"].ToString();
                    updated_at = data["updated_at"].ToString();

                    dataGridView1.Rows.Add(year, semester, status, isActive, created_at, updated_at);

                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Request: 500 Internal Error: ", err);
                MessageBox.Show("Request: 500 Internal Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            onLoadSy();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
