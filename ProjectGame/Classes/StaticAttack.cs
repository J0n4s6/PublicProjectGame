using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjectGame.Classes
{
    class StaticAttack
    {
        //--------------------------------------תכונות--------------------------
        /// <summary>
        /// מלבן המתקפת
        /// </summary>
        private Rectangle rectangle;
        /// <summary>
        /// מערך תמונות ימינה ושמאלה
        /// </summary>
        private Image[] imagesright, imagesleft;
        /// <summary>
        /// אינדקס תמונה עכשוית
        /// </summary>
        private int currentindexpicture;
        /// <summary>
        /// טיימר החלפת תמונות
        /// </summary>
        private Timer changepicturesTimer;
       /// <summary>
       /// תו המראה את כיוון המתקפה
       /// </summary>
        private char direction;
        /// <summary>
        /// מרחק המתקפה מהדמות משני הצדדים
        /// </summary>
        private int leftdx, rightdx, dy;
        /// <summary>
        /// "משתנה שמטרתו להפסיק את פעולת העצם אם העצם "מת
        /// </summary>
        private bool flag;
        /// <summary>
        /// איוונט מחיקת העצם
        /// </summary>
        public event EventHandler DeleteAttack;
        /// <summary>
        /// סוג המתקפה המתאימה לגיבור
        /// </summary>
        private CharacterType attacktype;
        /// <summary>
        /// מספר המתקפה
        /// </summary>
        private int attacknumber;
        //--------------------------------------פעולות----------------------------
        /// <summary>
        /// פעולה בונה
        /// </summary>
        /// <param name="x">איקס התחלתי</param>
        /// <param name="y">וואי התחלתי</param>
        /// <param name="attnum">מספר המתקפה</param>
        /// <param name="ty">סוג המתקפה</param>
        /// <param name="di">כיוון המתקפה</param>
        public StaticAttack(int x,int y,int attnum,CharacterType ty,char di)
        {
            this.flag = true;
            this.currentindexpicture = 0;
            this.attacknumber = attnum;
            this.attacktype = ty;
            this.direction = di;
            //-----------------------------טיימרים-------------------------------
            this.changepicturesTimer = new Timer();
            this.changepicturesTimer.Enabled = true;
            this.changepicturesTimer.Tick += changepicturesTimer_Tick;           
            //-------------------------------------תמונות---------------------------
            #region הכנסת תמונות
            switch (attacktype)
            {
                case CharacterType.archer:
                    switch (this.attacknumber)
                    {
                        case 1:
                            this.rightdx = 20;
                            this.leftdx = 20;
                            this.dy = 90;

              

                            this.imagesleft = new Image[9];
                            this.imagesright = new Image[9];
                            this.imagesleft[0] = AttackFrames.ArcherBoost1;
                            this.imagesleft[1] = AttackFrames.ArcherBoost2;
                            this.imagesleft[2] = AttackFrames.ArcherBoost3;
                            this.imagesleft[3] = AttackFrames.ArcherBoost4;
                            this.imagesleft[4] = AttackFrames.ArcherBoost5;
                            this.imagesleft[5] = AttackFrames.ArcherBoost6;
                            this.imagesleft[6] = AttackFrames.ArcherBoost7;
                            this.imagesleft[7] = AttackFrames.ArcherBoost8;
                            this.imagesleft[8] = AttackFrames.ArcherBoost9;

                            this.imagesright[0] = AttackFrames.ArcherBoost1;
                            this.imagesright[1] = AttackFrames.ArcherBoost2;
                            this.imagesright[2] = AttackFrames.ArcherBoost3;
                            this.imagesright[3] = AttackFrames.ArcherBoost4;
                            this.imagesright[4] = AttackFrames.ArcherBoost5;
                            this.imagesright[5] = AttackFrames.ArcherBoost6;
                            this.imagesright[6] = AttackFrames.ArcherBoost7;
                            this.imagesright[7] = AttackFrames.ArcherBoost8;
                            this.imagesright[8] = AttackFrames.ArcherBoost9;

                            if (this.direction == 'l') { this.rectangle = new Rectangle(x-leftdx, y-dy, 120, 120); }
                            if (this.direction == 'r') { this.rectangle = new Rectangle(x-rightdx, y-dy, 120, 120); }

                            this.changepicturesTimer.Interval = 130;
                            break;

                        case 2:
                            this.rightdx =20;
                            this.leftdx = 58;
                            this.dy = 90;

                            this.imagesleft = new Image[24];
                            this.imagesright = new Image[24];
                            this.imagesleft[0] = AttackFrames.ArcherLeftArrowEffect1;
                            this.imagesleft[1] = AttackFrames.ArcherLeftArrowEffect2;
                            this.imagesleft[2] = AttackFrames.ArcherLeftArrowEffect3;
                            this.imagesleft[3] = AttackFrames.ArcherLeftArrowEffect4;
                            this.imagesleft[4] = AttackFrames.ArcherLeftArrowEffect5;
                            this.imagesleft[5] = AttackFrames.ArcherLeftArrowEffect6;
                            this.imagesleft[6] = AttackFrames.ArcherLeftArrowEffect7;
                            this.imagesleft[7] = AttackFrames.ArcherLeftArrowEffect8;
                            this.imagesleft[8] = AttackFrames.ArcherLeftArrowEffect9;
                            this.imagesleft[9] = AttackFrames.ArcherLeftArrowEffect10;
                            this.imagesleft[10] = AttackFrames.ArcherLeftArrowEffect11;
                            this.imagesleft[11] = AttackFrames.ArcherLeftArrowEffect12;
                            this.imagesleft[12] = AttackFrames.ArcherLeftArrowEffect13;
                            this.imagesleft[13] = AttackFrames.ArcherLeftArrowEffect14;
                            this.imagesleft[14] = AttackFrames.ArcherLeftArrowEffect15;
                            this.imagesleft[15] = AttackFrames.ArcherLeftArrowEffect16;
                            this.imagesleft[16] = AttackFrames.ArcherLeftArrowEffect17;
                            this.imagesleft[17] = AttackFrames.ArcherLeftArrowEffect18;
                            this.imagesleft[18] = AttackFrames.ArcherLeftArrowEffect19;
                            this.imagesleft[19] = AttackFrames.ArcherLeftArrowEffect20;
                            this.imagesleft[20] = AttackFrames.ArcherLeftArrowEffect21;
                            this.imagesleft[21] = AttackFrames.ArcherLeftArrowEffect22;
                            this.imagesleft[22] = AttackFrames.ArcherLeftArrowEffect23;
                            this.imagesleft[23] = AttackFrames.ArcherLeftArrowEffect24;

                            this.imagesright[0] = AttackFrames.ArcherRightArrowEffect1;
                            this.imagesright[1] = AttackFrames.ArcherRightArrowEffect2;
                            this.imagesright[2] = AttackFrames.ArcherRightArrowEffect3;
                            this.imagesright[3] = AttackFrames.ArcherRightArrowEffect4;
                            this.imagesright[4] = AttackFrames.ArcherRightArrowEffect5;
                            this.imagesright[5] = AttackFrames.ArcherRightArrowEffect6;
                            this.imagesright[6] = AttackFrames.ArcherRightArrowEffect7;
                            this.imagesright[7] = AttackFrames.ArcherRightArrowEffect8;
                            this.imagesright[8] = AttackFrames.ArcherRightArrowEffect9;
                            this.imagesright[9] = AttackFrames.ArcherRightArrowEffect10;
                            this.imagesright[10] = AttackFrames.ArcherRightArrowEffect11;
                            this.imagesright[11] = AttackFrames.ArcherRightArrowEffect12;
                            this.imagesright[12] = AttackFrames.ArcherRightArrowEffect13;
                            this.imagesright[13] = AttackFrames.ArcherRightArrowEffect14;
                            this.imagesright[14] = AttackFrames.ArcherRightArrowEffect15;
                            this.imagesright[15] = AttackFrames.ArcherRightArrowEffect16;
                            this.imagesright[16] = AttackFrames.ArcherRightArrowEffect17;
                            this.imagesright[17] = AttackFrames.ArcherRightArrowEffect18;
                            this.imagesright[18] = AttackFrames.ArcherRightArrowEffect19;
                            this.imagesright[19] = AttackFrames.ArcherRightArrowEffect20;
                            this.imagesright[20] = AttackFrames.ArcherRightArrowEffect21;
                            this.imagesright[21] = AttackFrames.ArcherRightArrowEffect22;
                            this.imagesright[22] = AttackFrames.ArcherRightArrowEffect23;
                            this.imagesright[23] = AttackFrames.ArcherRightArrowEffect24;

                            if (this.direction == 'l') { this.rectangle = new Rectangle(x - leftdx, y - dy, 100, 120); }
                            if (this.direction == 'r') { this.rectangle = new Rectangle(x + rightdx, y - dy, 100, 120); }
                            this.changepicturesTimer.Interval = 50;
                            break;//למתקפה זו יש מחלקה מיוחדת נוספת

                        case 3:
                            this.rightdx = 180;
                            this.leftdx = 500;
                            this.dy = 300;


                            this.imagesleft = new Image[26];
                            this.imagesright = new Image[26];
                            this.imagesleft[0] = AttackFrames.ArrowRain1;
                            this.imagesleft[1] = AttackFrames.ArrowRain2;
                            this.imagesleft[2] = AttackFrames.ArrowRain3;
                            this.imagesleft[3] = AttackFrames.ArrowRain4;
                            this.imagesleft[4] = AttackFrames.ArrowRain5;
                            this.imagesleft[5] = AttackFrames.ArrowRain6;
                            this.imagesleft[6] = AttackFrames.ArrowRain7;
                            this.imagesleft[7] = AttackFrames.ArrowRain8;
                            this.imagesleft[8] = AttackFrames.ArrowRain9;
                            this.imagesleft[9] = AttackFrames.ArrowRain10;
                            this.imagesleft[10] = AttackFrames.ArrowRain11;
                            this.imagesleft[11] = AttackFrames.ArrowRain12;
                            this.imagesleft[12] = AttackFrames.ArrowRain13;
                            this.imagesleft[13] = AttackFrames.ArrowRain14;
                            this.imagesleft[14] = AttackFrames.ArrowRain15;
                            this.imagesleft[15] = AttackFrames.ArrowRain16;
                            this.imagesleft[16] = AttackFrames.ArrowRain17;
                            this.imagesleft[17] = AttackFrames.ArrowRain18;
                            this.imagesleft[18] = AttackFrames.ArrowRain19;
                            this.imagesleft[19] = AttackFrames.ArrowRain20;
                            this.imagesleft[20] = AttackFrames.ArrowRain21;
                            this.imagesleft[21] = AttackFrames.ArrowRain22;
                            this.imagesleft[22] = AttackFrames.ArrowRain23;
                            this.imagesleft[23] = AttackFrames.ArrowRain24;
                            this.imagesleft[24] = AttackFrames.ArrowRain25;
                            this.imagesleft[25] = AttackFrames.ArrowRain26;

                            this.imagesright[0] = AttackFrames.ArrowRain1;
                            this.imagesright[1] = AttackFrames.ArrowRain2;
                            this.imagesright[2] = AttackFrames.ArrowRain3;
                            this.imagesright[3] = AttackFrames.ArrowRain4;
                            this.imagesright[4] = AttackFrames.ArrowRain5;
                            this.imagesright[5] = AttackFrames.ArrowRain6;
                            this.imagesright[6] = AttackFrames.ArrowRain7;
                            this.imagesright[7] = AttackFrames.ArrowRain8;
                            this.imagesright[8] = AttackFrames.ArrowRain9;
                            this.imagesright[9] = AttackFrames.ArrowRain10;
                            this.imagesright[10] = AttackFrames.ArrowRain11;
                            this.imagesright[11] = AttackFrames.ArrowRain12;
                            this.imagesright[12] = AttackFrames.ArrowRain13;
                            this.imagesright[13] = AttackFrames.ArrowRain14;
                            this.imagesright[14] = AttackFrames.ArrowRain15;
                            this.imagesright[15] = AttackFrames.ArrowRain16;
                            this.imagesright[16] = AttackFrames.ArrowRain17;
                            this.imagesright[17] = AttackFrames.ArrowRain18;
                            this.imagesright[18] = AttackFrames.ArrowRain19;
                            this.imagesright[19] = AttackFrames.ArrowRain20;
                            this.imagesright[20] = AttackFrames.ArrowRain21;
                            this.imagesright[21] = AttackFrames.ArrowRain22;
                            this.imagesright[22] = AttackFrames.ArrowRain23;
                            this.imagesright[23] = AttackFrames.ArrowRain24;
                            this.imagesright[24] = AttackFrames.ArrowRain25;
                            this.imagesright[25] = AttackFrames.ArrowRain26;

                            if (this.direction == 'l') { this.rectangle = new Rectangle(x - leftdx, y - dy, 403, 353); }
                            if (this.direction == 'r') { this.rectangle = new Rectangle(x + rightdx, y - dy, 403, 353); }
                            this.changepicturesTimer.Interval = 100;
                            break;

                        default: break;
                    }
                    break;

                case CharacterType.mage:
                    switch (this.attacknumber)
                    {
                        case 1:
                            this.rightdx = 20;
                            this.leftdx = 20;
                            this.dy = 120;

                            this.imagesleft = new Image[9];
                            this.imagesright = new Image[9];
                            this.imagesleft[0] = AttackFrames.MageHeal1;
                            this.imagesleft[1] = AttackFrames.MageHeal2;
                            this.imagesleft[2] = AttackFrames.MageHeal3;
                            this.imagesleft[3] = AttackFrames.MageHeal4;
                            this.imagesleft[4] = AttackFrames.MageHeal5;
                            this.imagesleft[5] = AttackFrames.MageHeal6;
                            this.imagesleft[6] = AttackFrames.MageHeal7;
                            this.imagesleft[7] = AttackFrames.MageHeal8;
                            this.imagesleft[8] = AttackFrames.MageHeal9;

                            this.imagesright[0] = AttackFrames.MageHeal1;
                            this.imagesright[1] = AttackFrames.MageHeal2;
                            this.imagesright[2] = AttackFrames.MageHeal3;
                            this.imagesright[3] = AttackFrames.MageHeal4;
                            this.imagesright[4] = AttackFrames.MageHeal5;
                            this.imagesright[5] = AttackFrames.MageHeal6;
                            this.imagesright[6] = AttackFrames.MageHeal7;
                            this.imagesright[7] = AttackFrames.MageHeal8;
                            this.imagesright[8] = AttackFrames.MageHeal9;

                            if (this.direction == 'l') { this.rectangle = new Rectangle(x - leftdx, y - dy, 98, 130); }
                            if (this.direction == 'r') { this.rectangle = new Rectangle(x - rightdx, y - dy, 98, 130); }
                            this.changepicturesTimer.Interval = 150;
                            break;

                        case 2:
                            this.rightdx = 20;
                            this.leftdx = 20;
                            this.dy = 155;



                            this.imagesleft=new Image[12];
                            this.imagesright=new Image[12];
                            this.imagesleft[0]=AttackFrames.MageLeftBoost1;
                            this.imagesleft[1]=AttackFrames.MageLeftBoost2;
                            this.imagesleft[2]=AttackFrames.MageLeftBoost3;
                            this.imagesleft[3]=AttackFrames.MageLeftBoost4;
                            this.imagesleft[4]=AttackFrames.MageLeftBoost5;
                            this.imagesleft[5]=AttackFrames.MageLeftBoost6;
                            this.imagesleft[6]=AttackFrames.MageLeftBoost7;
                            this.imagesleft[7]=AttackFrames.MageLeftBoost8;
                            this.imagesleft[8]=AttackFrames.MageLeftBoost9;
                            this.imagesleft[9]=AttackFrames.MageLeftBoost10;
                            this.imagesleft[10]=AttackFrames.MageLeftBoost11;
                            this.imagesleft[11]=AttackFrames.MageLeftBoost12;

                            this.imagesright[0]=AttackFrames.MageRightBoost1;
                            this.imagesright[1] = AttackFrames.MageRightBoost2;
                            this.imagesright[2] = AttackFrames.MageRightBoost3;
                            this.imagesright[3] = AttackFrames.MageRightBoost4;
                            this.imagesright[4] = AttackFrames.MageRightBoost5;
                            this.imagesright[5] = AttackFrames.MageRightBoost6;
                            this.imagesright[6] = AttackFrames.MageRightBoost7;
                            this.imagesright[7] = AttackFrames.MageRightBoost8;
                            this.imagesright[8] = AttackFrames.MageRightBoost9;
                            this.imagesright[9] = AttackFrames.MageRightBoost10;
                            this.imagesright[10] = AttackFrames.MageRightBoost11;
                            this.imagesright[11] = AttackFrames.MageRightBoost12;

                            if (this.direction == 'l') { this.rectangle = new Rectangle(x - leftdx, y - dy, 111, 171); }
                            if (this.direction == 'r') { this.rectangle = new Rectangle(x - rightdx, y - dy, 111, 171); }
                            this.changepicturesTimer.Interval = 100;
                            break;

                        case 3:
                            this.rightdx = 20;
                            this.leftdx = 80;
                            this.dy = 100;


                            this.imagesleft = new Image[7];
                            this.imagesright = new Image[7];
                            this.imagesleft[0] = AttackFrames.MageLeftEnergyBallEffect1;
                            this.imagesleft[1] = AttackFrames.MageLeftEnergyBallEffect2;
                            this.imagesleft[2] = AttackFrames.MageLeftEnergyBallEffect3;
                            this.imagesleft[3] = AttackFrames.MageLeftEnergyBallEffect4;
                            this.imagesleft[4] = AttackFrames.MageLeftEnergyBallEffect5;
                            this.imagesleft[5] = AttackFrames.MageLeftEnergyBallEffect6;
                            this.imagesleft[6] = AttackFrames.MageLeftEnergyBallEffect7;

                            this.imagesright[0] = AttackFrames.RightEnergyBallEffect1;
                            this.imagesright[1] = AttackFrames.RightEnergyBallEffect2;
                            this.imagesright[2] = AttackFrames.RightEnergyBallEffect3;
                            this.imagesright[3] = AttackFrames.RightEnergyBallEffect4;
                            this.imagesright[4] = AttackFrames.RightEnergyBallEffect5;
                            this.imagesright[5] = AttackFrames.RightEnergyBallEffect6;
                            this.imagesright[6] = AttackFrames.RightEnergyBallEffect7;

                            if (this.direction == 'l') { this.rectangle = new Rectangle(x - leftdx, y - dy, 146, 125); }
                            if (this.direction == 'r') { this.rectangle = new Rectangle(x + rightdx, y - dy, 146, 125); }
                            this.changepicturesTimer.Interval = 100;
                            break;//למתקפה זו יש מחלקה מיוחדת נוספת

                        default: break;
                    }
                    break;

                case CharacterType.warrior:
                    switch (this.attacknumber)
                    {
                        case 1:
                            this.rightdx = 30;
                            this.leftdx = 30;
                            this.dy = 110;



                            this.imagesleft = new Image[9];
                            this.imagesright = new Image[9];
                            this.imagesleft[0] = AttackFrames.WarriorAttackBoost1;
                            this.imagesleft[1] = AttackFrames.WarriorAttackBoost2;
                            this.imagesleft[2] = AttackFrames.WarriorAttackBoost3;
                            this.imagesleft[3] = AttackFrames.WarriorAttackBoost2;
                            this.imagesleft[4] = AttackFrames.WarriorAttackBoost3;
                            this.imagesleft[5] = AttackFrames.WarriorAttackBoost2;
                            this.imagesleft[6] = AttackFrames.WarriorAttackBoost3;
                            this.imagesleft[7] = AttackFrames.WarriorAttackBoost4;
                            this.imagesleft[8] = AttackFrames.WarriorAttackBoost5;

                            this.imagesright[0] = AttackFrames.WarriorAttackBoost1;
                            this.imagesright[1] = AttackFrames.WarriorAttackBoost2;
                            this.imagesright[2] = AttackFrames.WarriorAttackBoost3;
                            this.imagesright[3] = AttackFrames.WarriorAttackBoost2;
                            this.imagesright[4] = AttackFrames.WarriorAttackBoost3;
                            this.imagesright[5] = AttackFrames.WarriorAttackBoost2;
                            this.imagesright[6] = AttackFrames.WarriorAttackBoost3;
                            this.imagesright[7] = AttackFrames.WarriorAttackBoost4;
                            this.imagesright[8] = AttackFrames.WarriorAttackBoost5;

                            if (this.direction == 'l') { this.rectangle = new Rectangle(x - leftdx, y - dy, 140, 159); }
                            if (this.direction == 'r') { this.rectangle = new Rectangle(x - rightdx, y - dy, 140, 159); }
                            this.changepicturesTimer.Interval = 150;
                            break;

                        case 2:
                            this.rightdx = 20;
                            this.leftdx = 20;
                            this.dy = 90;

                            this.imagesleft = new Image[18];
                            this.imagesright = new Image[18];
                            this.imagesleft[0] = AttackFrames.WarriorDefenseBoost1;
                            this.imagesleft[1] = AttackFrames.WarriorDefenseBoost2;
                            this.imagesleft[2] = AttackFrames.WarriorDefenseBoost3;
                            this.imagesleft[3] = AttackFrames.WarriorDefenseBoost4;
                            this.imagesleft[4] = AttackFrames.WarriorDefenseBoost5;
                            this.imagesleft[5] = AttackFrames.WarriorDefenseBoost6;
                            this.imagesleft[6] = AttackFrames.WarriorDefenseBoost7;
                            this.imagesleft[7] = AttackFrames.WarriorDefenseBoost8;
                            this.imagesleft[8] = AttackFrames.WarriorDefenseBoost9;
                            this.imagesleft[9] = AttackFrames.WarriorDefenseBoost10;
                            this.imagesleft[10] = AttackFrames.WarriorDefenseBoost11;
                            this.imagesleft[11] = AttackFrames.WarriorDefenseBoost12;
                            this.imagesleft[12] = AttackFrames.WarriorDefenseBoost13;
                            this.imagesleft[13] = AttackFrames.WarriorDefenseBoost14;
                            this.imagesleft[14] = AttackFrames.WarriorDefenseBoost15;
                            this.imagesleft[15] = AttackFrames.WarriorDefenseBoost16;
                            this.imagesleft[16] = AttackFrames.WarriorDefenseBoost17;
                            this.imagesleft[17] = AttackFrames.WarriorDefenseBoost18;

                            this.imagesright[0] = AttackFrames.WarriorDefenseBoost1;
                            this.imagesright[1] = AttackFrames.WarriorDefenseBoost2;
                            this.imagesright[2] = AttackFrames.WarriorDefenseBoost3;
                            this.imagesright[3] = AttackFrames.WarriorDefenseBoost4;
                            this.imagesright[4] = AttackFrames.WarriorDefenseBoost5;
                            this.imagesright[5] = AttackFrames.WarriorDefenseBoost6;
                            this.imagesright[6] = AttackFrames.WarriorDefenseBoost7;
                            this.imagesright[7] = AttackFrames.WarriorDefenseBoost8;
                            this.imagesright[8] = AttackFrames.WarriorDefenseBoost9;
                            this.imagesright[9] = AttackFrames.WarriorDefenseBoost10;
                            this.imagesright[10] = AttackFrames.WarriorDefenseBoost11;
                            this.imagesright[11] = AttackFrames.WarriorDefenseBoost12;
                            this.imagesright[12] = AttackFrames.WarriorDefenseBoost13;
                            this.imagesright[13] = AttackFrames.WarriorDefenseBoost14;
                            this.imagesright[14] = AttackFrames.WarriorDefenseBoost15;
                            this.imagesright[15] = AttackFrames.WarriorDefenseBoost16;
                            this.imagesright[16] = AttackFrames.WarriorDefenseBoost17;
                            this.imagesright[17] = AttackFrames.WarriorDefenseBoost18;

                            if (this.direction == 'l') { this.rectangle = new Rectangle(x - leftdx, y - dy, 120, 138); }
                            if (this.direction == 'r') { this.rectangle = new Rectangle(x - rightdx, y - dy, 120, 138); }
                            this.changepicturesTimer.Interval = 75;
                            break;

                        case 3:
                            this.rightdx = 45;
                            this.leftdx = 110;
                            this.dy = 110;
                            this.imagesleft = new Image[12];
                            this.imagesright = new Image[12];
                            this.imagesleft[0] = AttackFrames.LeftSwordsPlay1;
                            this.imagesleft[1] = AttackFrames.LeftSwordsPlay2;
                            this.imagesleft[2] = AttackFrames.LeftSwordsPlay3;
                            this.imagesleft[3] = AttackFrames.LeftSwordsPlay4;
                            this.imagesleft[4] = AttackFrames.LeftSwordsPlay5;
                            this.imagesleft[5] = AttackFrames.LeftSwordsPlay6;
                            this.imagesleft[6] = AttackFrames.LeftSwordsPlay7;
                            this.imagesleft[7] = AttackFrames.LeftSwordsPlay8;
                            this.imagesleft[8] = AttackFrames.LeftSwordsPlay9;
                            this.imagesleft[9] = AttackFrames.LeftSwordsPlay10;
                            this.imagesleft[10] = AttackFrames.LeftSwordsPlay11;
                            this.imagesleft[11] = AttackFrames.LeftSwordsPlay12;

                            this.imagesright[0] = AttackFrames.RightSwordsPlay1;
                            this.imagesright[1] = AttackFrames.RightSwordsPlay2;
                            this.imagesright[2] = AttackFrames.RightSwordsPlay3;
                            this.imagesright[3] = AttackFrames.RightSwordsPlay4;
                            this.imagesright[4] = AttackFrames.RightSwordsPlay5;
                            this.imagesright[5] = AttackFrames.RightSwordsPlay6;
                            this.imagesright[6] = AttackFrames.RightSwordsPlay7;
                            this.imagesright[7] = AttackFrames.RightSwordsPlay8;
                            this.imagesright[8] = AttackFrames.RightSwordsPlay9;
                            this.imagesright[9] = AttackFrames.RightSwordsPlay10;
                            this.imagesright[10] = AttackFrames.RightSwordsPlay11;
                            this.imagesright[11] = AttackFrames.RightSwordsPlay12;

                            if (this.direction == 'l') { this.rectangle = new Rectangle(x - leftdx, y - dy, 165, 167); }
                            if (this.direction == 'r') { this.rectangle = new Rectangle(x + rightdx, y - dy, 165, 167); }
                            this.changepicturesTimer.Interval = 100;
                            break;

                        default: break;
                    }
                    break;
                default: break;
            }
            #endregion הכנסת תמונות

        }

        /// <summary>
        /// החלפת אינדקס תמונות
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void changepicturesTimer_Tick(object sender, EventArgs e)
        {
            this.currentindexpicture++;
            if (this.currentindexpicture == this.imagesleft.Length && this.flag)
            {
                this.flag = false;
                DeleteAttack(this, null);
            }
         
        }
        /// <summary>
        /// פעולה המציירת את המתקפה
        /// </summary>
        /// <param name="e"></param>
        public void ShowMe(PaintEventArgs e)
        {
            switch (this.direction)
            {
                
                case 'l': e.Graphics.DrawImage(this.imagesleft[this.currentindexpicture], this.rectangle); break;
                case 'r': e.Graphics.DrawImage(this.imagesright[this.currentindexpicture], this.rectangle); break;
                default: break;
            }
        }
        /// <summary>
        /// פעולה המתאימה את האיקס של המתקפה לפי הדמות
        /// </summary>
        /// <param name="x">ערך האיקס של הדמות</param>
        public void SetX(int x)
        {
            if (this.direction == 'l') { this.rectangle.X = x - this.leftdx; }
            if (this.direction == 'r') { this.rectangle.X = x - this.rightdx; }
        }
        /// <summary>
        /// פעולה המתאימה את הוואי של המתקפה לפי הדמות
        /// </summary>
        /// <param name="y">ערך הוואי של הדמות</param>
        public void SetY(int y)
        {
            this.rectangle.Y = y-this.dy;
        }
        /// <summary>
        /// בודק אם המתקפה היא עושה פגיעות או לא
        /// </summary>
        /// <returns>מחזיר נכון אם היא לא פוגעת ולא נכון אם היא פוגעת</returns>
        public bool isBoost()
        {
            if (this.attacknumber == 1) return true;
            if (this.attacknumber == 2 && (this.attacktype == CharacterType.warrior||this.attacktype==CharacterType.mage)) return true;
            return false;
        }
        /// <summary>
        /// פעולת הזזת המתקפה שמאלה
        /// </summary>
        /// <param name="p">מספר הפיקסלים להזזה</param>
        public void MoveLeft(int p)
        {
            this.rectangle.X -= p;
        }
        /// <summary>
        /// פעולת הזזת המתקפה ימינה
        /// </summary>
        /// <param name="p">מספר הפיקסלים להזזה</param>
        public void MoveRight(int p)
        {
            this.rectangle.X += p;
        }
        /// <summary>
        /// בודק אם סוג המתקפה היא חץ
        /// </summary>
        /// <returns>מחזיר נכון אם כן ,אם לא אחרת</returns>
        public bool isArrow()
        {
            if (this.attacktype == CharacterType.archer && this.attacknumber == 2)
                return true;
            return false;
        }
        /// <summary>
        /// בודק אם המתקפה מסוג כדור חשמל
        /// </summary>
        /// <returns>מחזיר נכון אם כן אחרת אם לא</returns>
        public bool isMagicBall()
        {
            if (this.attacktype == CharacterType.mage && this.attacknumber == 3)
                return true;
            return false;
        }
        /// <summary>
        /// בודק אם המתקפה מסוג משחק חרבות
        /// </summary>
        /// <returns>מחזירה נכון אם כן אחרת אם לא</returns>
        public bool isSwordsPlay()
        {
            if (this.attacktype == CharacterType.warrior && this.attacknumber == 3)
                return true;
            return false;
        }
        /// <summary>
        /// בודק אם המתקפה מסוג גדם חצים
        /// </summary>
        /// <returns>מחזירה נכון אם כן אחרת אם לא</returns>
        public bool isArrowRain()
        {
            if (this.attacktype == CharacterType.archer && this.attacknumber == 3)
                return true;
            return false;
        }
        /// <summary>
        /// פעולת Get
        /// </summary>
        /// <returns>מחזיר תו המצין כיוון</returns>
        public char GetDirection()
        {
            return this.direction;
        }
        /// <summary>
        /// פעולת Get
        /// </summary>
        /// <returns>מחזיר את האיקס הימני</returns>
        public int GetAttackX2()
        {
            return this.rectangle.X + this.rectangle.Width;
        }
        /// <summary>
        /// פעולת Get
        /// </summary>
        /// <returns>מחזיר את האיקס השמאלי</returns>
        public int GetAttackX1()
        {
            return this.rectangle.X;
        }
        /// <summary>
        /// פעולת Get
        /// </summary>
        /// <returns>מחזיר את הוואי העליון</returns>
        public int GetAttackY()
        {
            return this.rectangle.Y;
        }
        /// <summary>
        /// פעולת Get
        /// </summary>
        /// <returns>מחזיר את המלבן של המתקפה</returns>
        public Rectangle GetRectangle()
        {
            return this.rectangle;
        }
        
  
    }
}
