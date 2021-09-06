using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectGame.Classes
{
    class MagicBall
    {
        //-----------------------------------------תכונות----------------------------
        /// <summary>
        /// מערך תמונות בתעופה
        /// </summary>
        protected Image[] flyingleft,flyingright;
        /// <summary>
        /// מערך תמונות בפיצוץ
        /// </summary>
        protected Image[] explosionleft, explosionright;
        /// <summary>
        /// מלבן המתקפה
        /// </summary>
        protected Rectangle rectangle;
        /// <summary>
        /// טיימר שינוי המקום של המתקפה
        /// </summary>
        protected Timer moveTimer;
        /// <summary>
        /// מספר הפיקסלי לההזזה בציר האיקס
        /// </summary>
        protected int dx;
        /// <summary>
        /// טיימר החלפת תמונות
        /// </summary>
        protected Timer changepictureTimer;
        /// <summary>
        /// אינדקס תמונה עכשוית
        /// </summary>
        protected int currentindexpicture;
        /// <summary>
        /// תו המראה על כיוון
        /// </summary>
        protected char direction;
        /// <summary>
        /// פעולה הבודקת אם המתקפה מפוצצת
        /// </summary>
        protected bool isExploding;
        /// <summary>
        /// "משתנה שנועד להפסיק את פעולת העצם אם הוא "מת
        /// </summary>
        protected bool flag;
        /// <summary>
        /// איוונט מחיקת המתקפה
        /// </summary>
        public event EventHandler DeleteMagicBall;
        //-----------------------------------------פעולות----------------------------
        /// <summary>
        /// פעולה בונה
        /// </summary>
        /// <param name="x">האיקס ההתחלתי</param>
        /// <param name="y">הוואי ההתחלתי</param>
        /// <param name="c">תו המייצג את כיוון הדמות</param>
        public MagicBall(int x, int y, char c)
        {
            this.flag = true;
            this.currentindexpicture = 0;
            this.isExploding = false;
            this.direction = c;
            this.dx = 5;
            this.rectangle = new Rectangle(x, y, 61, 57);
            #region הכנסת תמונות
            this.flyingleft = new Image[3];
            this.flyingright = new Image[3];
            this.flyingleft[0] = AttackFrames.MageLeftEnergyBallThrow1;
            this.flyingleft[1] = AttackFrames.MageLeftEnergyBallThrow2;
            this.flyingleft[2] = AttackFrames.MageLeftEnergyBallThrow3;
            this.flyingright[0] = AttackFrames.RightEnergyBallThrow1;
            this.flyingright[1] = AttackFrames.RightEnergyBallThrow2;
            this.flyingright[2] = AttackFrames.RightEnergyBallThrow3;

            this.explosionleft = new Image[7];
            this.explosionright = new Image[7];
            this.explosionleft[0] = AttackFrames.MageLeftEnergyBallHit1;
            this.explosionleft[1] = AttackFrames.MageLeftEnergyBallHit2;
            this.explosionleft[2] = AttackFrames.MageLeftEnergyBallHit3;
            this.explosionleft[3] = AttackFrames.MageLeftEnergyBallHit4;
            this.explosionleft[4] = AttackFrames.MageLeftEnergyBallHit5;
            this.explosionleft[5] = AttackFrames.MageLeftEnergyBallHit6;
            this.explosionleft[6] = AttackFrames.MageLeftEnergyBallHit7;
            this.explosionright[0] = AttackFrames.RightEnergyBallHit1;
            this.explosionright[1] = AttackFrames.RightEnergyBallHit2;
            this.explosionright[2] = AttackFrames.RightEnergyBallHit3;
            this.explosionright[3] = AttackFrames.RightEnergyBallHit4;
            this.explosionright[4] = AttackFrames.RightEnergyBallHit5;
            this.explosionright[5] = AttackFrames.RightEnergyBallHit6;
            this.explosionright[6] = AttackFrames.RightEnergyBallHit7;
            #endregion הכנסת תמונות
            //--------------------טיימרים------------------------
            this.moveTimer = new Timer();
            this.moveTimer.Enabled = true;
            this.moveTimer.Interval = 1;
            this.moveTimer.Tick += MoveTimer_Tick;

            this.changepictureTimer = new Timer();
            this.changepictureTimer.Enabled = true;
            this.changepictureTimer.Interval = 250;
            this.changepictureTimer.Tick += ChangepictureTimer_Tick;
        }
        #region timers
        /// <summary>
        /// פעולת שינוי האינדקס התמונות העכשווי
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void ChangepictureTimer_Tick(object sender, EventArgs e)
        {
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
                    DeleteMagicBall(this, null);
                }
            }
        }
        /// <summary>
        /// טיימר הזזת הדמות
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveTimer_Tick(object sender, EventArgs e)
        {

            if (this.direction == 'r') { this.rectangle.X += this.dx; }
            if (this.direction == 'l') { this.rectangle.X -= this.dx; }

        }
        #endregion timers
        /// <summary>
        /// פעולה המציירת את הדמות
        /// </summary>
        /// <param name="e"></param>
        public void ShowMe(PaintEventArgs e)
        {
            if (!this.isExploding)
            {
                if (this.direction == 'r') { e.Graphics.DrawImage(this.flyingright[this.currentindexpicture], this.rectangle); }
                if (this.direction == 'l') { e.Graphics.DrawImage(this.flyingleft[this.currentindexpicture], this.rectangle); }
            }
            else
            {
                if (this.direction == 'r') { e.Graphics.DrawImage(this.explosionright[this.currentindexpicture], this.rectangle); }
                if (this.direction == 'l') { e.Graphics.DrawImage(this.explosionleft[this.currentindexpicture], this.rectangle); }
            }
        }
        /// <summary>
        /// פעולה המחליפה את המתקפה למצב פיצוץ
        /// </summary>
        public virtual void SwitchObectToExplosion()
        {
            this.rectangle = new Rectangle(this.rectangle.X,this.rectangle.Y-120, 231, 206);
            this.isExploding = true;
            this.currentindexpicture = 0;
        }
        /// <summary>
        /// פעולת Get
        /// </summary>
        /// <returns>מחזיר מלבן</returns>
        public Rectangle GetRectangle()
        {
            return this.rectangle;
        }
        /// <summary>
        /// פעולת הזזה שמאלה
        /// </summary>
        /// <param name="p">מספר הפיקסלים שבו יש להזיז את המתקפה</param>
        public void MoveLeft(int p)
        {
            this.rectangle.X -= p;
        }
        /// <summary>
        /// פעולת הזזה ימינה
        /// </summary>
        /// <param name="p">מספר הפיקסלים שבו יש להזיז את המתקפה</param>
        public void MoveRight(int p)
        {
            this.rectangle.X += p;
        }
        /// <summary>
        /// פעולת Get
        /// </summary>
        /// <returns>נכון אם הדמות בפיצוץ לא נכון אחרת</returns>
        public bool GetisExplosion()
        {
            return this.isExploding;
        }
        /// <summary>
        /// פעולת עצירת המתקפה
        /// </summary>
        public void StopMoveTimer()
        {
            this.moveTimer.Enabled = false;
        }
    }
}
