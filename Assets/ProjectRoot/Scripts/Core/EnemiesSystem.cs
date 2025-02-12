using Characters;
using Movement;
using UnityEngine;
using System.Collections.Generic;

namespace Core
{
    public sealed class EnemiesSystem
    {

        private readonly EnemyMovementControl _control;


        private readonly Dictionary<IEnemy, AgentMovement> _allAgents;

        private readonly List<AgentMovement> _activeAgents;


        public EnemiesSystem(IReadOnlyCollection<IEnemy> allEnemies)
        {

            _control = new EnemyMovementControl();


            _allAgents = new Dictionary<IEnemy, AgentMovement>(allEnemies.Count);

            FillDictionary(allEnemies);


            _activeAgents = new List<AgentMovement>(allEnemies.Count);
        }


        public void HandleInput(Vector3 destination, float interval)
        {

            _control.HandleInput(destination, interval);
        }


        #region Add/Remove Enemy

        public void AddEnemy(IEnemy enemy)
        {

            if(TryGetAgent(enemy, out AgentMovement agent))
            {

                _control.Pressed += agent.MakeMovement;

                _activeAgents.Add(agent);
            }
        }
    

        public void RemoveEnemy(IEnemy enemy)
        {

            if(TryGetAgent(enemy, out AgentMovement agent))
            {

                _control.Pressed -= agent.MakeMovement;

                _activeAgents.Remove(agent);
            }
        }

        #endregion


        private void FillDictionary(IEnumerable<IEnemy> enemies)
        {

            foreach(IEnemy enemy in enemies)
            {

                AgentMovement agent = new (enemy);

                _allAgents.Add(enemy, agent);
            }
        }

        
        private bool TryGetAgent(IEnemy enemy, out AgentMovement agent)
        {

            return _allAgents.TryGetValue(enemy, out agent);
        }
    }
}
