using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectGame.Classes
{
    class Hero:Character
    {
        
        //--------------------------------------תכונות מחלקה-------------------------
        
        //-------------------------------------פעולות--------------------------
        /// <summary>
        /// פעולה בונה
        /// </summary>
        /// <param name="ty">סוג הגיבור</param>
        public Hero(CharacterType ty)
            : base(ty)
        {
            #region characters stats 
            switch (this.type)
            {                
                case CharacterType.archer:
                    this.Health = 750.00;
                    this.maxHealth = 750.00;
                    this.Mana = 500.00;
                    this.maxMana = 500.00;
                    this.Attack = 75;
                    this.maxAttack = 150;
                    this.minAttack = 75;
                    this.Defense = 25;
                    this.maxDefense = 25;
                    this.minDefense = 25;
                    this.move1manacost = 50;
                    this.move2manacost = 15;
                    this.move3manacost = 75;
                    break;
                case CharacterType.mage:
                    this.Health = 600.00;
                    this.maxHealth = 600.00;
                    this.Mana = 1000.00;
                    this.maxMana = 1000.00;
                    this.Attack = 50;
                    this.maxAttack = 100;
                    this.minAttack = 50;
                    this.Defense = 35;
                    this.maxDefense = 70;
                    this.minDefense = 35;
                    this.move1manacost = 50;
                    this.move2manacost = 50;
                    this.move3manacost = 35;
                    break;
                case CharacterType.warrior:
                    this.Health = 1000.00;
                    this.maxHealth = 1000.00;
                    this.Mana = 500.00;
                    this.maxMana = 500.00;
                    this.Attack = 40;
                    this.maxAttack = 80;
                    this.minAttack = 40;
                    this.Defense = 75;
                    this.maxDefense = 150;
                    this.minDefense = 75;
                    this.move1manacost = 50;
                    this.move2manacost = 50;
                    this.move3manacost = 15;
                    break;
                default: break;
            }
            #endregion characters stats
            //-------------------------------------------            
            this.jumplimit = 0;
            this.accelerationXlimit = 8;
            this.invulnerablecount = 0;

            this.standleft = new Image[5];
            this.standright = new Image[5];
            this.walkleft = new Image[4];
            this.walkright = new Image[4];
            this.shootleft = new Image[3];
            this.shootright = new Image[3];

            #region הכנסת תמונות
            switch (this.type)
            {
                case CharacterType.warrior:
                    this.downwidth = 84;
                    this.downheight = 43;
                    this.jumpwidth = 45;
                    this.jumpheight = 75;
                    this.standwidth = 63;
                    this.standheight = 69;
                    this.walkwidth = 70;
                    this.walkheight = 69;
                    this.shootwidth = 126;
                    this.shootheight = 77;
                    this.downleft = HeroFrames.warriorleftdown1;
                    this.downright = HeroFrames.warriorrightdown1;
                    this.jumpleft = HeroFrames.warriorleftjump1;
                    this.jumpright = HeroFrames.warriorrightjump1;
                    this.standleft[0] = HeroFrames.warriorleftstand1;
                    this.standleft[1] = HeroFrames.warriorleftstand2;
                    this.standleft[2] = HeroFrames.warriorleftstand3;
                    this.standleft[3] = HeroFrames.warriorleftstand4;
                    this.standleft[4] = HeroFrames.warriorleftstand5;
                    this.standright[0] = HeroFrames.warriorrightstand1;
                    this.standright[1] = HeroFrames.warriorrightstand2;
                    this.standright[2] = HeroFrames.warriorrightstand3;
                    this.standright[3] = HeroFrames.warriorrightstand4;
                    this.standright[4] = HeroFrames.warriorrightstand5;
                    this.walkleft[0] = HeroFrames.warriorleftwalk1;
                    this.walkleft[1] = HeroFrames.warriorleftwalk2;
                    this.walkleft[2] = HeroFrames.warriorleftwalk3;
                    this.walkleft[3] = HeroFrames.warriorleftwalk4;
                    this.walkright[0] = HeroFrames.warriorrightwalk1;
                    this.walkright[1] = HeroFrames.warriorrightwalk2;
                    this.walkright[2] = HeroFrames.warriorrightwalk3;
                    this.walkright[3] = HeroFrames.warriorrightwalk4;
                    this.shootleft[0] = HeroFrames.warriorleftshoot1;
                    this.shootleft[1] = HeroFrames.warriorleftshoot2;
                    this.shootleft[2] = HeroFrames.warriorleftshoot3;
                    this.shootright[0] = HeroFrames.warriorrightshoot1;
                    this.shootright[1] = HeroFrames.warriorrightshoot2;
                    this.shootright[2] = HeroFrames.warriorrightshoot3;
                    break;

                case CharacterType.mage:
                    this.downwidth = 72;
                    this.downheight = 71;
                    this.jumpwidth = 67;
                    this.jumpheight = 95;
                    this.standwidth = 67;
                    this.standheight = 97;
                    this.walkwidth = 67;
                    this.walkheight = 97;
                    this.shootwidth = 90;
                    this.shootheight = 97;
                    this.downleft = HeroFrames.mageleftdown1;
                    this.downright = HeroFrames.magerightdown1;
                    this.jumpleft = HeroFrames.mageleftjump1;
                    this.jumpright = HeroFrames.magerightjump1;
                    this.standleft[0] = HeroFrames.mageleftstand1;
                    this.standleft[1] = HeroFrames.mageleftstand2;
                    this.standleft[2] = HeroFrames.mageleftstand3;
                    this.standleft[3] = HeroFrames.mageleftstand4;
                    this.standleft[4] = HeroFrames.mageleftstand5;
                    this.standright[0] = HeroFrames.magerightstand1;
                    this.standright[1] = HeroFrames.magerightstand2;
                    this.standright[2] = HeroFrames.magerightstand3;
                    this.standright[3] = HeroFrames.magerightstand4;
                    this.standright[4] = HeroFrames.magerightstand5;
                    this.walkleft[0] = HeroFrames.mageleftwalk1;
                    this.walkleft[1] = HeroFrames.mageleftwalk2;
                    this.walkleft[2] = HeroFrames.mageleftwalk3;
                    this.walkleft[3] = HeroFrames.mageleftwalk4;
                    this.walkright[0] = HeroFrames.magerightwalk1;
                    this.walkright[1] = HeroFrames.magerightwalk2;
                    this.walkright[2] = HeroFrames.magerightwalk3;
                    this.walkright[3] = HeroFrames.magerightwalk4;
                    this.shootleft[0] = HeroFrames.mageleftshoot1;
                    this.shootleft[1] = HeroFrames.mageleftshoot2;
                    this.shootleft[2] = HeroFrames.mageleftshoot3;
                    this.shootright[0] = HeroFrames.magerightshoot1;
                    this.shootright[1] = HeroFrames.magerightshoot2;
                    this.shootright[2] = HeroFrames.magerightshoot3;
                    break;

                case CharacterType.archer:
                    this.downwidth = 98;
                    this.downheight = 50;
                    this.jumpwidth = 56;
                    this.jumpheight = 86;
                    this.standwidth = 74;
                    this.standheight = 77;
                    this.walkwidth = 77;
                    this.walkheight = 77;
                    this.shootwidth = 67;
                    this.shootheight = 77;
                    this.downleft = HeroFrames.archerleftdown1;
                    this.downright = HeroFrames.archerrightdown1;
                    this.jumpleft = HeroFrames.archerleftjump1;
                    this.jumpright = HeroFrames.archerrightjump1;
                    this.standleft[0] = HeroFrames.archerleftstand1;
                    this.standleft[1] = HeroFrames.archerleftstand2;
                    this.standleft[2] = HeroFrames.archerleftstand3;
                    this.standleft[3] = HeroFrames.archerleftstand4;
                    this.standleft[4] = HeroFrames.archerleftstand5;
                    this.standright[0] = HeroFrames.archerrightstand1;
                    this.standright[1] = HeroFrames.archerrightstand2;
                    this.standright[2] = HeroFrames.archerrightstand3;
                    this.standright[3] = HeroFrames.archerrightstand4;
                    this.standright[4] = HeroFrames.archerrightstand5;
                    this.walkleft[0] = HeroFrames.archerleftwalk1;
                    this.walkleft[1] = HeroFrames.archerleftwalk2;
                    this.walkleft[2] = HeroFrames.archerleftwalk3;
                    this.walkleft[3] = HeroFrames.archerleftwalk4;
                    this.walkright[0] = HeroFrames.archerrightwalk1;
                    this.walkright[1] = HeroFrames.archerrightwalk2;
                    this.walkright[2] = HeroFrames.archerrightwalk3;
                    this.walkright[3] = HeroFrames.archerrightwalk4;
                    this.shootleft[0] = HeroFrames.archerleftshoot1;
                    this.shootleft[1] = HeroFrames.archerleftshoot2;
                    this.shootleft[2] = HeroFrames.archerleftshoot3;
                    this.shootright[0] = HeroFrames.archerrightshoot1;
                    this.shootright[1] = HeroFrames.archerrightshoot2;
                    this.shootright[2] = HeroFrames.archerrightshoot3;
                    break;
            }
            #endregion הכנסת תמונות

            this.rectangle = new Rectangle((440 - (this.standwidth / 2)), this.arenafloor - this.standheight, this.standwidth, this.standheight);
            //---------------------------------------------טיימרים---------------------------------
        }

        #region timers
   
            /// <summary>
            /// פעולת הזזת הדמות בהתאם למהירות ולכיוונה
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public override void velocityXTimer_Tick(object sender, EventArgs e)//דרושה פעולת טיימר חדשה בגלל הגבולות של הדמות על המסך
        {
            if ((this.direction == DirectionType.walkleft || this.direction == DirectionType.jumpleft) && this.GetCharacterX1() > 300)
            { this.rectangle.X -= accelerationX; }
            if ((this.direction == DirectionType.walkright || this.direction == DirectionType.jumpright) && this.GetCharacterX2() < 580)
            { this.rectangle.X += accelerationX; }
            if (this.direction == DirectionType.standleft || this.direction == DirectionType.standright || this.direction == DirectionType.downleft || this.direction == DirectionType.downright || this.direction == DirectionType.shootleft | this.direction == DirectionType.shootright)
            { this.accelerationX = 0; }
        }
        #endregion timers

        /// <summary>
        /// פעולת עצירה
        /// </summary>
        public override void Stop()
        {
            this.changepicturesTimer.Enabled = false;
            this.velocityXTimer.Enabled = false;
            this.velocityYTimer.Enabled = false;
            if(!isVulnerable)
            {
                this.shakingTimer.Enabled = false;
                this.vulnerableTimer.Enabled = false;
            }
        }
        /// <summary>
        /// פעולת המשך
        /// </summary>
        public override void Continue()
        {
            this.changepicturesTimer.Enabled = true;
            this.velocityXTimer.Enabled = true;
            this.velocityYTimer.Enabled = true;
            if (!isVulnerable)
            {
                this.shakingTimer.Enabled = true;
                this.vulnerableTimer.Enabled = true;
            }
        }

        #region get & set methods
        /// <summary>
        /// פעולה המעדכנת את מיקום הדמות במעבר שלב
        /// </summary>
        public void NewLife()
        {           
            this.rectangle.X = 150;
            this.rectangle.Y = 0;
        }
        /// <summary>
        /// פעולה הבודקת ומבצעת את המתקפה שנבחרה ע"י השחקן
        /// </summary>
        /// <param name="indicator">מספר המתקפה לתקיפה</param>
        /// <returns>מחזיר שקר אם לא בוצעה המתקפה ואחרת אם היא בוצעה</returns>
        public bool ManaCosts(int indicator)//שולח את מספר המתקפה ומחזיר true אם ניתן לתקוף
        {
            if (Mana > 0)
            {
                switch (indicator)
                {
                    case 1:
                        if (this.Mana >= this.move1manacost)
                        {
                            this.Mana -= move1manacost;
                            return true;
                        }
                        break;
                    case 2:
                        if (this.Mana >= this.move2manacost)
                        {
                            this.Mana -= move2manacost;
                            return true;
                        }
                        break;
                    case 3:
                        if (this.Mana >= this.move3manacost)
                        {
                            this.Mana -= move3manacost;
                            return true;
                        }
                        break;

                }
            }
            return false;
        }
        /// <summary>
        /// מחזיר את מספר החיים המקסימלי
        /// </summary>
        /// <returns>ערך החיים המקסימלי</returns>
        public int GetMaxHealth()
        {
            return (int)this.maxHealth;
        }
        #endregion get & set methods


    }

    
}
