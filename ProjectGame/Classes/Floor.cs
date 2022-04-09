using System.Drawing;
using System.Windows.Forms;

namespace ProjectGame.Classes
{
    class Floor
    {
        //-----------------------------------תכונות-----------------------
        /// <summary>
        /// מכיל את תמונת הריצפה
        /// </summary>
        protected Image picture;
        /// <summary>
        /// מלבן התמונה
        /// </summary>
        protected Rectangle rectangle;
        /// <summary>
        /// סוג הריצפה
        /// </summary>
        protected BackgroundType bgtype;
        /// <summary>
        /// האם הריצפה היא קוצים או לא
        /// </summary>
        protected bool isSpikes;
        //---------------------------------פעולות-------------------------
        /// <summary>
        /// פעולה בונה
        /// </summary>
        /// <param name="x">איקס התחלתי של הריצפה</param>
        /// <param name="y">וואי התחלתי של הריצפה</param>
        /// <param name="ty">סוג הריצפה</param>
        /// <param name="isSpikes">אם ריצפה רוצית או לא</param>
        public Floor(int x, int y,BackgroundType ty,bool isSpikes)
        {
            this.isSpikes=isSpikes;
            this.bgtype = ty;

            if (this.isSpikes)
            {
                switch (this.bgtype)
                {
                    case BackgroundType.Grass1: this.picture = GameResources.GrassFloor1Spikes; break;
                    case BackgroundType.Grass2: this.picture = GameResources.GrassFloor2Spikes; break;
                    case BackgroundType.Rock1: this.picture = GameResources.RockFloor1Spikes; break;
                    case BackgroundType.Rock2: this.picture = GameResources.RockFloor2Spikes; break;

                }
            }
            else
            {
                switch (this.bgtype)
                {
                    case BackgroundType.Grass1: this.picture = GameResources.GrassFloor1; break;
                    case BackgroundType.Grass2: this.picture = GameResources.GrassFloor2; break;
                    case BackgroundType.Rock1: this.picture = GameResources.RockFloor1; break;
                    case BackgroundType.Rock2: this.picture = GameResources.RockFloor2; break;

                }
            }
            this.rectangle = new Rectangle(x, y, 65,25);
        }
        /// <summary>
        /// פעולה שמציירת את הריצפה
        /// </summary>
        /// <param name="e"></param>
        public void ShowMe(PaintEventArgs e)
        {
            e.Graphics.DrawImage(this.picture, this.rectangle);
        }

        #region getmethods
        /// <summary>
        /// פעולת Get
        /// </summary>
        /// <returns>מחזיר את המלבן</returns>
        public Rectangle GetRectangle()
        {
            return this.rectangle;
        }
        /// <summary>
        /// פעולה Get
        /// </summary>
        /// <returns>מחזיר את סוג הריצפה</returns>
        public new BackgroundType GetType()
        {
            return this.bgtype;
        }
        /// <summary>
        /// מחזיר מלבן חדש יותר קטן המתאים לקוצים
        /// </summary>
        /// <returns>מחזיר מלבן של הקוצים</returns>
        public Rectangle GetSpikesInteractRectangle()
        {
            return new Rectangle(this.rectangle.X+20,this.rectangle.Y-1,this.rectangle.Width-40,1);
        }
        /// <summary>
        /// פעולה Get
        /// </summary>
        /// <returns>האם הריצפה קוצית או לא</returns>
        public bool GetisSpikes()
        {
            return this.isSpikes;
        }
        /// <summary>
        /// האיקס השמאלי של הריצה
        /// </summary>
        /// <returns>ערך איקס שמאלי של דמות</returns>
        internal int GetFloorX1()
        {
            return this.rectangle.X;
        }
        /// <summary>
        /// האיקס הימני
        /// </summary>
        /// <returns>ערך האיקס הימני של הדמות</returns>
        internal int GetFloorX2()
        {
            return this.rectangle.X + this.rectangle.Width;
        }
        /// <summary>
        /// מחזיר את גובה הריצפה
        /// </summary>
        /// <returns>ערך הוואי העליון של הריצפה</returns>
        internal int GetFloorY()
        {
            return this.rectangle.Y;
        }
        #endregion getmethods
        /// <summary>
        /// פעולת הזזה שמאלה
        /// </summary>
        /// <param name="p">מספר הפיקסלים להזזה</param>
        public void MoveLeft(int p)
        {
            this.rectangle.X -= p;
        }
        /// <summary>
        /// פעולת הזזה ימינה
        /// </summary>
        /// <param name="p">מספר הפיקסלים להזזה</param>
        public void MoveRight(int p)
        {
            this.rectangle.X += p;
        }
    }
}
