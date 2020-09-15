using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace POPPING_BALLOONS_GAME // Created by: Joshua C. Magoliman
{
    static class Top10Only
    {
        #region Fields
        private static readonly string file = "HighScores.txt";
        private static readonly List<Top10OnlyEntry> entries = new List<Top10OnlyEntry>();
        #endregion

        #region User Defined Methods
        private static void GetTop10Only()
        {
            entries.Clear();
            if (File.Exists(file))
            {
                StreamReader read = new StreamReader(file);
                using (read)
                {
                    string line = read.ReadLine();
                    while (line != null)
                    {
                        string[] res = line.Split();
                        Top10OnlyEntry entry = new Top10OnlyEntry
                        {
                            Date = res[0],
                            Score = int.Parse(res[1])
                        };
                        entries.Add(entry);
                        line = read.ReadLine();
                    }
                }
            }
        }
        public static void CheckResultInTop10Only(string param_Date, int param_Score)
        {
            if (Top10Only.CheckingIfScoreIsAcceptable(param_Score))
            {
                Top10OnlyEntry entry = new Top10OnlyEntry();
                entry.Date = param_Date;
                entry.Score = param_Score;
                Top10Only.EnterTop10Only(entry);
            }
        }
        public static bool CheckingIfScoreIsAcceptable(int result)
        {
            GetTop10Only();
            if (result == 0)
            {
                return false;
            }
            if (entries.Count < 10)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    if (result > entries[i].Score)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public static void EnterTop10Only(Top10OnlyEntry entry)
        {
            entries.Add(entry);
            if (entries.Count > 10)
            {
                int min = int.MaxValue;
                int pos = 0;
                for (int i = 0; i < entries.Count; i++)
                {
                    if (entries[i].Score < min)
                    {
                        min = entries[i].Score;
                        pos = i;
                    }
                }
                entries.RemoveAt(pos);
            }
            SaveTop10OnlyEntry();
        }
        private static void SaveTop10OnlyEntry()
        {
            StreamWriter write = new StreamWriter(file, false);
            using (write)
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    write.WriteLine("{0} {1}", entries[i].Date, entries[i].Score);
                }
            }
        }
        public static string AddingCommasInScore(string param_Score)
        {
            string output = "";
            if (param_Score.Length >= 4)
            {
                double patternFormat = Convert.ToDouble(param_Score);
                output = patternFormat.ToString("#,##0");
            }
            else if (param_Score.Length < 4)
            {
                output = param_Score;
            }
            return output;
        }
        public static void Show(Label param_Rank, Label param_Date, Label param_Score)
        {
            GetTop10Only();
            var list = from entry in entries
                       orderby entry.Score descending
                       select entry;
            int counter = 1;

            if (!File.Exists(file))
            {
                param_Rank.Content += "\n\n\n\n\n    The file HighScores.txt doesn't exist!";
            }
            else
            {
                if (new FileInfo(file).Length == 0)
                {
                    param_Date.Content += "\n\n\n\n\nNO SCORES YET";
                }
                else
                {
                    foreach (var item in list)
                    {
                        if (counter % 2 == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }
                        if (counter % 3 == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }
                        string spaces;
                        if (counter == 10)
                        {
                            spaces = "  ";
                        }
                        else
                        {
                            spaces = "   ";
                        }
                        param_Rank.Content += Convert.ToString("\n" + spaces + counter);
                        param_Date.Content += Convert.ToString("\n" + item.Date);
                        param_Score.Content += Convert.ToString("\n" + AddingCommasInScore(Convert.ToString(item.Score)));
                        counter++;
                    }
                }
            }
        }
        #endregion
    }
}