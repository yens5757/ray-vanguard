using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RayVanguard.SceneManager;

namespace RayVanguard
{
    public class BackgroundManager
    {
        private Background _mainmenuSceneBackground, _gameSceneBackground1, _gameSceneBackground2, _gameSceneBackground3, _gameSceneBackground4, _shopSceneBackground, _endSceneBackground;
        private GameFactory _gameFactory;
        public BackgroundManager(Window window, GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _mainmenuSceneBackground = _gameFactory.CreateBackground("Menu1", 0, 0);
            _gameSceneBackground1 = _gameFactory.CreateBackground("Game1", 0, 0);
            _gameSceneBackground2 = _gameFactory.CreateBackground("Game1", 0, -window.Height);
            _gameSceneBackground3 = _gameFactory.CreateBackground("Game2", 0, 0);
            _gameSceneBackground4 = _gameFactory.CreateBackground("Game2", 0, -window.Height);
            _shopSceneBackground = _gameFactory.CreateBackground("Shop1", 0, 0);
            _endSceneBackground = _gameFactory.CreateBackground("End1", 0, 0);
        }
        public void Update(SceneManager.SceneState CurrentScene)
        {
            switch (CurrentScene)
            {
                case SceneState.MainMenu:
                    _gameSceneBackground1.Move();
                    _gameSceneBackground2.Move();
                    _gameSceneBackground3.Move();
                    _gameSceneBackground4.Move();
                    break;
                case SceneState.Game:
                    _gameSceneBackground1.Move();
                    _gameSceneBackground2.Move();
                    _gameSceneBackground3.Move();
                    _gameSceneBackground4.Move();
                    break;
                case SceneState.Shop:
                    break;
                case SceneState.End:
                    _gameSceneBackground1.Move();
                    _gameSceneBackground2.Move();
                    _gameSceneBackground3.Move();
                    _gameSceneBackground4.Move();
                    break;
                default:
                    throw new InvalidOperationException("Invalid scene state");
            }
        }

        public void Draw(SceneManager.SceneState CurrentScene)
        {
            switch (CurrentScene)
            {
                case SceneState.MainMenu:
                    _gameSceneBackground1.Draw();
                    _gameSceneBackground2.Draw();
                    _gameSceneBackground3.Draw();
                    _gameSceneBackground4.Draw();
                    _mainmenuSceneBackground.Draw();
                    break;
                case SceneState.Game:
                    _gameSceneBackground1.Draw();
                    _gameSceneBackground2.Draw();
                    _gameSceneBackground3.Draw();
                    _gameSceneBackground4.Draw();
                    break;
                case SceneState.Shop:
                    _shopSceneBackground.Draw();
                    break;
                case SceneState.End:
                    _gameSceneBackground1.Draw();
                    _gameSceneBackground2.Draw();
                    _gameSceneBackground3.Draw();
                    _gameSceneBackground4.Draw();
                    _endSceneBackground.Draw();
                    break;
                default:
                    throw new InvalidOperationException("Invalid scene state");
            }
        }
    }
}
