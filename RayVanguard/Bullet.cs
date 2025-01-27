using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayVanguard
{
    public class Bullet : GameObject
    {
        private double _speed;
        private bool _isPlayer;
        public Bullet(double x, double y, Window window) : this(SplashKit.LoadBitmap("PlayerBullet1", "img/player/bullet/bullet1.png"), x, y, 10, true, window)
        {

        }
        public Bullet(Bitmap bitmap, double x, double y, double speed, bool isPlayer, Window window) : base(bitmap, x, y, window)
        {
            _speed = speed;
            _isPlayer = isPlayer;
        }
        //if it's the player, the bullet shoots up, if it's not, it shoots down
        public void Move()
        {
            if (_isPlayer) 
            {
                Y -= _speed;
            }
            else
            {
                Y += _speed;
            }
        }
    }
}
