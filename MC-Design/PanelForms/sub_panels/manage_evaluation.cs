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
    public partial class manage_evaluation : Form
    {
        //public string fid;
        //public string class_id;
        //public string subject_id;
        public manage_evaluation()
        {
            InitializeComponent();
            onLoadCriteriaFaculty();
            onLoadCriteriaClasses();
            onLoadCriteriaSubject();
            onLoadCriteriaSy();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to add new data?",
                     "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    //add validation
                    API api = new API();
                    String URL = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/InsertRestrictions.php";

                    String faculty = HttpUtility.UrlEncode("" + cmb_faculty.Text.ToString());
                    String _classes = HttpUtility.UrlEncode("" + cmb_classes.Text.ToString());
                    String subject = HttpUtility.UrlEncode("" + cmb_subject.Text.ToString());
                    String sy = HttpUtility.UrlEncode("" + cmb_sy.Text.ToString());
                    String semester = HttpUtility.UrlEncode("" + cmb_semester.Text.ToString());

                    String response = api.SendPost(URL, String.Format("faculty={0}&_classes={1}&subject={2}&sy={3}&semester={4}", faculty, _classes, subject, sy, semester));
                    Console.WriteLine(response);
                    var data = JObject.Parse(response);
                    Console.WriteLine(data);

                    onCheckValidation(cmb_faculty.Text, cmb_classes.Text, cmb_subject.Text, cmb_sy.Text, cmb_semester.Text, "Added New Restrictions!");
                }
                catch (Exception err)
                {
                    Console.WriteLine("500 Internal Error" + err);
                    MessageBox.Show("500 Internal Error");
                }
            }
            else if (dr == DialogResult.No) { }
        }
        public void onCheckValidation(String faculty, String _class, String subject, String sy, String semester, String message)
        {
            if (faculty == "" || _class == "" || subject == "" || sy == "" || semester == "")
            {
                MessageBox.Show("Fill the Require fields!", "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(message, "Success",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
                onClearText();
            }
        }
        public void onClearText()
        {          
            cmb_classes.SelectedIndex = -1;
            cmb_faculty.SelectedIndex = -1;
            cmb_semester.SelectedIndex = -1;
            cmb_subject.SelectedIndex = -1;
            cmb_sy.SelectedIndex = -1;
        }
        private void onLoadCriteriaFaculty()
        {
            try
            {
                API api = new API();
                String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/FetchRestrictionsDataFaculty.php";
                String response = api.SendPost(req, "");

                var data = JArray.Parse(response);            
                Console.WriteLine(data);
                
                foreach (JObject result in data)
                {
                    string name;
                    name = result["name"].ToString();
                    //fid = result["TID"].ToString();
                    cmb_faculty.Items.Add(name);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                MessageBox.Show("500 Internal Error");
            }
        }
        private void onLoadCriteriaClasses()
        {
            try
            {
                API api = new API();
                String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/FetchRestrictionsDataClasses.php";
                String response = api.SendPost(req, "");

                var data = JArray.Parse(response);
                Console.WriteLine(data);

                foreach (JObject result in data)
                {
                    string _classes;
                    _classes = result["_classes"].ToString();
                    cmb_classes.Items.Add(_classes);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                MessageBox.Show("500 Internal Error");
            }
        }
        private void onLoadCriteriaSubject()
        {
            try
            {
                API api = new API();
                String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/FetchRestrictionsDataSubject.php";
                String response = api.SendPost(req, "");

                var data = JArray.Parse(response);
                Console.WriteLine(data);

                foreach (JObject result in data)
                {
                    string code;
                    code = result["code"].ToString();
                    //subject_id = result["id"].ToString();
                    cmb_subject.Items.Add(code);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                MessageBox.Show("500 Internal Error");
            }
        }

        private void onLoadCriteriaSy()
        {
            try
            {
                API api = new API();
                String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/FetchRestrictionsDataSy.php";
                String response = api.SendPost(req, "");

                var data = JArray.Parse(response);
                Console.WriteLine(data);

                foreach (JObject result in data)
                {
                    string sy;
                    string semester;
                    sy = result["year"].ToString();
                    semester = result["semester"].ToString();
                    cmb_sy.Items.Add(sy);
                    cmb_semester.Items.Add(semester);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                MessageBox.Show("500 Internal Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sub_panels.show_evaluation_restriction show_er = new sub_panels.show_evaluation_restriction();
            show_er.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
