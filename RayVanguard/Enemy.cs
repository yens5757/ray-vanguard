using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayVanguard
{
    public class Enemy : Ship
    {
        public Enemy(double x, double y, Window window) : this(SplashKit.LoadBitmap("Enemy1", "img/enemy/enemy1.png"), x, y, 5, 2000, window)
        {

        }
        public Enemy(Bitmap bitmap, double x, double y, double speed, uint shootSpeed, Window window) : base(bitmap, x, y, speed, shootSpeed, window)
        {

        }
        public void Move()
        {
            Y += Speed;
        }
    }
}
