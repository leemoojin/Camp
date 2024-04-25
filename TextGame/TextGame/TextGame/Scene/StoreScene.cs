using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Items;

namespace TextGame.Scene
{
    internal class StoreScene
    {
        private Player _player = Program.player;
        private Bag _bag = Program.bag;
        private Store _store = Program.store;
        public void ScenePlay()
        {

            while (true)
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n상점\n");
                Console.ResetColor();
                Console.Write(
                    "필요한 아이템을 얻을 수 있는 상점입니다.\n\n" +
                    "[보유골드]" +
                    $"{_player.Gold} G\n\n" +
                    $"[아이템 목록]\n" +
                    $"{_store.ShowInfo()}\n\n" +
                    $"1. 아이템 구매\n" +
                    $"0. 나가기\n\n" +
                    $"원하시는 행동을 입력해주세요.\n" +
                    $">>");

                string input = Console.ReadLine();

                //아이템 구매
                if (input == "1")
                {
                    BuyScene();
                }
                //나가기
                else if (input == "0")
                {
                    return;
                }
                else WrongInput();

            }

            

        }


        public void BuyScene()
        {
            while(true) 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n상점 - 아이템 구매\n");
                Console.ResetColor();
                Console.Write(
                    "필요한 아이템을 얻을 수 있는 상점입니다.\n\n" +
                    "[보유골드]" +
                    $"{_player.Gold} G\n\n" +
                    $"[아이템 목록]\n" +
                    $"{_store.ShowInfo()}\n\n" +
                    $"번호를 입력해 아이템을 선택해서 구매 해주세요.\n" +
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
                if (result > _store.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("아이템이 없습니다.\n\n");
                    Console.ResetColor();
                    continue;
                }

                
                if (_store.IndexToObj(result-1).IsSell)
                {
                    
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"\n{_store.IndexToObj(result - 1).Name}은/는 품절되었습니다!\n");
                    Console.ResetColor();
                    continue;
                }

                //돈부족
                if (_store.IndexToObj(result - 1).Gold > _player.Gold)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"\n골드가 부족합니다!\n");
                    Console.ResetColor();
                    continue;
                }

                //구매 성공
                _store.IndexToObj(result - 1).IsSell = true;
                var item = _store.IndexToObj(result - 1);
                //Console.Write(item.IsSell);


                _player.Gold -= item.Gold;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(
                    $"\n{item.Name}을/를 구매했습니다!\n" +
                    $"{_player.Gold}G 남았습니다!\n\n");
                Console.ResetColor();

                _bag.AddItem(item);
                
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
