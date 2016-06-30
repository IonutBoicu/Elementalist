using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CIA_Boicu_Ionut_clasa_a_XI_a
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
            pictureBox1.Focus();
        }
        int j = 0;
        public static OleDbConnection connection;
        public static OleDbDataReader dataReader;
        public static OleDbCommand command;
        public static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;
                                                  Data Source=Profiledb.mdb";
        public static string commandString = "";

        private void openPlay()
        {

                FirstLookForm.formPlay.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
           
               commandString = @"UPDATE Table1
                              SET Scene='1'
                              WHERE Nume='" + ProfileForm.usrName + "'";
               connection = new OleDbConnection(connectionString);
               command = new OleDbCommand(commandString, connection);
            try
               {
                    connection.Open();
                     command.ExecuteNonQuery();
                     this.Close();
                     openPlay();
                }
            catch (OleDbException exc)
            {
                MessageBox.Show("Eşec! " + exc.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            timer5.Interval = 4000 + j;
            int i = timer5.Interval;
            if (i == 4000)
            {
                label1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox2.Focus();
                pictureBox1.Load("..\\Debug\\black.png");
                pictureBox2.Load("..\\Debug\\pam00.jpg");
            }
            else if (i == 4001)
            {
                label2.Visible = true;
                pictureBox2.Load("..\\Debug\\pam0.jpg");

            }
            else if (i == 4002)
            {
                label4.Visible = true;
                pictureBox2.Load("..\\Debug\\pam5.jpg");

            }
            else if (i == 4003)
            {
                label3.Visible = true;
                label5.Visible = true;
                label7.Visible = true;
                pictureBox2.Load("..\\Debug\\pam4.jpg");
                pictureBox3.Visible = true;
            }
            else if (i == 4004)
            {
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                pictureBox3.Visible = false;
                pictureBox2.Load("..\\Debug\\pam3.jpg");
                pictureBox4.Visible = true;
            }
            else if (i == 4005)
            {
                pictureBox2.Enabled = false;
                pictureBox2.Visible = false;
                pictureBox4.Visible = false;
                pictureBox1.Load("..\\Debug\\pam7.jpg");
                pictureBox5.Visible = true;
                button1.Visible = true;
            }
            j++;
        }

        private void GameForm_Shown(object sender, EventArgs e)
        {
            timer5.Enabled = true;
            timer5.Start();
        }
    }
}
