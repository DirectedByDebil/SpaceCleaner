using System;

namespace Characters
{

    [Serializable]
    public struct SpawnSettings
    {

        public int MinEnemies;

        public int MaxEnemies;


        public float Standart;
        
        public float Heavy;
        
        public float Boss;


        public readonly float GetSpawnInterval(EnemyDifficulty difficulty)
        {

            switch (difficulty)
            {

                case EnemyDifficulty.Standart:
                    return Standart;


                case EnemyDifficulty.Heavy:
                    return Heavy;


                case EnemyDifficulty.Boss:
                    return Boss;


                default:
                    return Standart;
            }
        }
    }
}
