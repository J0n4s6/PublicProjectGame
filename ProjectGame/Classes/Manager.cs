using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;

namespace ProjectGame.Classes
{
    /// <summary>
    /// דלגייט המשמ לעדכון שורות החיים והמאנה
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    public delegate void SendLoses<T>(T t);
    /// <summary>
    /// דלגייט המשמש לשליחת הניקוד בסוף משחק
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sc1"></param>
    /// <param name="sc2"></param>
    /// <param name="sc3"></param>
    /// <param name="sc4"></param>
    public delegate void SendScores<T>(T sc1, T sc2, T sc3, T sc4);
    public class Manager
    { 
        #region properties
        //------------------------------------תכונות\עצמים---------------------------------------
        /// <summary>
        /// הגיבור
        /// </summary>
        private Hero player;
        /// <summary>
        /// סוג הגיבור
        /// </summary>
        private CharacterType herotype;
        /// <summary>
        /// האויבים
        /// </summary>
        private List<Enemy> enemys;
        /// <summary>
        /// האוכל
        /// </summary>
        private List<Consumable> consumables;
        /// <summary>
        /// הריצפות
        /// </summary>
        private List<Floor> floors;
        /// <summary>
        /// הריצפה הראשונה
        /// </summary>
        private Floor firstfloor;
        /// <summary>
        /// הריצפה האחרונה
        /// </summary>
        private LvlPassFloor lastfloor;
        /// <summary>
        /// ההתקפות הסטטיות
        /// </summary>
        private List<StaticAttack> attacks;
        /// <summary>
        /// הכדורי קסם/ברק
        /// </summary>
        private List<MagicBall> chidoris;
        /// <summary>
        /// החצים
        /// </summary>
        private List<Arrow> arrows;
        /// <summary>
        /// הרקע של המשחק
        /// </summary>
        private Image BackGround;
        /// <summary>
        /// האייקונים של המתקפות ןזמן המחזור שלהם
        /// </summary>
        private Cooldown cooldown1, cooldown2, cooldown3;
        /// <summary>
        /// נגן מוסיקה
        /// </summary>
        private SoundPlayer playIt;
        //-----------------------------------תכונות\תכונות------------------------------------
        /// <summary>
        /// אינדקס לרמה
        /// </summary>
        private int currentlevel;
        /// <summary>
        /// משתנה רנדומלי
        /// </summary>
        public static Random r;
        /// <summary>
        /// סוג הרקע
        /// </summary>
        private BackgroundType bgtype;
        /// <summary>
        /// טיימר התנגשות עם ריצפה
        /// </summary>
        private Timer interactionwithfloorTimer;
        /// <summary>
        /// טיימר הזזת רקע
        /// </summary>
        private Timer movebackgroundTimer;
        /// <summary>
        /// טיימר התנגשות עם אוכל
        /// </summary>
        private Timer interactionwithconsumableTimer;
        /// <summary>
        /// טיימר התנגשות עם אויבים
        /// </summary>
        private Timer intercationwithenemyTimer;
        /// <summary>
        /// טיימר התאמת המתקפת לדמות
        /// </summary>
        private Timer adjustboostattacks;
        /// <summary>
        /// טיימר התנגשות אויבים עם מתקפות עפות
        /// </summary>
        private Timer intercationwithflyingattack;
        /// <summary>
        /// טיימר התנגשות עם מתקפה סטטית
        /// </summary>
        private Timer intercationwithstaticattack;
        /// <summary>
        /// טיימר בדיקת התנגשות עם מעבר לשלב הבא
        /// </summary>
        private Timer endlevelTimer;
        /// <summary>
        /// הניקוד לכל רמת משחק
        /// </summary>
        private int lvl1score, lvl2score, lvl3score, lvl4score;

