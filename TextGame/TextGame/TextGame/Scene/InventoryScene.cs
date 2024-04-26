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

                //이미 착용한 장비 선택시
                if (_bag.IndexToObj(result - 1).IsUse)
                {
                    _bag.IndexToObj(result - 1).IsUse = false;
                    //var item = _bag.IndexToObj(result - 1);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"\n{_bag.IndexToObj(result - 1).Name}을/를 해제했습니다!\n");
                    Console.ResetColor();

                    _player.ReleaseEquip(_bag.IndexToObj(result - 1));
                    _player.EquipStatus();
                }
                //착용전 장비를 선택
                else
                {
                    //이미 다른 장비를 착용 중일때
                    if (_bag.IndexToObj(result - 1).Type == "무기" && _player.EquipWeapon != null)
                    {
                        //Console.WriteLine("무기 착용중");
                        _bag.IndexToObj(result - 1).IsUse = true;
                        _bag.ReturnList().Find(x => x == _player.EquipWeapon).IsUse = false;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"\n{_bag.IndexToObj(result - 1).Name}으로 교체했습니다!\n");
                        Console.ResetColor();
                        
                        _player.Equip(_bag.IndexToObj(result - 1));
                        _player.EquipStatus();

                        continue;
                    }
                    else if (_bag.IndexToObj(result - 1).Type == "방어구" && _player.EquipArmor != null)
                    {
                        //Console.WriteLine("방어구 착용중");
                        _bag.IndexToObj(result - 1).IsUse = true;
                        _bag.ReturnList().Find(x => x == _player.EquipArmor).IsUse = false;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"\n{_bag.IndexToObj(result - 1).Name}으로 교체했습니다!\n");
                        Console.ResetColor();
                        
                        _player.Equip(_bag.IndexToObj(result - 1));
                        _player.EquipStatus();

                        continue;

                    }

                    //장비 장착
                    _bag.IndexToObj(result - 1).IsUse = true;

                    //Console.WriteLine(_bag.IndexToObj(result - 1).Type);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"\n{_bag.IndexToObj(result - 1).Name}을/를 장착했습니다!\n");
                    Console.ResetColor();

                    _player.Equip(_bag.IndexToObj(result - 1));
                    _player.EquipStatus();

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
