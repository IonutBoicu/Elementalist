using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CIA_Boicu_Ionut_clasa_a_XI_a
{
    public partial class LabForm : Form
    {
        public LabForm()
        {
            InitializeComponent();
        }
        public static string[] numele = new string[99];
        public static string[] codul = new string[99];
        public static int[] viz = new int[102];
        string[] fisiere;
        string a;
        char l1, l2, l3, l4;
        string c;
        public static int K=4;
        public static int reff=0;
        GameOverForm formGameOver;

        void Go()
        {
            this.Close();
            if (formGameOver == null || formGameOver.IsDisposed)
            {
                formGameOver = new GameOverForm();
                formGameOver.Show();
            }
        }

        private void LabForm_Load(object sender, EventArgs e)
        {

            timer1.Start();
            label6.Text = "" + MenuForm.oxigen;
            fisiere = Directory.GetFiles("..\\Debug");
            for (int i = 0; i < fisiere.Length; i++)
            {
                int punct = fisiere[i].LastIndexOf('.');

                int bara = fisiere[i].LastIndexOf('\\');

                int virgula = fisiere[i].LastIndexOf(',');
                if (virgula > 0)
                {
                    string nume = fisiere[i].Substring(virgula + 1, punct - virgula - 1);
                    string code = fisiere[i].Substring(bara + 1, virgula - bara - 1);
                    numele[i] = nume;
                    codul[i] = code;
                    viz[i] = 0;
                    if (code.Length == 1 && code != "6" && code != "5") { viz[i] = 1; comboBox1.Items.Add(nume); listBox1.Items.Add(code); comboBox2.Items.Add(nume); listBox2.Items.Add(code); }
                }
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Visible == true && pictureBox3.Visible == true)
            {
                string z; string x;  int sw = 0;
                if (listBox1.SelectedItem.ToString().Length > 20 && listBox2.SelectedItem.ToString().Length > 20)
                {
                    l1 = listBox1.SelectedItem.ToString()[listBox1.SelectedItem.ToString().Length - 1];
                    l2 = listBox1.SelectedItem.ToString()[listBox1.SelectedItem.ToString().Length - 2];
                    l3 = listBox2.SelectedItem.ToString()[listBox2.SelectedItem.ToString().Length - 1];
                    l4 = listBox2.SelectedItem.ToString()[listBox2.SelectedItem.ToString().Length - 2];
                }
                pictureBox1.Load("..\\Debug\\Copy.jpg");

                z = string.Concat(listBox1.SelectedItem.ToString(), listBox2.SelectedItem.ToString());
                x = string.Concat(listBox2.SelectedItem.ToString(), listBox1.SelectedItem.ToString());
                for (int i = 0; i < 99; i++)
                    if (codul[i] == z && viz[i] == 0)
                    { 
                        K++; pictureBox4.Load("..\\Debug\\" + z + "," + numele[i] + ".jpg");
                        viz[i] = 1;label1.Text = numele[i]; sw = 1;
                        comboBox1.Items.Add(numele[i]);
                        listBox1.Items.Add(z);
                        comboBox2.Items.Add(numele[i]);
                        listBox2.Items.Add(z); break;
                    }
                    else if (codul[i] == x && viz[i] == 0)
                    {
                        K++; pictureBox4.Load("..\\Debug\\" + x + "," + numele[i] + ".jpg");
                        viz[i] = 1;label1.Text = numele[i];sw = 1;
                        comboBox1.Items.Add(numele[i]); 
                        listBox1.Items.Add(x);
                        comboBox2.Items.Add(numele[i]);
                        listBox2.Items.Add(x); break;
                    }
                if (sw == 0 && l2 == '3' && l4 == '3' && ((l1 == '5' && l3 == '6') || (l1 == '6' && l3 == '5')))
                { K++; pictureBox4.Load("..\\Debug\\,Reformarea Terrei.jpg"); reff = 1; label1.Text = "Reformarea Terrei"; 
                    sw = 1; MessageBox.Show("felicitări ai recreat Terra, acum încearcă sa o folosești în locul exploziei"); }
                else if (sw == 0) { pictureBox4.Load("..\\Debug\\W.jpg"); label1.Text = "Nimic"; }
                pictureBox4.Visible = true;   pictureBox2.Visible = false;pictureBox3.Visible = false;
                label2.Text = "";label2.Text = "" + K;timer2.Start();
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            c = comboBox2.SelectedIndex.ToString();
            int d = Convert.ToInt32(comboBox2.SelectedIndex.ToString());
            listBox2.SetSelected(d, true);
            pictureBox3.Load("..\\Debug\\" + listBox2.SelectedItem.ToString() + "," + comboBox2.SelectedItem.ToString() + ".jpg");
            pictureBox3.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = comboBox1.SelectedIndex.ToString();
            int b = Convert.ToInt32(comboBox1.SelectedIndex.ToString());
            listBox1.SetSelected(b, true);
            pictureBox2.Load("..\\Debug\\" + listBox1.SelectedItem.ToString() + "," + comboBox1.SelectedItem.ToString() + ".jpg");
            pictureBox2.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i=timer1.Interval;
            if (i % 30000 == 0)
            {
                MenuForm.oxigen--; label6.Text = ""; label6.Text = "" + MenuForm.oxigen;
                if (MenuForm.oxigen == 0)
                { this.Close(); Go(); FirstLookForm.formPlay.Close(); }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int i = timer2.Interval;
            if(i%1000==0)
                pictureBox1.Load("..\\Debug\\1Copy.jpg");
            timer2.Stop();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FirstLookForm.formPlay.Visible = true;
            FirstLookForm.formPlay.WindowState = FormWindowState.Normal;
        }

        private void LabForm_Activated(object sender, EventArgs e)
        {
            label6.Text = "" + MenuForm.oxigen;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Ajutor.docx");
        }

    }
}
