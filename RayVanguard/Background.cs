using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayVanguard
{
    public class Background : GameObject
    {
        //The speed of the background move
        private int _speed;
        public Background(Bitmap bitmap, double x, double y, int speed, Window window) : base(bitmap, x, y, window)
        {
            _speed = speed;
        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(Bitmap, X, Y);
        }
        //loop the background
        public void Move()
        {
            Y += _speed;
            if (Y >= Window.Height)
            { 
                Y = -Window.Height;
            }
        }
    }
}
