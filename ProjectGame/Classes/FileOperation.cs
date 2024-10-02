using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;

namespace ProjectGame.Classes
{
    /// <summary>
    /// סטראקט של שם המשחקן וניקודו
    /// </summary>
    public struct PlayerFile
    {
        public string name;
        public int score1;
        public int score2;
        public int score3;
        public int score4;
        public int totalscore;
        public string champ;
    }
    static class FileOperation
    {
        private static string _FileName = "HighScores.txt";
        /// <summary>
        /// הפעולה ממיינת ושומרת את חמשת המוב ילים בקובץ טקסט
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score1"></param>
        public static void SavePlayer(string name, int score1,int score2,int score3,int score4,string champ)
        {
            PlayerFile pl;
            pl.name = name;
            pl.score1 = score1;
            pl.score2 = score2;
            pl.score3 = score3;
            pl.score4 = score4;
            pl.totalscore = score1 + (score2 * 2) + (score3 * 3) + (score4 * 4);
            pl.champ = champ;
            List<PlayerFile> list = LoadPlayer();
            if (list == null)
                list = new List<PlayerFile>();
            list.Add(pl);
            list.Sort(Max);
            StreamWriter sw = new StreamWriter(_FileName, false);
            for (int i = 0; i < list.Count && i < 5; i++)
                sw.WriteLine(list[i].name + "," + list[i].score1.ToString() + ",," + list[i].score2.ToString() + ",,," + list[i].score3.ToString() + ",,,," + list[i].score4.ToString() + ",,,,," + list[i].totalscore.ToString() + ",,,,,," + list[i].champ);
            sw.Close();
        }
        /// <summary>
        /// הפעולה טוענת את המובילים מקובץ הטקסט על מנת לבצע מיון יחד עם תוצאות חדשות
        /// </summary>
        /// <returns></returns>
        public static List<PlayerFile> LoadPlayer()
        {
            List<PlayerFile> list = new List<PlayerFile>();
            if (!File.Exists(_FileName))
                return null;
            StreamReader sr = new StreamReader(_FileName, true);
            PlayerFile pl;
            string line = sr.ReadLine();
            while (line != null)
            {
                pl.name = line.Substring(0, line.IndexOf(','));
                pl.score1 = int.Parse(line.Substring(line.IndexOf(",") + 1,( line.IndexOf(",,")-(line.IndexOf(",")+1))));
                pl.score2 = int.Parse(line.Substring(line.IndexOf(",,") + 2, (line.IndexOf(",,,")-(line.IndexOf(",,")+2))));
                pl.score3 = int.Parse(line.Substring(line.IndexOf(",,,") + 3,( line.IndexOf(",,,,")-(line.IndexOf(",,,")+3))));
                pl.score4 = int.Parse(line.Substring(line.IndexOf(",,,,") + 4, (line.IndexOf(",,,,,")-(line.IndexOf(",,,,")+4))));
                pl.totalscore = int.Parse(line.Substring(line.IndexOf(",,,,,") + 5,(line.IndexOf(",,,,,,")-(line.IndexOf(",,,,,")+5))));
                pl.champ = line.Substring(line.IndexOf(",,,,,,")+6);
                list.Add(pl);
                line = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        /// <summary>
        /// הפעולה בודקת איזו תוצאה גבוה יותר מבין 2 תוצאות
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns> 
        private static int Max(PlayerFile p1,PlayerFile p2)
        {
            return p2.totalscore - p1.totalscore;
        }
    }
}

















