using System.Drawing;
using System.Windows.Forms;
namespace ProjectGame.Classes
{
    class Consumable
    {
        //----------------------תכונות-----------------------------  
        /// <summary>
        /// התמונה של המצרך
        /// </summary>
        private Image image;
        /// <summary>
        /// המלבן של המצרך שבו נצייר את התמונה
        /// </summary>
        private Rectangle rectangle;
        /// <summary>
        /// סוג המצרך
        /// </summary>
        private ConsumableType type;
        //--------------------פעולות-------------------------------
     /// <summary>
     /// פעולה בונה
     /// </summary>
     /// <param name="x">ערך האיקס של המצרך</param>
     /// <param name="y">ערך הוואי של המצרך</param>
     /// <param name="ty">סוג המצרך</param>
        public Consumable(int x,int y,ConsumableType ty)
        {
            this.type=ty;
            switch (this.type)
            {
                case ConsumableType.hamburger: this.image = GameResources.Hamburger; break;
                case ConsumableType.healthpot: this.image = GameResources.HealthPotion; break;
                case ConsumableType.manapot: this.image = GameResources.ManaPotion; break;
            }
            this.rectangle= new Rectangle(x,y,25,25);
        }
        /// <summary>
        /// פעולה שמציירת את המצרך
        /// </summary>
        /// <param name="e">עצם גרפי של האלמנט עליו אני מצייר</param>
        public void ShowMe(PaintEventArgs e)
        {
            e.Graphics.DrawImage(this.image, this.rectangle);
        }
        #region get & set methods
        /// <summary>
        /// פעולה שמחזירה את סוג המצרך
        /// </summary>
        /// <returns>סוג המצרך</returns>
        public new ConsumableType GetType()
        {
            return this.type;
        }
        /// <summary>
        /// פעולת get
        /// </summary>
        /// <returns>ערך האיקס השמאלי</returns>
        public int GetX1()
        {
            return this.rectangle.X;
        }
        /// <summary>
        /// פעולת get
        /// </summary>
        /// <returns>ערך האיקס הימני</returns>
        public int GetX2()
        {
            return this.rectangle.X + this.rectangle.Width;
        }    
        /// <summary>
        /// פעולת Get
        /// </summary>
        /// <returns>ערך המלבן של המצרך</returns>
        public Rectangle GetRectangle()
        {
            return this.rectangle;
        }        
        #endregion get & set methods
        /// <summary>
        /// פעולה שמזיזה את המצרך
        /// </summary>
        /// <param name="p">מספר הפיקסןלים שנזיז את המצרך שמאל</param>
        internal void MoveLeft(int p)
        {
            this.rectangle.X -= p;
        }
        /// <summary>
        /// פעולה שמזיזה את המצרך
        /// </summary>
        /// <param name="p">מספר הפיקסלים שנזיז את המצרך ימינה</param>
        internal void MoveRight(int p)
        {
            this.rectangle.X += p;
        }
    }
}
public enum ConsumableType
{
    hamburger,healthpot,manapot
}
