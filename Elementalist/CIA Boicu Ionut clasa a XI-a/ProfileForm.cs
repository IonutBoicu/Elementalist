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
    public partial class ProfileForm : Form
    {

        public static OleDbConnection connection;
        public static OleDbDataReader dataReader;
        public static OleDbCommand command;
        public static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;
                                                  Data Source=Profiledb.mdb";
        public static string commandString = "";

        public static string usrName = "";
        public static string pass;
        public static string nava = "";
        public static string scena = "";
        public static string oxigen = "";
        public static string magazin = "";


        public ProfileForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            textBoxUser.Text = "";
            textBoxPass.Text = "";
            textBoxUser.Focus();
        }

        private bool validatingInput()
        {
            usrName = textBoxUser.Text.Trim();
            pass = textBoxPass.Text.Trim();
            if (usrName == "")
            {
                errorProvider1.SetError(textBoxUser, "Este obligatorie umplerea acestui câmp!");
                textBoxUser.Focus();
                return false;
            }
            else
                errorProvider1.SetError(textBoxUser, "");

            if (pass == "")
            {
                errorProvider2.SetError(textBoxPass, "Este obligatorie umplerea acestui câmp!");
                textBoxPass.Focus();
                return false;
            }
            else
                errorProvider2.SetError(textBoxPass, "");
            return true;
        }

        private int findUserPass()
        {
            commandString = "SELECT * FROM Table1";
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand(commandString, connection);
            try
            {
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    if (dataReader[0].ToString().ToLower() == usrName.ToLower() &&
                       dataReader[1].ToString() == pass && dataReader[3].ToString() != "")
                        return 3;
                    else if (dataReader[0].ToString().ToLower() == usrName.ToLower() &&
                        dataReader[1].ToString() == pass && dataReader[2].ToString() != "")
                        return 1;
                    else if ((dataReader[0].ToString().ToLower() == usrName.ToLower() &&
                        dataReader[1].ToString() == pass))
                        return 2;
                }
                return 0;
            }
            catch (OleDbException exc)
            {
                MessageBox.Show("Error! " + exc.Message);
                return 0;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private bool findUser()
        {
            commandString = "SELECT * FROM Table1";
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand(commandString, connection);
            try
            {
                connection.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    if (dataReader[0].ToString().ToLower() == usrName.ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (OleDbException exc)
            {
                MessageBox.Show("Eroare! " + exc.Message);
                return true;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void addUser()
        {
            commandString = @"INSERT INTO Table1  (Nume,Parola) 
                              VALUES('" + usrName + "', '" + pass + "')";
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand(commandString, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Profil adaugat!");
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

        private void openMenu()
        {
                FirstLookForm.formMenu.Show();
            
        }

        private void openPlay()
        {
                FirstLookForm.formPlay.Show();
        }

        private void openGame()
        {
                FirstLookForm.formGame.Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (validatingInput())
            {
                if (findUser() == true)
                {
                    int x = findUserPass();
                    if (x == 1)
                    {
                        this.Close();
                        openGame();
                    }
                    else if (x == 2)
                    {
                        this.Close();
                        openMenu();
                    }

                    else if (x == 3)
                    {
                        this.Close();
                        openPlay();
                    }
                    if (x == 0)
                    {
                        MessageBox.Show("Parola greșită!");
                        usrName = "";
                    }
                }
                else MessageBox.Show("Profil inexistent!");
            }
                    
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            if (validatingInput())
                if (!findUser())
                    addUser();      
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Ajutor.docx");
        }

    }
}
