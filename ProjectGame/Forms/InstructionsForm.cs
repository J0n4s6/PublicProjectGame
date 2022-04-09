using System;
using System.Windows.Forms;

namespace ProjectGame.Forms
{
    public partial class InstructionsForm : Form
    {
        private ShowOffForm showoff;
        private MenuForm menu;
        //-----------------------------------------------
        public InstructionsForm(ShowOffForm sh, MenuForm me)
        {
            InitializeComponent();
            this.showoff = sh;
            this.menu = me;

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
