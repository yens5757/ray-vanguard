using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayVanguard
{
    public class ShopScene : IScene
    {
        private Music _music;
        private ShopBar _shopBar1, _shopBar2, _shopBar3, _shopBar4;
        public ShopScene(Window window, Music music)
        { 
            _music = music;
            _shopBar1 = new ShopBar(window, 10);
            _shopBar2 = new ShopBar(window, 10);
            _shopBar3 = new ShopBar(window, 10);
            _shopBar4 = new ShopBar(window, 10);
        }
        public void Draw()
        {
            _shopBar1.Draw(150, 160);
            _shopBar2.Draw(150, 265);
            _shopBar3.Draw(150, 365);
            _shopBar4.Draw(150, 470);
        }
        public void Update()
        {
            if (!SplashKit.MusicPlaying())
            {
                SplashKit.PlayMusic(_music);
                SplashKit.SetMusicVolume(0.1f);
            }
        }
        public ShopBar ShopBar1
        {
            get { return _shopBar1; }
        }
        public ShopBar ShopBar2
        {
            get { return _shopBar2; }
        }
        public ShopBar ShopBar3
        {
            get { return _shopBar3; }
        }
        public ShopBar ShopBar4
        {
            get { return _shopBar4; }
        }
    }
}
