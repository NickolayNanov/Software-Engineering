using System;
using System.Collections.Generic;
using System.Text;

namespace Mordor_sCruelPlan
{
    class Mood
    {
        private int currnetMood;
        private string[] items;

        public Mood(string[] items)
        {
            this.Items = items;
        }

        private string[] Items
        {
            get
            {
                return items;
            }
            set
            {
                this.items = value;
            }
        }


        public int CurrentMood
        {
            get { return GetMood(); }

        }

        private int GetMood()
        {
            int mood = 0;
            for (int i = 0; i < this.Items.Length; i++)
            {
                string command = this.Items[i];
                switch (command)
                {
                    case "Cram":
                        mood += 2;
                        break;
                    case "Lembas":
                        mood += 3;
                        break;
                    case "Apple":
                        mood += 1;
                        break;
                    case "Melon":
                        mood += 1;
                        break;
                    case "HoneyCake":
                        mood += 5;
                        break;
                    case "Mushrooms":
                        mood += -10;
                        break;
                    default:
                        mood -= 1;
                        break;
                }
            }
            return mood;
        }
    }
}
