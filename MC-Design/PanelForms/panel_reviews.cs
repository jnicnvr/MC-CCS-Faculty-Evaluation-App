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
    public partial class panel_reviews : Form
    {
        //API api = new API();
        public panel_reviews()
        {
            InitializeComponent();
            onLoadReviews();
        }

        private async void onLoadReviews()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Rating";
            dataGridView1.Columns[1].Name = "Comment";
            dataGridView1.Columns[2].Name = "Created At";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            try
            {
                //String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/FetchAdminFeedback.php";
                //String res = api.SendPost(req, "");

                string param = "feedback";
                var res = await RESTHelper.GetAll(param);
                Console.WriteLine("feedback get all");
                Console.WriteLine(res);
                var response = JArray.Parse(res);
            
                foreach (JObject data in response)
                {
                    string type;
                    string feedback;                
                    string created_at;

                    type = data["type"].ToString();
                    feedback = data["feedback"].ToString();
                    created_at = data["created_at"].ToString();                    

                    dataGridView1.Rows.Add(type, feedback, created_at);

                }
                // }
            }
            catch (Exception err)
            {
                Console.WriteLine("Request: 500 Internal Error: ", err);
                // MessageBox.Show("Request: 500 Internal Error");
                MessageBox.Show("Found no Result");
            }
        }

        private async void onSearchReviews(String rating)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Rating";
            dataGridView1.Columns[1].Name = "Comment";
            dataGridView1.Columns[2].Name = "Created At";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            try
            {
                //String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/SearchAdminFeedback.php";
                //String res = api.SendPost(req, String.Format("rating={0}",rating));

                string param = "feedback";
                var res = await RESTHelper.Get(param, rating);
                Console.WriteLine("feedback get ");
                Console.WriteLine(res);

                var response = JArray.Parse(res);
                Console.WriteLine(response);

                foreach (JObject data in response)
                {
                    Console.WriteLine("get");

                    Console.WriteLine(data);
                    string type;
                    string feedback;
                    string created_at;

                    type = data["type"].ToString();
                    feedback = data["feedback"].ToString();
                    created_at = data["created_at"].ToString();

                    dataGridView1.Rows.Add(type, feedback, created_at);

                }
                // }
            }
            catch (Exception err)
            {
                Console.WriteLine("Request: 500 Internal Error: ", err);
                // MessageBox.Show("Request: 500 Internal Error");
                MessageBox.Show("Found no Result");
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //All
            onLoadReviews();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //GREAT
            onSearchReviews("GREAT");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //GOOD
            onSearchReviews("GOOD");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //OKAY
            onSearchReviews("OKAY");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //BAD
            onSearchReviews("BAD");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //TERRIBLE
            onSearchReviews("TERRIBLE");
        }
    }
}
