using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayVanguard
{
    public class GameFactory
    {
        //This is a Factory, we create a single instance of this. And we can create different prefabs of a object. We use this by passing in the string of type, with x and y of the object. The string have to match to create a object.
        private Window _window;
        public GameFactory(Window window) 
        {
            _window = window;
        }
        public Player CreatePlayer(string type, double x, double y)
        {
            Player instance;
            switch (type)
            {
                case "Player1":
                    instance = new Player(SplashKit.LoadBitmap("Player1", "img/player/player1.png"), x, y, 6, 250, _window, this);
                    break;
                default:
                    throw new InvalidOperationException("Invalid player type");
            }
            return instance;
        }
        public Enemy CreateEnemy(string type, double x, double y)
        {
            Enemy instance;
            switch (type)
            {
                case "Enemy1":
                    instance = new Enemy(SplashKit.LoadBitmap("Enemy1", "img/enemy/enemy1.png"), x, y, 5, 2000, _window);
                    break;
                default:
                    throw new InvalidOperationException("Invalid enemy type");
            }
            return instance;
        }
        public Bullet CreateBullet(string type, double x, double y)
        {
            Bullet instance;
            switch (type)
            {
                case "Bullet1":
                    instance = new Bullet(SplashKit.LoadBitmap("PlayerBullet1", "img/player/bullet/bullet1.png"), x, y, 10, true, _window);
                    break;
                default:
                    throw new InvalidOperationException("Invalid bullet type");
            }
            return instance;
        }

        public Background CreateBackground(string type, double x, double y)
        {
            Background instance;
            switch (type)
            {
                case "Menu1":
                    instance = new Background(SplashKit.LoadBitmap("MenuBackground", "bg/menutext.png"), x, y, 0, _window);
                    break;
                case "Game1":
                    instance = new Background(SplashKit.LoadBitmap("Background1", "bg/stars_0.png"), x, y, 2, _window);
                    break;
                case "Game2":
                    instance = new Background(SplashKit.LoadBitmap("Background2", "bg/stars_1.png"), x, y, 4, _window);
                    break;
                case "Shop1":
                    instance = new Background(SplashKit.LoadBitmap("ShopBackground", "bg/shop.png"), x, y, 0, _window);
                    break;
                case "End1":
                    instance = new Background(SplashKit.LoadBitmap("EndBackground", "bg/gameover.png"), x, y, 0, _window);
                    break;
                default:
                    throw new InvalidOperationException("Invalid background type");
            }
            return instance;
        }
    }
}
