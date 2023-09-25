using UnityEngine;

namespace Sources.CameraLogic
{
    internal sealed class CameraMovement : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";

        [SerializeField] private Vector2 _xMoveLimit;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _moveSmooth;

        [Space]

        [SerializeField] private Transform _transform;

        private Vector2 _smoothVector;
        private Vector2 _velosity;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            float horizontal = Input.GetAxisRaw(HorizontalAxis);
            float moveDirection = horizontal * _moveSpeed;
            Vector2 moveVector = Vector2.right * moveDirection;

            _smoothVector = Vector2.SmoothDamp(_smoothVector, moveVector, ref _velosity, _moveSmooth);

            _transform.Translate(_smoothVector);

            LimitXMovement();
        }

        private void LimitXMovement()
        {
            Vector3 startPosition = _transform.position;
            float newX = Mathf.Clamp(startPosition.x, _xMoveLimit.x, _xMoveLimit.y);

            _transform.position = new(newX, startPosition.y, startPosition.z);
        }
    }
}