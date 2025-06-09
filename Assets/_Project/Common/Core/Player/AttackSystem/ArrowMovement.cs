using UnityEngine;
using static UnityEngine.Time;

namespace Project.Core.Player.AttackSystem
{
    public class ArrowMovement : IBulletMovement
    {
        public readonly Rigidbody _rigidBody;

        private Vector3 _duration;
        private float _speed;

        public ArrowMovement(Rigidbody rigidBody) =>
            _rigidBody = rigidBody;

        public void SetTarget(Vector3 duration) =>
            _duration = duration;

        public void SetSpeed(float speed) =>
            _speed = speed;

        public void Update() =>
            _rigidBody.MovePosition(_rigidBody.transform.position + _duration * _speed * deltaTime);
    }
}
