namespace MC_Design.PanelForms.reports
{
    partial class print_faculty
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.print_faculties = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // print_faculties
            // 
            this.print_faculties.ActiveViewIndex = -1;
            this.print_faculties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.print_faculties.Cursor = System.Windows.Forms.Cursors.Default;
            this.print_faculties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.print_faculties.Location = new System.Drawing.Point(0, 0);
            this.print_faculties.Name = "print_faculties";
            this.print_faculties.Size = new System.Drawing.Size(628, 552);
            this.print_faculties.TabIndex = 0;
            // 
            // print_faculty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 552);
            this.Controls.Add(this.print_faculties);
            this.Name = "print_faculty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "print_faculty";
            this.Load += new System.EventHandler(this.print_faculty_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer print_faculties;
    }
}