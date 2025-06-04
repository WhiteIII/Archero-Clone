using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Player.AttackSystem
{
    public class ArrowFactory : IFactory<ArrowData>, ISetablePrefab
    {
        private GameObject _currentArrowPrefab;

        public void SetPrefab(GameObject arrowPrefab) =>
            _currentArrowPrefab = arrowPrefab;
        
        public ArrowData Create()
        {
            GameObject arrowGameObject = GameObject.Instantiate(_currentArrowPrefab);

            return new ArrowData
            {
                ArrowGameObject = arrowGameObject,
                Rigidbody = arrowGameObject.GetComponent<Rigidbody>(),
                ArrowMovement = new ArrowMovement(arrowGameObject.GetComponent<Rigidbody>())
            };
        }
    }

    public class AttackSystemFactory : IFactory<AttackSystemFactoryData>
    {
        public readonly AttackController _attackController;

        public AttackSystemFactory(AttackController attackController) =>
            _attackController = attackController;

        public AttackSystemFactoryData Create()
        {
            return new AttackSystemFactoryData();
        }
    }

    public struct AttackSystemFactoryData
    {
        public AttackModel Model;
        //public 
    }
}
