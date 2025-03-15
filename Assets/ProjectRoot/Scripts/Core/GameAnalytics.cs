using Characters;
using Pickables;
using System;

namespace Core
{
    public sealed class GameAnalytics
    {

        public event Action<int, int> GarbagePointsChanged;
        
        public event Action<int, int> EnemyPointsChanged;

        public event Action GoalAchieved;
        

        private readonly GameAnalyticsCosts _costs;


        private int _garbagePoints;

        private int _enemyPoints;


        public GameAnalytics(GameAnalyticsCosts costs)
        {

            _costs = costs;
        }


        public void OnPickingGarbage(IGarbage garbage)
        {

            IncreaseGarbagePoints(garbage.GarbageType);


            garbage.OnPickedUp();
        }


        public void OnEnemyEnded(IEnemy enemy)
        {

            IncreaseEnemyPoints(enemy.EnemyDifficulty);
        }


        public void RefreshPoints()
        {

            _enemyPoints = 0;

            _garbagePoints = 0;


            EnemyPointsChanged?.Invoke(_enemyPoints, _costs.EnemyPointsToWin);

            GarbagePointsChanged?.Invoke(_garbagePoints, _costs.GarbagePointsToWin);
        }


        private void IncreaseGarbagePoints(GarbageType garbageType)
        {

            _garbagePoints += _costs.GetGarbagePoints(garbageType);

            GarbagePointsChanged?.Invoke(_garbagePoints, _costs.GarbagePointsToWin);


            if(_garbagePoints >= _costs.GarbagePointsToWin)
            {

                GoalAchieved?.Invoke();
            }
        }


        private void IncreaseEnemyPoints(EnemyDifficulty difficulty)
        {

            _enemyPoints += _costs.GetEnemyPoints(difficulty);

            EnemyPointsChanged?.Invoke(_enemyPoints, _costs.EnemyPointsToWin);


            if(_enemyPoints >= _costs.EnemyPointsToWin)
            {

                GoalAchieved?.Invoke();
            }
        }
    }
}
