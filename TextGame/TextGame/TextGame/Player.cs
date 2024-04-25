using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Items;

namespace TextGame
{
    internal class Player
    {
        //필드
        private int _lv;
        private string _name;
        private string _job;
        private int _str;
        private int _dex;
        private int _hp;
        private int _gold;

        private bool _isEquip;
        private int _equipStr;
        private int _equipDex;
        private List<Item> _equipList;

        private bool _isWeapon;
        private bool _isArmor;


        //생성자
        public Player() 
        {
            this._lv = 1;
            this._name = "null";
            this._job = "전사";
            this._str = 10;
            this._dex = 5;
            this._hp = 100;
            this._gold = 4000;
            this._isEquip = false;
            this._equipStr = 0;
            this._equipDex = 0;
            this.IsWeapon = false;
            this.IsArmor = false;

            _equipList = new List<Item>();
            
        }

        public void Equip(Item item) 
        {
            _equipList.Add(item);           
        }

        public void ReleaseEquip(Item item)
        {
            _equipList.Remove(item);
        }

        
        public void EquipStatus()
        {
            this.EquipStr = 0;
            this.EquipDex = 0;

            foreach (Item i in _equipList)
            {
                if (i.Type == "무기")
                {
                    //부모 클래스에서 자식클래스의 프로퍼티에 접근하는 방법이 있는지?
                    Weapon weapon = (Weapon)i;
                    this.EquipStr += weapon.Str;

                }
                else
                {
                    Armor armor = (Armor)i;
                    this.EquipDex += armor.Dex;
                }
            }
        }

        //프로퍼티
        public string Lv
        {
            get
            {
                if (_lv < 10)
                {
                    return $"0{_lv}";
                }
                else return _lv.ToString();
            }
            private set
            {
                _lv = int.Parse(value);
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Job
        {
            get { return _job; }
            set { _job = value; }
        }

        public int Str
        {
            get { return _str; }
            set { _str = value; }
        }

        public int Dex
        {
            get { return _dex; }
            set { _dex = value; }
        }

        public int Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }
        public bool IsEquip
        {
            get { return _isEquip; }
            set { _isEquip = value; }
        }
        public int EquipStr
        { 
            get { return _equipStr; }
            set { _equipStr = value; }
        }
        public int EquipDex
        {
            get { return _equipDex; }
            set { _equipDex = value; }
        }

        public string AllStr
        {
            get 
            {
                if (_equipStr > 0) return $"{this.Str} (+{this.EquipStr})";
                else return $"{this.Str}";

            }
        }

        public string AllDex
        {
            get
            {
                if (_equipDex > 0) return $"{this.Dex} (+{this.EquipDex})";
                else return $"{this.Dex}";
            }
        }

        public bool IsWeapon { get; set; }
        public bool IsArmor { get; set; }


    }
}
