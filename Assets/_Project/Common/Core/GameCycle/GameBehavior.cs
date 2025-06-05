using System.Collections.Generic;
using Project.Core.Services;
using Zenject;

namespace Project.Core.GameCycle
{
    public class GameBehavior : 
        ITickable, 
        IUpdatingController, 
        IRepository<IUpdateable>
    {
        private readonly List<IUpdateable> _updateableObjects = new();

        private bool _isUpdating = false;

        public void EnableUpdating() =>
            _isUpdating = true;

        public void DisableUpdating() =>
            _isUpdating = false;

        public void Add(IUpdateable updateableObject) =>
            _updateableObjects.Add(updateableObject);

        public void Remove(IUpdateable updateableObject) =>
            _updateableObjects.Remove(updateableObject);

        public void Tick()
        {
            if (_isUpdating == false)
                return;

            foreach (var updateableObject in _updateableObjects)
                updateableObject.Update();
        }
    }
}