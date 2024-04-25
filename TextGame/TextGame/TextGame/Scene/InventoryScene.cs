using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Scene
{
    internal class InventoryScene
    {
        private Bag _bag = Program.bag;
        private Player _player = Program.player;
        public InventoryScene()
        {
            if (_bag == null) Console.WriteLine("IS.cs Bag null");

        }

        public void ScenePlay()
        {
            if (_bag == null) Console.WriteLine("IS.cs Bag null");


            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n인벤토리\n");
                Console.ResetColor();
                Console.Write(
                    "보유 중인 아이템을 관리할 수 있습니다.\n\n" +
                    "[아이템 목록]\n\n" +
                    $"{_bag.ShowInfo()}\n\n" +
                    $"1. 장착 관리.\n" +
                    $"0. 나가기\n\n" +
                    $"원하시는 행동을 입력해주세요.\n" +
                    $">>");

                string input = Console.ReadLine();

                //장착 관리
                if (input == "1")
                {
                    EquipScene();
                }
                //나가기
                else if (input == "0")
                {
                    return;
                }
                else WrongInput();

            }


        }

        //장착관리 신
        public void EquipScene() 
        {
            while (true) 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n인벤토리 - 장착 관리\n");
                Console.ResetColor();
                Console.Write(
                    "보유 중인 아이템을 관리할 수 있습니다.\n\n" +
                    "[아이템 목록]\n\n" +
                    $"{_bag.ShowInfo()}\n\n" +
                    $"번호를 입력해 아이템을 선택해서 장착/해제 해주세요.\n" +
                    $"0. 나가기\n\n" +
                    $"원하시는 행동을 입력해주세요.\n" +
                    $">>");

                string input = Console.ReadLine();

                if (input == "0") return;

                int result;

                //숫자가 아닌것을 입력 했을 때
                if (!int.TryParse(input, out result))
                {
                    WrongInput();
                    continue;
                }
                //인덱스 외의 아이템을 선택했을 때
                if (result > _bag.Count) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("아이템이 없습니다.\n\n");
                    Console.ResetColor();
                    continue;
                }               


                if (_bag.IndexToObj(result - 1).IsUse)
                {
                    _bag.IndexToObj(result - 1).IsUse = false;
                    var item = _bag.IndexToObj(result - 1);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"\n{item.Name}을/를 해제했습니다!\n");
                    Console.ResetColor();

                    _player.ReleaseEquip(item);
                    _player.EquipStatus();
                }
                //장비 장착
                else 
                {
                    _bag.IndexToObj(result - 1).IsUse = true;
                    var item = _bag.IndexToObj(result - 1);

                    Console.WriteLine(item.Type);

                    ////이미 장비를 착용한 경우
                    //if (item.Type == "무기" && _player.IsWeapon)
                    //{
                    //    //기존 장비해제
                    //    _player.ReleaseEquip("무기");

                    //    Console.ForegroundColor = ConsoleColor.Yellow;
                    //    Console.Write($"\n{item.Name}으로 교체했습니다!\n");
                    //    Console.ResetColor();

                    //    _player.Equip(item);
                    //    _player.EquipStatus();
                    //    continue;
                    //}
                    //else if (item.Type == "방어구" && _player.IsArmor)
                    //{
                    //    //기존 장비해제
                    //    _player.ReleaseEquip("방어구");

                    //    Console.ForegroundColor = ConsoleColor.Yellow;
                    //    Console.Write($"\n{item.Name}으로 교체했습니다!\n");
                    //    Console.ResetColor();

                    //    _player.Equip(item);
                    //    _player.EquipStatus();
                    //    continue;
                    //}


                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"\n{item.Name}을/를 장착했습니다!\n");
                    Console.ResetColor();

                    _player.Equip(item);
                    _player.EquipStatus();

                    if(item.Type == "무기")_player.IsWeapon = true;
                    else if(item.Type == "방어구")_player.IsArmor = true;
                }





            }



        }





        void WrongInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("잘못된 입력입니다\n\n");
            Console.ResetColor();
        }
    }
}
