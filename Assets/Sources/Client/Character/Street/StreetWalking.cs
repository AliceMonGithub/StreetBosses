using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Client.CharacterLogic
{
    internal sealed class StreetWalking : MonoBehaviour
    {
        private const string MovingParameterName = "Moving";
        private const float StopDistance = 0.1f;

        private readonly int MovingParameterHash = Animator.StringToHash(MovingParameterName);

        [SerializeField] private Vector2 _xWalkArea;
        [SerializeField] private Vector2 _yWalkArea;

        [SerializeField] private float _movementSmooth;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _waitTime;

        [Space]

        [SerializeField] private Transform _transform;
        [SerializeField] private Animator _animator;

        private Vector3 _velosity;

        private void Awake()
        {
            StartCoroutine(MoveToRandomPoint());
        }

        private IEnumerator MoveToRandomPoint()
        {
            Vector2 target = ComputeEndPosition();
            FlipToTarget(target);

            _animator.SetBool(MovingParameterHash, true);

            while(Vector2.Distance(_transform.position, target) > StopDistance)
            {
                _transform.position = Vector3.SmoothDamp(_transform.position, target, ref _velosity, _movementSmooth, _maxSpeed);

                yield return null;
            }

            _animator.SetBool(MovingParameterHash, false);

            yield return new WaitForSeconds(_waitTime);

            StartCoroutine(MoveToRandomPoint());
        }

        private Vector2 ComputeEndPosition()
        {
            return new(UnityEngine.Random.Range(_xWalkArea.x, _xWalkArea.y), UnityEngine.Random.Range(_yWalkArea.x, _yWalkArea.y));
        }

        private void FlipToTarget(Vector3 target)
        {
            bool targetIsBehind = target.x > _transform.position.x;
            Vector3 scale = transform.localScale;

            if (targetIsBehind)
            {
                scale.x = -Mathf.Abs(scale.x);
            }
            else
            {
                scale.x = Mathf.Abs(scale.x);
            }

            _transform.localScale = scale;
        }
    }
}