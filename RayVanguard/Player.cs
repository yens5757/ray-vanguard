using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RayVanguard
{
    public class Player : Ship
    {
        private List<Bullet> _bullets;
        private SoundEffect _shootingSound;
        private GameFactory _gameFactory;
        private string _bulletType;
        private uint _lastShotTime;
        private SplashKitSDK.Timer _shootTimer;

        public Player(double x, double y, Window window, GameFactory gameFactory) : this(SplashKit.LoadBitmap("Player Ship", "img/player/player1.png"), x, y, 6, 250, window, gameFactory)
        {

        }
        public Player(Bitmap bitmap, double x, double y, double speed, uint shootSpeed, Window window, GameFactory gameFactory) : base(bitmap, x, y, speed, 250, window)
        {
            _bullets = new List<Bullet>();
            _shootingSound = SplashKit.LoadSoundEffect("shoot1", "laser/laserSmall_001.ogg");
            _gameFactory = gameFactory;
            _bulletType = "Bullet1";
            _lastShotTime = 0;
            _shootTimer = new SplashKitSDK.Timer("ShootTimer");
            _shootTimer.Start();
        }
        //Player controller, player can move up, down, left and right using the function
        public void MoveLeft()
        {
            if (X - (Bitmap.Width / 2) > 0)
            {
                X -= Speed;
            }
        }
        public void MoveRight()
        {
            if (X + (Bitmap.Width / 2) < Window.Width)
            {
                X += Speed;
            }
        }
        public void MoveUp()
        {
            if (Y - (Bitmap.Height / 2) > 0)
            {
                Y -= Speed;
            }
        }
        public void MoveDown()
        {
            if (Y + (Bitmap.Height / 2) < Window.Height)
            {
                Y += Speed;
            }
        }
        public void Shoot()
        {
            uint currentTime = _shootTimer.Ticks;
            if (currentTime - _lastShotTime > ShootSpeed)
            {
                SplashKit.PlaySoundEffect(_shootingSound);
                _bullets.Add(_gameFactory.CreateBullet(_bulletType, X, Y));
                _lastShotTime = currentTime;
            }
        }
        public List<Bullet> Bullets
        {
            get { return _bullets; }
        }
        public string BulletType
        { 
            get { return _bulletType; }
            set { _bulletType = value; }
        }
    }
}
