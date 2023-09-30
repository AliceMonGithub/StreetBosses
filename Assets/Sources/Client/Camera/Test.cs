using Server.CharacterLogic;
using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Sources.CameraLogic
{
    internal sealed class Test : MonoBehaviour
    {
        private PlayerRuntime _playerRuntime;

        [Inject]
        private void Contructor(PlayerRuntime playerRuntime)
        {
            _playerRuntime = playerRuntime;
        }

        private void Awake()
        {
            //foreach (var item in _playerRuntime.AttackBusiness.Security)
            //{

            //}
        }
    }
}