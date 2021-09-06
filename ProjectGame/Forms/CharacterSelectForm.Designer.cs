using System;

namespace ProjectGame.Forms
{
    partial class CharacterSelectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterSelectForm));
            this.backButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.warriorButton = new System.Windows.Forms.Button();
            this.mageButton = new System.Windows.Forms.Button();
            this.archerButton = new System.Windows.Forms.Button();
            this.warriorLabel = new System.Windows.Forms.Label();
            this.mageLabel = new System.Windows.Forms.Label();
            this.archerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.BackgroundImage = global::ProjectGame.GameResources.BaseButton1;
            this.backButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.backButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(722, 400);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(150, 50);
            this.backButton.TabIndex = 4;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            this.backButton.MouseEnter += new System.EventHandler(this.backButton_MouseEnter);
            this.backButton.MouseLeave += new System.EventHandler(this.backButton_MouseLeave);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Transparent;
            this.startButton.BackgroundImage = global::ProjectGame.GameResources.BaseButton1;
            this.startButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.startButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.startButton.ForeColor = System.Drawing.Color.White;
            this.startButton.Location = new System.Drawing.Point(566, 400);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(150, 50);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start!";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            this.startButton.MouseEnter += new System.EventHandler(this.startButton_MouseEnter);
            this.startButton.MouseLeave += new System.EventHandler(this.startButton_MouseLeave);
            // 
            // warriorButton
            // 
            this.warriorButton.BackColor = System.Drawing.Color.Transparent;
            this.warriorButton.BackgroundImage = global::ProjectGame.GameResources.WarriorFront;
            this.warriorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.warriorButton.FlatAppearance.BorderSize = 0;
            this.warriorButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.warriorButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.warriorButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.warriorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.warriorButton.Location = new System.Drawing.Point(154, 178);
            this.warriorButton.Name = "warriorButton";
            this.warriorButton.Size = new System.Drawing.Size(94, 112);
            this.warriorButton.TabIndex = 6;
            this.warriorButton.UseVisualStyleBackColor = false;
            this.warriorButton.Click += new System.EventHandler(this.warriorButton_Click);
            this.warriorButton.MouseEnter += new System.EventHandler(this.warriorButton_MouseEnter);
            this.warriorButton.MouseLeave += new System.EventHandler(this.warriorButton_MouseLeave);
            // 
            // mageButton
            // 
            this.mageButton.BackColor = System.Drawing.Color.Transparent;
            this.mageButton.BackgroundImage = global::ProjectGame.GameResources.MageFront;
            this.mageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mageButton.FlatAppearance.BorderSize = 0;
            this.mageButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.mageButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mageButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mageButton.Location = new System.Drawing.Point(382, 125);
            this.mageButton.Name = "mageButton";
            this.mageButton.Size = new System.Drawing.Size(100, 145);
            this.mageButton.TabIndex = 7;
            this.mageButton.UseVisualStyleBackColor = false;
            this.mageButton.Click += new System.EventHandler(this.mageButton_Click);
            this.mageButton.MouseEnter += new System.EventHandler(this.mageButton_MouseEnter);
            this.mageButton.MouseLeave += new System.EventHandler(this.mageButton_MouseLeave);
            // 
            // archerButton
            // 
            this.archerButton.BackColor = System.Drawing.Color.Transparent;
            this.archerButton.BackgroundImage = global::ProjectGame.GameResources.ArcherFront;
            this.archerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.archerButton.FlatAppearance.BorderSize = 0;
            this.archerButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.archerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.archerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.archerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.archerButton.Location = new System.Drawing.Point(626, 176);
            this.archerButton.Name = "archerButton";
            this.archerButton.Size = new System.Drawing.Size(111, 114);
            this.archerButton.TabIndex = 8;
            this.archerButton.UseVisualStyleBackColor = false;
            this.archerButton.Click += new System.EventHandler(this.archerButton_Click);
            this.archerButton.MouseEnter += new System.EventHandler(this.archerButton_MouseEnter);
            this.archerButton.MouseLeave += new System.EventHandler(this.archerButton_MouseLeave);
            // 
            // warriorLabel
            // 
            this.warriorLabel.AutoSize = true;
            this.warriorLabel.BackColor = System.Drawing.Color.Transparent;
            this.warriorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.warriorLabel.ForeColor = System.Drawing.Color.White;
            this.warriorLabel.Location = new System.Drawing.Point(169, 350);
            this.warriorLabel.Name = "warriorLabel";
            this.warriorLabel.Size = new System.Drawing.Size(67, 20);
            this.warriorLabel.TabIndex = 9;
            this.warriorLabel.Text = "Warrior";
            // 
            // mageLabel
            // 
            this.mageLabel.AutoSize = true;
            this.mageLabel.BackColor = System.Drawing.Color.Transparent;
            this.mageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.mageLabel.ForeColor = System.Drawing.Color.White;
            this.mageLabel.Location = new System.Drawing.Point(405, 317);
            this.mageLabel.Name = "mageLabel";
            this.mageLabel.Size = new System.Drawing.Size(53, 20);
            this.mageLabel.TabIndex = 10;
            this.mageLabel.Text = "Mage";
            // 
            // archerLabel
            // 
            this.archerLabel.AutoSize = true;
            this.archerLabel.BackColor = System.Drawing.Color.Transparent;
            this.archerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.archerLabel.ForeColor = System.Drawing.Color.White;
            this.archerLabel.Location = new System.Drawing.Point(635, 350);
            this.archerLabel.Name = "archerLabel";
            this.archerLabel.Size = new System.Drawing.Size(62, 20);
            this.archerLabel.TabIndex = 11;
            this.archerLabel.Text = "Archer";
            // 
            // CharacterSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProjectGame.GameResources.MenuBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.ControlBox = false;
            this.Controls.Add(this.archerLabel);
            this.Controls.Add(this.mageLabel);
            this.Controls.Add(this.warriorLabel);
            this.Controls.Add(this.archerButton);
            this.Controls.Add(this.mageButton);
            this.Controls.Add(this.warriorButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.backButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CharacterSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select a Character!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button warriorButton;
        private System.Windows.Forms.Button mageButton;
        private System.Windows.Forms.Button archerButton;
        private System.Windows.Forms.Label warriorLabel;
        private System.Windows.Forms.Label mageLabel;
        private System.Windows.Forms.Label archerLabel;

    }
}