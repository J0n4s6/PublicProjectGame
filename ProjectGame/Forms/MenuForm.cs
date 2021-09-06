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
    public partial class MenuForm :Form
    {
        private ShowOffForm showoff;
        //--------------------------------------------------------------
        public MenuForm(ShowOffForm sh)
        {
            InitializeComponent();
            this.showoff = sh;
        }

        public HighscoresForm HighscoresForm
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

        public CharacterSelectForm CharacterSelectForm
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        #region buttons
        private void backButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            backButton.BackgroundImage = GameResources.BaseButton2;
        }

        private void backButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            backButton.BackgroundImage = GameResources.BaseButton1;
        }

        private void instructionsButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            instructionsButton.BackgroundImage = GameResources.BaseButton2;
        }

        private void instructionsButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            instructionsButton.BackgroundImage = GameResources.BaseButton1;
        }

        private void highscoresButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            highscoresButton.BackgroundImage = GameResources.BaseButton2;
        }

        private void highscoresButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            highscoresButton.BackgroundImage = GameResources.BaseButton1;
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
        

        private void backButton_Click(object sender, EventArgs e)
        {
            showoff.Show();
            this.Close();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Forms.CharacterSelectForm characterselect = new Forms.CharacterSelectForm(this.showoff, this);
            characterselect.Show();
            this.Close();
        }
        #endregion buttons

        private void highscoresButton_Click(object sender, EventArgs e)
        {
            Forms.HighscoresForm highscores = new Forms.HighscoresForm(this.showoff, this);
            highscores.Show();
            this.Close();
        }

        private void instructionsButton_Click(object sender, EventArgs e)
        {
            Forms.InstructionsForm instructions = new Forms.InstructionsForm(this.showoff, this);
            instructions.Show();
            this.Close();
        }
    }
}
