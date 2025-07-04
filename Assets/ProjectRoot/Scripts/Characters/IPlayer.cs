using Movement;

namespace Characters
{
    public interface IPlayer: ICharacter, IPhysical, IAgent
    {

        public IPlayerUI UI { get; }
    }
}
