using System;
using Project.Core.GameCycle;
using UnityEngine;

namespace Project.Core.Enemy
{
    public class CanopyBullet : IUpdateable
    {
        public event Action OnEndFlying;
        
        private readonly AnimationCurve _animationCurve;
        private readonly Transform _bulletTransform;
        private readonly Rigidbody _bulletRigidbody;
        private readonly float _flightDuration;

        private float _progress;
        private bool _isFlying;
        private Vector3 _currentTarget;
        private Vector3 _startPosition;

        public CanopyBullet(
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

        public void StartFly()
        {
            _isFlying = true;
            _progress = 0f;
        }

        public void SetTarget(Vector3 target) =>
            _currentTarget = target;

        public void SetStartPosition(Vector3 startPosition) => 
            _startPosition = startPosition;
    }
}
