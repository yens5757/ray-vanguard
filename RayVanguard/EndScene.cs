using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayVanguard
{
    public class EndScene : IScene
    {
        private Music _music;
        private Window _window;
        public EndScene(Window window, Music music)
        {
            _music = music;
            _window = window;
        }
        public void Draw()
        {
            
        }
        public void Update()
        {
            if (!SplashKit.MusicPlaying())
            {
                SplashKit.PlayMusic(_music);
                SplashKit.SetMusicVolume(0.1f);
            }
        }
    }
}
