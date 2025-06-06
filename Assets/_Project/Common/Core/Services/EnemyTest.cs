using Project.Core.Enemy;
using Project.Core.GameCycle;
using UnityEngine;
using Zenject;

namespace Project.Core.Services
{
    public class EnemyTest : 
        ITickable, 
        IInitializable<(
            IFactory<CreteadMeleeEnemyActorData>, 
            IRepository<IUpdateable>,
            IHealth,
            IMeleeEnemyStats,
            Transform)>
    {
        private IFactory<CreteadMeleeEnemyActorData> _meleeEnemyFactory;
        private IRepository<IUpdateable> _gameBehavior;
        private IHealth _playerHealth;
        private IMeleeEnemyStats _meleeEnemyStats;
        private Transform _playerTransform;

        public void Initialize((
            IFactory<CreteadMeleeEnemyActorData>, 
            IRepository<IUpdateable>,
            IHealth,
            IMeleeEnemyStats,
            Transform) data)
        {
            _meleeEnemyFactory = data.Item1;
            _gameBehavior = data.Item2;
            _playerHealth = data.Item3;
            _meleeEnemyStats = data.Item4;
            _playerTransform = data.Item5;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CreteadMeleeEnemyActorData data = _meleeEnemyFactory.Create();

                data.ActorInitilialize.Initialize(new MeleeEnemyActorData { 
                    EnemyStats = _meleeEnemyStats,
                    PlayerHealth = _playerHealth,
                    PlayerTransform = _playerTransform,
                });

                _gameBehavior.Add(data.AiActor);
            }
        }
    }
}
