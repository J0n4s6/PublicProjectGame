namespace ProjectGame.Forms
{
    partial class InstructionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructionsForm));
            this.backButton = new System.Windows.Forms.Button();
            this.KeyboardBox1 = new System.Windows.Forms.PictureBox();
            this.KeyboardBox2 = new System.Windows.Forms.PictureBox();
            this.SkillzBox = new System.Windows.Forms.PictureBox();
            this.TextLabel = new System.Windows.Forms.Label();
            this.ConsumableBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.KeyboardBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyboardBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkillzBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsumableBox)).BeginInit();
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
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(712, 431);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(175, 58);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            this.backButton.MouseEnter += new System.EventHandler(this.backButton_MouseEnter);
            this.backButton.MouseLeave += new System.EventHandler(this.backButton_MouseLeave);
            // 
            // KeyboardBox1
            // 
            this.KeyboardBox1.BackgroundImage = global::ProjectGame.GameResources.MoveKeyboardKeys;
            this.KeyboardBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.KeyboardBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.KeyboardBox1.Location = new System.Drawing.Point(439, 375);
            this.KeyboardBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.KeyboardBox1.Name = "KeyboardBox1";
            this.KeyboardBox1.Size = new System.Drawing.Size(209, 114);
            this.KeyboardBox1.TabIndex = 2;
            this.KeyboardBox1.TabStop = false;
            // 
            // KeyboardBox2
            // 
            this.KeyboardBox2.BackgroundImage = global::ProjectGame.GameResources.SkillsKeyboardKeys;
            this.KeyboardBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.KeyboardBox2.Location = new System.Drawing.Point(671, 12);
            this.KeyboardBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.KeyboardBox2.Name = "KeyboardBox2";
            this.KeyboardBox2.Size = new System.Drawing.Size(216, 390);
            this.KeyboardBox2.TabIndex = 3;
            this.KeyboardBox2.TabStop = false;
            // 
            // SkillzBox
            // 
            this.SkillzBox.BackgroundImage = global::ProjectGame.GameResources.SkillExplanings;
            this.SkillzBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SkillzBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SkillzBox.Location = new System.Drawing.Point(13, 323);
            this.SkillzBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SkillzBox.Name = "SkillzBox";
            this.SkillzBox.Size = new System.Drawing.Size(380, 166);
            this.SkillzBox.TabIndex = 4;
            this.SkillzBox.TabStop = false;
            // 
            // TextLabel
            // 
            this.TextLabel.AutoSize = true;
            this.TextLabel.BackColor = System.Drawing.Color.Transparent;
            this.TextLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TextLabel.Location = new System.Drawing.Point(14, 14);
            this.TextLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(671, 242);
            this.TextLabel.TabIndex = 5;
            this.TextLabel.Text = resources.GetString("TextLabel.Text");
            // 
            // ConsumableBox
            // 
            this.ConsumableBox.BackColor = System.Drawing.Color.Transparent;
            this.ConsumableBox.BackgroundImage = global::ProjectGame.GameResources.Consumables_Value;
            this.ConsumableBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConsumableBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConsumableBox.Location = new System.Drawing.Point(534, 228);
            this.ConsumableBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ConsumableBox.Name = "ConsumableBox";
            this.ConsumableBox.Size = new System.Drawing.Size(114, 119);
            this.ConsumableBox.TabIndex = 6;
            this.ConsumableBox.TabStop = false;
            // 
            // InstructionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProjectGame.GameResources.MenuBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(900, 501);
            this.ControlBox = false;
            this.Controls.Add(this.KeyboardBox2);
            this.Controls.Add(this.ConsumableBox);
            this.Controls.Add(this.TextLabel);
            this.Controls.Add(this.SkillzBox);
            this.Controls.Add(this.KeyboardBox1);
            this.Controls.Add(this.backButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "InstructionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InstructionsForm";
            ((System.ComponentModel.ISupportInitialize)(this.KeyboardBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyboardBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkillzBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsumableBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.PictureBox KeyboardBox1;
        private System.Windows.Forms.PictureBox KeyboardBox2;
        private System.Windows.Forms.PictureBox SkillzBox;
        private System.Windows.Forms.Label TextLabel;
        private System.Windows.Forms.PictureBox ConsumableBox;
    }
}