using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class Player : Character, IPlayer
    {

        public Rigidbody Rigidbody { get => GetComponent<Rigidbody>(); }
    }
}
