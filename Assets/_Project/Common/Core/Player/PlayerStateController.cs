using Project.Core.Services;

namespace Project.Core.Player
{
    public class PlayerStateController : IPlayerStateModel
    {
        private readonly IActivatedAndDeactivatedObject _shootingController;
        private readonly IActivatedAndDeactivatedObject _baseInputController;

        public bool IsAlive { get; private set; }

        public PlayerStateController(
            IActivatedAndDeactivatedObject shootingController, 
            IActivatedAndDeactivatedObject baseInputController,
            bool isAlive = true)
        {
            _shootingController = shootingController;
            _baseInputController = baseInputController;
            IsAlive = isAlive;
        }

        public void Kill()
        {
            _shootingController.Deactivate();
            _baseInputController.Deactivate();
            IsAlive = false;
        }

        public void Revive()
        {
            _shootingController.Activate();
            _baseInputController.Activate();
            IsAlive = true;
        }
    }
}