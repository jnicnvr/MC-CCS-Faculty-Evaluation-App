﻿using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
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
    public partial class panel_student : Form
    {
        API api = new API();
        public panel_student()
        {
            InitializeComponent();
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            _Application importExcelToDataGridViewApp;
            _Workbook importExcelToDataGridViewWorkbook;
            _Worksheet importExcelToDataGridViewWorksheet;
            Range importExcelToDataGridViewRange;

            try
            {
                importExcelToDataGridViewApp = new Microsoft.Office.Interop.Excel.Application();

                OpenFileDialog importExcelToDataGridViewOpenFileDialog = new OpenFileDialog();
                //importExcelToDataGridViewOpenFileDialog.InitialDirectory = @"C:/Users/Authentic/Desktop";
                //importExcelToDataGridViewOpenFileDialog.RestoreDirectory = true;
                //Dialog Box Title
                importExcelToDataGridViewOpenFileDialog.Title = "Import Excel File To DataGridView";
                //filter Excel Files Only
                importExcelToDataGridViewOpenFileDialog.Filter = "Choose Excel File | *.xlsx;*.xls;*.xlm";
                //If Open Button Is Clicked
                if (importExcelToDataGridViewOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    importExcelToDataGridViewWorkbook = importExcelToDataGridViewApp.Workbooks.Open(importExcelToDataGridViewOpenFileDialog.FileName);
                    importExcelToDataGridViewWorksheet = importExcelToDataGridViewWorkbook.ActiveSheet;
                    importExcelToDataGridViewRange = importExcelToDataGridViewWorksheet.UsedRange;

                    //Start Importing from the second row. Since the first row is column header
                    for (int excelWorkSheetRowIndex = 2; excelWorkSheetRowIndex < importExcelToDataGridViewRange.Rows.Count + 1; excelWorkSheetRowIndex++)
                    {
                        //Convert The Path to image and display it in datagridviewimagecolumn
                        dataGridView1.Rows.Add(importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 1].Value, importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 2].Value, importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 3].Value, importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 4].Value, importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 5].Value, importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 6].Value, importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 7].Value, importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 8].Value, importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 9].Value, importExcelToDataGridViewWorksheet.Cells[excelWorkSheetRowIndex, 10].Value);
                    }
                }

            }
            catch (Exception importExcelToDataGridViewException)
            {
                MessageBox.Show("Error" + importExcelToDataGridViewException);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            onLoadStudents();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            //  MessageBox.Show("Running like a shit!");         
            MessageBox.Show("Loading in Background Please Wait", "Success",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           // MessageBox.Show("Loading in Background Please Wait");
            const string param = "student";
          
            try
            {
                string _SID = string.Empty;
                string _Fname = string.Empty;
                string _Lname = string.Empty;
                string _Age = string.Empty;

                string _Sex = string.Empty;
                string _Course = string.Empty;
                string _year_level = string.Empty;
                string _section = string.Empty;
                string _username = string.Empty;
                string _password = string.Empty;
                int k = dataGridView1.RowCount;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int index = 0;

                    _SID = row.Cells[index].Value.ToString();
                    index += 1;
                    _Fname = row.Cells[index].Value.ToString();
                    index += 1;
                    _Lname = row.Cells[index].Value.ToString();
                    index += 1;
                    _Age = row.Cells[index].Value.ToString();

                    index += 1;
                    _Sex = row.Cells[index].Value.ToString();
                    index += 1;
                    _Course = row.Cells[index].Value.ToString();
                    index += 1;
                    _year_level = row.Cells[index].Value.ToString();
                    index += 1;
                    _section = row.Cells[index].Value.ToString();
                    index += 1;
                    _username = row.Cells[index].Value.ToString();
                    index += 1;
                    _password = row.Cells[index].Value.ToString();

                    string SID = _SID;
                    string Fname = _Fname;
                    string Lname = _Lname;
                    string Age = _Age;
                    string Sex = _Sex;
                    string Course = _Course;
                    string year_level = _year_level;
                    string section = _section;
                    string username = _username;
                    string password = _password;

                    object mydata = new
                    {
                         SID = SID,
                         Fname = Fname,
                         Lname = Lname,
                         Age = Age,
                         Sex = Sex,
                        curriculum = Course,
                         year_level = year_level,
                         section = section,
                         username = username,
                         password = password
                     };
                    Console.WriteLine(mydata);
                    var res = await RESTHelper.Post(param, mydata);
                    Console.WriteLine(res);
                    //var details1 = JArray.Parse(res);

                    //var details = JObject.Parse(details1[0].ToString());
                    //MessageBox.Show("" + details1[0]["success"]);

                    int percentage = (row.Index + 1) * 100 / k;
                    backgroundWorker1.ReportProgress(percentage);
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("Error: ", err);
                MessageBox.Show("504 Bad Request!", err.ToString());
            }           

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Added Student Successfully!", "Success",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
                      
            onSearchStudents(tb_search.Text);
            
        }

        public async void onLoadStudents()
        {         
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();

            dataGridView2.ColumnCount = 8;
            dataGridView2.Columns[0].Name = "Student ID";
            dataGridView2.Columns[1].Name = "Student Name";
            dataGridView2.Columns[2].Name = "Age";
            dataGridView2.Columns[3].Name = "Sex";
            dataGridView2.Columns[4].Name = "Course";
            dataGridView2.Columns[5].Name = "Username";
            dataGridView2.Columns[6].Name = "Password";
            dataGridView2.Columns[7].Name = "Created At";

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                string param = "student";
                var res = await RESTHelper.GetAll(param);

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

                    dataGridView2.Rows.Add(SID, student_name, Age, Sex, _class, username, password, created_at);

                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Request: 500 Internal Error: ", err);
                MessageBox.Show("Found No Student", "Information",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public async void onSearchStudents(String value)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();

            dataGridView2.ColumnCount = 8;
            dataGridView2.Columns[0].Name = "Student ID";
            dataGridView2.Columns[1].Name = "Student Name";
            dataGridView2.Columns[2].Name = "Age";
            dataGridView2.Columns[3].Name = "Sex";
            dataGridView2.Columns[4].Name = "Course";
            dataGridView2.Columns[5].Name = "Username";
            dataGridView2.Columns[6].Name = "Password";
            dataGridView2.Columns[7].Name = "Created At";

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {

                const string param = "student";
                string id = value;
                var res = await RESTHelper.Get(param, id);

              
                // var result = JArray.Parse(res2);

                //MessageBox.Show(""+details1[0]["success"]);
                var obj = JsonConvert.DeserializeObject(res);
                var formatted = JsonConvert.SerializeObject(obj, Formatting.Indented);
                 Console.WriteLine(formatted);
                    Console.WriteLine("mydata", formatted);

                foreach (JObject data in formatted)
                {
                    Console.WriteLine("mydata",data);
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

                    dataGridView2.Rows.Add(SID, student_name, Age, Sex, _class, username, password, created_at);

                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Request: 500 Internal Error: ", err);
                MessageBox.Show("Found No Student", "Information",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

    }
}
