using UnityEngine;

namespace Sources.CameraLogic
{
    internal sealed class CameraMovement : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";

        [SerializeField] private Vector2 _xMoveLimit;
        [SerializeField] private float _moveSpeed;

        [Space]

        [SerializeField] private Transform _transform;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            float horizontal = Input.GetAxisRaw(HorizontalAxis);
            float moveDirection = horizontal * _moveSpeed;

            _transform.Translate(Vector3.right * moveDirection);

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