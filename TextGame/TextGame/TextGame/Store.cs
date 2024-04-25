using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Items;

namespace TextGame
{
    internal class Store
    {
        private List<Item> list = new List<Item>();
        //Dictionary<string, Item> dictionary = new Dictionary<string, Item>();

        public Store() 
        {
            Armor item1 = new Armor("수련자 갑옷    ", 5, "수련에 도움을 주는 갑옷입니다.                   ", 1000);
            Armor item2 = new Armor("무쇠갑옷       ", 7, "무쇠로 만들어져 튼튼한 갑옷입니다.               ", 2000);
            Armor item3 = new Armor("스파르타의 갑옷", 9, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500);
            Weapon item4 = new Weapon("낡은 검        ", 2, "쉽게 볼 수 있는 낡은 검 입니다.                  ", 2000);
            Weapon item5 = new Weapon("청동 도끼      ", 5, "어디선가 사용됐던거 같은 도끼입니다.             ", 1500);
            Weapon item6 = new Weapon("스파르타의 창  ", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.  ", 2000);
            list.Add(item1);
            list.Add(item2);
            list.Add(item3);
            list.Add(item4);
            list.Add(item5);
            list.Add(item6);

            //dictionary.Add(item1.Name, item1);
            //dictionary.Add(item2.Name, item2);
            //dictionary.Add(item3.Name, item3);
            //dictionary.Add(item4.Name, item4);
            //dictionary.Add(item5.Name, item5);
            //dictionary.Add(item6.Name, item6);

        }

      

     

        public string ShowInfo()
        {
            if (list.Count == 0) return "아이템 없음";

            string str = "";

            for (int i = 0; i < list.Count; i++)
            {
                str += $" - {i + 1} {list[i].ShowInfoStore()}\n";
            }

            return str;
        }

        public int Count { get { return list.Count; } }

        public Item IndexToObj(int index)
        {
            return list[index];
        }
        public List<Item> ReturnList()
        {
            return this.list;
        }

    }
}
