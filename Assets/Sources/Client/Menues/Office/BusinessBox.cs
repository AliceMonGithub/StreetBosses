using Server.BusinessLogic;
using TMPro;
using UnityEngine;

namespace Client.MenuesLogic
{
    internal sealed class BusinessBox : MonoBehaviour
    {
        [SerializeField] private TMP_Text _businessNameText;

        private Business _business;

        public void Init(Business business)
        {
            _business = business;

            UpdateAllUI();
        }

        private void UpdateAllUI()
        {
            _businessNameText.text = _business.Name;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}