﻿using System;
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
    public partial class panel_profile : Form
    {
        public panel_profile()
        {           
            InitializeComponent();
            lb_username.Text = Program.globalString;
            lb_user.Text = "@" + Program.globalString;
            tb_position.Text = Program.globalString;
        }
    }
}