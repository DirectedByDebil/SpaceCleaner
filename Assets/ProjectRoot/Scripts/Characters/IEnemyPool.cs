using Core;
using System.Collections.Generic;

namespace Characters
{
    public interface IEnemyPool: IPool<Enemy>
    {

        public bool TryGetEnemy(EnemyDifficulty difficulty, out Enemy enemy);


        public IReadOnlyCollection<Enemy> AllEnemies { get; }
    }
}
