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
    public partial class panel_evaluation : Form
    {
        API api = new API();
        public panel_evaluation()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView1.ColumnCount = 16;
                dataGridView1.Columns[0].Name = "Description";
                dataGridView1.Columns[1].Name = "Faculty";
                dataGridView1.Columns[2].Name = "Class";
                dataGridView1.Columns[3].Name = "Subject";
                dataGridView1.Columns[4].Name = "Year";
                dataGridView1.Columns[5].Name = "Semester";
                dataGridView1.Columns[6].Name = "Prepare for the days learning activity";
                dataGridView1.Columns[7].Name = "Start and ends classes promptly";
                dataGridView1.Columns[8].Name = "Administers test effectively and announces the result of the tests";
                dataGridView1.Columns[9].Name = "Provides stimulating atmosphere in the classrooms which encourages student to participate in class discussion";
                dataGridView1.Columns[10].Name = "Determines the psychological needs of the students and adapt appropriate teaching styles";
                dataGridView1.Columns[11].Name = "Provide student centered activities rather than teacher centered";
                dataGridView1.Columns[12].Name = "Maintains discipline in the class";
                dataGridView1.Columns[13].Name = "Make herself available for consultation";
                dataGridView1.Columns[14].Name = "Provides instructional materials relevant to the topics";
                dataGridView1.Columns[15].Name = "Leaves the room in proper order.";

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                try
                {
                    String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/RatingReportManagement.php";
                    String res = api.SendPost(req, "");
                    var data = JArray.Parse(res);

                    string description;
                    string name;
                    string _class;
                    string subject;
                    string year;
                    string semester;
                    string rating1;
                    string rating2;
                    string rating3;
                    string rating4;
                    string rating5;
                    string rating6;
                    string rating7;
                    string rating8;
                    string rating9;
                    string rating10;

                    //MessageBox.Show(""+details1[0]["success"]);

                    foreach (JObject a in data)
                    {

                        description = a["description"].ToString();
                        name = a["name"].ToString();
                        _class = a["_class"].ToString();
                        subject = a["subject"].ToString();
                        year = a["year"].ToString();
                        semester = a["semester"].ToString();
                        rating1 = a["rating1"].ToString();
                        rating2 = a["rating2"].ToString();
                        rating3 = a["rating3"].ToString();
                        rating4 = a["rating4"].ToString();
                        rating5 = a["rating5"].ToString();
                        rating6 = a["rating6"].ToString();
                        rating7 = a["rating7"].ToString();
                        rating8 = a["rating8"].ToString();
                        rating9 = a["rating9"].ToString();
                        rating10 = a["rating10"].ToString();
                        dataGridView1.Rows.Add(description, name, _class, subject, year, semester, rating1, rating2, rating3, rating4, rating5, rating6, rating7, rating8, rating9, rating10);

                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine("Request: 500 Internal Error: ", err);
                    MessageBox.Show("Request: 500 Internal Error");
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                dataGridView1.ColumnCount = 16;
                dataGridView1.Columns[0].Name = "Description";
                dataGridView1.Columns[1].Name = "Faculty";
                dataGridView1.Columns[2].Name = "Class";
                dataGridView1.Columns[3].Name = "Subject";
                dataGridView1.Columns[4].Name = "Year";
                dataGridView1.Columns[5].Name = "Semester";
                dataGridView1.Columns[6].Name = "Discusses topics that are relevant to the subject";
                dataGridView1.Columns[7].Name = "Motivates students to ask questions";
                dataGridView1.Columns[8].Name = "Uses different teaching strategies to meet the learning needs of the students";
                dataGridView1.Columns[9].Name = "Communicate effectively both in English and Filipino";
                dataGridView1.Columns[10].Name = "Shares knowledge on the current trens and issues pf the object";
                dataGridView1.Columns[11].Name = "Shows comprehensive and accurate knowledge of the subject matter";
                dataGridView1.Columns[12].Name = "Integrates the subject matter into real life situations";
                dataGridView1.Columns[13].Name = "Relates lessons to existing conditions and real life situations.";
                dataGridView1.Columns[14].Name = "Enriches class discussions with contemporary issues and events";
                dataGridView1.Columns[15].Name = "Provides varied learning experiences for intellectual development";

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                try
                {
                    String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/RatingReportEffectiveness.php";
                    String res = api.SendPost(req, "");
                    var data = JArray.Parse(res);

                    string description;
                    string name;
                    string _class;
                    string subject;
                    string year;
                    string semester;
                    string rating1;
                    string rating2;
                    string rating3;
                    string rating4;
                    string rating5;
                    string rating6;
                    string rating7;
                    string rating8;
                    string rating9;
                    string rating10;

                    //MessageBox.Show(""+details1[0]["success"]);

                    foreach (JObject a in data)
                    {

                        description = a["description"].ToString();
                        name = a["name"].ToString();
                        _class = a["_class"].ToString();
                        subject = a["subject"].ToString();
                        year = a["year"].ToString();
                        semester = a["semester"].ToString();
                        rating1 = a["rating1"].ToString();
                        rating2 = a["rating2"].ToString();
                        rating3 = a["rating3"].ToString();
                        rating4 = a["rating4"].ToString();
                        rating5 = a["rating5"].ToString();
                        rating6 = a["rating6"].ToString();
                        rating7 = a["rating7"].ToString();
                        rating8 = a["rating8"].ToString();
                        rating9 = a["rating9"].ToString();
                        rating10 = a["rating10"].ToString();
                        dataGridView1.Rows.Add(description, name, _class, subject, year, semester, rating1, rating2, rating3, rating4, rating5, rating6, rating7, rating8, rating9, rating10);

                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine("Request: 500 Internal Error: ", err);
                    MessageBox.Show("Request: 500 Internal Error");
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                dataGridView1.ColumnCount = 16;
                dataGridView1.Columns[0].Name = "Description";
                dataGridView1.Columns[1].Name = "Faculty";
                dataGridView1.Columns[2].Name = "Class";
                dataGridView1.Columns[3].Name = "Subject";
                dataGridView1.Columns[4].Name = "Year";
                dataGridView1.Columns[5].Name = "Semester";
                dataGridView1.Columns[6].Name = "Observes teachers code of ethic and the rules and regulations of the institution";
                dataGridView1.Columns[7].Name = "Sets example of moral and ethical behavior";
                dataGridView1.Columns[8].Name = "Guides every stuent to develop his potentials and capability to the utmost";
                dataGridView1.Columns[9].Name = "Makes learning experiences of students enjoyable, fruitful and meaningful";
                dataGridView1.Columns[10].Name = "Computes objectively the grades of the students";
                dataGridView1.Columns[11].Name = "Manifests interest in the progress of the student";               
                dataGridView1.Columns[12].Name = "Interacts with students to create positive classroom climate.";
                dataGridView1.Columns[13].Name = "Considers views and opinion of students";
                dataGridView1.Columns[14].Name = "Takes part in school realted activities";
                dataGridView1.Columns[15].Name = "Identifies and responds to the learning needs of the students.";

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                try
                {
                    String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/RatingReportPEPQ.php";
                    String res = api.SendPost(req, "");
                    var data = JArray.Parse(res);

                    string description;
                    string name;
                    string _class;
                    string subject;
                    string year;
                    string semester;
                    string rating1;
                    string rating2;
                    string rating3;
                    string rating4;
                    string rating5;
                    string rating6;
                    string rating7;
                    string rating8;
                    string rating9;
                    string rating10;

                    //MessageBox.Show(""+details1[0]["success"]);

                    foreach (JObject a in data)
                    {

                        description = a["description"].ToString();
                        name = a["name"].ToString();
                        _class = a["_class"].ToString();
                        subject = a["subject"].ToString();
                        year = a["year"].ToString();
                        semester = a["semester"].ToString();
                        rating1 = a["rating1"].ToString();
                        rating2 = a["rating2"].ToString();
                        rating3 = a["rating3"].ToString();
                        rating4 = a["rating4"].ToString();
                        rating5 = a["rating5"].ToString();
                        rating6 = a["rating6"].ToString();
                        rating7 = a["rating7"].ToString();
                        rating8 = a["rating8"].ToString();
                        rating9 = a["rating9"].ToString();
                        rating10 = a["rating10"].ToString();
                        dataGridView1.Rows.Add(description, name, _class, subject, year, semester, rating1, rating2, rating3, rating4, rating5, rating6, rating7, rating8, rating9, rating10);

                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine("Request: 500 Internal Error: ", err);
                    MessageBox.Show("Request: 500 Internal Error");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            onLoadComments();
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PanelForms.sub_panels.manage_evaluation manage_evaluation = new PanelForms.sub_panels.manage_evaluation();
            manage_evaluation.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }
        private void onLoadComments()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 10;
            dataGridView1.Columns[0].Name = "Student ID";
            dataGridView1.Columns[1].Name = "Student Name";
            dataGridView1.Columns[2].Name = "Course";
            dataGridView1.Columns[3].Name = "Subject Code";
            dataGridView1.Columns[4].Name = "Faculty";
            dataGridView1.Columns[5].Name = "Department";
            dataGridView1.Columns[6].Name = "School Year";
            dataGridView1.Columns[7].Name = "Semester";
            dataGridView1.Columns[8].Name = "Comment";
            dataGridView1.Columns[9].Name = "Created At";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            try
            {
                String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/FetchAdminFeedback.php";
                String res = api.SendPost(req, "");

                var response = JArray.Parse(res);

                foreach (JObject data in response)
                {
                    string SID;
                    string student_name;
                    string _class;
                    string code;
                    string subject;
                    string name;
                    string Department;
                    string year;
                    string semester;
                    string comment;
                    string created_at;

                    SID = data["SID"].ToString();
                    student_name = data["student_name"].ToString();
                    _class = data["_class"].ToString();
                    code = data["code"].ToString();
                    subject = data["subject"].ToString();
                    name = data["name"].ToString();
                    Department = data["Department"].ToString();
                    year = data["year"].ToString();
                    semester = data["semester"].ToString();
                    comment = data["comment"].ToString();
                    created_at = data["created_at"].ToString();

                    dataGridView1.Rows.Add(SID, student_name, _class, code, subject, name, Department, year, semester, comment, created_at);

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
    }
}
