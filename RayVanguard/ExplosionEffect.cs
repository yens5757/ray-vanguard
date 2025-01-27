using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayVanguard
{
    
    public class ExplosionEffect
    {
        private Sprite _sprite;
        public double X, Y;
        private int _totalFrames;
        public bool IsActive { get; private set; }
        public ExplosionEffect(Bitmap bitmap, AnimationScript script, double x, double y)
        {
            _sprite = SplashKit.CreateSprite(bitmap, script);
            X = x;
            Y = y;
            IsActive = true;
            _sprite.StartAnimation("explode");
            _totalFrames = 14;
        }
        public void Update()
        {
            if (!IsActive) return;

            _sprite.Update();
            _totalFrames--;
            if (_totalFrames == 0)
            {
                IsActive = false;
            }
        }

        public void Draw()
        {
            if (!IsActive) return;
            SplashKit.DrawSprite(_sprite, X, Y);
        }

        public void Free()
        {
            SplashKit.FreeSprite(_sprite);
        }
    }
}
