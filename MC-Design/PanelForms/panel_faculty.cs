using Microsoft.Office.Interop.Excel;
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
using System.Windows.Forms;

namespace MC_Design.PanelForms
{
    public partial class panel_faculty : Form
    {
        public panel_faculty()
        {
            InitializeComponent();
            onLoadFaculty();
         //   FetchFaculty();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PanelForms.sub_panels.add_panel_faculty add_faculty = new PanelForms.sub_panels.add_panel_faculty();
            add_faculty.Show();
        }
        private async void onLoadFaculty()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            
                dataGridView1.ColumnCount = 4;
                dataGridView1.Columns[0].Name = "Faculty ID";
                dataGridView1.Columns[1].Name = "First Name";
                dataGridView1.Columns[2].Name = "Middle Name";
                dataGridView1.Columns[3].Name = "Last Name";
              
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                try
                {
                string param = "teacher";
                var res = await RESTHelper.GetAll(param);

                Console.WriteLine(res);
                var result = JArray.Parse(res);

                //MessageBox.Show(""+details1[0]["success"]);
                    foreach (JObject data in result)
                    {
                        string fid;
                        string fname;
                        string mname;
                        string lname;
                        fid = data["TID"].ToString();
                        fname = data["Fname"].ToString();
                        mname = data["Mname"].ToString();
                        lname = data["Lname"].ToString();                       
                        dataGridView1.Rows.Add(fid, fname, mname, lname);             
                     }           
           
            }
            catch (Exception err)
                {
                Console.WriteLine("Request: 500 Internal Error: ", err);
                MessageBox.Show("Request: 500 Internal Error");
            }
            }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //PanelForms.reports.print_faculty print_faculties = new PanelForms.reports.print_faculty();
            //print_faculties.Show();
            copyAlltoClipboard();

            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
          
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();        
           
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[1,1] = "Republic of the Philippines";
            xlWorkSheet.Cells[2, 1] = "Mabini College";
            xlWorkSheet.Cells[3, 1] = "College of Computer Science";
            xlWorkSheet.Cells[4, 1] = "Faculty Evaluation System Report";
            Range titleRange = xlexcel.get_Range("A1:J1", Type.Missing);
          
            titleRange.MergeCells = true;
            titleRange.Merge(Type.Missing);        
            //Center the title horizontally then vertically at the above defined range
            titleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            titleRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            //Increase the font-size of the title
            titleRange.Font.Size = 10;
            //Make the title bold
            titleRange.Font.Bold = false;
            //Give the title background color
            titleRange.Interior.Color = ColorTranslator.ToOle(Color.White);
            //Set the title row height
            //titleRange.RowHeight = 50;

            Range mabini = xlexcel.get_Range("A2:J2", Type.Missing);
            mabini.MergeCells = true;
            mabini.Merge(Type.Missing);
            mabini.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            mabini.VerticalAlignment = XlVAlign.xlVAlignCenter;
            mabini.Font.Size = 10;

            Range department = xlexcel.get_Range("A3:J3", Type.Missing);
            department.MergeCells = true;
            department.Merge(Type.Missing);
            department.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            department.VerticalAlignment = XlVAlign.xlVAlignCenter;
            department.Font.Size = 10;

            Range mccss = xlexcel.get_Range("A4:J4", Type.Missing);
            mccss.MergeCells = true;
            mccss.Merge(Type.Missing);
            mccss.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            mccss.VerticalAlignment = XlVAlign.xlVAlignCenter;
            mccss.Font.Size = 10;


            Range CR = (Range)xlWorkSheet.Cells[6, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            CR = xlWorkSheet.UsedRange;
           // Range cell = CR.Cells["A6:D14"];

            ((Range)xlWorkSheet.get_Range("A6:D14")).Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
            //Borders border = cell.Borders;
            //  border.LineStyle = XlLineStyle.xlContinuous;
            //  border.Weight = 2d;            
        }
          private void copyAlltoClipboard()
        {

            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView1.MultiSelect = true;        
            //to remove the first blank column from datagridview
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
     
       
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            onLoadFaculty();
        }
    }
}
