using DG.Tweening;
using Server.BusinessLogic;
using System.Collections;
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

        [SerializeField] private float _moveToTargetSpeed;

        [Space]

        [SerializeField] private Transform _transform;

        private Vector2 _smoothVector;
        private Vector2 _velosity;

        private void Update()
        {
            Move();
        }

        public void MoveToBusiness(Business business)
        {
            _transform.DOMoveX(business.BusinessButton.transform.position.x, _moveToTargetSpeed);
        }

        private void Move()
        {
            float horizontal = Input.GetAxisRaw(HorizontalAxis);
            float moveDirection = horizontal * _moveSpeed;
            Vector2 moveVector = moveDirection * Time.deltaTime * Vector2.right;

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