using Characters;
using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    public sealed class AgentMovement
    {

        private readonly NavMeshAgent _agent;


        public AgentMovement(IEnemy enemy)
        {

            _agent = enemy.NavMeshAgent;

            _agent.speed = enemy.MovementStats.Speed;

            _agent.acceleration = enemy.MovementStats.Acceleration;
        }


        public void MakeMovement(Vector3 destination)
        {

            _agent.destination = destination;
        }
    }
}
