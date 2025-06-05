using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Player.AttackSystem
{
    public class ArrowFactory : IFactory<ArrowData, IObjectPool<ArrowData>>, ISetablePrefab
    {
        private readonly IArrowStats _arrowStats;
        
        private GameObject _currentArrowPrefab;

        public ArrowFactory(
            IArrowStats arrowStats,
            GameObject arrowDefualtPrefab)
        {
            _arrowStats = arrowStats;
            _currentArrowPrefab = arrowDefualtPrefab;
        }

        public void SetPrefab(GameObject arrowPrefab) =>
            _currentArrowPrefab = arrowPrefab;
        
        public ArrowData Create(IObjectPool<ArrowData> arrowObjectPool)
        {
            ArrowData arrowData = new();

            arrowData.ArrowGameObject = GameObject.Instantiate(_currentArrowPrefab);
            arrowData.Rigidbody = arrowData.ArrowGameObject.GetComponent<Rigidbody>();
            arrowData.ArrowMovement = new ArrowMovement(arrowData.Rigidbody);
            arrowData.ArrowActor = new BaseArrowActor(
                arrowObjectPool, 
                _arrowStats, 
                arrowData, 
                arrowData.ArrowGameObject.GetComponentInChildren<IArrowTargetHandler>());

            return arrowData;
        }
    }
}
