using UnityEngine;

namespace Project.Core.InputController
{
    public class InputController : MonoBehaviour, IActivatedAndDeactivatedObject
    {
        private IInput[] _inputs;
        private IInputModelController _model;

        private bool _isActive = true;
        public void Initialize(
            IInput[] inputs,
            IInputModelController model)
        {
            _inputs = inputs;
            _model = model;
        }

        private void Update()
        {
            if (_isActive == false)
                return;

            foreach (IInput input in _inputs)
                _model.SetAxis(input.GetAxis());
        }

        public void Activate() =>
            _isActive = true;

        public void Deactivate() =>
            _isActive = false;
    }
}