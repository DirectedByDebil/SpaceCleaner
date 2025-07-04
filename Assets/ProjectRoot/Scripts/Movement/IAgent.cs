using UnityEngine.AI;

namespace Movement
{
    public interface IAgent : IMoveable
    {

        public NavMeshAgent NavMeshAgent { get; }
    }
}