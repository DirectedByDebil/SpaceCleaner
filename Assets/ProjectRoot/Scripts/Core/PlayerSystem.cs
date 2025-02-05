using Characters;
using Movement;
using Combat;

namespace Core
{
    public sealed class PlayerSystem
    {

        private readonly PlayerMovementControl _movementControl;

        private readonly PhysicsMovement _movementModel;


        public PlayerSystem(IPlayer player)
        {

            _movementControl = new PlayerMovementControl();

            _movementModel = new PhysicsMovement(
                player.MovementStats, player.Rigidbody);
        }


        #region Set/Unset
       
        public void SetSystem()
        {

            _movementControl.Pressed += _movementModel.MakeMovement;
        }


        public void UnsetSystem()
        {

            _movementControl.Pressed -= _movementModel.MakeMovement;
        }

        #endregion


        public void HandleInput(bool isMovementRaw)
        {

            _movementControl.HandleInput(isMovementRaw);
        }
    }
}
