using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGame.Items;

namespace TextGame.Scene
{
    internal class StartScene
    {   
        private Player _player = Program.player;
        //private Bag _bag = Program.bag;

        //private StatusScene _statusScene = Program.statusScene;
        private StatusScene _statusScene;
        private InventoryScene _inventoryScene;
        private StoreScene _storeScene;

        private bool _isFirst = true;

        public StartScene() 
        {
            //if (Program.statusScene == null) 
            //{
            //    _statusScene = new StatusScene();
            //}

            //if (_bag == null) Console.WriteLine("SS.cs Bag null");
            //Weapon items = new Weapon("스파르타의 창  ", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.");
            //_bag.AddItem(items);
            //Console.WriteLine(items.ShowInfo());
            //Console.WriteLine(_bag.ShowInfo());

            _statusScene = new StatusScene();
            _inventoryScene = new InventoryScene();
            _storeScene = new StoreScene();
        }

        public void ScenePlay()
        {
            //Console.WriteLine(_player.Hp);

            //if (_statusScene == null) Console.WriteLine("_statusScene null");
            
            while (true)
            {
                //이름 생성
                while (_isFirst)
                {
                    Console.Write(
                        "당신의 이름은 무엇입니까?\n" +
                        ">>");

                    string name = Console.ReadLine();

                    //미입력시
                    if (name.Length == 0)
                    {
                        WrongInput();
                    }
                    else
                    {
                        _player.Name = name;
                        Console.Write(
                        $"{_player.Name}님 반갑습니다!\n");
                        _isFirst = false;
                    }
                }

                //게임 시작 화면
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n마을\n");
                Console.ResetColor();
                Console.Write(
                    "스파르타 마을에 오신 여러분 환영합니다.\n" +
                    "이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n\n" +
                    "1. 상태보기\n" +
                    "2. 인벤토리\n" +
                    "3. 상점\n\n" +
                    "원하시는 행동을 입력해주세요.\n" +
                    ">>");

                string input = Console.ReadLine();

                //상태보기
                if (input == "1")
                {
                    _statusScene.ScenePlay();
                }
                //인벤토리
                else if (input == "2")
                {
                    //Console.WriteLine("2선택");
                    _inventoryScene.ScenePlay();
                }
                //상점
                else if (input == "3")
                {
                    //Console.WriteLine("3선택");
                    _storeScene.ScenePlay();
                }
                else
                {
                    WrongInput();
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
