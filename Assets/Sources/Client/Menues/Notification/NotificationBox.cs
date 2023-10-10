using Server.NotificationLogic;
using TMPro;
using UnityEngine;

namespace Client.MenuesLogic
{
    internal sealed class NotificationBox : MonoBehaviour
    {
        [SerializeField] private TMP_Text _messageText;

        private Notification _notification;

        public void Init(Notification notification)
        {
            _notification = notification;

            UpdateBoxUI();
        }

        private void UpdateBoxUI()
        {
            _messageText.text = _notification.Message;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}