using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectGame.Classes
{
    class Enemy:Character
    {     
        //------------------------------------------- תכונות מחלקה-----------------------
        /// <summary>
        /// טיימר הזזת הדמות באופן מחזורי פשוט
        /// </summary>
        private Timer moveTimer;
        /// <summary>
        /// טיימר המראה את אחוז החיים של האויב
        /// </summary>
        private Timer adjusthealthbarTimer;
        /// <summary>
        /// נקודת מיקום לשורת חיים
        /// </summary>
        private Point healthbarlocation;
        /// <summary>
        /// מערך תמונות מצבים שונים של שורת החיים
        /// </summary>
        private Image[] HealthbarImage;
        /// <summary>
        /// מספר הנקודות שמביא כל מפלצת
        /// </summary>
        private int bonusPoints;
        //------------------------------------------פעולות--------------------------------
        /// <summary>
        /// פעולה בונה
        /// </summary>
        /// <param name="x">מיקום איקס התחלתי</param>
        /// <param name="y">מיקום וואי התחלתי</param>
        /// <param name="ty">סוג המפלצת</param>
        public Enemy(int x, int y, CharacterType ty)
            : base(ty)
        {
            #region הכנסת תמונות
            switch (this.type)
            {
                case CharacterType.redsnail:
                    this.standwidth = 44;
                    this.standheight = 34;
                    this.isdeadwidth = 56;
                    this.isdeadheight = 32;
                    this.ishurtwidth = 41;
                    this.ishurtheight = 39;
                    this.walkwidth = 44;
                    this.walkheight = 34;

                    this.bonusPoints = 200;

                    this.standleft = new Image[1];
                    this.standright = new Image[1];
                    this.walkleft = new Image[6];
                    this.walkright = new Image[6];
                    this.isdeadleft = new Image[3];
                    this.isdeadright = new Image[3];

                    this.standleft[0] = EnemyFrames.redsnailleftstand1;
                    this.standright[0] = EnemyFrames.redsnailrightstand1;
                    this.walkleft[0] = EnemyFrames.redsnailleftwalk1;
                    this.walkleft[1] = EnemyFrames.redsnailleftwalk2;
                    this.walkleft[2] = EnemyFrames.redsnailleftwalk3;
                    this.walkleft[3] = EnemyFrames.redsnailleftwalk4;
                    this.walkleft[4] = EnemyFrames.redsnailleftwalk5;
                    this.walkleft[5] = EnemyFrames.redsnailleftwalk6;
                    this.walkright[0] = EnemyFrames.redsnailrightwalk1;
                    this.walkright[1] = EnemyFrames.redsnailrightwalk2;
                    this.walkright[2] = EnemyFrames.redsnailrightwalk3;
                    this.walkright[3] = EnemyFrames.redsnailrightwalk4;
                    this.walkright[4] = EnemyFrames.redsnailrightwalk5;
                    this.walkright[5] = EnemyFrames.redsnailrightwalk6;
                    this.isdeadleft[0] = EnemyFrames.redsnailleftdie1;
                    this.isdeadleft[1] = EnemyFrames.redsnailleftdie2;
                    this.isdeadleft[2] = EnemyFrames.redsnailleftdie3;
                    this.isdeadright[0] = EnemyFrames.redsnailrightdie1;
                    this.isdeadright[1] = EnemyFrames.redsnailrightdie2;
                    this.isdeadright[2] = EnemyFrames.redsnailrightdie3;
                    this.ishurtleft = EnemyFrames.redsnaillefthurt1;
                    this.ishurtright = EnemyFrames.redsnailrighthurt1;
                    break;
                case CharacterType.bluesnail:
                    this.standwidth = 44;
                    this.standheight = 34;
                    this.isdeadwidth = 56;
                    this.isdeadheight = 32;
                    this.ishurtwidth = 41;
                    this.ishurtheight = 39;
                    this.walkwidth = 44;
                    this.walkheight = 34;

                    this.bonusPoints = 200;

                    this.standleft = new Image[1];
                    this.standright = new Image[1];
                    this.walkleft = new Image[6];
                    this.walkright = new Image[6];
                    this.isdeadleft = new Image[3];
                    this.isdeadright = new Image[3];

                    this.standleft[0] = EnemyFrames.bluesnailleftstand1;
                    this.standright[0] = EnemyFrames.bluesnailrightstand1;
                    this.walkleft[0] = EnemyFrames.bluesnailleftwalk1;
                    this.walkleft[1] = EnemyFrames.bluesnailleftwalk2;
                    this.walkleft[2] = EnemyFrames.bluesnailleftwalk3;
                    this.walkleft[3] = EnemyFrames.bluesnailleftwalk4;
                    this.walkleft[4] = EnemyFrames.bluesnailleftwalk5;
                    this.walkleft[5] = EnemyFrames.bluesnailleftwalk6;
                    this.walkright[0] = EnemyFrames.bluesnailrightwalk1;
                    this.walkright[1] = EnemyFrames.bluesnailrightwalk2;
                    this.walkright[2] = EnemyFrames.bluesnailrightwalk3;
                    this.walkright[3] = EnemyFrames.bluesnailrightwalk4;
                    this.walkright[4] = EnemyFrames.bluesnailrightwalk5;
                    this.walkright[5] = EnemyFrames.bluesnailrightwalk6;
                    this.isdeadleft[0] = EnemyFrames.bluesnailleftdie1;
                    this.isdeadleft[1] = EnemyFrames.bluesnailleftdie2;
                    this.isdeadleft[2] = EnemyFrames.bluesnailleftdie3;
                    this.isdeadright[0] = EnemyFrames.bluesnailrightdie1;
                    this.isdeadright[1] = EnemyFrames.bluesnailrightdie2;
                    this.isdeadright[2] = EnemyFrames.bluesnailrightdie3;
                    this.ishurtleft = EnemyFrames.bluesnaillefthurt1;
                    this.ishurtright = EnemyFrames.bluesnailrighthurt1;
                    break;
                case CharacterType.purplesnail:
                    this.standwidth = 35;
                    this.standheight = 34;
                    this.isdeadwidth = 56;
                    this.isdeadheight = 34;
                    this.ishurtwidth = 41;
                    this.ishurtheight = 39;
                    this.walkwidth = 41;
                    this.walkheight = 34;

                    this.bonusPoints = 200;

                    this.standleft = new Image[1];
                    this.standright = new Image[1];
                    this.walkleft = new Image[6];
                    this.walkright = new Image[6];
                    this.isdeadleft = new Image[3];
                    this.isdeadright = new Image[3];

                    this.standleft[0] = EnemyFrames.purplesnailleftstand1;
                    this.standright[0] = EnemyFrames.purplesnailrightstand1;
                    this.walkleft[0] = EnemyFrames.purplesnailleftwalk1;
                    this.walkleft[1] = EnemyFrames.purplesnailleftwalk2;
                    this.walkleft[2] = EnemyFrames.purplesnailleftwalk3;
                    this.walkleft[3] = EnemyFrames.purplesnailleftwalk4;
                    this.walkleft[4] = EnemyFrames.purplesnailleftwalk5;
                    this.walkleft[5] = EnemyFrames.purplesnailleftwalk6;
                    this.walkright[0] = EnemyFrames.purplesnailrightwalk1;
                    this.walkright[1] = EnemyFrames.purplesnailrightwalk2;
                    this.walkright[2] = EnemyFrames.purplesnailrightwalk3;
                    this.walkright[3] = EnemyFrames.purplesnailrightwalk4;
                    this.walkright[4] = EnemyFrames.purplesnailrightwalk5;
                    this.walkright[5] = EnemyFrames.purplesnailrightwalk6;
                    this.isdeadleft[0] = EnemyFrames.purplesnailleftdie1;
                    this.isdeadleft[1] = EnemyFrames.purplesnailleftdie2;
                    this.isdeadleft[2] = EnemyFrames.purplesnailleftdie3;
                    this.isdeadright[0] = EnemyFrames.purplesnailrightdie1;
                    this.isdeadright[1] = EnemyFrames.purplesnailrightdie2;
                    this.isdeadright[2] = EnemyFrames.purplesnailrightdie3;
                    this.ishurtleft = EnemyFrames.purplesnaillefthurt1;
                    this.ishurtright = EnemyFrames.purplesnailrighthurt1;
                    break;
                case CharacterType.bluepig:
                    this.standwidth = 69;
                    this.standheight = 49;
                    this.isdeadwidth = 71;
                    this.isdeadheight = 57;
                    this.ishurtwidth = 60;
                    this.ishurtheight = 54;
                    this.walkwidth = 67;
                    this.walkheight = 49;

                    this.bonusPoints = 100;
                    this.standleft = new Image[3];
                    this.standright = new Image[3];
                    this.walkleft = new Image[2];
                    this.walkright = new Image[2];
                    this.isdeadleft = new Image[4];
                    this.isdeadright = new Image[4];

                    this.standleft[0] = EnemyFrames.bluepigleftstand1;
                    this.standleft[1] = EnemyFrames.bluepigleftstand2;
                    this.standleft[2] = EnemyFrames.bluepigleftstand3;
                    this.standright[0] = EnemyFrames.bluepigrightstand1;
                    this.standright[1] = EnemyFrames.bluepigrightstand2;
                    this.standright[2] = EnemyFrames.bluepigrightstand3;
                    this.walkleft[0] = EnemyFrames.bluepigleftwalk1;
                    this.walkleft[1] = EnemyFrames.bluepigleftwalk2;             
                    this.walkright[0] = EnemyFrames.bluepigrightwalk1;
                    this.walkright[1] = EnemyFrames.bluepigrightwalk2;               
                    this.isdeadleft[0] = EnemyFrames.bluepigleftdie1;
                    this.isdeadleft[1] = EnemyFrames.bluepigleftdie2;
                    this.isdeadleft[2] = EnemyFrames.bluepigleftdie3;
                    this.isdeadleft[3] = EnemyFrames.bluepigleftdie4;
                    this.isdeadright[0] = EnemyFrames.bluepigrightdie1;
                    this.isdeadright[1] = EnemyFrames.bluepigrightdie2;
                    this.isdeadright[2] = EnemyFrames.bluepigrightdie3;
                    this.isdeadright[3] = EnemyFrames.bluepigrightdie4;
                    this.ishurtleft = EnemyFrames.bluepiglefthurt1;
                    this.ishurtright = EnemyFrames.bluepigrighthurt1;
                    break;
                case CharacterType.redpig:
                    this.standwidth = 69;
                    this.standheight = 49;
                    this.isdeadwidth = 78;
                    this.isdeadheight = 59;
                    this.ishurtwidth = 60;
                    this.ishurtheight = 54;
                    this.walkwidth = 67;
                    this.walkheight = 56;

                    this.bonusPoints = 100;

                    this.standleft = new Image[3];
                    this.standright = new Image[3];
                    this.walkleft = new Image[3];
                    this.walkright = new Image[3];
                    this.isdeadleft = new Image[3];
                    this.isdeadright = new Image[3];

                    this.standleft[0] = EnemyFrames.redpigleftstand1;
                    this.standleft[1] = EnemyFrames.redpigleftstand2;
                    this.standleft[2] = EnemyFrames.redpigleftstand3;
                    this.standright[0] = EnemyFrames.redpigrightstand1;
                    this.standright[1] = EnemyFrames.redpigrightstand2;
                    this.standright[2] = EnemyFrames.redpigrightstand3;
                    this.walkleft[0] = EnemyFrames.redpigleftwalk1;
                    this.walkleft[1] = EnemyFrames.redpigleftwalk2;
                    this.walkleft[2] = EnemyFrames.redpigleftwalk3;
                    this.walkright[0] = EnemyFrames.redpigrightwalk1;
                    this.walkright[1] = EnemyFrames.redpigrightwalk2;
                    this.walkright[2] = EnemyFrames.redpigrightwalk3;
                    this.isdeadleft[0] = EnemyFrames.redpigleftdie1;
                    this.isdeadleft[1] = EnemyFrames.redpigleftdie2;
                    this.isdeadleft[2] = EnemyFrames.redpigleftdie3;
                    this.isdeadright[0] = EnemyFrames.redpigrightdie1;
                    this.isdeadright[1] = EnemyFrames.redpigrightdie2;
                    this.isdeadright[2] = EnemyFrames.redpigrightdie3;
                    this.ishurtleft = EnemyFrames.redpiglefthurt1;
                    this.ishurtright = EnemyFrames.redpigrighthurt1;
                    break;
                case CharacterType.blueshroom:
                    this.standwidth = 56;
                    this.standheight = 52;
                    this.isdeadwidth = 59;
                    this.isdeadheight = 50;
                    this.ishurtwidth = 56;
                    this.ishurtheight = 56;
                    this.walkwidth = 56;
                    this.walkheight = 52;

                    this.bonusPoints = 50;

                    this.standleft = new Image[2];
                    this.standright = new Image[2];
                    this.walkleft = new Image[3];
                    this.walkright = new Image[3];
                    this.isdeadleft = new Image[3];
                    this.isdeadright = new Image[3];

                    this.standleft[0] = EnemyFrames.blueshroomleftstand1;
                    this.standleft[1] = EnemyFrames.blueshroomleftstand2;
                    this.standright[0] = EnemyFrames.blueshroomrightstand1;
                    this.standright[1] = EnemyFrames.blueshroomrightstand2;
                    this.walkleft[0] = EnemyFrames.blueshroomleftwalk1;
                    this.walkleft[1] = EnemyFrames.blueshroomleftwalk2;
                    this.walkleft[2] = EnemyFrames.blueshroomleftwalk3;
                    this.walkright[0] = EnemyFrames.blueshroomrightwalk1;
                    this.walkright[1] = EnemyFrames.blueshroomrightwalk2;
                    this.walkright[2] = EnemyFrames.blueshroomrightwalk3;
                    this.isdeadleft[0] = EnemyFrames.blueshroomleftdie1;
                    this.isdeadleft[1] = EnemyFrames.blueshroomleftdie2;
                    this.isdeadleft[2] = EnemyFrames.blueshroomleftdie3;
                    this.isdeadright[0] = EnemyFrames.blueshroomrightdie1;
                    this.isdeadright[1] = EnemyFrames.blueshroomrightdie2;
                    this.isdeadright[2] = EnemyFrames.blueshroomrightdie3;
                    this.ishurtleft = EnemyFrames.blueshroomlefthurt1;
                    this.ishurtright = EnemyFrames.blueshroomrighthurt1;
                    break;
                case CharacterType.greyshroom: 
              this.standwidth = 56;
                    this.standheight = 52;
                    this.isdeadwidth = 59;
                    this.isdeadheight = 50;
                    this.ishurtwidth = 56;
                    this.ishurtheight = 56;
                    this.walkwidth = 56;
                    this.walkheight = 52;

                    this.bonusPoints = 50;
                                    
                    this.standleft = new Image[2];
                    this.standright = new Image[2];
                    this.walkleft = new Image[3];
                    this.walkright = new Image[3];
                    this.isdeadleft = new Image[3];
                    this.isdeadright = new Image[3];

                    this.standleft[0] = EnemyFrames.greyshroomleftstand1;
                    this.standleft[1] = EnemyFrames.greyshroomleftstand2;
                    this.standright[0] = EnemyFrames.greyshroomrightstand1;
                    this.standright[1] = EnemyFrames.greyshroomrightstand2;
                    this.walkleft[0] = EnemyFrames.greyshroomleftwalk1;
                    this.walkleft[1] = EnemyFrames.greyshroomleftwalk2;
                    this.walkleft[2] = EnemyFrames.greyshroomleftwalk3;
                    this.walkright[0] = EnemyFrames.greyshroomrightwalk1;
                    this.walkright[1] = EnemyFrames.greyshroomrightwalk2;
                    this.walkright[2] = EnemyFrames.greyshroomrightwalk3;
                    this.isdeadleft[0] = EnemyFrames.greyshroomleftdie1;
                    this.isdeadleft[1] = EnemyFrames.greyshroomleftdie2;
                    this.isdeadleft[2] = EnemyFrames.greyshroomleftdie3;
                    this.isdeadright[0] = EnemyFrames.greyshroomrightdie1;
                    this.isdeadright[1] = EnemyFrames.greyshroomrightdie2;
                    this.isdeadright[2] = EnemyFrames.greyshroomrightdie3;
                    this.ishurtleft = EnemyFrames.greyshroomlefthurt1;
                    this.ishurtright = EnemyFrames.greyshroomrighthurt1;break;
                case CharacterType.greenshroom:
                    this.standwidth = 56;
                    this.standheight = 52;
                    this.isdeadwidth = 59;
                    this.isdeadheight = 50;
                    this.ishurtwidth = 56;
                    this.ishurtheight = 56;
                    this.walkwidth = 56;
                    this.walkheight = 52;

                    this.bonusPoints = 50;

                    this.standleft = new Image[2];
                    this.standright = new Image[2];
                    this.walkleft = new Image[3];
                    this.walkright = new Image[3];
                    this.isdeadleft = new Image[3];
                    this.isdeadright = new Image[3];

                    this.standleft[0] = EnemyFrames.greenshroomleftstand1;
                    this.standleft[1] = EnemyFrames.greenshroomleftstand2;
                    this.standright[0] = EnemyFrames.greenshroomrightstand1;
                    this.standright[1] = EnemyFrames.greenshroomrightstand2;
                    this.walkleft[0] = EnemyFrames.greenshroomleftwalk1;
                    this.walkleft[1] = EnemyFrames.greenshroomleftwalk2;
                    this.walkleft[2] = EnemyFrames.greenshroomleftwalk3;
                    this.walkright[0] = EnemyFrames.greenshroomrightwalk1;
                    this.walkright[1] = EnemyFrames.greenshroomrightwalk2;
                    this.walkright[2] = EnemyFrames.greenshroomrightwalk3;
                    this.isdeadleft[0] = EnemyFrames.greenshroomleftdie1;
                    this.isdeadleft[1] = EnemyFrames.greenshroomleftdie2;
                    this.isdeadleft[2] = EnemyFrames.greenshroomleftdie3;
                    this.isdeadright[0] = EnemyFrames.greenshroomrightdie1;
                    this.isdeadright[1] = EnemyFrames.greenshroomrightdie2;
                    this.isdeadright[2] = EnemyFrames.greenshroomrightdie3;
                    this.ishurtleft = EnemyFrames.greenshroomlefthurt1;
                    this.ishurtright = EnemyFrames.greenshroomrighthurt1;
                    break;
                case CharacterType.orangeshroom:
                    this.standwidth = 63;
                    this.standheight = 58;
                    this.isdeadwidth = 65;
                    this.isdeadheight = 59;
                    this.ishurtwidth = 62;
                    this.ishurtheight = 65;
                    this.walkwidth = 64;
                    this.walkheight = 67;

                    this.bonusPoints = 50;

                    this.standleft = new Image[2];
                    this.standright = new Image[2];
                    this.walkleft = new Image[3];
                    this.walkright = new Image[3];
                    this.isdeadleft = new Image[3];
                    this.isdeadright = new Image[3];

                    this.standleft[0] = EnemyFrames.orangeshroomleftstand1;
                    this.standleft[1] = EnemyFrames.orangeshroomleftstand2;
                    this.standright[0] = EnemyFrames.orangeshroomrightstand1;
                    this.standright[1] = EnemyFrames.orangeshroomrightstand2;
                    this.walkleft[0] = EnemyFrames.orangeshroomleftwalk1;
                    this.walkleft[1] = EnemyFrames.orangeshroomleftwalk2;
                    this.walkleft[2] = EnemyFrames.orangeshroomleftwalk3;
                    this.walkright[0] = EnemyFrames.orangeshroomrightwalk1;
                    this.walkright[1] = EnemyFrames.orangeshroomrightwalk2;
                    this.walkright[2] = EnemyFrames.orangeshroomrightwalk3;
                    this.isdeadleft[0] = EnemyFrames.orangeshroomleftdie1;
                    this.isdeadleft[1] = EnemyFrames.orangeshroomleftdie2;
                    this.isdeadleft[2] = EnemyFrames.orangeshroomleftdie3;
                    this.isdeadright[0] = EnemyFrames.orangeshroomrightdie1;
                    this.isdeadright[1] = EnemyFrames.orangeshroomrightdie2;
                    this.isdeadright[2] = EnemyFrames.orangeshroomrightdie3;
                    this.ishurtleft = EnemyFrames.orangeshroomlefthurt1;
                    this.ishurtright = EnemyFrames.orangeshroomrighthurt1;
                    break;
                default: break;
            }
            #endregion הכנסת תמונות
            this.maxHealth = 200.00;
            this.Health = 200.00;
            this.Attack = 150;
            this.accelerationXlimit = 3;
            this.rectangle = new Rectangle(x, y, this.standwidth, this.standheight);
            #region שורת חיים
            this.HealthbarImage = new Image[11];
            this.HealthbarImage[0] = EnemyFrames.HealthBar0_;
            this.HealthbarImage[1] = EnemyFrames.HealthBar10_;
            this.HealthbarImage[2] = EnemyFrames.HealthBar20_;
            this.HealthbarImage[3] = EnemyFrames.HealthBar30_;
            this.HealthbarImage[4] = EnemyFrames.HealthBar40_;
            this.HealthbarImage[5] = EnemyFrames.HealthBar50_;
            this.HealthbarImage[6] = EnemyFrames.HealthBar60_;
            this.HealthbarImage[7] = EnemyFrames.HealthBar70_;
            this.HealthbarImage[8] = EnemyFrames.HealthBar80_;
            this.HealthbarImage[9] = EnemyFrames.HealthBar90_;
            this.HealthbarImage[10] = EnemyFrames.HealthBar100_;
            this.healthbarlocation = new Point(this.rectangle.X, this.rectangle.Y -5);
            #endregion שורת חיים
            //---------------------------------טיימרים-----------------------------------
            this.moveTimer = new Timer();
            this.moveTimer.Enabled = true;
            this.moveTimer.Interval = 500;
            this.moveTimer.Tick += moveTimer_Tick;

            this.adjusthealthbarTimer = new Timer();
            this.adjusthealthbarTimer.Enabled = true;
            this.adjusthealthbarTimer.Interval = 1;
            this.adjusthealthbarTimer.Tick += AdjusthealthbarTimer_Tick;
            //---------------------------------הליכה זמנית------------------------------
            SetDirection(DirectionType.walkright); 
            //Move();                       
        }
        /// <summary>
        /// פעולת הורדת מספר נקודות חיים
        /// </summary>
        /// <param name="dmg">מספר הנקודות להוריד</param>
        /// <param name="truedmg">משתנה הקובע האם להתייחס להגנה של הדמות</param>
        public override void LooseHealth(int dmg, bool truedmg)
        {
            this.Health -= dmg;
            if (this.GetDirection() == 'l') { this.direction = DirectionType.ishurtleft; }
            if (this.GetDirection() == 'r') { this.direction = DirectionType.ishurtright; }
        }
        /// <summary>
        /// פעולה המתאימה את מיקום השורת חיים למפלצת
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdjusthealthbarTimer_Tick(object sender, EventArgs e)
        {
            this.healthbarlocation.X = this.rectangle.X;
            this.healthbarlocation.Y = this.rectangle.Y -5;
        }
        /// <summary>
        /// פעולה המציית את האויב על המסך
        /// </summary>
        /// <param name="e"></param>
        public void ShowEnemy(PaintEventArgs e)
        {
            this.ShowMe(e);
            this.percentageHealth = this.Health / this.maxHealth;
            if (this.percentageHealth> 0)
            {
                if (this.percentageHealth <= 0.1)
                    e.Graphics.DrawImage(this.HealthbarImage[1], this.healthbarlocation);
                else
                    if (this.percentageHealth <= 0.2)
                    e.Graphics.DrawImage(this.HealthbarImage[2], this.healthbarlocation);
                else
                    if (this.percentageHealth <= 0.3)
                    e.Graphics.DrawImage(this.HealthbarImage[3], this.healthbarlocation);
                else
                if (this.percentageHealth <= 0.4)
                    e.Graphics.DrawImage(this.HealthbarImage[4], this.healthbarlocation);
                else
                if (this.percentageHealth <= 0.5)
                    e.Graphics.DrawImage(this.HealthbarImage[5], this.healthbarlocation);
                else
                if (this.percentageHealth <= 0.6)
                    e.Graphics.DrawImage(this.HealthbarImage[6], this.healthbarlocation);
                else
                if (this.percentageHealth <= 0.7)
                    e.Graphics.DrawImage(this.HealthbarImage[7], this.healthbarlocation);
                else
                if (this.percentageHealth <= 0.8)
                    e.Graphics.DrawImage(this.HealthbarImage[8], this.healthbarlocation);
                else
                if (this.percentageHealth <= 0.9)
                    e.Graphics.DrawImage(this.HealthbarImage[9], this.healthbarlocation);
                else
                if (this.percentageHealth <= 1)
                    e.Graphics.DrawImage(this.HealthbarImage[10], this.healthbarlocation);               
            }
            else
            {
                if (this.GetDirection() == 'l') { this.direction = DirectionType.isdeadleft; }
                if (this.GetDirection() == 'r') { this.direction = DirectionType.isdeadright; }
            } 
        }
        /// <summary>
        /// טיימר הגורם לתנועה מחזורית של המפלצות
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void moveTimer_Tick(object sender, EventArgs e)//טיימר שגורם לתנועה מחזורית מימין לשמאל
        {
            if (this.direction == DirectionType.walkleft)//תנועה שמאלה לזמן מסויים
            {
                SetDirection(DirectionType.walkright);
                Move();
            }
            else
                if (this.direction == DirectionType.walkright)//ואז תנועה ימינה ! :D
                {
                    SetDirection(DirectionType.walkleft);
                    Move();
                }
        }
        /// <summary>
        /// פעולה המזיזה את הדמות
        /// </summary>
        /// <param name="p">מספר הפיקסלים שבו נזיז את הדמות שמאלה</param>
        internal void MoveLeft(int p)//כדי שהדמות תוכל לזוז חלק ביחד עם מסך הרקע
        {
            this.rectangle.X -= p;
        }
        /// <summary>
        /// פעולה המזיזה את הדמות
        /// </summary>
        /// <param name="p">מספר הפיקסלים שבו נזיז את הדמות ימינה</param>
        internal void MoveRight(int p)//כדי שהדמות תוכל לזוז חלק ביחד עם מסך הרקע
        {
            this.rectangle.X += p;
        }
        /// <summary>
        /// פעולת עצור
        /// </summary>
        public override void Stop()
        {
            this.changepicturesTimer.Enabled = false;
            this.velocityXTimer.Enabled = false;
            this.velocityYTimer.Enabled = false;
            this.moveTimer.Enabled = false;

        }
        /// <summary>
        /// פעולת המשך
        /// </summary>
        public override void Continue()
        {
            this.changepicturesTimer.Enabled = true;
            this.velocityXTimer.Enabled = true;
            this.velocityYTimer.Enabled = true;
            this.moveTimer.Enabled = true;
        }
        /// <summary>
        /// פעולת Get
        /// </summary>
        /// <returns>מחזיר את השווי של המפלצת בנקודות</returns>
        public int GetPoints()
        {
            return this.bonusPoints;
        }
    }
}
