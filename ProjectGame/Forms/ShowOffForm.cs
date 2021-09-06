using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectGame
{
    public partial class ShowOffForm : Form
    {
        private Timer gamenameTimer;
        private int currentindexpicture;
        private Image[] names;
        //----------------
        public ShowOffForm()
        {
            InitializeComponent();
            this.currentindexpicture = 0;
            this.gamenameTimer = new Timer();
            this.gamenameTimer.Enabled = true;
            this.gamenameTimer.Interval = 50;
            this.gamenameTimer.Tick += GamenameTimer_Tick;
            this.names = new Image[22];
            this.names[0] = GameResources._0;
            this.names[1] = GameResources._1;
            this.names[2] = GameResources._2;
            this.names[3] = GameResources._3;
            this.names[4] = GameResources._4;
            this.names[5] = GameResources._5;
            this.names[6] = GameResources._6;
            this.names[7] = GameResources._7;
            this.names[8] = GameResources._8;
            this.names[9] = GameResources._9;
            this.names[10] = GameResources._10;
            this.names[11] = GameResources._11;
            this.names[12] = GameResources._12;
            this.names[13] = GameResources._13;
            this.names[14] = GameResources._14;
            this.names[15] = GameResources._15;
            this.names[16] = GameResources._16;
            this.names[17] = GameResources._17;
            this.names[18] = GameResources._18;
            this.names[19] = GameResources._19;
            this.names[20] = GameResources._20;
            this.names[21] = GameResources._21;


        }

        public ProjectGame.Forms.MenuForm MenuForm
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private void GamenameTimer_Tick(object sender, EventArgs e)
        {
            this.currentindexpicture++;
            if (this.currentindexpicture == 22)
                this.currentindexpicture = 0;
        }

        private void launchButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            launchButton.BackgroundImage = GameResources.LaunchButton2;
        }

        private void launchButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            launchButton.BackgroundImage = GameResources.LaunchButton1;
        }

        private void exitButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            exitButton.BackgroundImage = GameResources.BaseButton2;
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            exitButton.BackgroundImage = GameResources.BaseButton1;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            SoundPlayer lolsound = new SoundPlayer(Sounds.LoL_Button);
            lolsound.Play();
            Forms.MenuForm menu = new Forms.MenuForm(this);
            menu.Show();
            this.Hide();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            this.pictureBox.Refresh();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(this.names[this.currentindexpicture], new Point(150, 100));
        }
    }
}
