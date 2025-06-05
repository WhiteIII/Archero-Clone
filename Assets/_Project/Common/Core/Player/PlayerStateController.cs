using Project.Core.Services;

namespace Project.Core.Player
{
    public class PlayerStateController
    {
        private readonly IActivatedAndDeactivatedObject _shootingController;
        private readonly IActivatedAndDeactivatedObject _baseInputController;

        public PlayerStateController(
            IActivatedAndDeactivatedObject shootingController, 
            IActivatedAndDeactivatedObject baseInputController)
        {
            _shootingController = shootingController;
            _baseInputController = baseInputController;
        }

        public void Kill()
        {
            _shootingController.Deactivate();
            _baseInputController.Deactivate();
        }

        public void Revive()
        {
            _shootingController.Activate();
            _baseInputController.Activate();
        }
    }
}