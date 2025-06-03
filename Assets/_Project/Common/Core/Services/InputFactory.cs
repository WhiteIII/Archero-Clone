using Project.Core.InputController;

namespace Project.Core.Services
{
    public class InputFactory : IFactory<FactoryInputData>
    {
        private readonly IInitializable<InputControllerInitializeData> _inputController;

        public InputFactory(IInitializable<InputControllerInitializeData> inputController) =>
            _inputController = inputController;

        public FactoryInputData Create()
        {
            InputModel inputModel = new();
            IInput[] inputs = new[] { new KeyboardInputHandler() };

            _inputController.Initialize(
                new InputControllerInitializeData 
                { 
                    InputModelController = inputModel,
                    Inputs = inputs
                });

            return new FactoryInputData 
            { 
                InputModel = inputModel,
                InputModelController = inputModel,
                Inputs = inputs
            };
        }
    }
}