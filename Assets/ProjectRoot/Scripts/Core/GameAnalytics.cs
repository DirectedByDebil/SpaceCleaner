using Characters;
using Pickables;
using System;

namespace Core
{
    public sealed class GameAnalytics
    {

        public event Action<int> GarbagePointsChanged;
        
        public event Action<int> EnemyPointsChanged;

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

            GUIOutput.AddOutput("Garbage Points", _garbagePoints);

            garbage.OnPickedUp();
        }


        public void OnEnemyEnded(IEnemy enemy)
        {

            IncreaseEnemyPoints(enemy.EnemyDifficulty);

            GUIOutput.AddOutput("Enemy Points", _enemyPoints);
        }



        private void IncreaseGarbagePoints(GarbageType garbageType)
        {

            _garbagePoints += _costs.GetGarbagePoints(garbageType);

            GarbagePointsChanged?.Invoke(_garbagePoints);


            if(_garbagePoints >= _costs.GarbagePointsToWin)
            {
                GUIOutput.AddOutput("Game Won",  "Garbage Points");
                GoalAchieved?.Invoke();
            }
        }


        private void IncreaseEnemyPoints(EnemyDifficulty difficulty)
        {

            _enemyPoints += _costs.GetEnemyPoints(difficulty);

            EnemyPointsChanged?.Invoke(_enemyPoints);


            if(_enemyPoints >= _costs.EnemyPointsToWin)
            {

                GUIOutput.AddOutput("Game Won", "Enemy Points");
                GoalAchieved?.Invoke();
            }
        }
    }
}
