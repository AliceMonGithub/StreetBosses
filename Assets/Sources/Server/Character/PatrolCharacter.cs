using System.Collections;
using UnityEngine;

namespace Server.BusinessLogic
{
    public sealed class PatrolCharacter : MonoBehaviour
    {
        private const string MovingParameterName = "Moving";
        private const float StopDistance = 0.1f;

        private readonly int MovingParameterHash = Animator.StringToHash(MovingParameterName);

        private CharacterInstance _instance;

        private Vector2 _moveZoneX;
        private Vector2 _moveZoneY;

        private float _movementSmooth;
        private float _maxSpeed;
        private float _waitTime;

        private Vector3 _velosity;

        public void Init(CharacterInstance instance, Vector2 moveZoneX, Vector2 moveZoneY, float movementSmooth, float maxSpeed, float waitTime)
        {
            _instance = instance;

            _moveZoneX = moveZoneX;
            _moveZoneY = moveZoneY;

            _movementSmooth = movementSmooth;
            _maxSpeed = maxSpeed;
            _waitTime = waitTime;
        }

        public void Boot()
        {
            StartCoroutine(MoveToRandomPoint());
        }

        private IEnumerator MoveToRandomPoint()
        {
            Vector2 target = ComputeEndPosition();
            FlipToTarget(target);

            _instance.Animator.SetBool(MovingParameterHash, true);

            while (Vector2.Distance(_instance.Transform.position, target) > StopDistance)
            {
                _instance.Transform.position = Vector3.SmoothDamp(_instance.Transform.position, target, ref _velosity, _movementSmooth, _maxSpeed);

                yield return null;
            }

            _instance.Animator.SetBool(MovingParameterHash, false);

            yield return new WaitForSeconds(_waitTime);

            StartCoroutine(MoveToRandomPoint());
        }

        private Vector2 ComputeEndPosition()
        {
            return new(UnityEngine.Random.Range(_moveZoneX.x, _moveZoneX.y), UnityEngine.Random.Range(_moveZoneY.x, _moveZoneY.y));
        }

        private void FlipToTarget(Vector3 target)
        {
            bool targetIsBehind = target.x > _instance.Transform.position.x;
            Vector3 scale = transform.localScale;

            if (targetIsBehind)
            {
                scale.x = -Mathf.Abs(scale.x);
            }
            else
            {
                scale.x = Mathf.Abs(scale.x);
            }

            _instance.Transform.localScale = scale;
        }
    }
}