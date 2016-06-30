using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CIA_Boicu_Ionut_clasa_a_XI_a
{
    public partial class PlayForm : Form
    {
        public PlayForm()
        {
            InitializeComponent();
        }
        Random r = new Random();
        FirstLookForm form;

        private void LabButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FirstLookForm.formLab.Visible = true;
            FirstLookForm.formLab.WindowState = FormWindowState.Normal;
        }

        void Tick()
        {
            int i = timer1.Interval;
            if (i % 1500 == 0)
            { pictureBox2.Load("..\\Debug\\ert1.jpg"); timer1.Interval++; }
            else if (i % 1500 == 0)
            { pictureBox2.Load("..\\Debug\\ert2.jpg"); timer1.Stop(); timer1.Enabled = false; }
        }
               
        private void ExploButton_Click(object sender, EventArgs e)
        {
            if (LabForm.reff == 1)
            {
                timer1.Start();
                ExploButton.Visible = false;
                while(timer1.Enabled==true)
                Tick();
            }
        }

        private void ShopButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FirstLookForm.formShop.Visible = true;
            FirstLookForm.formShop.WindowState = FormWindowState.Normal;
            if (r.Next(1, 5) == 1&&MenuForm.abilitate!=1)
            {
                MenuForm.magazin -= 100;
                MessageBox.Show("Ai fost prada piraților pentru 100Credite");
            }
        }

        private void PlayForm_Load(object sender, EventArgs e)
        {
                FirstLookForm.formLab.Show();
                FirstLookForm.formLab.Visible = false;
                FirstLookForm.formShop.Show();
                FirstLookForm.formShop.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FirstLookForm.formLab.Close();
            FirstLookForm.formShop.Close();
            FirstLookForm.formPlay.Close();
            this.Close();
            if (form == null || form.IsDisposed || form.Visible == false)
            {
                form = new FirstLookForm();
                form.Show();
            }
            
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Ajutor.docx");
        }

    }
}
