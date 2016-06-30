using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CIA_Boicu_Ionut_clasa_a_XI_a
{
    public partial class ShopForm : Form
    {
        public ShopForm()
        {
            InitializeComponent();
        }

        GameOverForm formGameOver;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FirstLookForm.formPlay.Visible = true;
            FirstLookForm.formPlay.WindowState = FormWindowState.Normal;
        }

        void Go()
        {
            this.Close();
            if (formGameOver == null || formGameOver.IsDisposed)
            {
                formGameOver = new GameOverForm();
                formGameOver.Show();
            }
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label5.Text = "" + MenuForm.oxigen;
            label7.Text = "" + MenuForm.magazin;
            if (MenuForm.abilitate == 2)
            {
                label1.Text = "-2000";
                label2.Text = "-2000";
                label3.Text = "-75";
            }
            if (MenuForm.abilitate == 3)
            {
                button1.Visible = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MenuForm.abilitate == 2)
            {
                if (MenuForm.magazin >= 75)
                {
                    MenuForm.oxigen++;
                    label5.Text = "" + MenuForm.oxigen;
                    MenuForm.magazin -= 75;
                    label7.Text = "" + MenuForm.magazin;
                }
                else MessageBox.Show("Îmi pare rău dar nu ai suficiente credite!");
            }
            else
            {
                if (MenuForm.magazin >= 100)
                {
                    MenuForm.oxigen++;
                    label5.Text = "" + MenuForm.oxigen;
                    MenuForm.magazin -= 100;
                    label7.Text = "" + MenuForm.magazin;
                }
                else MessageBox.Show("Îmi pare rău dar nu ai suficiente credite!");
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MenuForm.abilitate == 2)
            {
                if (MenuForm.magazin >= 2000)
                {
                    MenuForm.magazin -= 2000;
                    for (int i = 1; i < 99; i++)
                        if (LabForm.codul[i] == "5")
                        { LabForm.viz[i] = 1; LabForm.K++; break; }
                    label7.Text = "" + MenuForm.magazin;
                }
                else MessageBox.Show("Îmi pare rău dar nu ai suficiente credite!");
            }
            else
            {
                if (MenuForm.magazin >= 2500)
                {
                    MenuForm.magazin -= 2500;
                    for (int i = 1; i < 99; i++)
                        if (LabForm.codul[i] == "5")
                        { LabForm.viz[i] = 1; LabForm.K++; break; }
                    label7.Text = "" + MenuForm.magazin;
                }
                else MessageBox.Show("Îmi pare rău dar nu ai suficiente credite!");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (MenuForm.abilitate == 2)
            {
                if (MenuForm.magazin >= 2000)
                {
                    MenuForm.magazin -= 2000;
                    for (int i = 1; i < 99; i++)
                        if (LabForm.codul[i] == "6")
                        { LabForm.viz[i] = 1; LabForm.K++; break; }
                    label7.Text = "" + MenuForm.magazin;
                }
                else MessageBox.Show("Îmi pare rău dar nu ai suficiente credite!");
            }
            else
            {
                if (MenuForm.magazin >= 2500)
                {
                    MenuForm.magazin -= 2500;
                    for (int i = 1; i < 99; i++)
                        if (LabForm.codul[i] == "6")
                        { LabForm.viz[i] = 1; LabForm.K++; break; }
                    label7.Text = "" + MenuForm.magazin;
                }
                else MessageBox.Show("Îmi pare rău dar nu ai suficiente credite!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = timer1.Interval;           
            if (this.Visible == false)
                timer1.Stop();
            else if (i % 30000 == 0 && this.Visible == true)
            { 
                MenuForm.oxigen--;
                label5.Text = "" + MenuForm.oxigen;
                if (MenuForm.oxigen <= 0)
                { this.Close(); Go(); FirstLookForm.formPlay.Close(); }
            }
        }

        private void ShopForm_Activated(object sender, EventArgs e)
        {
            label5.Text = "" + MenuForm.oxigen;
            label7.Text = "" + MenuForm.magazin;
            if(MenuForm.abilitate==2)
            {
                label1.Text="-75";
                label2.Text="-2000";
                label3.Text="-2000";
            }
            if (MenuForm.abilitate == 3)
            {
                button1.Visible = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = false;
            MenuForm.magazin -= 1000;
            label7.Text = "" + MenuForm.magazin;
            timer8.Start();
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            int i = timer8.Interval;
            if (i % 300000 == 0)
                button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuForm.magazin += 100;
            label7.Text = "" + MenuForm.magazin;
            button3.Visible = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Ajutor.docx");
        }
        
    }
}
