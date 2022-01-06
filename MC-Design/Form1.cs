using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC_Design
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //MessageBox.Show(Program.globalString);
           // Program.globalString = "Accessible in Form1.";
            InitializeComponent();
          //  MessageBox.Show(Program.globalString);

            lb_username.Text = Program.globalString;
            lb_user.Text = "@"+Program.globalString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            onLoadPanel("Home");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
            //open dialog confirmation
        }

        private void button6_Click(object sender, EventArgs e)
         {
            //this.Dispose();
            DialogResult dr = MessageBox.Show("Do you want to exit?",
                     "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            { Environment.Exit(0); }
            else if (dr == DialogResult.No) {}
                
        }
           
        private void onLoadPanel(string choice)
        {
            switch (choice)
            {
                case "Home":
                    panel_fill.Controls.Clear();
                    PanelForms.panel_home home = new PanelForms.panel_home();
                    home.TopLevel = false;
                    panel_fill.Controls.Add(home);
                    home.Show();

                    break;
                case "Faculty":
                    panel_fill.Controls.Clear();
                    PanelForms.panel_faculty faculty = new PanelForms.panel_faculty();
                    faculty.TopLevel = false;
                    panel_fill.Controls.Add(faculty);
                    faculty.Show();
                    break;
                case "Evaluation":
                    panel_fill.Controls.Clear();
                    PanelForms.panel_evaluation evaluation = new PanelForms.panel_evaluation();
                    evaluation.TopLevel = false;
                    panel_fill.Controls.Add(evaluation);
                    evaluation.Show();
                    break;
                case "About":
                    panel_fill.Controls.Clear();
                    PanelForms.panel_about about = new PanelForms.panel_about();
                    about.TopLevel = false;
                    panel_fill.Controls.Add(about);
                    about.Show();
                    break;
                case "Profile":
                    panel_fill.Controls.Clear();
                    PanelForms.panel_profile profile = new PanelForms.panel_profile();
                    profile.TopLevel = false;
                    panel_fill.Controls.Add(profile);
                    profile.Show();
                    break;
                case "Sy":
                    panel_fill.Controls.Clear();
                    PanelForms.panel_sy sy = new PanelForms.panel_sy();
                    sy.TopLevel = false;
                    panel_fill.Controls.Add(sy);
                    sy.Show();
                    break;
                case "Subjects":
                    panel_fill.Controls.Clear();
                    PanelForms.panel_subjects subjects = new PanelForms.panel_subjects();
                    subjects.TopLevel = false;
                    panel_fill.Controls.Add(subjects);
                    subjects.Show();
                    break;
                case "Classes":
                    panel_fill.Controls.Clear();
                    PanelForms.panel_classes _classes = new PanelForms.panel_classes();
                    _classes.TopLevel = false;
                    panel_fill.Controls.Add(_classes);
                    _classes.Show();
                    break;
                case "Student":
                    panel_fill.Controls.Clear();
                    PanelForms.panel_student student = new PanelForms.panel_student();
                    student.TopLevel = false;
                    panel_fill.Controls.Add(student);
                    student.Show();
                    break;
                case "Reviews":
                    panel_fill.Controls.Clear();
                    PanelForms.panel_reviews reviews = new PanelForms.panel_reviews();
                    reviews.TopLevel = false;
                    panel_fill.Controls.Add(reviews);
                    reviews.Show();
                    break;
                default:
                    panel_fill.Controls.Clear();
                    PanelForms.panel_home f = new PanelForms.panel_home();
                    f.TopLevel = false;
                    panel_fill.Controls.Add(f);
                    f.Show();
                    break;
            }          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            onLoadPanel("Home");
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            onLoadPanel("About");
        }

        private void btn_evaluation_report_Click(object sender, EventArgs e)
        {
            onLoadPanel("Evaluation");
        }

        private void btn_faculty_Click(object sender, EventArgs e)
        {
            onLoadPanel("Faculty");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            onLoadPanel("Profile");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            onLoadPanel("Sy");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            onLoadPanel("Subjects");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            onLoadPanel("Classes");
        }

        private void btn_student_Click(object sender, EventArgs e)
        {
            onLoadPanel("Student");
        }

        private void btn_about_Click_1(object sender, EventArgs e)
        {
            onLoadPanel("About");
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            PanelForms.panel_notification notif = new PanelForms.panel_notification();
            notif.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            onLoadPanel("Reviews");
        }
    }
}
