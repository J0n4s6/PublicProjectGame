namespace ProjectGame.Forms
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.timeLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.textLabel = new System.Windows.Forms.Label();
            this.manaBar = new System.Windows.Forms.PictureBox();
            this.backgroundBar2 = new System.Windows.Forms.PictureBox();
            this.healthBar = new System.Windows.Forms.PictureBox();
            this.backgroundBar1 = new System.Windows.Forms.PictureBox();
            this.pauseButton = new System.Windows.Forms.PictureBox();
            this.backButton = new System.Windows.Forms.PictureBox();
            this.arenaBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.manaBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pauseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arenaBox)).BeginInit();
            this.SuspendLayout();
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 1;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.White;
            this.timeLabel.Location = new System.Drawing.Point(234, 1);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(110, 29);
            this.timeLabel.TabIndex = 8;
            this.timeLabel.Text = "something";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(741, 1);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(110, 29);
            this.scoreLabel.TabIndex = 9;
            this.scoreLabel.Text = "something";
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.BackColor = System.Drawing.Color.Transparent;
            this.textLabel.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLabel.ForeColor = System.Drawing.Color.White;
            this.textLabel.Location = new System.Drawing.Point(663, 1);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(77, 29);
            this.textLabel.TabIndex = 10;
            this.textLabel.Text = "Score:";
            // 
            // manaBar
            // 
            this.manaBar.BackColor = System.Drawing.Color.Transparent;
            this.manaBar.BackgroundImage = global::ProjectGame.GameResources.ManaBar;
            this.manaBar.Location = new System.Drawing.Point(1, 437);
            this.manaBar.Name = "manaBar";
            this.manaBar.Size = new System.Drawing.Size(600, 20);
            this.manaBar.TabIndex = 6;
            this.manaBar.TabStop = false;
            // 
            // backgroundBar2
            // 
            this.backgroundBar2.BackColor = System.Drawing.Color.Transparent;
            this.backgroundBar2.BackgroundImage = global::ProjectGame.GameResources.BackgroundBar;
            this.backgroundBar2.Location = new System.Drawing.Point(1, 437);
            this.backgroundBar2.Name = "backgroundBar2";
            this.backgroundBar2.Size = new System.Drawing.Size(608, 20);
            this.backgroundBar2.TabIndex = 5;
            this.backgroundBar2.TabStop = false;
            // 
            // healthBar
            // 
            this.healthBar.BackColor = System.Drawing.Color.Transparent;
            this.healthBar.BackgroundImage = global::ProjectGame.GameResources.HealthBar;
            this.healthBar.Location = new System.Drawing.Point(1, 415);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(600, 20);
            this.healthBar.TabIndex = 4;
            this.healthBar.TabStop = false;
            // 
            // backgroundBar1
            // 
            this.backgroundBar1.BackColor = System.Drawing.Color.Transparent;
            this.backgroundBar1.BackgroundImage = global::ProjectGame.GameResources.BackgroundBar;
            this.backgroundBar1.Location = new System.Drawing.Point(1, 415);
            this.backgroundBar1.Name = "backgroundBar1";
            this.backgroundBar1.Size = new System.Drawing.Size(608, 20);
            this.backgroundBar1.TabIndex = 3;
            this.backgroundBar1.TabStop = false;
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.Color.Transparent;
            this.pauseButton.BackgroundImage = global::ProjectGame.GameResources.PauseButton1;
            this.pauseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pauseButton.Location = new System.Drawing.Point(610, 417);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(130, 40);
            this.pauseButton.TabIndex = 2;
            this.pauseButton.TabStop = false;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            this.pauseButton.MouseEnter += new System.EventHandler(this.pauseButton_MouseEnter);
            this.pauseButton.MouseLeave += new System.EventHandler(this.pauseButton_MouseLeave);
            // 
            // backButton
            // 
            this.backButton.BackgroundImage = global::ProjectGame.GameResources.BackButton1;
            this.backButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backButton.Location = new System.Drawing.Point(746, 417);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(130, 40);
            this.backButton.TabIndex = 1;
            this.backButton.TabStop = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            this.backButton.MouseEnter += new System.EventHandler(this.backButton_MouseEnter);
            this.backButton.MouseLeave += new System.EventHandler(this.backButton_MouseLeave);
            // 
            // arenaBox
            // 
            this.arenaBox.BackColor = System.Drawing.Color.Transparent;
            this.arenaBox.Location = new System.Drawing.Point(1, 1);
            this.arenaBox.Name = "arenaBox";
            this.arenaBox.Size = new System.Drawing.Size(880, 410);
            this.arenaBox.TabIndex = 0;
            this.arenaBox.TabStop = false;
            this.arenaBox.Paint += new System.Windows.Forms.PaintEventHandler(this.arenaBox_Paint);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.ControlBox = false;
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.manaBar);
            this.Controls.Add(this.backgroundBar2);
            this.Controls.Add(this.healthBar);
            this.Controls.Add(this.backgroundBar1);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.arenaBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.manaBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pauseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arenaBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox arenaBox;
        private System.Windows.Forms.PictureBox backButton;
        private System.Windows.Forms.PictureBox pauseButton;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.PictureBox backgroundBar1;
        private System.Windows.Forms.PictureBox healthBar;
        private System.Windows.Forms.PictureBox backgroundBar2;
        private System.Windows.Forms.PictureBox manaBar;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label textLabel;
    }
}