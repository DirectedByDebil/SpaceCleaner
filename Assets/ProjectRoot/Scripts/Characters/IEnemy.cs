using UnityEngine.AI;

namespace Characters
{
    public interface IEnemy: ICharacter
    {

        public NavMeshAgent NavMeshAgent { get; }
    }
}
