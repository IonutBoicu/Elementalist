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
    public partial class GameOverForm : Form
    {
        public GameOverForm()
        {
            InitializeComponent();
        }

        private void GameOverForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Ai ramas fară oxigen și ai pierdut");
            Process pr = Process.GetCurrentProcess();
            pr.Kill();
        }
    }
}
