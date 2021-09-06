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
    public partial class GameOverForm : Form
    {
        private ShowOffForm showoff;
        private MenuForm menu;
        private int score1, score2, score3, score4;
        private string champ;
        //----------------------------------
        public GameOverForm(ShowOffForm sh,MenuForm me,int score1,int score2,int score3,int score4,string champ)
        {
            InitializeComponent();
            this.showoff = sh;
            this.menu = me;
            this.score1 = score1;
            this.score2 = score2;
            this.score3 = score3;
            this.score4 = score4;
            this.champ = champ;
        }

        public ProjectGame.Classes.PlayerFile PlayerFile
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public InstructionsForm InstructionsForm
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            if (this.nameBox.Text.Count() < 2 || this.nameBox.Text.Count() > 15)
            {
                MessageBox.Show("Please intput a name that has between two to fifteen letters");
                this.nameBox.Text = "";
            }
            else
            {
                FileOperation.SavePlayer(nameBox.Text, this.score1, this.score2, this.score3, this.score4, this.champ);
                HighscoresForm highscores = new HighscoresForm(this.showoff, this.menu);
                highscores.Show();
                this.Close();
            }
        }

        private void continueButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            continueButton.BackgroundImage = GameResources.BaseButton2;
        }

        private void continueButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            continueButton.BackgroundImage = GameResources.BaseButton1;
        }
    }
}
