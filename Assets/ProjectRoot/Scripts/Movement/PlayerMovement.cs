using Characters;
using UnityEngine;

namespace Movement
{
    public sealed class PlayerMovement
    {

        private readonly IPlayer _player;

        private readonly AgentMovement _agentMovement;


        public PlayerMovement(IPlayer player)
        {

            _player = player;

            _agentMovement = new AgentMovement(player);
        }


        public void MakeMovement(Vector3 direction)
        {

            _agentMovement.Move(direction);
        }
    }
}
