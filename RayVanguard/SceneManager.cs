using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayVanguard
{
    public class SceneManager : IScene
    {
        private GameScene _gameScene;
        private ShopScene _shopScene;
        private MainMenuScene _mainMenuScene;
        private EndScene _endScene;
        private SceneState _currentScene;
        private Player _player;
        private BackgroundManager _backgroundManager;
        private Window _window;
        private DifficultyTracker _difficultyTracker;
        private int _score;

        private GameFactory _gameFactory;

        private Music _titleMusic, _level1Music, _level2Music, _endingMusic;
        public SceneManager(Window window)
        {
            _window = window;
            _currentScene = new SceneState();
            _gameFactory = new GameFactory(_window);
            _backgroundManager = new BackgroundManager(_window, _gameFactory);
            _difficultyTracker = new DifficultyTracker();
            _score = 0;

            _titleMusic = SplashKit.LoadMusic("titlemusic", "level/title.wav");
            _level1Music = SplashKit.LoadMusic("level1music", "level/level1.wav");
            _level2Music = SplashKit.LoadMusic("level2music", "level/level2.wav");
            _endingMusic = SplashKit.LoadMusic("endmusic", "level/end.wav");

            _player = _gameFactory.CreatePlayer("Player1", 220, 650);

            _mainMenuScene = new MainMenuScene(_window, _titleMusic);
            _gameScene = new GameScene(_window, _player, _difficultyTracker.EnemyFrequency, _level1Music, _gameFactory);
            _shopScene = new ShopScene(_window, _level2Music);
            _endScene = new EndScene(_window, _endingMusic);
        }
        //SceneState for scene change
        public enum SceneState
        {
            MainMenu,
            Game,
            Shop,
            End
        }
        public SceneState CurrentScene
        {
            get { return _currentScene; }
        }

        public void Update()
        {
            _backgroundManager.Update(CurrentScene);
            switch (CurrentScene)
            {
                case SceneState.MainMenu:
                    _mainMenuScene.Update();
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        MenuToGame();
                        MenuToQuit();
                    }
                    break;
                case SceneState.Game:
                    _gameScene.Update();
                    if (_gameScene.IsDead)
                    {
                        _score += _gameScene.ClearedEnemies;
                        GameToEnd();
                    }
                    if (_gameScene.ClearedEnemies >= _difficultyTracker.MaxEnemies)
                    {
                        _score += _gameScene.ClearedEnemies;
                        GameToShop();
                    }
                    break;
                case SceneState.Shop:
                    _shopScene.Update();
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        ShopToGame();
                        UpgradeCharge();
                    }
                    break;
                case SceneState.End:
                    _endScene.Update();
                    break;
                default:
                    throw new InvalidOperationException("Invalid scene state");
            }
        }
        public void Draw()
        {
            _backgroundManager.Draw(CurrentScene);
            switch (CurrentScene)
            {
                case SceneState.MainMenu:
                    _mainMenuScene.Draw();
                    break;
                case SceneState.Game:
                    _gameScene.Draw();
                    break;
                case SceneState.Shop:
                    _shopScene.Draw();
                    break;
                case SceneState.End:
                    _endScene.Draw();
                    _window.DrawText(_score.ToString(), Color.Purple, "default", 24, _window.Width / 2, _window.Height / 2);
                    if (SplashKit.MouseClicked(MouseButton.LeftButton))
                    {
                        EndToGame();
                        EndToMenu();
                    }
                    break;
                default:
                    throw new InvalidOperationException("Invalid scene state");
            }
        }
        //Represent the upgrade in the shop
        private void UpgradeCharge()
        { 
            if (_difficultyTracker.UpgradeTimes > 0) 
            {
                if ((SplashKit.MousePosition().X > 385 && SplashKit.MousePosition().X < 475) && (SplashKit.MousePosition().Y > 160 && SplashKit.MousePosition().Y < 185) && _shopScene.ShopBar1.Charge < 10)
                {
                    _shopScene.ShopBar1.IncreaseCharge();
                    _difficultyTracker.UpgradeTimes -= 1;
                }
                if ((SplashKit.MousePosition().X > 385 && SplashKit.MousePosition().X < 475) && (SplashKit.MousePosition().Y > 260 && SplashKit.MousePosition().Y < 285) && _shopScene.ShopBar2.Charge < 10)
                {
                    _shopScene.ShopBar2.IncreaseCharge();
                    _player.ShootSpeed -= 15;
                    _difficultyTracker.UpgradeTimes -= 1;
                }
                if ((SplashKit.MousePosition().X > 385 && SplashKit.MousePosition().X < 475) && (SplashKit.MousePosition().Y > 365 && SplashKit.MousePosition().Y < 390) && _shopScene.ShopBar3.Charge < 10)
                {
                    _shopScene.ShopBar3.IncreaseCharge();
                    _player.Speed += 1;
                    _difficultyTracker.UpgradeTimes -= 1;

                }
                if ((SplashKit.MousePosition().X > 385 && SplashKit.MousePosition().X < 475) && (SplashKit.MousePosition().Y > 475 && SplashKit.MousePosition().Y < 490) && _shopScene.ShopBar4.Charge < 10)
                {
                    _shopScene.ShopBar4.IncreaseCharge();
                    _difficultyTracker.UpgradeTimes -= 1;
                }
            }
        }

        //All of the XX to XX means the scene changes
        private void ShopToGame()
        {
            if ((SplashKit.MousePosition().X > 100 && SplashKit.MousePosition().X < 370) && (SplashKit.MousePosition().Y > 756 && SplashKit.MousePosition().Y < 780))
            {
                _currentScene = SceneState.Game;
                _gameScene = new GameScene(_window, _player, _difficultyTracker.EnemyFrequency, _level1Music, _gameFactory);
            }
        }
        private void MenuToGame()
        {
            if ((SplashKit.MousePosition().X > 160 && SplashKit.MousePosition().X < 320) && (SplashKit.MousePosition().Y > 570 && SplashKit.MousePosition().Y < 600))
            {
                _currentScene = SceneState.Game;
            }
        }
        private void MenuToQuit()
        {
            if ((SplashKit.MousePosition().X > 205 && SplashKit.MousePosition().X < 272) && (SplashKit.MousePosition().Y > 640 && SplashKit.MousePosition().Y < 660))
            {
                SplashKit.CloseAllWindows();
            }
        }
        private void GameToEnd()
        {
            _currentScene = SceneState.End;
        }

        private void GameToShop()
        {
            _currentScene = SceneState.Shop;
            _difficultyTracker.NextRound();
        }

        private void EndToGame()
        {
            if ((SplashKit.MousePosition().X > 133 && SplashKit.MousePosition().X < 336) && (SplashKit.MousePosition().Y > 543 && SplashKit.MousePosition().Y < 562))
            {
                _currentScene = SceneState.Game;
                ResetData();
            }
        }
        private void EndToMenu()
        {
            if ((SplashKit.MousePosition().X > 146 && SplashKit.MousePosition().X < 320) && (SplashKit.MousePosition().Y > 603 && SplashKit.MousePosition().Y < 628))
            {
                _currentScene = SceneState.MainMenu;
                ResetData();
            }
        }
        //Reset the player Data after player is dead
        private void ResetData()
        {
            _player = _gameFactory.CreatePlayer("Player1", 220, 650);
            _difficultyTracker.ResetDifficulty();
            _score = 0;
            _gameScene = new GameScene(_window, _player, _difficultyTracker.EnemyFrequency, _level1Music, _gameFactory);
            _shopScene = new ShopScene(_window, _level2Music);
        }
    }
}
