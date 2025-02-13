using Core;
using System;
using System.Collections.Generic;

namespace Characters
{
    public sealed class EnemySpawnSystem
    {

        private readonly IPool<IEnemy> _pool;


        public EnemySpawnSystem(IPool<IEnemy> pool)
        {

            _pool = pool;
        }


        public void OnEnded(IEnemy enemy)
        {


        }
    }
}
