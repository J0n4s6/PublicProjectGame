using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectGame.Classes
{
    class Character
    {
        #region properties
        /// <summary>
        /// סוג גיבור
        /// </summary>
        protected CharacterType type;
        /// <summary>
        /// כיוון הדמות
        /// </summary>
        protected DirectionType direction;
        /// <summary>
        /// משתנה של חסינות הדמות כשהיא מקבלת מכה
        /// </summary>
        protected bool isVulnerable;
        /// <summary>
        /// מונה לכל כמה פעמים הדמות תהיה בלתי נראית 
        /// </summary>
        protected double invulnerablecount;
        /// <summary>
        /// מגביל את מספר הפעמים שניתן לקפוץ
        /// </summary>
        protected int jumplimit;
        /// <summary>
        /// האם הדמות מתה
        /// </summary>
        protected bool isDEAD;
        /// <summary>
        /// תאוצה בציר האיקס
        /// </summary>
        protected int accelerationXlimit;
        /// <summary>
        /// הריצפה של הדמות,בערך הזה הדמות מפסיקה ליפול
        /// </summary>
        protected int arenafloor;
        /// <summary>
        /// גודלי התמונות בכל מצבי הדמות
        /// </summary>
        protected int standwidth, standheight, walkwidth, walkheight, jumpwidth, jumpheight,downwidth,downheight, shootwidth, shootheight,ishurtwidth,ishurtheight,isdeadwidth,isdeadheight;
        /// <summary>
        /// מלבן שמטרתו לצייר את הדמות בגודל מתאים
        /// </summary>
        protected Rectangle rectangle;
        /// <summary>
        /// הזמן שבו הדמות לא מקבלת פגיעות
        /// </summary>
        protected Timer vulnerableTimer;
        /// <summary>
        /// מספר הרעידות כמה זמן
        /// </summary>
        protected Timer shakingTimer;
        /// <summary>
        /// איוונט לסיום המשחק כאשר נגמר לשחק נקודות החיים
        /// </summary>
        public event EventHandler EndGame;
        //-------------------------------------תכונות דמות במשחק-------------------------
        /// <summary>
        /// משתנים הקשורים לנקודות החיים של הדמות
        /// </summary>
        protected double Health, maxHealth, percentageHealth;
        /// <summary>
        /// משתנים הקשורים לנקודות המאנה של הדמות
        /// </summary>
        protected double Mana, maxMana, percentageMana;
        /// <summary>
        /// משתנים הקשורים לערך התקיפה של הדמות
        /// </summary>
        protected double Attack, maxAttack, minAttack;
        /// <summary>
        /// מתשנים הקשורים לערך ההגנה של הדמות
        /// </summary>
        protected double Defense, maxDefense, minDefense;
        /// <summary>
        /// מספר העלות במאנה לכל מתקפת
        /// </summary>
        protected int move1manacost, move2manacost, move3manacost;
        //---------------------------------------------------------------------------------
        /// <summary>
        /// תמונה של פגיעה
        /// </summary>
        protected Image ishurtleft, ishurtright;
        /// <summary>
        /// מערכי תמונות של הדמות למטה
        /// </summary>
        protected Image downleft, downright;
        /// <summary>
        /// תמונת הדמות בקפיצה
        /// </summary>
        protected Image jumpleft, jumpright;
        /// <summary>
        /// מערכי תמונות בעמידה ישרה
        /// </summary>
        protected Image[] standleft, standright;
        /// <summary>
        /// מערכי תמונות בהליכה
        /// </summary>
        protected Image[] walkleft, walkright;
        /// <summary>
        /// מערכי תמונות בירייה
        /// </summary>
        protected Image[] shootleft, shootright;
        /// <summary>
        /// מערכי תמונות במוות
        /// </summary>
        protected Image[] isdeadleft, isdeadright;
        /// <summary>
        /// איוונט למחיקת הדמות
        /// </summary>
        public event EventHandler DeleteCharacter;
        /// <summary>
        /// טיימר להחלפת תמונות
        /// </summary>
        protected Timer changepicturesTimer;
        /// <summary>
        /// מונה את התמונה העכשוית
        /// </summary>
        protected int currentpictureindex;
        /// <summary>
        /// טיימר תזוזה בציר האיקס
        /// </summary>
        protected Timer velocityXTimer;
        /// <summary>
        /// תאוצה בציר האיקס
        /// </summary>
        protected int accelerationX;
        /// <summary>
        /// טיימר לתזוזה בציר הוואי
        /// </summary>
        protected Timer velocityYTimer;
        /// <summary>
        /// תאוצה בציר הוואי
        /// </summary>
        protected int accelerationY;  
 
        #endregion properties
        //-----------------------------------------------------------------------------
        /// <summary>
        /// פעולה בונה
        /// </summary>
        /// <param name="ty">סוג הדמות</param>
        public Character(CharacterType ty)
        {
            this.type = ty;
            this.currentpictureindex = 0;
            this.arenafloor = 100;
            this.isVulnerable = true;
            this.direction = DirectionType.standright;
            this.isDEAD = false;
            //------------------------------------טיימר-----------------------
            this.changepicturesTimer = new Timer();
            this.changepicturesTimer.Enabled = true;
            this.changepicturesTimer.Interval = 250;
            this.changepicturesTimer.Tick += changepicturesTimer_Tick;

            this.velocityXTimer = new Timer();
            this.velocityXTimer.Enabled = false;
            this.velocityXTimer.Interval = 1;
            this.velocityXTimer.Tick += velocityXTimer_Tick;
            this.accelerationX = 0;

            this.velocityYTimer = new Timer();
            this.velocityYTimer.Enabled = true;
            this.velocityYTimer.Interval = 1;
            this.velocityYTimer.Tick += velocityYTimer_Tick;
            this.accelerationY = 0;

            this.vulnerableTimer = new Timer();
            this.vulnerableTimer.Enabled = false;
            this.vulnerableTimer.Interval = 1500;
            this.vulnerableTimer.Tick += vulnerableTimer_Tick;

            this.shakingTimer = new Timer();
            this.shakingTimer.Enabled = false;
            this.shakingTimer.Interval = 50;
            this.shakingTimer.Tick += shakingTimer_Tick;

    
        }


        #region timers
        /// <summary>
        /// פעולה המשנה את ערך הוואי של הדמות לפי תאוצתה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void velocityYTimer_Tick(object sender, EventArgs e)
        {

            this.accelerationY += 1;
            this.rectangle.Y += this.accelerationY;

            if (this.rectangle.Y + this.rectangle.Height > this.arenafloor)
            {
                this.accelerationY = -1;
                if (this.direction == DirectionType.downleft || this.direction == DirectionType.downright)
                {
                    this.rectangle.Y = this.arenafloor - this.downheight;
                }
                else
                {
                    if (this.direction == DirectionType.jumpright) { this.direction = DirectionType.standright; }
                    if (this.direction == DirectionType.jumpleft) { this.direction = DirectionType.standleft; }
                    this.rectangle.Y = this.arenafloor - this.standheight;
                }
                this.jumplimit = 0;
            }

        }
        /// <summary>
        /// פעולה המשנה את ערך איקס של הדמות לפי תאוצתה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void velocityXTimer_Tick(object sender, EventArgs e)
        {
            
                if ((this.direction == DirectionType.walkleft || this.direction == DirectionType.jumpleft))
                {
                this.rectangle.X -= accelerationX;
                }
                if ((this.direction == DirectionType.walkright || this.direction == DirectionType.jumpright))
                {
                this.rectangle.X += accelerationX;
                }
                if (this.direction == DirectionType.standleft || this.direction == DirectionType.standright || this.direction == DirectionType.downleft || this.direction == DirectionType.downright || this.direction == DirectionType.shootleft | this.direction == DirectionType.shootright)
                { this.accelerationX = 0; }
            
        }                  
        /// <summary>
        /// פעולת שינוי המונה של התמונה העכשוית
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void changepicturesTimer_Tick(object sender, EventArgs e)
        {
            if (this.direction == DirectionType.standleft || this.direction == DirectionType.standright)
            {
                this.currentpictureindex++;
                if (this.currentpictureindex == this.standleft.Length)
                    this.currentpictureindex = 0;
            }
            if (this.direction == DirectionType.walkleft || this.direction == DirectionType.walkright)
            {
                this.currentpictureindex++;
                if (this.currentpictureindex == this.walkleft.Length)
                    this.currentpictureindex = 0;
            }
            if (this.direction == DirectionType.shootleft || this.direction == DirectionType.shootright)
            {
                this.currentpictureindex++;
                if (this.currentpictureindex == this.shootleft.Length)
                    this.currentpictureindex = 0;
            }
            if (this.direction == DirectionType.isdeadleft || this.direction == DirectionType.isdeadright)
            {
                this.currentpictureindex++;
                if (this.currentpictureindex == this.isdeadleft.Length && !isDEAD)
                {
                    this.currentpictureindex = 0;
                    this.isDEAD = true;
                    DeleteCharacter(this, null);                    
                }
            }
            if (this.direction == DirectionType.ishurtleft || this.direction == DirectionType.ishurtright)
            {
                this.currentpictureindex = 0;
                if (this.GetDirection() == 'l') { this.direction = DirectionType.walkleft; }
                if (this.GetDirection() == 'r') { this.direction = DirectionType.walkright; }
            }
        }
        /// <summary>
        /// פעולת המשנה את המונה של מספר הפעמים שהדמות תהיה בלתי נראית לשנייה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void shakingTimer_Tick(object sender, EventArgs e)
        {
            this.invulnerablecount++;
            if (this.invulnerablecount == 2)
                this.invulnerablecount = 0;
        }
        /// <summary>
        /// פעולה שעוצרת את החסינות של הדמות לאחר זמן מסויים
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void vulnerableTimer_Tick(object sender, EventArgs e)
        {
            this.isVulnerable = true;
            this.invulnerablecount = 0;
            this.shakingTimer.Enabled = false;
            this.vulnerableTimer.Enabled = false;
        }
        #endregion timers
        /// <summary>
        /// פעולה המציירת את הדמות
        /// </summary>
        /// <param name="e">עצם גרפי של האלמנט עליו אני מצייר</param>
        public void ShowMe(PaintEventArgs e)
        {
            if (this.invulnerablecount %2 == 0)
            {
                switch (this.direction)
                {
                    case DirectionType.downleft: this.rectangle = new Rectangle(this.rectangle.X, this.rectangle.Y, this.downwidth, this.downheight); e.Graphics.DrawImage(this.downleft, this.rectangle); break;
                    case DirectionType.downright: this.rectangle = new Rectangle(this.rectangle.X, this.rectangle.Y, this.downwidth, this.downheight); e.Graphics.DrawImage(this.downright, this.rectangle); break;

                    case DirectionType.jumpleft: this.rectangle = new Rectangle(this.rectangle.X, this.rectangle.Y, this.jumpwidth, this.jumpheight); e.Graphics.DrawImage(this.jumpleft, this.rectangle); break;
                    case DirectionType.jumpright: this.rectangle = new Rectangle(this.rectangle.X, this.rectangle.Y, this.jumpwidth, this.jumpheight); e.Graphics.DrawImage(this.jumpright, this.rectangle); break;

                    case DirectionType.standleft: this.rectangle = new Rectangle(this.rectangle.X, this.rectangle.Y, this.standwidth, this.standheight); e.Graphics.DrawImage(this.standleft[this.currentpictureindex], this.rectangle); break;
                    case DirectionType.standright: this.rectangle = new Rectangle(this.rectangle.X, this.rectangle.Y, this.standwidth, this.standheight); e.Graphics.DrawImage(this.standright[this.currentpictureindex], this.rectangle); break;

                    case DirectionType.walkleft: this.rectangle = new Rectangle(this.rectangle.X, this.rectangle.Y, this.walkwidth, this.walkheight); e.Graphics.DrawImage(this.walkleft[this.currentpictureindex], this.rectangle); break;
                    case DirectionType.walkright: this.rectangle = new Rectangle(this.rectangle.X, this.rectangle.Y, this.walkwidth, this.walkheight); e.Graphics.DrawImage(this.walkright[this.currentpictureindex], this.rectangle); break;

                    case DirectionType.shootleft: this.rectangle = new Rectangle(this.rectangle.X, this.rectangle.Y, this.shootwidth, this.shootheight); e.Graphics.DrawImage(this.shootleft[this.currentpictureindex], this.rectangle); break;
                    case DirectionType.shootright: this.rectangle = new Rectangle(this.rectangle.X, this.rectangle.Y, this.shootwidth, this.shootheight); e.Graphics.DrawImage(this.shootright[this.currentpictureindex], this.rectangle); break;

                    case DirectionType.ishurtleft: this.rectangle = new Rectangle(this.rectangle.X, this.rectangle.Y, this.ishurtwidth, this.ishurtheight); e.Graphics.DrawImage(this.ishurtleft, this.rectangle); break;
                    case DirectionType.ishurtright: this.rectangle = new Rectangle(this.rectangle.X, this.rectangle.Y, this.ishurtwidth, this.ishurtheight); e.Graphics.DrawImage(this.ishurtright, this.rectangle); break;

                    case DirectionType.isdeadleft: this.rectangle = new Rectangle(this.rectangle.X, this.rectangle.Y, this.isdeadwidth, this.isdeadheight); e.Graphics.DrawImage(this.isdeadleft[this.currentpictureindex], this.rectangle); break;
                    case DirectionType.isdeadright: this.rectangle = new Rectangle(this.rectangle.X, this.rectangle.Y, this.isdeadwidth, this.isdeadheight); e.Graphics.DrawImage(this.isdeadright[this.currentpictureindex], this.rectangle); break;
                }
            }
        }
        /// <summary>
        /// פעולה העוצרת את הדמות
        /// </summary>
        public virtual void Stop()
        {
            this.changepicturesTimer.Enabled = false;
            this.velocityXTimer.Enabled = false;
            this.velocityYTimer.Enabled = false;

        }
        /// <summary>
        /// פעולה הממשיכה את הדמות
        /// </summary>
        public virtual void Continue()
        {
            this.changepicturesTimer.Enabled = true;
            this.velocityXTimer.Enabled = true;
            this.velocityYTimer.Enabled = true;
        }

        #region movingmethods
        /// <summary>
        /// פעולה המזיזה את הדמות בלחיצה על כפתור
        /// </summary>
        public void Move()
        {
            switch (this.direction)
            {
                case DirectionType.walkleft:
                    this.velocityXTimer.Enabled = true;
                    if (this.accelerationXlimit > this.accelerationX)
                        this.accelerationX += 4;
                    else
                        this.accelerationX = this.accelerationXlimit;

                    break;
                case DirectionType.walkright:
                    this.velocityXTimer.Enabled = true;
                    if (this.accelerationXlimit > this.accelerationX)
                        this.accelerationX += 4;
                    else
                        this.accelerationX = this.accelerationXlimit;
                    break;
            }
        }
        /// <summary>
        /// פעולה המקפיצה את הדמות. מותרת רק קפיצה אחת
        /// </summary>
        internal void Jump()
        {

            if (jumplimit < 1)
            {
                switch (this.direction)
                {
                    case DirectionType.standright: this.direction = DirectionType.jumpright; break;
                    case DirectionType.standleft: this.direction = DirectionType.jumpleft; break;
                    case DirectionType.walkright: this.direction = DirectionType.jumpright; break;
                    case DirectionType.walkleft: this.direction = DirectionType.jumpleft; ; break;
                    case DirectionType.shootright: this.direction = DirectionType.jumpright; break;
                    case DirectionType.shootleft: this.direction = DirectionType.jumpleft; ; break;
                    default: break;
                }

                if (this.direction == DirectionType.jumpleft || this.direction == DirectionType.jumpright)
                {
                    this.accelerationY -= 16;
                    this.jumplimit++;
                }
            }
        }

        #endregion movingmethods
        /// <summary>
        /// פעולת התחלת החסינות מפני פגעים
        /// </summary>
        public void StartInvulnerability()
        {
            this.invulnerablecount = 0;
            this.shakingTimer.Enabled = true;
            this.isVulnerable = false;
            this.vulnerableTimer.Enabled = true;
        }

        #region Get Set methods for stats
        /// <summary>
        /// מחזירה את ערך ההתקפה לערך הרגיל
        /// </summary>
        public void ReturnAttackToNorm()
        {
            this.Attack = this.minAttack;
        }
        /// <summary>
        /// מחזירה את ערך ההגנה לערך הרגיל
        /// </summary>
        public void ReturnDefenseToNorm()
        {
            this.Defense = this.minDefense;
        }
        /// <summary>
        /// מגבירה את ערך ההתקפה של הדמות אחוזית
        /// </summary>
        /// <param name="boost">אחזו ההגברה של ערך ההתקפה</param>
        public void AddAttack(double boost)
        {            
            this.Attack *= boost;
            if (this.Attack > this.maxAttack)
                this.Attack = maxAttack;

        }
        /// <summary>
        /// מגבירה את ערך ההגנה של הדמות אחוזית
        /// </summary>
        /// <param name="boost">אחוז ההגברה של ערך ההגנה</param>
        public void AddDefense(double boost)
        {
            this.Defense *= boost;
            if (this.Defense > this.maxDefense)
                this.Defense = this.maxDefense;

        }
        /// <summary>
        /// מחזירה נקודות חיים לדמות
        /// </summary>
        /// <param name="heal">מספר נקודות החיים המוחזרות</param>
        public void HealHealth(int heal)
        {
            this.Health += heal;
            if (this.Health > this.maxHealth)
                this.Health = maxHealth;
        }
        /// <summary>
        /// מחזירה נקודות מאנה לדמות
        /// </summary>
        /// <param name="heal">מספר  נקודות המאנה המוחזות</param>
        public void HealMana(int heal)
        {
            this.Mana += heal;
            if (this.Mana > maxMana)
                this.Mana = maxMana;
        }
        /// <summary>
        /// מחזירה את ערך ההתקפה
        /// </summary>
        /// <returns></returns>
        public double GetAttack()
        {
            return this.Attack;
        }
        /// <summary>
        /// פעולה המחסירה נוקודות חיים
        /// </summary>
        /// <param name="dmg">מספר נקודות החיים להחסרה</param>
        /// <param name="truedmg">משתנה המורה אם להתייחס לערך ההגנה או לא</param>
        public virtual void LooseHealth(int dmg,bool truedmg)
        {/* המשתנה הבוליאני נמצא כאן כדי להוריד חיים ללא
           השפעה של ה"הגנה" של הדמות. 
          כמו לדוגמא הקוצים בריצפה שלא מושפעים מה"הגנה" של הדמות
           */
          if (truedmg)
            {
                this.Health -= dmg;
            }
            else
            {
                this.Health -= (dmg-this.Defense);
            }
            if (this.Health <= 0)
            {
                EndGame(null, null);//נגמר המשחק כי נגמרו החיים
            }
        }
        /// <summary>
        /// מחזיר את אחוז החיים למטרת הצגה במשחק
        /// </summary>
        /// <returns>מחזיר את אחוז החיים של הדמות</returns>
        public double GetPercentageHealth()
        {
            this.percentageHealth = Health / maxHealth;
            return this.percentageHealth;
        }
        /// <summary>
        /// מחזיר את אחוז המאנה למטרת הצגה במשחק
        /// </summary>
        /// <returns>מחזיר את אחוז המאנה של הדמות</returns>
        public double GetPercentageMana()
        {
            this.percentageMana = Mana / (double)maxMana;
            return this.percentageMana;
        }
        #endregion Get Set methods for stats

        #region Get Set methods
        /// <summary>
        /// האם הדמות חסינה לפגיעות
        /// </summary>
        /// <returns>מחזיר משתנה בוליאני</returns>
        public bool GetVulnerability()
        {
            return this.isVulnerable;
        }
        /// <summary>
        /// מחזיר את סוג הדמות
        /// </summary>
        /// <returns></returns>
        public new CharacterType GetType()
        { return this.type; }
        /// <summary>
        /// מחזיר את הכיוון של הדמות
        /// </summary>
        /// <returns>תו המציג את הכיוון ימין או שמאל</returns>
        public char GetDirection()
        {
            if (this.direction == DirectionType.downleft || this.direction == DirectionType.walkleft || this.direction == DirectionType.jumpleft || this.direction == DirectionType.shootleft || this.direction == DirectionType.standleft || this.direction == DirectionType.ishurtleft || this.direction == DirectionType.isdeadleft)
                return 'l';
            if (this.direction == DirectionType.downright || this.direction == DirectionType.walkright || this.direction == DirectionType.jumpright || this.direction == DirectionType.shootright || this.direction == DirectionType.standright || this.direction == DirectionType.ishurtright || this.direction == DirectionType.isdeadright)
                return 'r';
            return 'n';
        }
        /// <summary>
        /// מחזיר את מלבן הדמות
        /// </summary>
        /// <returns>מלבן הדמות</returns>
        internal Rectangle GetRectangle()
        {
            return this.rectangle;
        }
        /// <summary>
        /// מחזיר את תאוצת הדמות למטרת הזזת המסך
        /// </summary>
        /// <returns>מספר המייצג את תאוצצת הדמות</returns>
        internal int GetAccelerationX()
        {
            return this.accelerationX;
        }
        /// <summary>
        /// מחזיר את הגובה של הריצפה לדמות
        /// </summary>
        /// <param name="newfloor">מקבל את הגובה החדש של הרצפה</param>
        internal void SetArenaFloor(int newfloor)
        {
            this.arenafloor = newfloor;   
        }
        /// <summary>
        /// פעולת Get
        /// </summary>
        /// <returns>האיקס השמאלי של הדמות</returns>
        internal int GetCharacterX1()
        {
            return this.rectangle.X;
        }
        /// <summary>
        /// פעולת Get
        /// </summary>
        /// <returns>האיקס הימני של הדמות</returns>
        internal int GetCharacterX2()
        {
            return this.rectangle.X + this.rectangle.Width;
        }
        /// <summary>
        /// פעולת Get
        /// </summary>
        /// <returns>מחזיר את גובה הוואי התחתון של הדמות</returns>
        internal int GetCharacterY()
        {
            return this.rectangle.Y + this.rectangle.Height;
        }
        /// <summary>
        /// פעולת Set
        /// </summary>
        /// <param name="di">משנה את כיוון הדמות</param>
        public void SetDirection(DirectionType di)
        {            
            if (this.direction != di)
                {
                    this.direction = di;
                    this.currentpictureindex = 0;
                }            
        }
        /// <summary>
        /// מאפס את האינדקס של התמונה
        /// </summary>
        public void SetPictureIndex()
        {
            this.currentpictureindex = 0;
        }
        /// <summary>
        /// משנה את כיוון הדמות לירייה
        /// </summary>
        public void SetDirectionToShoot()
        {
            
                this.currentpictureindex = 0;
                if (this.direction == DirectionType.jumpleft || this.direction == DirectionType.downleft || this.direction == DirectionType.standleft)
                    this.direction = DirectionType.shootleft;
                if (this.direction == DirectionType.jumpright || this.direction == DirectionType.downright || this.direction == DirectionType.standright)
                    this.direction = DirectionType.shootright;
            
        }
        /// <summary>
        /// משנה את כיוון הדמות עמידה
        /// </summary>
        public void SetDirectionToStand()
        {
            
                this.currentpictureindex = 0;
                if (this.direction == DirectionType.jumpleft || this.direction == DirectionType.downleft || this.direction==DirectionType.shootleft)
                    this.direction = DirectionType.standleft;
                if (this.direction == DirectionType.jumpright || this.direction == DirectionType.downright|| this.direction==DirectionType.shootright)
                    this.direction = DirectionType.standright;
            
        }
        /// <summary>
        /// מאפס את המהירות של הדמות
        /// </summary>
        internal void SetVelocityX()
        {
            this.accelerationX = 0;
            this.velocityXTimer.Enabled = false;
        }        
        /// <summary>
        /// משנה את כיוון הדמות למטה
        /// </summary>
        internal void SetDirectionDown()
        {
            if (this.direction == DirectionType.standleft || this.direction == DirectionType.walkleft)
                this.direction = DirectionType.downleft;
            if (this.direction == DirectionType.standright || this.direction == DirectionType.walkright)
                this.direction = DirectionType.downright;
        }
        #endregion Get Set methods

        
    }
}
public enum DirectionType//המצבים: עומד,הולך,קופץ,למטה,פגוע,מת
{
    standright,standleft,walkright,walkleft,jumpright,jumpleft,downright,downleft,shootright,shootleft,ishurtright,ishurtleft,isdeadright,isdeadleft
}