        //-----------------------------------התרחשויות------------------------------------------
        /// <summary>
        /// שני איוונטים להתאמת שורות החיים והמאנה
        /// </summary>
        public event SendLoses<double> GetPercentageHealth, GetPercentageMana;
        /// <summary>
        /// איוונטים לעצירה והפעלת הטיימר
        /// </summary>
        public event EventHandler StopTime, ContinueTime;
        /// <summary>
        /// איוונט המוסר את הניקוד בסוף או בהפסד המשחק
        /// </summary>
        public event SendScores<int> TotalEndGame;
        /// <summary>
        /// איוונט המקבל את הזמן סיום השלב
        /// </summary>
        public event EventHandler GetTime;
        #endregion properties
        //-------------------------------------פעולות---------------------------------------\
        /// <summary>
        /// פעולה בונה
        /// </summary>
        /// <param name="ty">סוג הדמות שנבחר</param>
        public Manager(CharacterType ty)
        {
            this.herotype = ty;
            this.player = new Hero(ty);
            this.player.EndGame += player_EndGame;
            r = new Random();


            this.lvl1score = 0;
            this.lvl2score = 0;
            this.lvl3score = 0;
            this.lvl4score = 0;

            this.attacks = new List<StaticAttack>();
            this.chidoris = new List<MagicBall>();
            this.arrows = new List<Arrow>();

            #region יצירת מתקפות
            switch (ty)
            {
                case CharacterType.archer:
                    this.cooldown1 = new Cooldown(CharacterType.archer, 1);
                    this.cooldown2 = new Cooldown(CharacterType.archer, 2);
                    this.cooldown3 = new Cooldown(CharacterType.archer, 3);
                    break;
                case CharacterType.mage:
                    this.cooldown1 = new Cooldown(CharacterType.mage, 1);
                    this.cooldown2 = new Cooldown(CharacterType.mage, 2);
                    this.cooldown3 = new Cooldown(CharacterType.mage, 3);
                    break;
                case CharacterType.warrior:
                    this.cooldown1 = new Cooldown(CharacterType.warrior, 1);
                    this.cooldown2 = new Cooldown(CharacterType.warrior, 2);
                    this.cooldown3 = new Cooldown(CharacterType.warrior, 3);
                    break;

                default: break;
            }
            #endregion יצירת מתקפות

            #region יצירת רקע
            this.bgtype = 0;
            switch (this.bgtype)
            {
                case BackgroundType.Grass1: this.BackGround = GameResources.GrassBackground1; break;
                case BackgroundType.Grass2: this.BackGround = GameResources.GrassBackground2; break;
                case BackgroundType.Rock1: this.BackGround = GameResources.RockBackground1; break;
                case BackgroundType.Rock2: this.BackGround = GameResources.RockBackground2; break;

            }
            #endregion יצירת רקע

            #region יצירת אויבים
            this.enemys = new List<Enemy>();
            this.enemys.Add(new Enemy(1000, 0, CharacterType.blueshroom));
            this.enemys.Add(new Enemy(1500, 0, CharacterType.blueshroom));
            this.enemys.Add(new Enemy(2000, 0, CharacterType.blueshroom));
            this.enemys.Add(new Enemy(2500, 0, CharacterType.blueshroom));
            this.enemys.Add(new Enemy(3000, 0, CharacterType.blueshroom));
            this.enemys.Add(new Enemy(750, 0, CharacterType.greenshroom));
            this.enemys.Add(new Enemy(1250, 0, CharacterType.greenshroom));
            this.enemys.Add(new Enemy(1750, 0, CharacterType.greenshroom));
            this.enemys.Add(new Enemy(2250, 0, CharacterType.greenshroom));
            this.enemys.Add(new Enemy(2750, 0, CharacterType.greenshroom));
            this.enemys.Add(new Enemy(3250, 0, CharacterType.greenshroom));
            for (int i = 0; i < this.enemys.Count; i++)
                this.enemys[i].DeleteCharacter += Manager_DeleteCharacter;
            #endregion יצירת אויבים

            #region יצירת רצפת רמה ראשונה
            this.currentlevel = 1;
            this.floors = new List<Floor>();
            this.floors.Add(new Floor(-65, 385, this.bgtype, false));//מיצר ריצפה במקום -1
            this.GenerateFloors(0, 385, 15, false);//פעולה שיוצרת רצף ריצפות הכי נמוכות.
            this.GenerateFloors(975, 385, 30, true);
            this.GenerateFloors(2925, 385, 40, false);
            this.GenerateFloors(750, 285, 5, false);
            this.GenerateFloors(1100, 185, 9, false);
            this.GenerateFloors(1700, 85, 5, false);
            this.GenerateFloors(2100, 185, 5, false);
            this.GenerateFloors(2500, 285, 9, false);
            this.GenerateFloors(3100, 185, 9, false);
            this.GenerateFloors(3900, 85, 5, false);
            this.GenerateFloors(4300, 185, 5, false);
            this.GenerateFloors(4700, 285, 9, false);
            this.firstfloor = this.floors.ElementAt(1);//כדי לשים גבול בתחילת המפה
            this.lastfloor = new LvlPassFloor(FindLastFloor());
            #endregion יצירת רצפת רמה ראשונה

            #region יצירת בונוסים
            this.consumables = new List<Consumable>();
            this.GenerateConsumables();
            #endregion יצירת בונוסים

            #region הגדרת טיימרים
            this.interactionwithfloorTimer = new Timer();
            this.interactionwithfloorTimer.Enabled = true;
            this.interactionwithfloorTimer.Interval = 1;
            this.interactionwithfloorTimer.Tick += interactionwithfloorTimer_Tick;

            this.movebackgroundTimer = new Timer();
            this.movebackgroundTimer.Enabled = true;
            this.movebackgroundTimer.Interval = 1;
            this.movebackgroundTimer.Tick += movebackgroundTimer_Tick;

            this.interactionwithconsumableTimer = new Timer();
            this.interactionwithconsumableTimer.Enabled = true;
            this.interactionwithconsumableTimer.Interval = 1;
            this.interactionwithconsumableTimer.Tick += interactionwithconsumableTimer_Tick;

            this.intercationwithenemyTimer = new Timer();
            this.intercationwithenemyTimer.Enabled = true;
            this.intercationwithenemyTimer.Interval = 1;
            this.intercationwithenemyTimer.Tick += intercationwithenemyTimer_Tick;

            this.adjustboostattacks = new Timer();
            this.adjustboostattacks.Enabled = true;
            this.adjustboostattacks.Interval = 1;
            this.adjustboostattacks.Tick += adjustboostattacks_Tick;

            this.intercationwithflyingattack = new Timer();
            this.intercationwithflyingattack.Enabled = true;
            this.intercationwithflyingattack.Interval = 1;
            this.intercationwithflyingattack.Tick += Intercationwithflyingattack_Tick; ;

            this.intercationwithstaticattack = new Timer();
            this.intercationwithstaticattack.Enabled = true;
            this.intercationwithstaticattack.Interval = 330;
            this.intercationwithstaticattack.Tick += Intercationwithstaticattack_Tick;

            this.endlevelTimer = new Timer();
            this.endlevelTimer.Enabled = true;
            this.endlevelTimer.Interval = 1;
            this.endlevelTimer.Tick += endlevelTimer_Tick;
            #endregion הגדרת טיימרים
        }

   
        #region משהו מוזר
        internal StaticAttack StaticAttack
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal Consumable Consumable
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal Floor Floor
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal Arrow Arrow
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal MagicBall MagicBall
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal Hero Hero
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal Enemy Enemy
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal Cooldown Cooldown
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal LvlPassFloor LvlPassFloor
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
#endregion משהו מוזר
        /// <summary>
        /// פעולת סיום המשחק
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void player_EndGame(object sender, EventArgs e)
        {
            this.playIt = new SoundPlayer(Sounds.Sad_Trombone___Gaming_Sound_Effect_HD_);
            this.playIt.Play();            
            this.StopAllElements();
            GetTime(null, null);
            this.TotalEndGame(this.lvl1score,this.lvl2score,this.lvl3score,this.lvl4score);
        }
        
