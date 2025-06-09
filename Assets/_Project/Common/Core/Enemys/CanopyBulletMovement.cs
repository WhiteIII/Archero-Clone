using System;
using Project.Core.Player.AttackSystem;
using UnityEngine;

namespace Project.Core.Enemy
{
    public class CanopyBulletMovement : IBulletMovement
    {
        public event Action OnEndFlying;
        
        private readonly AnimationCurve _animationCurve;
        private readonly Transform _bulletTransform;
        private readonly Rigidbody _bulletRigidbody;

        private float _flightDuration;
        private float _progress;
        private bool _isFlying;
        private Vector3 _currentTarget;
        private Vector3 _startPosition;

        public CanopyBulletMovement(
            AnimationCurve animationCurve, 
            Transform bulletTransform, 
            Rigidbody bulletRigidbody, 
            float flightDuration)
        {
            _animationCurve = animationCurve;
            _bulletTransform = bulletTransform;
            _bulletRigidbody = bulletRigidbody;
            _flightDuration = flightDuration;
        }

        public void Update()
        {
            if (_isFlying == false) 
                return;

            _progress += Time.deltaTime / _flightDuration;

            Vector3 newPosistion = Vector3.Lerp(_startPosition, _currentTarget, _progress);

            float curveValue = _animationCurve.Evaluate(_progress);
            newPosistion.y += curveValue;

            _bulletRigidbody.MovePosition(newPosistion);

            if (newPosistion != _bulletTransform.position)
                _bulletTransform.forward = newPosistion - _bulletTransform.position;

            if (_progress >= 1f)
            {
                OnEndFlying?.Invoke();
                _isFlying = false;
            }
        }

        public void SetTarget(Vector3 target)
        {
            _isFlying = true;
            _progress = 0f;
            _currentTarget = target;
            _startPosition = _bulletTransform.position;
        }

        public void SetSpeed(float speed) =>
            _flightDuration = speed;
    }
}
