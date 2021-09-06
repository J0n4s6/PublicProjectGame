using ProjectGame.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectGame.Forms
{
     public partial class PauseForm : Form
    {
         private Manager mymanager;
         private GameForm gameform;
        //-----------------------------------------------------------
        public PauseForm(Manager ma,GameForm ga)
        {
            //
            InitializeComponent();
            this.mymanager = ma;
            this.gameform = ga;
        }

        private void playButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            playButton.BackgroundImage = GameResources.BaseButton2;
        }

        private void playButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            playButton.BackgroundImage = GameResources.BaseButton1;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            this.mymanager.ContinueAllElements();
            this.gameform.Show();
            this.Close();
        }
    }
}
