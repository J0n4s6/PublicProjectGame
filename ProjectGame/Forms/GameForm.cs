using System;
using System.Windows.Forms;
using ProjectGame.Classes;
using System.Diagnostics;

namespace ProjectGame.Forms
{

    public partial class GameForm:Form
    {
        #region properties
        private Stopwatch watchagonnado;
        private ShowOffForm showoff;
        private MenuForm menu;
        private CharacterSelectForm characterselect;
        private Manager mymanager;

      
        //-----------------------------------חיים ומאנה-----------------------
        private Timer showscoreTimer;
        private Timer changehealthandmanaTimer;
        private double playerPercentHealth, playerPercentMana;//אחוז החיים של השחקן העכשוי והעדכני
        private double currentHealth, currentMana;//אחוז החיים המופיע בממשק ברגע זה
        #endregion properties
        //-----------------------------------------------------------------------------
        public GameForm(ShowOffForm sh, MenuForm me, CharacterSelectForm ch, CharacterType ty)
        {
            InitializeComponent();
            this.showoff = sh;
            this.menu = me;
            this.characterselect = ch;

            this.watchagonnado = new Stopwatch();
            this.watchagonnado.Start();
            this.timeLabel.Parent = this.arenaBox;
            this.scoreLabel.Parent = this.arenaBox;
            this.textLabel.Parent = this.arenaBox;
            //-----------------------------------------manager----------------------------
            this.mymanager = new Manager(ty);
            this.mymanager.GetPercentageHealth += Mymanager_GetPercentageHealth;
            this.mymanager.GetPercentageMana += Mymanager_GetPercentageMana;
            this.mymanager.TotalEndGame += mymanager_TotalEndGame;
            this.mymanager.GetTime += mymanager_GetTime;
            this.mymanager.StopTime += Mymanager_StopTime;
            this.mymanager.ContinueTime += Mymanager_ContinueTime;
            this.currentHealth = 1;
            this.currentMana = 1;
            this.playerPercentHealth = 1;
            this.playerPercentMana = 1;
            //---------------------------------------timer-----------------------------------
            this.changehealthandmanaTimer = new Timer();
            this.changehealthandmanaTimer.Enabled = true;
            this.changehealthandmanaTimer.Interval = 1;
            this.changehealthandmanaTimer.Tick += ChangehealthandmanaTimer_Tick;

            this.showscoreTimer = new Timer();
            this.showscoreTimer.Interval = 1;
            this.showscoreTimer.Enabled = true;
            this.showscoreTimer.Tick += showscoreTimer_Tick;
        }

        public ProjectGame.Classes.Manager Manager
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public PauseForm PauseForm
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public GameOverForm GameOverForm
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private void Mymanager_ContinueTime(object sender, EventArgs e)
        {
            this.watchagonnado.Start();
        }

        private void Mymanager_StopTime(object sender, EventArgs e)
        {
            this.watchagonnado.Stop();
        }

        void showscoreTimer_Tick(object sender, EventArgs e)
        {
            this.scoreLabel.Text = this.mymanager.GetScore().ToString();
        }

        void mymanager_GetTime(object sender, EventArgs e)
        {
            this.mymanager.SendStopWatch(this.watchagonnado);
            this.watchagonnado = new Stopwatch();
            this.watchagonnado.Start();
        }


        void mymanager_TotalEndGame(int sc1, int sc2, int sc3, int sc4)
        {
            GameOverForm gameover = new GameOverForm(this.showoff, this.menu, sc1, sc2, sc3, sc4, this.mymanager.GetPlayerType());
            gameover.Show();
            this.Hide();
        }
              

        #region buttons
        private void backButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            backButton.BackgroundImage = GameResources.BackButton2;
        }

        private void backButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            backButton.BackgroundImage = GameResources.BackButton1;
        }

        private void pauseButton_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            pauseButton.BackgroundImage = GameResources.PauseButton2;
        }

        private void pauseButton_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            pauseButton.BackgroundImage = GameResources.PauseButton1;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.characterselect = new CharacterSelectForm(this.showoff, this.menu);
            this.characterselect.Show();
            this.Close();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {

            Forms.PauseForm pause = new PauseForm(this.mymanager,this);
            pause.Show();
            this.mymanager.StopAllElements();
            this.Hide();
        }
        #endregion buttons

        #region events
        private void arenaBox_Paint(object sender, PaintEventArgs e)
        {
            this.mymanager.ShowAllElements(e);
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            this.arenaBox.Refresh();
            this.timeLabel.Text = this.watchagonnado.Elapsed.ToString("mm\\:ss\\:ff");
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            this.mymanager.StopCharacter(e.KeyCode);

        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            this.mymanager.MoveCharacter(e.KeyCode);
        }
        #endregion events

        #region health & mana
        private void Mymanager_GetPercentageMana(double t)
        {
            if (t <= 1)
                this.playerPercentMana = t;
            else
                this.playerPercentMana = 1;
        }

        private void Mymanager_GetPercentageHealth(double t)
        {
            if (t <= 1)
                this.playerPercentHealth = t;
            else
                this.playerPercentHealth = 1;
        }
        private void ChangehealthandmanaTimer_Tick(object sender, EventArgs e)
        {
            //playerPercentHealth = Math.Round(playerPercentHealth, 2);
            //playerPercentMana = Math.Round(playerPercentMana, 2);
            //currentHealth = Math.Round(currentHealth, 2);
            //currentMana = Math.Round(currentMana, 2);

            //-------------------------------שינוי שורת חיים------------------------                            
            if (currentHealth < playerPercentHealth)
            {
                this.currentHealth += 0.01;
                this.healthBar.Width += 6;
            }            
            if (currentHealth > playerPercentHealth)
            {
                this.currentHealth -= 0.01;
                this.healthBar.Width -= 6;
            }
            //---------------------------שינוי שורת מאנה-------------------------------
            if (currentMana < playerPercentMana)
            {
                this.currentMana += 0.01;
                this.manaBar.Width += 6;
            }
            if (currentMana > playerPercentMana)
            {
                this.currentMana -= 0.01;
                this.manaBar.Width -= 6;
            }
        }
        #endregion health & mana

    

    }
}
