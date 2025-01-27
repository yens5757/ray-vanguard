using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayVanguard
{
    public abstract class Ship : GameObject
    {
        private double _speed;
        private uint _shootSpeed;
        public Ship(Bitmap bitmap, double x, double y, double speed, uint shootSpeed, Window window) : base(bitmap, x, y, window)
        {
            _speed = speed;
            _shootSpeed = shootSpeed;
        }
        public double Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public uint ShootSpeed
        {
            get { return _shootSpeed; }
            set { _shootSpeed = value; }
        }
    }
}
