using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Items
{
    internal class Weapon : Item
    {
        private int str;
      


        public Weapon(string name, int str, string info, int gold)
        {
            this.Name = name;
            this.Str = str;
            this.Info = info;
            this.Gold = gold;
            this.Type = "무기";
            this.IsSell = false;

        }

        override public string ShowInfo()
        {
            if (this.IsUse == false)
            {
                return $"{this.Name} | 공격력 +{this.Str} | {this.Info}";
            }
            else
            {
                return $"[E]{this.Name} | 공격력 +{this.Str} | {this.Info}";

            }
        }

        override public string ShowInfoStore()
        {
            return $"{this.Name} | 공격력 +{this.Str} | {this.Info} | {this.IsSellGetString}";
        }

        public int Str { get; set; }
       

    }
}
