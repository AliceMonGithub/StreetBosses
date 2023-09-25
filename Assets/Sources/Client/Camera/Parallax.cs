using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField, Range(0, 1)] float _parallaxEffect;
    Transform _camera;
    Vector3 _cameraOldPosition;
    private void Awake()
    {
        _camera = Camera.main.transform;
        _cameraOldPosition = _camera.position;
    }
    private void FixedUpdate()
    {
        Vector3 delta = _camera.position - _cameraOldPosition;
        _cameraOldPosition = _camera.position;
        transform.position += delta * _parallaxEffect;
    }
}
