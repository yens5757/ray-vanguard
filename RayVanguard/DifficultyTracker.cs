using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayVanguard
{
    public class DifficultyTracker
    {
        private double _enemyFrequency, _maxEnemies;
        private int  _upgradeTimes, _score;
        public DifficultyTracker() 
        {
            _maxEnemies = 15;
            _enemyFrequency = 5;
            _upgradeTimes = 3;
            _score = 0;
        }
        //Reset the difficulty when player dies
        public void ResetDifficulty()
        {
            _maxEnemies = 15;
            _enemyFrequency = 5;
            _upgradeTimes = 3;
            _score = 0;
        }
        //Increase thne difficulty when player move to next round
        public void NextRound()
        {
            _maxEnemies = _maxEnemies * 1.4;
            _enemyFrequency = _enemyFrequency * 1.25;
            _upgradeTimes = 3;
        }
        public double MaxEnemies
        {
            get { return _maxEnemies; }
            set { _maxEnemies = value;}
        }
        public double EnemyFrequency
        {
            get { return _enemyFrequency; }
            set { _enemyFrequency = value; }
        }
        public int UpgradeTimes
        {
            get { return _upgradeTimes; }
            set { _upgradeTimes = value; }
        }
        public int Score
        {
            get { return _score; } 
            set { _score = value; }
        }
    }
}
