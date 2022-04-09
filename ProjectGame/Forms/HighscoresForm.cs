using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ProjectGame.Classes;

namespace ProjectGame.Forms
{
    public partial class HighscoresForm : Form
    {
        private ShowOffForm showoff;
        private Forms.MenuForm menu;
        private List<PlayerFile> players;
        //----------------------------------------------------------------
        public HighscoresForm(ShowOffForm sh, Forms.MenuForm me)
        {
            InitializeComponent();
            this.showoff = sh;
            this.menu = me;
            this.players = FileOperation.LoadPlayer();
            #region נתונים
            if (this.players != null)
            {
                if (this.players.Count >= 1)
                {
                    this.Name1.Text = this.players[0].name;
                    this.Name1.ForeColor = Color.Gray;
                    this.Score1Lvl1.Text = this.players[0].score1.ToString();
                    this.Score1Lvl2.Text = this.players[0].score2.ToString();
                    this.Score1Lvl3.Text = this.players[0].score3.ToString();
                    this.Score1Lvl4.Text = this.players[0].score4.ToString();
                    this.TotalScore1.Text = this.players[0].totalscore.ToString();
                    this.TotalScore1.ForeColor = Color.Gray;
                    switch (this.players[0].champ)
                    {
                        case "Archer":
                            this.Champ1.Text = "Archer";
                            this.Champ1.ForeColor = Color.Green;
                            break;
                        case "Mage":
                            this.Champ1.Text = "Mage";
                            this.Champ1.ForeColor = Color.Purple;
                            break;
                        case "Warrior":
                            this.Champ1.Text = "Warrior";
                            this.Champ1.ForeColor = Color.Red;
                            break;
                        default: this.Champ1.Text = "NO"; break;
                    }

                }
                if (this.players.Count >= 2)
                {
                    this.Name2.Text = this.players[1].name;
                    this.Name2.ForeColor = Color.Gray;

                    this.Score2Lvl1.Text = this.players[1].score1.ToString();
                    this.Score2Lvl2.Text = this.players[1].score2.ToString();
                    this.Score2Lvl3.Text = this.players[1].score3.ToString();
                    this.Score2Lvl4.Text = this.players[1].score4.ToString();
                    this.TotalScore2.Text = this.players[1].totalscore.ToString();
                    this.TotalScore2.ForeColor = Color.Gray;

                    switch (this.players[1].champ)
                    {
                        case "Archer":
                            this.Champ2.Text = "Archer";
                            this.Champ2.ForeColor = Color.Green;
                            break;
                        case "Mage":
                            this.Champ2.Text = "Mage";
                            this.Champ2.ForeColor = Color.Purple;
                            break;
                        case "Warrior":
                            this.Champ2.Text = "Warrior";
                            this.Champ2.ForeColor = Color.Red;
                            break;
                        default: this.Champ2.Text = "NO"; break;
                    }

                }
                if (this.players.Count >= 3)
                {
                    this.Name3.Text = this.players[2].name;
                    this.Name3.ForeColor = Color.Gray;

                    this.Score3Lvl1.Text = this.players[2].score1.ToString();
                    this.Score3Lvl2.Text = this.players[2].score2.ToString();
                    this.Score3Lvl3.Text = this.players[2].score3.ToString();
                    this.Score3Lvl4.Text = this.players[2].score4.ToString();
                    this.TotalScore3.Text = this.players[2].totalscore.ToString();
                    this.TotalScore3.ForeColor = Color.Gray;

                    switch (this.players[2].champ)
                    {
                        case "Archer":
                            this.Champ3.Text = "Archer";
                            this.Champ3.ForeColor = Color.Green;
                            break;
                        case "Mage":
                            this.Champ3.Text = "Mage";
                            this.Champ3.ForeColor = Color.Purple;
                            break;
                        case "Warrior":
                            this.Champ3.Text = "Warrior";
                            this.Champ3.ForeColor = Color.Red;
                            break;
                        default: this.Champ3.Text = "NO"; break;
                    }

                }
                if (this.players.Count >= 4)
                {
                    this.Name4.Text = this.players[3].name;
                    this.Name4.ForeColor = Color.Gray;

                    this.Score4Lvl1.Text = this.players[3].score1.ToString();
                    this.Score4Lvl2.Text = this.players[3].score2.ToString();
                    this.Score4Lvl3.Text = this.players[3].score3.ToString();
                    this.Score4Lvl4.Text = this.players[3].score4.ToString();
                    this.TotalScore4.Text = this.players[3].totalscore.ToString();
                    this.TotalScore4.ForeColor = Color.Gray;

                    switch (this.players[3].champ)
                    {
                        case "Archer":
                            this.Champ4.Text = "Archer";
                            this.Champ4.ForeColor = Color.Green;
                            break;
                        case "Mage":
                            this.Champ4.Text = "Mage";
                            this.Champ4.ForeColor = Color.Purple;
                            break;
                        case "Warrior":
                            this.Champ4.Text = "Warrior";
                            this.Champ4.ForeColor = Color.Red;
                            break;
                        default: this.Champ4.Text = "NO"; break;
                    }

                }
                if (this.players.Count >= 5)
                {
                    this.Name5.Text = this.players[4].name;
                    this.Name5.ForeColor = Color.Gray;
                    this.Score5Lvl1.Text = this.players[4].score1.ToString();
                    this.Score5Lvl2.Text = this.players[4].score2.ToString();
                    this.Score5Lvl3.Text = this.players[4].score3.ToString();
                    this.Score5Lvl4.Text = this.players[4].score4.ToString();
                    this.TotalScore5.Text = this.players[4].totalscore.ToString();
                    this.TotalScore5.ForeColor = Color.Gray;

                    switch (this.players[4].champ)
                    {
                        case "Archer":
                            this.Champ5.Text = "Archer";
                            this.Champ5.ForeColor = Color.Green;
                            break;
                        case "Mage":
                            this.Champ5.Text = "Mage";
                            this.Champ5.ForeColor = Color.Purple;
                            break;
                        case "Warrior":
                            this.Champ5.Text = "Warrior";
                            this.Champ5.ForeColor = Color.Red;
                            break;
                        default: this.Champ5.Text = "NO"; break;
                    }

                }
            }
            #endregion נתונים

        }

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

        private void backButton_Click(object sender, EventArgs e)
        {
            this.menu = new MenuForm(this.showoff);
            this.menu.Show();
            this.Close();
        }
    }
}
