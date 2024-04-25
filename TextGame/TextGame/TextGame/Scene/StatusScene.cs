using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Scene
{
    internal class StatusScene
    {
        private Player _player = Program.player;

        public void ScenePlay()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n상태보기\n");
                Console.ResetColor();
                Console.Write("캐릭터의 정보가 표시됩니다.\n\n");


                Console.Write(
                    $"Lv. {_player.Lv}\n" +
                    $"{_player.Name} ( {_player.Job} )\n" +
                    $"공격력 : {_player.AllStr}\n" +
                    $"방어력 : {_player.AllDex}\n" +
                    $"체력 : {_player.Hp}\n" +
                    $"Gold : {_player.Gold}\n" +
                    $"\n" +
                    $"0. 나가기\n" +
                    $"\n" +
                    $"원하시는 행동을 입력해주세요.\n" +
                    $">>");

                string input = Console.ReadLine();

                if (input == "0")
                {
                    //상태신 종료
                    return;
                }
                else WrongInput();
               
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
