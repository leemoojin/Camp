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

        //private bool _isEquip;
        private int _equipStr;
        private int _equipDex;
        //private List<Item> _equipList;

        private Weapon? _equipWeapon;
        private Armor? _equipArmor;

        //private bool _isWeapon;
        //private bool _isArmor;


        //생성자
        public Player() 
        {
            this.Lv = "1";
            this.Name = "null";
            this.Job = "전사";
            this.Str = 10;
            this.Dex = 5;
            this.Hp = 100;
            this.Gold = 8000;
            //this.IsEquip = false;
            this.EquipStr = 0;
            this.EquipDex = 0;
            //this.IsWeapon = false;
            //this.IsArmor = false;
            this.EquipWeapon = null;
            this.EquipArmor = null;

            //_equipList = new List<Item>();
            
        }

        public void Equip(Item item) 
        {
            if (item.Type == "무기")
            {   
                if(this.EquipWeapon != null) ReleaseEquip(this.EquipWeapon);

                this.EquipWeapon = (Weapon)item;
                //this.IsWeapon = true;

                //Console.WriteLine($"무기 장착 {this.EquipWeapon.Str}");

            }
            else
            {
                if (this.EquipArmor != null) ReleaseEquip(this.EquipArmor);

                this.EquipArmor = (Armor)item;
                //this.IsArmor = true;
                //Console.WriteLine($"방어구 장착 {this.EquipArmor.Dex}");


            }

            Console.WriteLine($"공 : {this.AllStr}, 방 : {this.AllDex}");
        }

        public void ReleaseEquip(Item item)
        {
            if (item.Type == "무기")
            {
                //this.EquipStr -= this.EquipWeapon.Str;
                this.EquipWeapon = null;
                //this.IsWeapon = false;
            }
            else
            {
                //this.EquipDex -= this.EquipArmor.Dex;
                this.EquipArmor = null;
                //this.IsArmor = false;
            };

            Console.WriteLine($"공 : {this.AllStr}, 방 : {this.AllDex}");

        }


        public void EquipStatus()
        {
            this.EquipStr = 0;
            this.EquipDex = 0;

            if(this.EquipWeapon != null) this.EquipStr += this.EquipWeapon.Str;
            if (this.EquipArmor != null) this.EquipDex += this.EquipArmor.Dex;


            //if (this.EquipWeapon == null) this.EquipStr = 0;
            //else this.EquipStr += this.EquipWeapon.Str;

            //if (this.EquipArmor == null) this.EquipDex = 0;
            //else this.EquipDex += this.EquipArmor.Dex;

            Console.WriteLine($"공 : {this.AllStr}, 방 : {this.AllDex}");


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
        //public bool IsEquip
        //{
        //    get { return _isEquip; }
        //    set { _isEquip = value; }
        //}
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
                if (this.EquipStr > 0) return $"{this.Str} (+{this.EquipStr})";
                else return $"{this.Str}";

            }
        }

        public string AllDex
        {
            get
            {
                if (this.EquipDex > 0) return $"{this.Dex} (+{this.EquipDex})";
                else return $"{this.Dex}";
            }
        }

        //public bool IsWeapon { get; private set;}
        //public bool IsArmor { get; private set; }

        public Weapon? EquipWeapon { get; private set; }
        public Armor? EquipArmor { get; private set; }



    }
}
