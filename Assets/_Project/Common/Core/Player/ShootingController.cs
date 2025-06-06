using Project.Core.Services;
using Zenject;
using Project.Core.InputController;
using Project.Core.Player.AttackSystem;

namespace Project.Core.Player
{
    public class ShootingController : 
        ITickable, 
        IInitializable<(IInputModel, IArrowSpawnerController, IAttackModel)>, 
        IShootingController
    {
        private IInputModel _inputModel;
        private IArrowSpawnerController _arrowSpawnerController;
        private IAttackModel _attackModel;

        private bool _isActive = false;
        private bool _isShooting = false;

        public void Initialize((IInputModel, IArrowSpawnerController, IAttackModel) data)
        {
            _inputModel = data.Item1;
            _arrowSpawnerController = data.Item2;
            _attackModel = data.Item3;
        }
        
        public void Activate() =>
            _isActive = true;

        public void Deactivate() => 
            _isActive = false;

        public async void Tick()
        {
            if (_isActive == false || _attackModel.AttackableEnemies.Count == 0 || 
                _inputModel.Axis.x > 0 || _inputModel.Axis.y > 0 || _isShooting)
            {
                return;
            }
            _isShooting = true;
            await _arrowSpawnerController.StartShooting();
            _isShooting = false;
        }
    }
}