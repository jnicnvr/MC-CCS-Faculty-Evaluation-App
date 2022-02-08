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

namespace MC_Design.PanelForms
{
    public partial class panel_classes : Form
    {
        API api = new API();
        public panel_classes()
        {
            InitializeComponent();
            onLoadClasses();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            PanelForms.sub_panels.add_panel_classes add_classes = new PanelForms.sub_panels.add_panel_classes();
            add_classes.Show();
        }

        private async void onLoadClasses()
        { 
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Curriculum";
            dataGridView1.Columns[1].Name = "Year Level";
            dataGridView1.Columns[2].Name = "Section";
            dataGridView1.Columns[3].Name = "Created At";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                string param = "class_list";
                var res = await RESTHelper.GetAll(param);

                Console.WriteLine(res);
                var result = JArray.Parse(res);

                //MessageBox.Show(""+details1[0]["success"]);

                foreach (JObject data in result)
                {
                    string curriculum;
                    string year_level;
                    string section;
                    string created_at;

                    curriculum = data["curriculum"].ToString();
                    year_level = data["year_level"].ToString();
                    section = data["section"].ToString();
                    created_at = data["created_at"].ToString();

                    dataGridView1.Rows.Add(curriculum, year_level, section, created_at);

                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Request: 500 Internal Error: ", err);
                MessageBox.Show("Request: 500 Internal Error");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(tb_search.Text == "")
            {
                MessageBox.Show("Found No Result", "Information",
           MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                onSearchClass(tb_search.Text);
            }
        }

        public void onSearchClass(String value)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Cirriculum";
            dataGridView1.Columns[1].Name = "Year Level";
            dataGridView1.Columns[2].Name = "Section";       
            dataGridView1.Columns[3].Name = "Created At";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                String valueOf = HttpUtility.UrlEncode("" + value);

                String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/SearchAdminClassesList.php";
                String res = api.SendPost(req, String.Format("valueOf={0}", valueOf));

                var result = JArray.Parse(res);

                //MessageBox.Show(""+details1[0]["success"]);

                foreach (JObject data in result)
                {
                    string _class;
                    string curriculum;
                    string year_level;
                    string section;         
                    string created_at;

                    _class = data["_class"].ToString();
                    curriculum = data["curriculum"].ToString();
                    year_level = data["year_level"].ToString();
                    section = data["section"].ToString();
                    created_at = data["created_at"].ToString();

                    dataGridView1.Rows.Add(curriculum, year_level, section, created_at);

                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Request: 500 Internal Error: ", err);
                MessageBox.Show("Found No Result", "Information",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            onLoadClasses();
        }
    }
}
