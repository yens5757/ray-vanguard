using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayVanguard
{
    public abstract class GameObject
    {
        private Bitmap _bitmap;
        private double _x, _y;
        private Window _window;
        public GameObject(Bitmap bitmap, double x, double y, Window window)
        {
            _bitmap = bitmap;
            _x = x;
            _y = y;
            _window = window;
        }
        public virtual void Draw()
        {
            SplashKit.DrawBitmap(Bitmap, X - Bitmap.Width / 2, Y - Bitmap.Height / 2);
        }
        public Bitmap Bitmap
        { 
            get { return _bitmap; } 
        }
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }
        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public Window Window
        { 
            get { return _window; } 
        }
    }
}