        #region timers
        /// <summary>
        /// בדיקת סיום הרמה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endlevelTimer_Tick(object sender, EventArgs e)
        {
            if (this.player.GetRectangle().IntersectsWith(this.lastfloor.GetRectangle()))
            {
                GetTime(null, null);
                GoToNextLevel();
            }
        }
        /// <summary>
        /// בדיקת התנגשות עם מתקפה סטטית
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Intercationwithstaticattack_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < this.enemys.Count; i++)
                for (int l = 0; l < this.attacks.Count; l++)
                    if ((this.attacks[l].isSwordsPlay() || this.attacks[l].isArrowRain()) && this.attacks[l].GetRectangle().IntersectsWith(this.enemys[i].GetRectangle()))
                        this.enemys[i].LooseHealth((int)this.player.GetAttack(),true);

        }
        /// <summary>
        /// בדיקת התנגשות עם מתקפה עפה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Intercationwithflyingattack_Tick(object sender, EventArgs e)
        {
            Rectangle rectangle;
            for (int i = 0; i < this.enemys.Count; i++)
            {
                rectangle = this.enemys[i].GetRectangle();
                for (int j = 0; j < this.arrows.Count; j++)
                    if (!this.arrows[j].GetisExplosion() && this.arrows[j].GetRectangle().IntersectsWith(rectangle))
                    {
                        this.enemys[i].LooseHealth((int)this.player.GetAttack(), true);
                        this.arrows[j].StopMoveTimer();
                        this.arrows[j].StopFallTimer();
                        this.arrows[j].SwitchObectToExplosion();
                    }
                for (int k = 0; k < this.chidoris.Count; k++)
                    if (!this.chidoris[k].GetisExplosion() && this.chidoris[k].GetRectangle().IntersectsWith(rectangle))
                    {
                        this.enemys[i].LooseHealth((int)this.player.GetAttack(), true);
                        this.chidoris[k].StopMoveTimer();
                        this.chidoris[k].SwitchObectToExplosion();
                    }

            }

        }
        /// <summary>
        /// מתאים את ההתקפה לדמות
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void adjustboostattacks_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.attacks.Count; i++)
            {
                if (this.attacks[i].isBoost())
                {
                    this.attacks[i].SetX(this.player.GetCharacterX1());
                    this.attacks[i].SetY(this.player.GetCharacterY());
                }
            }
        }
        /// <summary>
        /// פעולת הזזת הרקע
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void movebackgroundTimer_Tick(object sender, EventArgs e)
        {
            int playeracc = this.player.GetAccelerationX();
            if (this.player.GetCharacterX1() <= 300 && this.firstfloor.GetFloorX1() < 0)//גבול ימ ני
            {
                for (int i = 0; i < this.floors.Count; i++)
                    this.floors[i].MoveRight(playeracc);
                this.lastfloor.MoveRight(playeracc);
                for (int j = 0; j < this.consumables.Count; j++)
                    this.consumables[j].MoveRight(playeracc);
                for (int h = 0; h < this.enemys.Count; h++)
                    this.enemys[h].MoveRight(playeracc);
                for (int m = 0; m < this.chidoris.Count; m++)
                    this.chidoris[m].MoveRight(playeracc);
                for (int n = 0; n < this.arrows.Count; n++)
                    this.arrows[n].MoveRight(playeracc);
                for (int l = 0; l < this.attacks.Count; l++)
                    if (!this.attacks[l].isBoost())
                        this.attacks[l].MoveRight(playeracc);

            }
            if (this.player.GetCharacterX2() >= 580)
            {
                for (int i = 0; i < this.floors.Count; i++)//גבול שמאלי
                    this.floors[i].MoveLeft(playeracc);
                this.lastfloor.MoveLeft(playeracc);
                for (int j = 0; j < this.consumables.Count; j++)
                    this.consumables[j].MoveLeft(playeracc);
                for (int h = 0; h < this.enemys.Count; h++)
                    this.enemys[h].MoveLeft(playeracc);
                for (int m = 0; m < this.chidoris.Count; m++)
                    this.chidoris[m].MoveLeft(playeracc);
                for (int n = 0; n < this.arrows.Count; n++)
                    this.arrows[n].MoveLeft(playeracc);
                for (int l = 0; l < this.attacks.Count; l++)
                    if (!this.attacks[l].isBoost())
                        this.attacks[l].MoveLeft(playeracc);

            }
        }
        /// <summary>
        /// בדיקת התנגשות הדמויות עם הריצפה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void interactionwithfloorTimer_Tick(object sender, EventArgs e)
        {

            int heroY = this.player.GetCharacterY();
            int heroX1 = this.player.GetCharacterX1(), heroX2 = this.player.GetCharacterX2();
            int floorY;
            int floorX1, floorX2;

            for (int i = 0; i < this.floors.Count; i++)
            {
                floorY = this.floors[i].GetFloorY();
                floorX1 = this.floors[i].GetFloorX1();
                floorX2 = this.floors[i].GetFloorX2();

                if (heroY - 8 <= floorY)//כדי שהדמות תעמוד על הרצפות
                    if (floorX1 < heroX2 && floorX2 > heroX1)
                        this.player.SetArenaFloor(floorY);

                for (int j = 0; j < this.enemys.Count; j++)//כדי שהאויבים יעמדו על הרצפה
                    if (this.enemys[j].GetCharacterY() - 8 <= floorY)
                        if (floorX1 < this.enemys[j].GetCharacterX2() && floorX2 > this.enemys[j].GetCharacterX1())
                            this.enemys[j].SetArenaFloor(floorY);

                if (this.floors[i].GetisSpikes() && this.player.GetRectangle().IntersectsWith(this.floors[i].GetSpikesInteractRectangle()))
                    if (this.player.GetVulnerability())//הורדת חיים אם הדמות דורכת על קוצים
                    {
                        this.player.StartInvulnerability();
                        this.player.LooseHealth(150,true);
                        GetPercentageHealth(this.player.GetPercentageHealth());
                    }
            }
        }
        /// <summary>
        /// פעולת התנגשות האוכל עם הגיבור
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void interactionwithconsumableTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.consumables.Count; i++)
            {
                if (this.consumables[i].GetRectangle().IntersectsWith(this.player.GetRectangle()))
                {
                    switch (this.consumables[i].GetType())
                    {
                        case ConsumableType.hamburger:
                            this.player.HealHealth(50);
                            GetPercentageHealth(this.player.GetPercentageHealth());
                            this.player.HealMana(50);
                            GetPercentageMana(this.player.GetPercentageMana());
                            break;
                        case ConsumableType.healthpot:
                            this.player.HealHealth(50);
                            GetPercentageHealth(this.player.GetPercentageHealth());
                            break;
                        case ConsumableType.manapot:
                            this.player.HealMana(50);
                            GetPercentageMana(this.player.GetPercentageMana());
                            break;

                    }
                    this.consumables.RemoveAt(i);
                }
            }
        }
        /// <summary>
        /// בדיקת התנגשות הגיבור עם האויבים
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void intercationwithenemyTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.enemys.Count; i++)
            {
                if (this.player.GetRectangle().IntersectsWith(this.enemys[i].GetRectangle()))
                {
                    if (this.player.GetVulnerability())
                    {
                        this.player.LooseHealth((int)this.enemys[i].GetAttack(),false);//אומרים לדמות להפסיד חיים
                        GetPercentageHealth(this.player.GetPercentageHealth());
                        this.player.StartInvulnerability();
                    }
                }
            }

        }
        #endregion timers

        #region all elements methods
        /// <summary>
        /// פעולה המציירת את כל הדמויות ועצמים
        /// </summary>
        /// <param name="e"></param>
        public void ShowAllElements(PaintEventArgs e)
        {
            e.Graphics.DrawImage(this.BackGround, new Point(0, 0));
            for (int j = 0; j < this.floors.Count; j++)
                this.floors[j].ShowMe(e);
            for (int k = 0; k < this.consumables.Count; k++)
                this.consumables[k].ShowMe(e);
            for (int i = 0; i < this.enemys.Count; i++)
                this.enemys[i].ShowEnemy(e);
            if (this.cooldown1 != null) { this.cooldown1.ShowMe(e); }
            if (this.cooldown2 != null) { this.cooldown2.ShowMe(e); }
            if (this.cooldown3 != null) { this.cooldown3.ShowMe(e); }

            this.lastfloor.ShowLastFloor(e);

            this.player.ShowMe(e);
            for (int l = 0; l < this.attacks.Count; l++)
                this.attacks[l].ShowMe(e);
            for (int m = 0; m < this.arrows.Count; m++)
                this.arrows[m].ShowMe(e);
            for (int n = 0; n < this.chidoris.Count; n++)
                this.chidoris[n].ShowMe(e);
        }
        /// <summary>
        /// פעולה העוצר את כל העצמים
        /// </summary>
        public void StopAllElements()
        {
            this.player.Stop();
            this.movebackgroundTimer.Enabled = false;
            this.interactionwithfloorTimer.Enabled = false;
            this.interactionwithconsumableTimer.Enabled = false;
            this.intercationwithenemyTimer.Enabled = false;
            for (int i = 0; i < this.enemys.Count; i++)
                this.enemys[i].Stop();
            StopTime(null, null);
            this.cooldown1.Stop();
            this.cooldown2.Stop();
            this.cooldown3.Stop();

        }
        /// <summary>
        /// פעולה הממשיכה את כל העצמים
        /// </summary>
        public void ContinueAllElements()
        {
            this.player.Continue();
            this.movebackgroundTimer.Enabled = true;
            this.interactionwithfloorTimer.Enabled = true;
            this.interactionwithconsumableTimer.Enabled = true;
            this.intercationwithenemyTimer.Enabled = true;
            for (int i = 0; i < this.enemys.Count; i++)
                this.enemys[i].Continue();
            ContinueTime(null, null);
            this.cooldown1.Continue();
            this.cooldown2.Continue();
            this.cooldown3.Continue();

        }
        #endregion all elements methods

        #region character methods & events
        /// <summary>
        /// פעולה המזיזה את הגיבור בהקשת מקשים
        /// </summary>
        /// <param name="keyCode">המקש שהוקש</param>
        internal void MoveCharacter(Keys keyCode)
        {
            StaticAttack attack;

            switch (keyCode)
            {
                case Keys.Right: this.player.SetDirection(DirectionType.walkright); this.player.Move(); break;
                case Keys.Left: this.player.SetDirection(DirectionType.walkleft); this.player.Move(); break;
                case Keys.Up: this.player.Jump(); break;
                case Keys.Down: this.player.SetDirectionDown(); break;
                case Keys.Q:
                    if (this.cooldown1.isAvaible() && this.player.ManaCosts(1))
                    {
                        GetPercentageMana(this.player.GetPercentageMana());
                        this.player.SetDirectionToShoot();

                        attack = new StaticAttack(this.player.GetCharacterX1(), this.player.GetCharacterY(), 1, this.herotype, this.player.GetDirection());
                        attack.DeleteAttack += Manager_DeleteAttack;
                        this.attacks.Add(attack);


                        switch (this.herotype)
                        {
                            case CharacterType.mage:
                                this.player.HealHealth(this.player.GetMaxHealth()/2); GetPercentageHealth(this.player.GetPercentageHealth());
                                break;
                            case CharacterType.warrior: this.player.AddAttack(2); break;
                            case CharacterType.archer: this.player.AddAttack(2); break;
                        }
                        this.cooldown1.StartAnimate();
                        this.cooldown1.Effects += Cooldown1_Effects;
                    }
                    break;
                case Keys.W:
                    if (this.cooldown2.isAvaible() && this.player.ManaCosts(2))
                    {
                        GetPercentageMana(this.player.GetPercentageMana());
                        this.player.SetDirectionToShoot();
                        attack = new StaticAttack(this.player.GetCharacterX1(), this.player.GetCharacterY(), 2, this.herotype, this.player.GetDirection());
                        attack.DeleteAttack += Manager_DeleteAttack;
                        this.attacks.Add(attack);

                        switch (this.herotype)
                        {
                            case CharacterType.mage: this.player.AddAttack(1.5); this.player.AddDefense(1.5); break;
                            case CharacterType.warrior: this.player.AddDefense(2); break;
                        }
                        this.cooldown2.StartAnimate();
                        this.cooldown2.Effects += Cooldown2_Effects;

                    }
                    break;
                case Keys.E:
                    if (this.cooldown3.isAvaible() && this.player.ManaCosts(3))
                    {
                        GetPercentageMana(this.player.GetPercentageMana());
                        this.player.SetDirectionToShoot();

                        attack = new StaticAttack(this.player.GetCharacterX1(), this.player.GetCharacterY(), 3, this.herotype, this.player.GetDirection());
                        attack.DeleteAttack += Manager_DeleteAttack;
                        this.attacks.Add(attack);

                        this.cooldown3.StartAnimate();
                        this.cooldown3.Effects += Cooldown3_Effects;
                    }
                    break;
                case Keys.H: this.enemys[2].StartInvulnerability(); break;

            }
        }
        /// <summary>
        /// פעולת מחיקת ההתקפה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Manager_DeleteAttack(object sender, EventArgs e)
        {
            StaticAttack att = (StaticAttack)sender;
            if (att.isArrow())
            {
                Arrow arr;
                if (att.GetDirection() == 'l')
                {
                    arr = new Arrow(att.GetAttackX1() - 10, att.GetAttackY() + 50, 'l');
                    arr.DeleteArrow += Manager_DeleteArrow;
                    this.arrows.Add(arr);
                }
                if (att.GetDirection() == 'r')
                {
                    arr = new Arrow(att.GetAttackX2() - 100, att.GetAttackY() + 50, 'r');
                    arr.DeleteArrow += Manager_DeleteArrow;
                    this.arrows.Add(arr);
                }
                
            }
            if (att.isMagicBall())
            {
                MagicBall ball;
                if (att.GetDirection() == 'l')
                {
                    ball = new MagicBall(att.GetAttackX1() + 20, att.GetAttackY() + 40, 'l');
                    ball.DeleteMagicBall += Manager_DeleteMagicBall;
                    this.chidoris.Add(ball);
                }
                if (att.GetDirection() == 'r')
                {
                    ball = new MagicBall(att.GetAttackX2() - 100, att.GetAttackY() + 40, 'r');
                    ball.DeleteMagicBall += Manager_DeleteMagicBall;
                    this.chidoris.Add(ball);
                }
            }
            this.attacks.Remove(att);

            if (this.attacks.Count == 0)
                this.player.SetDirectionToStand();
        }
        /// <summary>
        /// פעולת מחיקת כדור הקסם
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Manager_DeleteMagicBall(object sender, EventArgs e)
        {
            MagicBall ball = (MagicBall)sender;
            this.chidoris.Remove(ball);
        }
        /// <summary>
        /// פעולת מחיקת החץ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Manager_DeleteArrow(object sender, EventArgs e)
        {
            Arrow arr = (Arrow)sender;
            this.arrows.Remove(arr);
        }
        /// <summary>
        /// פעולת מחיקת האויב
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Manager_DeleteCharacter(object sender, EventArgs e)
        {
            this.playIt = new SoundPlayer(Sounds.Super_Mario_Bros);
            this.playIt.Play();
            Enemy enem = (Enemy)sender;    
            this.enemys.Remove(enem);
            switch (this.currentlevel)
            {
                case 1: this.lvl1score += enem.GetPoints(); break;
                case 2: this.lvl2score += enem.GetPoints(); break;
                case 3: this.lvl3score += enem.GetPoints(); break;
                case 4: this.lvl4score += enem.GetPoints(); break;
                default: break;
            }
        }
        /// <summary>
        /// פעולת עצירת הדמות בתנועתה
        /// </summary>
        /// <param name="keyCode"></param>
        internal void StopCharacter(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.Right: this.player.SetDirection(DirectionType.standright); this.player.SetVelocityX(); break;
                case Keys.Left: this.player.SetDirection(DirectionType.standleft); this.player.SetVelocityX(); break;
                case Keys.Up: this.player.SetDirectionToStand(); this.player.SetVelocityX(); break;
                case Keys.Down: this.player.SetDirectionToStand(); break;
            }
        }
        #endregion character methods & events

        #region cooldowns effects
        private void Cooldown3_Effects(object sender, EventArgs e)
        { }
        /// <summary>
        /// החזרת נתוני התקפה והגנה של הגיבור לנורמה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cooldown2_Effects(object sender, EventArgs e)
        {
            if (this.herotype == CharacterType.mage)
            {
                this.player.ReturnAttackToNorm();
                this.player.ReturnDefenseToNorm();
            }
            if (this.herotype == CharacterType.warrior)
                this.player.ReturnDefenseToNorm();
        }
        /// <summary>
        /// החזרת נתוני הגיבור לנורמה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cooldown1_Effects(object sender, EventArgs e)
        {
            if (this.herotype == CharacterType.archer || this.herotype == CharacterType.warrior)
                this.player.ReturnAttackToNorm();
        }
        #endregion cooldowns effects
        /// <summary>
        /// פעולת עזר ליצירת רצפות
        /// </summary>
        /// <param name="locationx">מיקום איקס התחלתי לשרשרת הריצפות</param>
        /// <param name="locationy">מיקום וואי התחלתי לשרשרת הריצפות</param>
        /// <param name="numberoffloors">מספר הריצפות</param>
        private void GenerateFloors(int locationx, int locationy, int numberoffloors)
        {
            int rndm;
            for (int i = 0; i < numberoffloors; i++)
            {
                rndm = r.Next(1, 11);
                if (rndm <= 1)
                    this.floors.Add(new Floor((locationx + (i * 65)), locationy, this.bgtype, true));
                else
                    this.floors.Add(new Floor((locationx + (i * 65)), locationy, this.bgtype, false));
            }
        }
        /// <summary>
        /// פעולה שנייה של עזר ליצירת ריצפות
        /// </summary>
        /// <param name="locationx">מיקום איקס התחלתי לשרשרת הריצפות</param>
        /// <param name="locationy">מיקום וואי התחלתי לשרשרת הריצפות</param>
        /// <param name="numberoffloors">מספר הריצפות</param>
        /// <param name="spikey">אם הריצפה דוקרת או לא</param>
        private void GenerateFloors(int locationx, int locationy, int numberoffloors, bool spikey)
        {
            for (int i = 0; i < numberoffloors; i++)
                this.floors.Add(new Floor((locationx + (i * 65)), locationy, this.bgtype, spikey));

        }
        /// <summary>
        /// פעולת יצירת אוכל על הריצפות
        /// </summary>
        private void GenerateConsumables()
        {
            for (int i = 0; i < 15; i++)
            {
                
                Floor randomfloor = this.floors[r.Next(10, this.floors.Count)];
                if (!randomfloor.GetisSpikes())
                    this.consumables.Add(new Consumable(randomfloor.GetFloorX1() + 32, randomfloor.GetFloorY() - 25, (ConsumableType)r.Next(3)));
                else
                    i--;
            }
        }
        /// <summary>
        /// פעולת עזר שעוזרת לי למצוא את הריצפה הרחוקה ביותר
        /// </summary>
        /// <returns></returns>
        private Floor FindLastFloor()
        {
            List<Floor> temp = this.floors;
            int maxX;
            Floor maxXfloor;
            //-------------------------------
            maxX = temp[0].GetFloorX1();
            maxXfloor = temp[0];
            for (int i = 1; i < temp.Count; i++)
            {
                if (temp[i].GetFloorX1() > maxX)
                {
                    maxXfloor = temp[i];
                    maxX = maxXfloor.GetFloorX1();
                }
            }
            return maxXfloor;
        }
        /// <summary>
        /// פעולת עזר שמחליפה את כל הרמה לרמה הבאה
        /// </summary>
        private void GoToNextLevel()
        {
            //--------------------מפה חדשה----------------------       
            this.currentlevel++;

            this.bgtype = (BackgroundType)(this.currentlevel - 1);
            this.floors.Clear();
            this.enemys.Clear();
            switch (this.currentlevel)
            {
                case 2:
                    this.floors.Add(new Floor(-65, 385, this.bgtype, false));//מיצר ריצפה במקום -1
                    this.GenerateFloors(0, 385, 75, true);//פעולה שיוצרת רצף ריצפות הכי נמוכות.
                    this.GenerateFloors(750, 285, 5, false);
                    this.GenerateFloors(1100, 185, 9, false);
                    this.GenerateFloors(1700, 85, 5, false);
                    this.GenerateFloors(2100, 185, 5, false);
                    this.GenerateFloors(2500, 285, 9, false);
                    this.GenerateFloors(3100, 185, 9, false);
                    this.GenerateFloors(3600, 85, 5, false);
                    this.GenerateFloors(4000, 185, 9, false);

                    this.enemys.Add(new Enemy(1000, 0, CharacterType.greyshroom));
                    this.enemys.Add(new Enemy(1500, 0, CharacterType.greyshroom));
                    this.enemys.Add(new Enemy(2000, 0, CharacterType.greyshroom));
                    this.enemys.Add(new Enemy(2500, 0, CharacterType.greyshroom));
                    this.enemys.Add(new Enemy(3000, 0, CharacterType.greyshroom));
                    this.enemys.Add(new Enemy(750, 0, CharacterType.redpig));
                    this.enemys.Add(new Enemy(1250, 0, CharacterType.redpig));
                    this.enemys.Add(new Enemy(1750, 0, CharacterType.redpig));
                    this.enemys.Add(new Enemy(2250, 0, CharacterType.redpig));
                    this.enemys.Add(new Enemy(2750, 0, CharacterType.redpig));
                    this.enemys.Add(new Enemy(3250, 0, CharacterType.redpig));
                    break;
                case 3:
                    this.floors.Add(new Floor(-65, 385, this.bgtype, false));//מיצר ריצפה במקום -1
                    this.GenerateFloors(0, 385, 65, false);//פעולה שיוצרת רצף ריצפות הכי נמוכות.
                    this.GenerateFloors(750, 285, 5, false);
                    this.GenerateFloors(1100, 185, 9, false);
                    this.GenerateFloors(1700, 85, 5, false);
                    this.GenerateFloors(2100, 185, 5, false);
                    this.GenerateFloors(2500, 285, 9, false);
                    this.GenerateFloors(3100, 185, 9, false);
                    this.GenerateFloors(3600, 85, 5, false);

                    this.enemys.Add(new Enemy(1000, 0, CharacterType.bluesnail));
                    this.enemys.Add(new Enemy(1500, 0, CharacterType.purplesnail));
                    this.enemys.Add(new Enemy(2000, 0, CharacterType.bluesnail));
                    this.enemys.Add(new Enemy(2500, 0, CharacterType.bluesnail));
                    this.enemys.Add(new Enemy(3000, 0, CharacterType.redsnail));
                    this.enemys.Add(new Enemy(750, 0, CharacterType.redsnail));
                    this.enemys.Add(new Enemy(1250, 0, CharacterType.redsnail));
                    this.enemys.Add(new Enemy(1750, 0, CharacterType.redsnail));
                    this.enemys.Add(new Enemy(2250, 0, CharacterType.purplesnail));
                    this.enemys.Add(new Enemy(2750, 0, CharacterType.purplesnail));
                    this.enemys.Add(new Enemy(3250, 0, CharacterType.purplesnail));
                    break;
                case 4:
                    this.floors.Add(new Floor(-65, 385, this.bgtype, false));//מיצר ריצפה במקום -1
                    this.GenerateFloors(0, 385, 60, false);//פעולה שיוצרת רצף ריצפות הכי נמוכות.
                    this.GenerateFloors(750, 285, 5, false);
                    this.GenerateFloors(1100, 185, 9, false);
                    this.GenerateFloors(1700, 85, 5, false);
                    this.GenerateFloors(2100, 185, 5, false);
                    this.GenerateFloors(2500, 285, 9, false);
                    this.GenerateFloors(3100, 185, 9, false);
                    this.GenerateFloors(3900, 85, 5, false);

                    this.enemys.Add(new Enemy(1000, 0, CharacterType.orangeshroom));
                    this.enemys.Add(new Enemy(1500, 0, CharacterType.bluepig));
                    this.enemys.Add(new Enemy(2000, 0, CharacterType.orangeshroom));
                    this.enemys.Add(new Enemy(2500, 0, CharacterType.orangeshroom));
                    this.enemys.Add(new Enemy(3000, 0, CharacterType.bluepig));
                    this.enemys.Add(new Enemy(750, 0, CharacterType.orangeshroom));
                    this.enemys.Add(new Enemy(1250, 0, CharacterType.bluepig));
                    this.enemys.Add(new Enemy(1750, 0, CharacterType.bluepig));
                    this.enemys.Add(new Enemy(2250, 0, CharacterType.orangeshroom));
                    this.enemys.Add(new Enemy(2750, 0, CharacterType.orangeshroom));
                    this.enemys.Add(new Enemy(3250, 0, CharacterType.bluepig));

                    break;
                case 5: TotalEndGame(this.lvl1score, this.lvl2score, this.lvl3score, this.lvl4score); break;
                default: break;

            }
            if (this.currentlevel < 5)
            {
                for (int i = 0; i < this.enemys.Count; i++)
                    this.enemys[i].DeleteCharacter += Manager_DeleteCharacter;
                //------------------

                this.firstfloor = this.floors.ElementAt(1);//כדי לשים גבול בתחילת המפה
                this.lastfloor = new LvlPassFloor(FindLastFloor());

                switch (this.bgtype)
                {
                    case BackgroundType.Grass1: this.BackGround = GameResources.GrassBackground1; break;
                    case BackgroundType.Grass2: this.BackGround = GameResources.GrassBackground2; break;
                    case BackgroundType.Rock1: this.BackGround = GameResources.RockBackground1; break;
                    case BackgroundType.Rock2: this.BackGround = GameResources.RockBackground2; break;

                }
                //-----------------דמות חדשה----------------------
                this.player.NewLife();
                GetPercentageHealth(this.player.GetPercentageHealth());
                GetPercentageMana(this.player.GetPercentageMana());

                //----------------משקאות חדשים------------------
                this.consumables.Clear();
                this.GenerateConsumables();

            }
        }
        /// <summary>
        /// מחזיר את שם הגיבור בו השתמש השחקן
        /// </summary>
        /// <returns></returns>
        public string GetPlayerType()
        {
            switch (this.herotype)
            {
                case CharacterType.archer: return "Archer";
                case CharacterType.mage: return "Mage";
                case CharacterType.warrior: return "Warrior";
                default: return "Human";
            }
        }
        /// <summary>
        /// פעולה המקבלת את הזמן בו סיים השחקן את המשחק
        /// </summary>
        /// <param name="stopwatch">שעון עצר</param>
        public void SendStopWatch(Stopwatch stopwatch)
        {
            switch(currentlevel)
            {
                case 1: 
                    if(stopwatch.Elapsed.Minutes<3)
                    {
                        this.lvl1score += 1000 * (2 - stopwatch.Elapsed.Minutes);
                        this.lvl1score += 10 * (60 - stopwatch.Elapsed.Seconds);
                    }
                            break;
                case 2:
                         if(stopwatch.Elapsed.Minutes<3)
                    {
                        this.lvl2score += 1000 * (2 - stopwatch.Elapsed.Minutes);
                        this.lvl2score+=10*(60-stopwatch.Elapsed.Seconds);
                    }
                     
                    break;
                case 3:
                    if (stopwatch.Elapsed.Minutes < 3)
                    {
                        this.lvl3score += 1000 * (2 - stopwatch.Elapsed.Minutes);
                        this.lvl3score += 10 * (60 - stopwatch.Elapsed.Seconds);
                    }

                    break;
                case 4:
                    if (stopwatch.Elapsed.Minutes < 3)
                    {
                        this.lvl4score += 1000 * (2 - stopwatch.Elapsed.Minutes);
                        this.lvl4score += 10 * (60 - stopwatch.Elapsed.Seconds);
                    }

                    break;
            }
        }
        /// <summary>
        /// פעולת Get
        /// </summary>
        /// <returns>מחזיר את הניקוד לרמה העכשוית</returns>
        public int GetScore()
        {
            switch (this.currentlevel)
            {
                case 1: return this.lvl1score;
                case 2: return this.lvl2score;
                case 3: return this.lvl3score;
                case 4: return this.lvl4score;
                default: return 0;
            }
        }
    }
}
/// <summary>
/// משתנה לסוג הרקע/רצפה
/// </summary>
public enum BackgroundType
{
    Grass1,Rock1,Grass2,Rock2,
}
