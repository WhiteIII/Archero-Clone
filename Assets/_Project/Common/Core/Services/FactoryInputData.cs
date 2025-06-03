using Project.Core.InputController;

namespace Project.Core.Services
{
    public struct FactoryInputData
    {
        public IInputModel InputModel;
        public IInputModelController InputModelController;
        public IInput[] Inputs;
    }
}