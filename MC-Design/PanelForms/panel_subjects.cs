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
    public partial class panel_subjects : Form
    {
        public panel_subjects()
        {
            InitializeComponent();
            onLoadSubjects();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelForms.sub_panels.add_panel_subject add_subject = new PanelForms.sub_panels.add_panel_subject();
            add_subject.Show();
        }

        public void onLoadSubjects()
        {
            API api = new API();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Subject Code";
            dataGridView1.Columns[1].Name = "Subject Name";
            dataGridView1.Columns[2].Name = "Subject Description";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/FetchSubjects.php";
                String res = api.SendPost(req, "");


                var result = JArray.Parse(res);

                //MessageBox.Show(""+details1[0]["success"]);

                foreach (JObject data in result)
                {
                    string code;
                    string subject;
                    string description;

                    code = data["code"].ToString();
                    subject = data["subject"].ToString();
                    description = data["description"].ToString();

                    dataGridView1.Rows.Add(code, subject, description);

                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Request: 500 Internal Error: ", err);
                MessageBox.Show("Request: 500 Internal Error");
            }

        }

        private void panel_subjects_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            onLoadSubjects();
        }
    }
}
