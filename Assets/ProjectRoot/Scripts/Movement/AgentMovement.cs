using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    public class AgentMovement
    {

        private readonly NavMeshAgent _agent;

        private readonly IMovementStats _stats;


        public AgentMovement(IAgent agent)
        {
            
            _agent = agent.NavMeshAgent;

            _stats = agent.MovementStats;


            _agent.speed = _stats.Speed;

            _agent.acceleration = _stats.Acceleration;
        }


        public void SetDestination(Vector3 destination)
        {
            
            _agent.destination = destination;
        }
    

        public void Move(Vector3 destination)
        {

            destination *= _stats.Speed * Time.fixedDeltaTime;

            _agent.Move(destination);
        }
    }
}
