using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RayVanguard
{
    public class GameScene : IScene
    {
        private Player _player;
        private List<Enemy> _enemies;
        private Random _enemyGenerator;
        private Window _window;
        private Music _music;
        private SoundEffect _explosionSound;
        private int _clearedEnemies;
        private GameFactory _gameFactory;
        private double _enemiesFrequency;
        private Bitmap _explosionAnimation;
        private AnimationScript _explosionScript;
        private List<ExplosionEffect> _explosions;


        private bool _isDead;
        public GameScene(Window window, Player player, double enemiesFrequency, Music music, GameFactory gameFactory)
        {
            _player = player;
            _enemies = new List<Enemy>();
            _enemyGenerator = new Random();
            _gameFactory = gameFactory;
            _window = window;
            _music = music;
            _clearedEnemies = 0;
            _isDead = false;
            _explosionSound = SplashKit.LoadSoundEffect("explosion1", "explosionCrunch_004.ogg");
            _explosionAnimation = SplashKit.LoadBitmap("explosion_effect1", "img/explosion/explosion_blue.png");
            _explosionAnimation.SetCellDetails(_explosionAnimation.Width / 14, _explosionAnimation.Height, 14, 1, 14);
            _explosionScript = SplashKit.LoadAnimationScript("ExplosionScript", "explosion_script.txt");
            _enemiesFrequency = enemiesFrequency;
            _explosions = new List<ExplosionEffect>();

            SplashKit.PlayMusic(_music);
            SplashKit.SetMusicVolume(0.1f);
        }
        public void Update()
        {
            CheckInput();
            CheckSpawnAndCollide();
            UpdateExplosions();
            if (!SplashKit.MusicPlaying())
            {
                SplashKit.PlayMusic(_music);
                SplashKit.SetMusicVolume(0.1f);
            }
        }
        public void Draw()
        {
            _player.Draw();
            foreach (Enemy enemy in _enemies)
            {
                enemy.Draw();
            }
            foreach (Bullet bullet in _player.Bullets)
            {
                bullet.Draw();
            }
            foreach (var explosion in _explosions)
            {
                explosion.Draw();
            }
        }
        private void UpdateExplosions()
        {
            // Update existing explosions
            foreach (var explosion in _explosions.ToList())
            {
                explosion.Update();
                if (!explosion.IsActive)
                {
                    explosion.Free();
                    _explosions.Remove(explosion);
                }
            }
        }
        public bool IsDead
        {
            get { return _isDead; }
        }
        public int ClearedEnemies
        {
            get { return _clearedEnemies; }
        }

        private void CheckInput()
        {
            if (_enemyGenerator.Next(0, 101) < _enemiesFrequency)
            {
                _enemies.Add(_gameFactory.CreateEnemy("Enemy1", (_enemyGenerator.Next(0, _window.Width)), 0));
            }
            if (SplashKit.KeyDown(KeyCode.AKey))
            {
                _player.MoveLeft();
            }
            if (SplashKit.KeyDown(KeyCode.DKey))
            {
                _player.MoveRight();
            }
            if (SplashKit.KeyDown(KeyCode.WKey))
            {
                _player.MoveUp();
            }
            if (SplashKit.KeyDown(KeyCode.SKey))
            {
                _player.MoveDown();
            }
            if (SplashKit.KeyDown(KeyCode.SpaceKey))
            {
                _player.Shoot();
            }
        }

        private void CheckSpawnAndCollide()
        {
            List<Enemy> enemiesToDelete = new List<Enemy>();
            List<Bullet> bulletsToDelete = new List<Bullet>();

            //This is checking the collision of different object, and also checking if enemy had leave the screen already
            foreach (Enemy enemy in _enemies)
            {
                enemy.Move();
                if (enemy.Y > _window.Height + enemy.Bitmap.Height)
                {
                    enemiesToDelete.Add(enemy);
                }
                foreach (Bullet bullet in _player.Bullets)
                {
                    if (SplashKit.BitmapCollision(enemy.Bitmap, enemy.X - enemy.Bitmap.Width / 2, enemy.Y - enemy.Bitmap.Height / 2, bullet.Bitmap, bullet.X - bullet.Bitmap.Width / 2, bullet.Y - bullet.Bitmap.Height / 2))
                    {
                        SplashKit.PlaySoundEffect(_explosionSound);
                        _explosions.Add(new ExplosionEffect(_explosionAnimation, _explosionScript, enemy.X - enemy.Bitmap.Width / 2, enemy.Y - enemy.Bitmap.Height / 2));
                        _clearedEnemies += 1;
                        enemiesToDelete.Add(enemy);
                        bulletsToDelete.Add(bullet);
                    }
                }
                if (SplashKit.BitmapCollision(enemy.Bitmap, enemy.X - enemy.Bitmap.Width / 2, enemy.Y - enemy.Bitmap.Height / 2, _player.Bitmap, _player.X - _player.Bitmap.Width / 2, _player.Y - _player.Bitmap.Height / 2))
                {
                    _isDead = true;
                }
            }

            //This is removing the enemy if it's needed to delete, the reason for we to make something like this is that we can't change the list when we are doing a for loop on the list at the same time
            foreach (Enemy enemy in enemiesToDelete)
            {
                _enemies.Remove(enemy);
            }
            //This is checking if the bullet left the screen already
            foreach (Bullet bullet in _player.Bullets)
            {
                bullet.Move();
                if (bullet.Y > _window.Height + bullet.Bitmap.Height)
                {
                    bulletsToDelete.Add(bullet);
                }
            }
            //This is removing the bullet if it's needed to delete
            foreach (Bullet bullet in bulletsToDelete)
            {
                _player.Bullets.Remove(bullet);
            }
        }
    }
}
