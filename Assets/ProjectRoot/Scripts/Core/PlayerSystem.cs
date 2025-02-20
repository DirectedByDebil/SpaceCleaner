using Characters;
using Movement;

namespace Core
{
    public sealed class PlayerSystem
    {

        private readonly PlayerMovementControl _movementControl;

        private readonly PlayerMovement _movement;


        public PlayerSystem(IPlayer player)
        {

            _movementControl = new PlayerMovementControl();

            _movement = new PlayerMovement(player);
        }


        #region Set/Unset
       
        public void SetSystem()
        {

            _movementControl.Pressed += _movement.MakeMovement;
        }


        public void UnsetSystem()
        {

            _movementControl.Pressed -= _movement.MakeMovement;
        }

        #endregion


        public void HandleInput(bool isMovementRaw)
        {

            _movementControl.HandleInput(isMovementRaw);
        }
    }
}
