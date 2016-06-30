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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }


        public static OleDbConnection connection;
        public static OleDbDataReader dataReader;
        public static OleDbCommand command;
        public static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;
                                                  Data Source=Profiledb.mdb";
        public static string commandString = "";
        public static int nava = 0;
        public static int abilitate = 0;
        public static int oxigen = 0;
        public static int magazin = 0;

        private void openGame()
        {

                FirstLookForm.formGame.Show(); 
         
        }

        private bool check()
        {
            if (l1.ForeColor == Color.Crimson || l2.ForeColor == Color.Crimson || l3.ForeColor == Color.Crimson || l4.ForeColor == Color.Crimson || l5.ForeColor == Color.Crimson)
                return true;
            return false;
        }

        private void JoacaButton_Click(object sender, EventArgs e)
        {
            if (check() == true)
            {
                if (l1.ForeColor == Color.Crimson)
                {
                    commandString = @"UPDATE Table1
                                SET Nava='1',Oxigen='300',Magazin='15000',Abilitate='0'
                              WHERE Nume='" + ProfileForm.usrName + "'";
                    MenuForm.nava = 1;
                    MenuForm.oxigen = 300;
                    MenuForm.magazin = 15000;
                    MenuForm.abilitate = 0;
                }
                if (l2.ForeColor == Color.Crimson)
                 {
                    commandString = @"UPDATE Table1
                              SET Nava='2',Oxigen='400',Magazin='11000',Abilitate='2'
                              WHERE Nume='" + ProfileForm.usrName + "'";
                    MenuForm.nava = 4;
                    MenuForm.oxigen = 400;
                    MenuForm.magazin = 11000;
                    MenuForm.abilitate = 2;
                }
                if (l3.ForeColor == Color.Crimson)
                {
                    commandString = @"UPDATE Table1
                              SET Nava='5',Oxigen='400',Magazin='9000',Abilitate='3'
                              WHERE Nume='" + ProfileForm.usrName + "'";
                    MenuForm.nava = 5;
                    MenuForm.oxigen = 400;
                    MenuForm.magazin = 9000;
                    MenuForm.abilitate = 3;
                }
                if (l4.ForeColor == Color.Crimson)
                {
                    commandString = @"UPDATE Table1
                              SET Nava='2',Oxigen='500',Magazin='9000',Abilitate='0'
                              WHERE Nume='" + ProfileForm.usrName + "'";
                    MenuForm.nava = 2;
                    MenuForm.oxigen = 500;
                    MenuForm.magazin = 9000;
                    MenuForm.abilitate = 0;
                }
                if (l5.ForeColor == Color.Crimson)
                {
                    commandString = @"UPDATE Table1
                              SET Nava='3',Oxigen='400',Magazin='1000',Abilitate='1'
                              WHERE Nume='" + ProfileForm.usrName + "'";
                    MenuForm.nava = 3;
                    MenuForm.oxigen = 400;
                    MenuForm.magazin = 10000;
                    MenuForm.abilitate = 1;
                }
                        
                connection = new OleDbConnection(connectionString);
                command = new OleDbCommand(commandString, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    this.Close();
                    openGame();
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
            else
            {
                errorProvider1.SetError(l1, "Este necesară alegerea unei nave!");
                errorProvider2.SetError(l2, "Este necesară alegerea unei nave!");
                errorProvider3.SetError(l3, "Este necesară alegerea unei nave!");
                errorProvider4.SetError(l4, "Este necesară alegerea unei nave!");
                errorProvider5.SetError(l5, "Este necesară alegerea unei nave!");
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            l1.ForeColor = Color.Crimson;
            if (l2.ForeColor == Color.Crimson)
                l2.ForeColor = Color.White;
            if (l3.ForeColor == Color.Crimson)
                l3.ForeColor = Color.White;
            if (l4.ForeColor == Color.Crimson)
                l4.ForeColor = Color.White;
            if (l5.ForeColor == Color.Crimson)
                l5.ForeColor = Color.White;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            l4.ForeColor = Color.Crimson;
            if (l2.ForeColor == Color.Crimson)
                l2.ForeColor = Color.White;
            if (l3.ForeColor == Color.Crimson)
                l3.ForeColor = Color.White;
            if (l1.ForeColor == Color.Crimson)
                l1.ForeColor = Color.White;
            if (l5.ForeColor == Color.Crimson)
                l5.ForeColor = Color.White;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            l5.ForeColor = Color.Crimson;
            if (l2.ForeColor == Color.Crimson)
                l2.ForeColor = Color.White;
            if (l3.ForeColor == Color.Crimson)
                l3.ForeColor = Color.White;
            if (l4.ForeColor == Color.Crimson)
                l4.ForeColor = Color.White;
            if (l1.ForeColor == Color.Crimson)
                l1.ForeColor = Color.White;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            l2.ForeColor = Color.Crimson;
            if (l1.ForeColor == Color.Crimson)
                l1.ForeColor = Color.White;
            if (l3.ForeColor == Color.Crimson)
                l3.ForeColor = Color.White;
            if (l4.ForeColor == Color.Crimson)
                l4.ForeColor = Color.White;
            if (l5.ForeColor == Color.Crimson)
                l5.ForeColor = Color.White;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            l3.ForeColor = Color.Crimson;
            if (l2.ForeColor == Color.Crimson)
                l2.ForeColor = Color.White;
            if (l1.ForeColor == Color.Crimson)
                l1.ForeColor = Color.White;
            if (l4.ForeColor == Color.Crimson)
                l4.ForeColor = Color.White;
            if (l5.ForeColor == Color.Crimson)
                l5.ForeColor = Color.White;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Ajutor.docx");
        }
    }
}
