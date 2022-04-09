using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectGame.Classes
{
    class Cooldown
    {
        //-----------------------------תכונות-------------------------------
        /// <summary>
        /// מלבן העצם
        /// </summary>
        private Rectangle rectangle;
        /// <summary>
        /// מערך תמונות העצם
        /// </summary>
        private Image[] images;
        /// <summary>
        /// אינדקס תמונות
        /// </summary>
        private int currentindexpicture;
        /// <summary>
        /// סוג הדמות שלה מתאים העצם
        /// </summary>
        private CharacterType type;
        /// <summary>
        /// מספר המתקפה של הדמות
        /// </summary>
        private int attackindex;
        /// <summary>
        /// טיימר החלפת תמונות
        /// </summary>
        private Timer changepictureTimer;
        /// <summary>
        /// איוונט המראה למנאג'ר מה לעשות
        /// </summary>
        public event EventHandler Effects;
        //-------------------------------פעולות-----------------------------
        /// <summary>
        /// פעולה בונה
        /// </summary>
        /// <param name="ty">סוג הדמות שלה מתאים עצם מסוים</param>
        /// <param name="i">מספר המתאים למתקפה</param>
        public Cooldown(CharacterType ty, int i)
        {
            this.currentindexpicture = 0;
            this.type = ty;
            this.attackindex = i;
            this.images = new Image[9];

            this.changepictureTimer = new Timer();
            this.changepictureTimer.Enabled = false;
            this.changepictureTimer.Tick += changepictureTimer_Tick;

            #region הכנסת תמונות
            switch (this.type)
            {
                case CharacterType.archer:
                    switch(this.attackindex)
                    {
                        case 1:
                        this.changepictureTimer.Interval = 1000;
                        this.rectangle = new Rectangle(0, 0, 32, 32);
                        this.images[0] = CooldownsResources.ArcherAttackBoost0;
                        this.images[1] = CooldownsResources.ArcherAttackBoost1;
                        this.images[2] = CooldownsResources.ArcherAttackBoost2;
                        this.images[3] = CooldownsResources.ArcherAttackBoost3;
                        this.images[4] = CooldownsResources.ArcherAttackBoost4;
                        this.images[5] = CooldownsResources.ArcherAttackBoost5;
                        this.images[6] = CooldownsResources.ArcherAttackBoost6;
                        this.images[7] = CooldownsResources.ArcherAttackBoost7;
                        this.images[8] = CooldownsResources.ArcherAttackBoost8;
                            break;
                        case 2:
                            this.changepictureTimer.Interval = 31;

                            this.rectangle = new Rectangle(34, 0, 32, 32);
                        this.images[0] = CooldownsResources.ArcherArrowIcon0;
                        this.images[1] = CooldownsResources.ArcherArrowIcon1;
                        this.images[2] = CooldownsResources.ArcherArrowIcon2;
                        this.images[3] = CooldownsResources.ArcherArrowIcon3;
                        this.images[4] = CooldownsResources.ArcherArrowIcon4;
                        this.images[5] = CooldownsResources.ArcherArrowIcon5;
                        this.images[6] = CooldownsResources.ArcherArrowIcon6;
                        this.images[7] = CooldownsResources.ArcherArrowIcon7;
                        this.images[8] = CooldownsResources.ArcherArrowIcon8;
                            break;

                        case 3:
                            this.changepictureTimer.Interval = 750;

                            this.rectangle = new Rectangle(68, 0, 32, 32);
                            this.images[0] = CooldownsResources.ArcherAttackIcon0;
                            this.images[1] = CooldownsResources.ArcherAttackIcon1;
                            this.images[2] = CooldownsResources.ArcherAttackIcon2;
                            this.images[3] = CooldownsResources.ArcherAttackIcon3;
                            this.images[4] = CooldownsResources.ArcherAttackIcon4;
                            this.images[5] = CooldownsResources.ArcherAttackIcon5;
                            this.images[6] = CooldownsResources.ArcherAttackIcon6;
                            this.images[7] = CooldownsResources.ArcherAttackIcon7;
                            this.images[8] = CooldownsResources.ArcherAttackIcon8;
                            break;
                    }

                    break;
                case CharacterType.mage:
                    switch (this.attackindex)
                    {
                        case 1:
                            this.changepictureTimer.Interval = 1000;

                            this.rectangle = new Rectangle(0, 0, 32, 32);
                            this.images[0] = CooldownsResources.MageHealIcon0;
                            this.images[1] = CooldownsResources.MageHealIcon1;
                            this.images[2] = CooldownsResources.MageHealIcon2;
                            this.images[3] = CooldownsResources.MageHealIcon3;
                            this.images[4] = CooldownsResources.MageHealIcon4;
                            this.images[5] = CooldownsResources.MageHealIcon5;
                            this.images[6] = CooldownsResources.MageHealIcon6;
                            this.images[7] = CooldownsResources.MageHealIcon7;
                            this.images[8] = CooldownsResources.MageHealIcon8;
                            break;
                        case 2:
                            this.changepictureTimer.Interval = 1500;

                            this.rectangle = new Rectangle(34, 0, 32, 32);
                            this.images[0] = CooldownsResources.MageBothBoost0;
                            this.images[1] = CooldownsResources.MageBothBoost1;
                            this.images[2] = CooldownsResources.MageBothBoost2;
                            this.images[3] = CooldownsResources.MageBothBoost3;
                            this.images[4] = CooldownsResources.MageBothBoost4;
                            this.images[5] = CooldownsResources.MageBothBoost5;
                            this.images[6] = CooldownsResources.MageBothBoost6;
                            this.images[7] = CooldownsResources.MageBothBoost7;
                            this.images[8] = CooldownsResources.MageBothBoost8;
                            break;
                        case 3:
                            this.changepictureTimer.Interval = 62;

                            this.rectangle = new Rectangle(68, 0, 32, 32);
                            this.images[0] = CooldownsResources.MageAttackIcon0;
                            this.images[1] = CooldownsResources.MageAttackIcon1;
                            this.images[2] = CooldownsResources.MageAttackIcon2;
                            this.images[3] = CooldownsResources.MageAttackIcon3;
                            this.images[4] = CooldownsResources.MageAttackIcon4;
                            this.images[5] = CooldownsResources.MageAttackIcon5;
                            this.images[6] = CooldownsResources.MageAttackIcon6;
                            this.images[7] = CooldownsResources.MageAttackIcon7;
                            this.images[8] = CooldownsResources.MageAttackIcon8;
                            break;
                    }
                    break;
                case CharacterType.warrior:
                    switch(this.attackindex)
                    {
                        case 1:
                            this.changepictureTimer.Interval = 1500;

                            this.rectangle = new Rectangle(0, 0, 32, 32);
                        this.images[0] = CooldownsResources.WarriorAttackBoostIcon0;
                        this.images[1] = CooldownsResources.WarriorAttackBoostIcon1;
                        this.images[2] = CooldownsResources.WarriorAttackBoostIcon2;
                        this.images[3] = CooldownsResources.WarriorAttackBoostIcon3;
                        this.images[4] = CooldownsResources.WarriorAttackBoostIcon4;
                        this.images[5] = CooldownsResources.WarriorAttackBoostIcon5;
                        this.images[6] = CooldownsResources.WarriorAttackBoostIcon6;
                        this.images[7] = CooldownsResources.WarriorAttackBoostIcon7;
                        this.images[8] = CooldownsResources.WarriorAttackBoostIcon8;
                            break;

                        case 2:
                            this.changepictureTimer.Interval = 1500;

                            this.rectangle = new Rectangle(34, 0, 32, 32);
                        this.images[0] = CooldownsResources.WarriorDefenseBoostIcon0;
                        this.images[1] = CooldownsResources.WarriorDefenseBoostIcon1;
                        this.images[2] = CooldownsResources.WarriorDefenseBoostIcon2;
                        this.images[3] = CooldownsResources.WarriorDefenseBoostIcon3;
                        this.images[4] = CooldownsResources.WarriorDefenseBoostIcon4;
                        this.images[5] = CooldownsResources.WarriorDefenseBoostIcon5;
                        this.images[6] = CooldownsResources.WarriorDefenseBoostIcon6;
                        this.images[7] = CooldownsResources.WarriorDefenseBoostIcon7;
                        this.images[8] = CooldownsResources.WarriorDefenseBoostIcon8;
                            break;

                        case 3:
                            this.changepictureTimer.Interval = 62;

                            this.rectangle = new Rectangle(68, 0, 32, 32);
                            this.images[0] = CooldownsResources.WarriorAttackIcon0;
                            this.images[1] = CooldownsResources.WarriorAttackIcon1;
                            this.images[2] = CooldownsResources.WarriorAttackIcon2;
                            this.images[3] = CooldownsResources.WarriorAttackIcon3;
                            this.images[4] = CooldownsResources.WarriorAttackIcon4;
                            this.images[5] = CooldownsResources.WarriorAttackIcon5;
                            this.images[6] = CooldownsResources.WarriorAttackIcon6;
                            this.images[7] = CooldownsResources.WarriorAttackIcon7;
                            this.images[8] = CooldownsResources.WarriorAttackIcon8;
                            break;
                    }

                    break;
            }
            #endregion הכנסת תמונות

        }


        /// <summary>
        /// טיימר החלפת תמונו
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changepictureTimer_Tick(object sender, EventArgs e)
        {
            this.currentindexpicture++;
            if (this.currentindexpicture == 9)
            {
                this.currentindexpicture = 0;
                Effects(null, null);
                this.changepictureTimer.Enabled = false;

            }
        }
        /// <summary>
        /// פעולה עוצרת
        /// </summary>
        public void Stop()
        {
            this.changepictureTimer.Enabled = false;
        }
        /// <summary>
        /// פעולה ממשיכה
        /// </summary>
        public void Continue()
        {
            this.changepictureTimer.Enabled = true;
        }
        /// <summary>
        /// פעולה שמציית את העצם
        /// </summary>
        /// <param name="e">עצם גרפי של האלמנט עליו אני מצייר</param>
        public void ShowMe(PaintEventArgs e)
        {
            e.Graphics.DrawImage(this.images[this.currentindexpicture], this.rectangle);
        }
        /// <summary>
        /// התחל את האנימצייה של העצם
        /// </summary>
        public void StartAnimate()
        {
            this.changepictureTimer.Enabled = true;

        }
        /// <summary>
        ///  בודק אם ניתן להשתמש במתקפה שוב
        /// </summary>
        /// <returns></returns>
        public bool isAvaible()
        {
            if (this.changepictureTimer.Enabled == true) { return false; }
            return true;
        }
    }
}
