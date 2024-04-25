using TextGame.Scene;

namespace TextGame
{
    internal class Program
    {
        static public Player player = new Player();
        static public Bag bag = new Bag();
        static public Store store = new Store();

        static public StartScene startScene = new StartScene();
        //static public StatusScene statusScene = new StatusScene();


        static void Main(string[] args)
        {
                    
            startScene.ScenePlay();
            
        }
    }
}