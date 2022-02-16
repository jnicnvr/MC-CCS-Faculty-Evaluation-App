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
    public partial class panel_getAAPI : Form
    {
       
        public panel_getAAPI()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string param = "subject";
            var res = await RESTHelper.GetAll(param);
            txtRes.Text = res;
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            string data = txtGet.Text; //NC101
            string param = "subject";
            var res = await RESTHelper.Get(param,data);
            txtRes.Text = res;
        }

        private async void button2_Click(object sender, EventArgs e) //POST
        {
            string param = "subject";
            string code = txtCode.Text; //NC101
            string subject = txtSubject.Text;
            string description = txtDescription.Text;
            object mydata = new
            {
                code = code,
                subject = subject,
                description = description
            };
            var res = await RESTHelper.Post(param, mydata);
            txtRes.Text = res;
        }

        private async void put_Click(object sender, EventArgs e) //PUT
        {
            string id = txtGet.Text;
            string code = txtCode.Text; //NC101
            string subject = txtSubject.Text;
            string description = txtDescription.Text;
            string param = "subject";
            object mydata = new
            {
                code = code,
                subject = subject,
                description = description                
            };
            var res = await RESTHelper.Put(param,id, mydata);
            txtRes.Text = res;
        }

        private async void delete_Click(object sender, EventArgs e)
        {
            string id = txtGet.Text;
            string param = "subject";
            var res = await RESTHelper.Delete(param, id);
            txtRes.Text = res;
        }
    }
}
