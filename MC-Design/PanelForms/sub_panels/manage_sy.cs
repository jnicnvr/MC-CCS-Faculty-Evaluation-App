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
    public partial class manage_sy : Form
    {
        public manage_sy()
        {
            InitializeComponent();
            onLoadSy();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to add new data?",
                     "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                API api = new API();
                try
                {
                    //add validation
                    //String req = "http://fundamental-winches.000webhostapp.com/MCFE/mc_evaluation/UpdateSyConfig.php";

                    //String sy = HttpUtility.UrlEncode("" + cmb_sy.Text.ToString());
                    //String semester = HttpUtility.UrlEncode("" + cmb_semester.Text.ToString());
                    //String isDefault = HttpUtility.UrlEncode("" + cmb_default.Text.ToString());
                    //String status = HttpUtility.UrlEncode("" + cmb_status.Text.ToString());

                    //String res = api.SendPost(req, String.Format("sy={0}&semester={1}&isDefault={2}&status={3}", sy, semester, isDefault, status));
                    string sy = cmb_sy.Text;
                    string status = cmb_status.Text;
                    string semester = cmb_semester.Text;
                    string isDefault = cmb_default.Text;
                    string param = "school_year";

                    object mydata = new
                    {
                        sy = sy,
                        status = status,
                        semester = semester,
                        isDefault = isDefault
                    };

                    var res = await RESTHelper.Put(param, sy, mydata);
                    // Console.WriteLine(result);
                    var data = JObject.Parse(res);
                    //Console.WriteLine(details);

                    // MessageBox.Show("" + data["success"]);              
                    onCheckValidation(cmb_sy.Text, cmb_semester.Text, cmb_default.Text, cmb_status.Text, "Added New Restrictions!");

                }
                catch (Exception err)
                {
                    Console.WriteLine("500 Internal Error" + err);
                    MessageBox.Show("500 Internal Error");
                }
            }
            else if(dr == DialogResult.No) { }
        }
        public void onCheckValidation(String sy, String semester, String sys_default, String status, String message)
        {
            if (sy == "" || semester == "" || sys_default == "" || status == "")
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
            cmb_default.SelectedIndex = -1;
            cmb_semester.SelectedIndex = -1;
            cmb_status.SelectedIndex = -1;
            cmb_sy.SelectedIndex = -1;           
        }
        private async void onLoadSy()
        {
            try
            {
                string param = "school_year";
                string res = await RESTHelper.GetAll(param);

                var data = JArray.Parse(res);

                Console.WriteLine("res :",data);

                foreach (JObject result in data)
                {
                    string sy;
                    sy = result["year"].ToString();
                    //fid = result["TID"].ToString();
                    cmb_sy.Items.Add(sy);
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
