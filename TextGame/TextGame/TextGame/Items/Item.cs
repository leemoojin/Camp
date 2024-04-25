using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Items
{
    internal abstract class Item
    {
        private string name;
        private string info;
        private bool isUse;
        private string type;
        private int gold;

        private bool isSell;



        abstract public string ShowInfo();

        abstract public string ShowInfoStore();



        public string Name { get; set; }
        public string Info { get; set; }
        public bool IsUse { get; set; }
        public string Type { get; set; }
        public int Gold { get; set; }
        public bool IsSell { get; set; }
        public string IsSellGetString 
        {   get
            {
                if (this.IsSell) return "구매완료";
                else return $"{this.Gold} G";
            }        
        }




    }
}
