using System;
using System.Numerics;
using SplashKitSDK;

namespace RayVanguard
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Ray Vanguard", 480, 854);
            SceneManager sceneManager = new SceneManager(window);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                sceneManager.Update();
                sceneManager.Draw();
                SplashKit.RefreshScreen(60);
            } while (!window.CloseRequested);
        }
    }
}
