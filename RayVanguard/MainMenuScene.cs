using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RayVanguard.SceneManager;

namespace RayVanguard
{
    public class MainMenuScene : IScene
    {
        private Music _music;
        public MainMenuScene(Window window, Music music) 
        {
            _music = music;
            SplashKit.PlayMusic(_music);
            SplashKit.SetMusicVolume(0.1f);
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
