using UnityEngine;

namespace Client.MenuesLogic
{
    internal sealed class DestroyTimer : MonoBehaviour
    {
        [SerializeField] private float _timer;

        private void Awake()
        {
            Destroy(gameObject, _timer);
        }
    }
}