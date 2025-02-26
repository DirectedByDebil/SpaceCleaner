using Characters;
using UnityEngine;
using System.Collections.Generic;

namespace Movement
{
    public sealed class EnemyMovementSystem
    {

        private readonly EnemyMovementControl _control;


        private readonly Dictionary<IEnemy, AgentMovement> _allAgents;

        private readonly List<AgentMovement> _activeAgents;


        public EnemyMovementSystem(IReadOnlyCollection<IEnemy> allEnemies)
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

                _control.Pressed += agent.SetDestination;

                _activeAgents.Add(agent);
            }
        }
    

        public void RemoveEnemy(IEnemy enemy)
        {

            if(TryGetAgent(enemy, out AgentMovement agent))
            {

                _control.Pressed -= agent.SetDestination;

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
