using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectGame.Classes
{
    class Arrow:MagicBall
    {
        //---------------------------תכונות----------------
        /// <summary>
        /// טיימר נפילה
        /// </summary>
        private Timer FallTimer;
        /// <summary>
        /// מספר הפיקסלים שבו ניפול בכל Tick
        /// </summary>
        private int dy;
        /// <summary>
        /// אייונט המוחק את העצם
        /// </summary>
        public event EventHandler DeleteArrow;
        //--------------------------פעולות----------------
        /// <summary>
        /// פעולה בונה
        /// </summary>
        /// <param name="x">ערך האיקס ההתחלתי של החץ</param>
        /// <param name="y">ערך הוואי ההתחלתי של החץ</param>
        /// <param name="c">תו המראה על כיוון החץ. ימינה או שמאלה</param>
       public Arrow(int x, int y,char c):base(x,y,c)
        {
            this.dy = 1;
            this.dx = 10;
            this.rectangle = new Rectangle(x, y, 99, 20);

            this.flyingleft = new Image[7];
            this.flyingright = new Image[7];
            this.flyingleft[0] = AttackFrames.ArcherLeftArrowThrow1;
            this.flyingleft[1] = AttackFrames.ArcherLeftArrowThrow2;
            this.flyingleft[2] = AttackFrames.ArcherLeftArrowThrow3;
            this.flyingleft[3] = AttackFrames.ArcherLeftArrowThrow4;
            this.flyingleft[4] = AttackFrames.ArcherLeftArrowThrow5;
            this.flyingleft[5] = AttackFrames.ArcherLeftArrowThrow6;
            this.flyingleft[6] = AttackFrames.ArcherLeftArrowThrow7;
            this.flyingright[0] = AttackFrames.ArcherRightArrowThrow1;
            this.flyingright[1] = AttackFrames.ArcherRightArrowThrow2;
            this.flyingright[2] = AttackFrames.ArcherRightArrowThrow3;
            this.flyingright[3] = AttackFrames.ArcherRightArrowThrow3;
            this.flyingright[4] = AttackFrames.ArcherRightArrowThrow5;
            this.flyingright[5] = AttackFrames.ArcherRightArrowThrow6;
            this.flyingright[6] = AttackFrames.ArcherRightArrowThrow7;

            this.explosionleft = new Image[8];
            this.explosionright = new Image[8];
            this.explosionleft[0] = AttackFrames.ArcherLeftArrowHit1;
            this.explosionleft[1] = AttackFrames.ArcherLeftArrowHit2;
            this.explosionleft[2] = AttackFrames.ArcherLeftArrowHit3;
            this.explosionleft[3] = AttackFrames.ArcherLeftArrowHit4;
            this.explosionleft[4] = AttackFrames.ArcherLeftArrowHit5;
            this.explosionleft[5] = AttackFrames.ArcherLeftArrowHit6;
            this.explosionleft[6] = AttackFrames.ArcherLeftArrowHit7;
            this.explosionleft[7] = AttackFrames.ArcherLeftArrowHit8;
            this.explosionright[0] = AttackFrames.ArcherRightArrowHit1;
            this.explosionright[1] = AttackFrames.ArcherRightArrowHit2;
            this.explosionright[2] = AttackFrames.ArcherRightArrowHit3;
            this.explosionright[3] = AttackFrames.ArcherRightArrowHit4;
            this.explosionright[4] = AttackFrames.ArcherRightArrowHit5;
            this.explosionright[5] = AttackFrames.ArcherRightArrowHit6;
            this.explosionright[6] = AttackFrames.ArcherRightArrowHit7;
            this.explosionright[7] = AttackFrames.ArcherRightArrowHit8;

            //------------------------------טיימר-------------------------
            this.FallTimer = new Timer();
            this.FallTimer.Enabled = true;
            this.FallTimer.Interval = 20;
            this.FallTimer.Tick += FallTimer_Tick;

        }

        #region timers
        /// <summary>
        /// פעולה המשנה את מונה התמונות העכשוי
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ChangepictureTimer_Tick(object sender, EventArgs e)
        {
            this.flag = true;
            this.dy++;//כדי שהנפילה תהיה איטית יותר אז המשתנה של הנפילה נמצא בטיימר יותר איטי
            this.currentindexpicture++;
            if (!this.isExploding)
            {
                if (this.currentindexpicture == this.flyingleft.Length)
                    this.currentindexpicture = 0;
            }
            else
            {
                if (this.currentindexpicture == this.explosionleft.Length && this.flag)
                {
                    this.flag = false;
                    DeleteArrow(this, null);
                }
            }
        }
        /// <summary>
        /// פעולה הגורמת לנפילת החץ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FallTimer_Tick(object sender, EventArgs e)
        {
            this.rectangle.Y +=dy;
            if (this.rectangle.Y + this.rectangle.Height > 385 && this.flag)
            {
                this.flag = false;
                DeleteArrow(this, null);
            }
        }
        #endregion timers
        /// <summary>
        /// פעולה שמחליפה את מערך התמונות לפיצוץ
        /// </summary>
        public override void SwitchObectToExplosion()
        {
            this.rectangle = new Rectangle(this.rectangle.X, this.rectangle.Y-100, 238, 274);
            this.isExploding = true;
        }
        /// <summary>
        /// עצור את הנפילה של העצם
        /// </summary>
        public void StopFallTimer()
        {
            this.FallTimer.Enabled = false;
        }
    }
}
