using Combat.Guns;
using UnityEngine;

namespace Core
{
    public sealed class ShootingSystem
    {

        private readonly GunControl _control;

        private GunModel _gun;

        private IGunView _gunView;


        public ShootingSystem()
        {

            _control = new GunControl();
        }


        public void AddGun(GunModel model, IGunView view)
        {
            
            _gun = model;

            _gunView = view;
        }


        public void SetSystem()
        {

            _control.DirectionChanged += _gunView.OnDirectionChanged;
            
            //_control.PullingTrigger += _gun.Shoot;
        }

        public void UnsetSystem()
        {

            _control.DirectionChanged -= _gunView.OnDirectionChanged;
            
            //_control.PullingTrigger -= _gun.Shoot;
        }


        public void HandleInput()
        {

            _control.HandleInput();
        }
    }
}
