using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextGame.Items
{
    internal class Armor : Item
    {
       
        private int dex;
        
        public Armor(string name, int dex, string info, int gold)        
        {
            this.Name = name;
            this.Dex = dex;
            this.Info = info;
            this.Gold = gold;
            this.Type = "방어구";
            this.IsSell = false;
        }

        override public string ShowInfo()
        {
            if (this.IsUse == false)
            {
                return $"{this.Name} | 방어력 +{this.Dex} | {this.Info}";
            }
            else
            {
                return $"[E]{this.Name} | 방어력 +{this.Dex} | {this.Info}";

            }
        }

        override public string ShowInfoStore()
        {
            return $"{this.Name} | 방어력 +{this.Dex} | {this.Info} | {this.IsSellGetString}";
        }

        public int Dex { get; set; }


    }
}
