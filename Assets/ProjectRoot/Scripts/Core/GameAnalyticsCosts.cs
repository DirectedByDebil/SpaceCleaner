using System;
using Pickables;
using Characters;

namespace Core
{
    [Serializable]
    public struct GameAnalyticsCosts
    {

        public GarbagePoints GarbagePoints;

        public EnemyPoints EnemyPoints;


        public int GarbagePointsToWin;

        public int EnemyPointsToWin;


        public readonly int GetGarbagePoints(GarbageType garbageType)
        {

            switch (garbageType)
            {

                case GarbageType.Small:
                    return GarbagePoints.Small;


                case GarbageType.Medium:
                    return GarbagePoints.Medium;


                case GarbageType.Big:
                    return GarbagePoints.Big;


                default:
                    return GarbagePoints.Small;
            }
        }


        public readonly int GetEnemyPoints(EnemyDifficulty difficulty)
        {

            switch (difficulty)
            {

                case EnemyDifficulty.Standart:
                    return EnemyPoints.Standart;


                case EnemyDifficulty.Heavy:
                    return EnemyPoints.Heavy;


                case EnemyDifficulty.Boss:
                    return EnemyPoints.Boss;


                default:
                    return EnemyPoints.Standart;
            }
        }
    }
}