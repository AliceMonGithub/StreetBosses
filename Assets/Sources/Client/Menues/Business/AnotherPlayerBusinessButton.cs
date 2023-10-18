using Server.BotLogic;
using TMPro;
using UnityEngine;

namespace Client.MenuesLogic
{
    internal sealed class AnotherPlayerBusinessButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nicknameText;

        private Bot _bot;

        public void Init(Bot bot)
        {
            _bot = bot;
        }

        private void UpdateAllUI()
        {
            _nicknameText.name = _bot.Nickname;
        }
    }
}