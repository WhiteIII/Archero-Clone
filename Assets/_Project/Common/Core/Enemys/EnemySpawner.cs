using System;
using System.Collections.Generic;
using Project.Core.Services;
using UnityEngine;

namespace Project.Core.Enemy
{
    public class EnemySpawner : IDisposable
    {
        private readonly IObjectPool<CreatedMeleeEnemyActorData> _meleeEnemyObjectPool;
        private readonly IObjectPool<CreatedDistantEnemyActorData> _distantEnemyObjectPool;

        public readonly List<CreatedMeleeEnemyActorData> _createdMeleeEnemyActorDatas = new();
        public readonly List<CreatedDistantEnemyActorData> _createdDistantEnemyActorDatas = new();

        public EnemySpawner(
            IObjectPool<CreatedMeleeEnemyActorData> meleeEnemyObjectPool, 
            IObjectPool<CreatedDistantEnemyActorData> distantEnemyObjectPool)
        {
            _meleeEnemyObjectPool = meleeEnemyObjectPool;
            _distantEnemyObjectPool = distantEnemyObjectPool;
        }
        
        public void Dispose()
        {
            foreach (CreatedMeleeEnemyActorData meleeEnemyActorData in _createdMeleeEnemyActorDatas)
                meleeEnemyActorData.EnemyActor.OnDead -= RemoveMeleeEnemy;

            foreach (CreatedDistantEnemyActorData distantEnemyActorData in _createdDistantEnemyActorDatas)
                distantEnemyActorData.EnemyActor.OnDead -= RemoveDistantEnemy;
        }

        public void SpawnMeleeEnemy(Vector3 position)
        {
            CreatedMeleeEnemyActorData data = _meleeEnemyObjectPool.Get();
            data.MeleeEnemyGameObject.transform.position = position;
            data.EnemyActor.OnDead += RemoveMeleeEnemy;
            _createdMeleeEnemyActorDatas.Add(data);
        }

        public void SpawnDistantEnemy(Vector3 position)
        {
            CreatedDistantEnemyActorData data = _distantEnemyObjectPool.Get();
            data.DistantEnemyGameObject.transform.position = position;
            data.EnemyActor.OnDead += RemoveDistantEnemy;
            _createdDistantEnemyActorDatas.Add(data);
        }

        private void RemoveMeleeEnemy(ICreatedActorData actorData)
        {
            CreatedMeleeEnemyActorData meleeEnemyActorData = (CreatedMeleeEnemyActorData)actorData;
            meleeEnemyActorData.EnemyActor.OnDead -= RemoveMeleeEnemy;
            _createdMeleeEnemyActorDatas.Remove(meleeEnemyActorData);
            _meleeEnemyObjectPool.Release(meleeEnemyActorData);
        }

        private void RemoveDistantEnemy(ICreatedActorData actorData)
        {
            CreatedDistantEnemyActorData meleeEnemyActorData = (CreatedDistantEnemyActorData)actorData;
            meleeEnemyActorData.EnemyActor.OnDead -= RemoveMeleeEnemy;
            _createdDistantEnemyActorDatas.Remove(meleeEnemyActorData);
            _distantEnemyObjectPool.Release(meleeEnemyActorData);

        }
    }
}
