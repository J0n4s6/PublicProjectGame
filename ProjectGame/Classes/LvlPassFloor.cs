using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectGame.Classes
{
    class LvlPassFloor : Floor
    {
        /// <summary>
        /// ריצפה 
        /// </summary>
        private Floor floor;
        /// <summary>
        /// מערך תמונות המעבר שלב
        /// </summary>
        private Image[] images;
        /// <summary>
        /// טיימר החלפת תמונות
        /// </summary>
        private Timer changepictureTimer;
        /// <summary>
        /// אינדקס לתמונה העכשוית
        /// </summary>
        private int currentindexpicture;
        //----------------------------------------
        /// <summary>
        /// פעולה בונה
        /// </summary>
        /// <param name="f">מקבל את הריצפה במיקום הכי רחוק כדי לשים שם את מעבר השלב</param>
        public LvlPassFloor(Floor f)
            : base(f.GetFloorX1(), f.GetFloorY(), f.GetType(), false)
        {
            this.floor = f;
            this.currentindexpicture = 0;
            //-------------------------------------
            this.images= new Image[12];
            this.images[0] = GameResources.Door1;
            this.images[1] = GameResources.Door2;
            this.images[2] = GameResources.Door3;
            this.images[3] = GameResources.Door4;
            this.images[4] = GameResources.Door5;
            this.images[5] = GameResources.Door6;
            this.images[6] = GameResources.Door7;
            this.images[7] = GameResources.Door8;
            this.images[8] = GameResources.Door9;
            this.images[9] = GameResources.Door10;
            this.images[10] = GameResources.Door11;
            this.images[11] = GameResources.Door12;
            //--------------------------------
            this.changepictureTimer = new Timer();
            this.changepictureTimer.Enabled = true;
            this.changepictureTimer.Interval = 200;
            this.changepictureTimer.Tick += changepictureTimer_Tick;
            //------------------------------------
            this.rectangle= new Rectangle(f.GetFloorX1(),f.GetFloorY()-85,87,85);
        }
        /// <summary>
        /// פעולה שינוי אינדקס התמונה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void changepictureTimer_Tick(object sender, EventArgs e)
        {
            this.currentindexpicture++;
            if (this.currentindexpicture == 12)
                this.currentindexpicture = 0;
        }
        /// <summary>
        /// פעולה המציירת את הריצפה
        /// </summary>
        /// <param name="e"></param>
        public void ShowLastFloor(PaintEventArgs e)
        {
            e.Graphics.DrawImage(this.images[this.currentindexpicture], this.rectangle);
        }
        
    }
}
