using Combat;
using UnityEngine.AI;

namespace Characters
{
    public interface IEnemy: ICharacter, IDamager
    {

        public NavMeshAgent NavMeshAgent { get; }
    }
}
