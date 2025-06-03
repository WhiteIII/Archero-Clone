using Project.Core.Services;
using UnityEngine;

namespace Project.Core.InputController
{
    public class BaseInputController : 
        MonoBehaviour, 
        IActivatedAndDeactivatedObject,
        IInitializable<InputControllerInitializeData>
    {
        private IInput[] _inputs;
        private IInputModelController _model;

        private bool _isActive = true;
        public void Initialize(InputControllerInitializeData data)
        {
            _inputs = data.Inputs;
            _model = data.InputModelController;
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

    public struct InputControllerInitializeData
    {
        public IInput[] Inputs; 
        public IInputModelController InputModelController;
    }
}