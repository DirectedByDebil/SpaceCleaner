using UnityEngine;

namespace Characters
{
    public interface IPlayer: ICharacter
    {

        public Rigidbody Rigidbody { get; }
    }
}
