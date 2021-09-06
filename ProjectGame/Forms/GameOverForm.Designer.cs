namespace ProjectGame.Forms
{
    partial class GameOverForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOverForm));
            this.continueButton = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.instructLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.Color.Transparent;
            this.continueButton.BackgroundImage = global::ProjectGame.GameResources.BaseButton1;
            this.continueButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.continueButton.FlatAppearance.BorderSize = 0;
            this.continueButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.continueButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.continueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.continueButton.ForeColor = System.Drawing.Color.White;
            this.continueButton.Location = new System.Drawing.Point(722, 400);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(150, 50);
            this.continueButton.TabIndex = 2;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            this.continueButton.MouseEnter += new System.EventHandler(this.continueButton_MouseEnter);
            this.continueButton.MouseLeave += new System.EventHandler(this.continueButton_MouseLeave);
            // 
            // nameBox
            // 
            this.nameBox.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameBox.Location = new System.Drawing.Point(344, 277);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(186, 37);
            this.nameBox.TabIndex = 3;
            // 
            // instructLabel
            // 
            this.instructLabel.BackColor = System.Drawing.Color.Transparent;
            this.instructLabel.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructLabel.Location = new System.Drawing.Point(321, 144);
            this.instructLabel.Name = "instructLabel";
            this.instructLabel.Size = new System.Drawing.Size(252, 61);
            this.instructLabel.TabIndex = 4;
            this.instructLabel.Text = "Please write your name in the box bellow ;)";
            // 
            // GameOverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProjectGame.GameResources.MenuBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.instructLabel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.continueButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameOverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameOverForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label instructLabel;
    }
}