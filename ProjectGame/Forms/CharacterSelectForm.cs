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
    public partial class CharacterSelectForm : Form
    {
        private ShowOffForm showoff;
        private Forms.MenuForm menu;
        private CharacterType type;
        //--------------------------------------------------------------------------------------
        public CharacterSelectForm(ShowOffForm sh,Forms.MenuForm me)
        {
            InitializeComponent();
            this.type = CharacterType.none;
            this.showoff = sh;
            this.menu = me;
        }

        public GameForm GameForm
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

        private void startButton_MouseEnter(object sender, EventArgs e)
        {
            if (this.type != CharacterType.none)
            {
                this.Cursor = Cursors.Hand;
                startButton.BackgroundImage = GameResources.BaseButton2;
            }
        }

        private void startButton_MouseLeave(object sender, EventArgs e)
        {
            if (this.type != CharacterType.none)
            {
                this.Cursor = Cursors.Default;
                startButton.BackgroundImage = GameResources.BaseButton1;
            }
        }

        private void warriorButton_MouseEnter(object sender, EventArgs e)
        {
            warriorButton.Location = new Point(warriorButton.Location.X - 10, warriorButton.Location.Y - 10);
            warriorButton.Width += 20;
            warriorButton.Height += 20;
        }

        private void warriorButton_MouseLeave(object sender, EventArgs e)
        {
            warriorButton.Location = new Point(warriorButton.Location.X + 10, warriorButton.Location.Y + 10);
            warriorButton.Width -= 20;
            warriorButton.Height -= 20;
        }

        private void mageButton_MouseEnter(object sender, EventArgs e)
        {
            mageButton.Location = new Point(mageButton.Location.X - 10, mageButton.Location.Y - 10);
            mageButton.Width += 20;
            mageButton.Height += 20;
        }

        private void mageButton_MouseLeave(object sender, EventArgs e)
        {
            mageButton.Location = new Point(mageButton.Location.X + 10, mageButton.Location.Y + 10);
            mageButton.Width -= 20;
            mageButton.Height -= 20;
        }

        private void archerButton_MouseEnter(object sender, EventArgs e)
        {
            archerButton.Location = new Point(archerButton.Location.X - 10, archerButton.Location.Y - 10);
            archerButton.Width += 20;
            archerButton.Height += 20;
        }

        private void archerButton_MouseLeave(object sender, EventArgs e)
        {
            archerButton.Location = new Point(archerButton.Location.X + 10, archerButton.Location.Y + 10);
            archerButton.Width -= 20;
            archerButton.Height -= 20;
        }


        private void warriorButton_Click(object sender, EventArgs e)
        {
            this.warriorLabel.ForeColor = Color.OrangeRed;
            if (this.type == CharacterType.archer || this.type == CharacterType.mage || this.type == CharacterType.none)
            {
                this.archerLabel.ForeColor = Color.White;
                this.mageLabel.ForeColor = Color.White;
            }
            this.type = CharacterType.warrior;
        }

        private void mageButton_Click(object sender, EventArgs e)
        {
            this.mageLabel.ForeColor = Color.OrangeRed;
            if (this.type == CharacterType.archer || this.type == CharacterType.warrior || this.type == CharacterType.none)
            {
                this.archerLabel.ForeColor = Color.White;
                this.warriorLabel.ForeColor = Color.White;
            }
            this.type = CharacterType.mage;
        }

        private void archerButton_Click(object sender, EventArgs e)
        {
            this.archerLabel.ForeColor = Color.OrangeRed;
            if (this.type == CharacterType.warrior || this.type == CharacterType.mage || this.type == CharacterType.none)
            {
                this.warriorLabel.ForeColor = Color.White;
                this.mageLabel.ForeColor = Color.White;
            }
            this.type = CharacterType.archer;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.menu = new Forms.MenuForm(this.showoff);
            this.menu.Show();
            this.Close();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (this.type != CharacterType.none)
            {
                Forms.GameForm game = new GameForm(this.showoff, this.menu, this, this.type);
                game.Show();
                this.Close();
            }
        }
        #endregion buttons

    }    
}
public enum CharacterType//כל סוגי הדמויות הקיימים
{
    warrior,mage,archer,none,bluepig,redpig,blueshroom,greyshroom,greenshroom,orangeshroom,bluesnail,redsnail,purplesnail,
}
