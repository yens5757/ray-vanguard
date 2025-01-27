using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayVanguard
{
    public class ShopBar
    {
        private int _blockWidth;
        private int _blockHeight;

        private Window _window;
        private int _maxCharge;
        private int _charge;
        private Color _blockColor;

        public ShopBar(Window window, int maxCharge)
        {
            _window = window;
            _maxCharge = maxCharge;
            _blockWidth = 20;
            _blockHeight = 20;
        }

        public void IncreaseCharge()
        {
            _charge = Math.Min(_charge + 1, _maxCharge);
        }
        public int Charge
        { 
            get { return _charge; } 
        }
        //check the charge, if the charge is 5, draw 5 green block in the screen, and leave the other 5 gray
        public void Draw(float x, float y)
        {
            for (int i = 0; i < _maxCharge; i++)
            {
                if (i < _charge)
                {
                    _blockColor = Color.Green;
                }
                else
                {
                    _blockColor = Color.Gray;
                }

                _window.FillRectangle(_blockColor, x + (i * _blockWidth), y, _blockHeight - 1, _blockHeight - 1);
            }
        }
    }
}
