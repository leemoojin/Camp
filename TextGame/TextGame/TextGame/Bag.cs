using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Items;

namespace TextGame
{
    internal class Bag
    {
        private List<Item> list = new List<Item>();

        public void AddItem(Item item)
        {
            list.Add(item);
        }

        public void RemoveItem(int index)
        {
            list.Remove(list[index]);
        }

        public string ShowInfo()
        {
            if (list.Count == 0) return "아이템 없음";

            string str = "";

            for (int i = 0; i < list.Count; i++)
            {
                str += $" - {i + 1} {list[i].ShowInfo()}\n";
            }

            return str;
        }

        public int Count { get { return list.Count; } }

        public Item IndexToObj(int index)
        {
            return list[index];
        }
        public List<Item> ReturnList() {
            return this.list;
        }

    }
}
