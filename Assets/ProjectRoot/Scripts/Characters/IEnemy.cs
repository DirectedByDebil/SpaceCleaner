using Combat;
using Movement;

namespace Characters
{
    public interface IEnemy: ICharacter, IDamager, IAgent
    {

        public EnemyDifficulty EnemyDifficulty { get; }
    }
}