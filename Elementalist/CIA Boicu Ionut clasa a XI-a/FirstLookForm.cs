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
    public partial class FirstLookForm : Form
    {
        public FirstLookForm()
        {
            InitializeComponent();
        }

        ProfileForm profileForm;
        public static MenuForm formMenu = new MenuForm();
        public static GameForm formGame = new GameForm();
        public static PlayForm formPlay = new PlayForm();
        public static LabForm formLab = new LabForm();
        public static ShopForm formShop = new ShopForm();
        

        private void FirstLookForm_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (profileForm == null || profileForm.IsDisposed)
            {
                profileForm = new ProfileForm();
                profileForm.Show();
                this.Visible = false;
                button3.Enabled = false;
            }
        }

        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            Process pr = Process.GetCurrentProcess();
            pr.Kill();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            pictureBox3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            pictureBox3.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Ajutor.docx");
        }
    }
}
