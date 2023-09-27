using Server.CharacterLogic;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.CameraLogic
{
    internal sealed class Test : MonoBehaviour
    {
        [SerializeField] private Transform _first;
        [SerializeField] private Transform _second;
        [SerializeField] private Transform _third;

        private void Awake()
        {
            Character firstTeamCharacter = new(null, "tttt", 1, 0.4f, 4, null);
            Character secondTeamCharacter = new(null, "4444", 1, 0.4f, 4, null);
            Character secondButFirstTeamCharacter = new(null, "331", 1, 0.4f, 4, null);

            BattleCharacter firstBattleCharacter = _first.gameObject.AddComponent<BattleCharacter>();
            BattleCharacter secondBattleCharacter = _second.gameObject.AddComponent<BattleCharacter>();
            BattleCharacter thirdBattleCharacter = _third.gameObject.AddComponent<BattleCharacter>();

            BattleData battleData = new(new(1) { firstBattleCharacter }, new(2) { secondBattleCharacter, thirdBattleCharacter });

            //firstBattleCharacter.Init(firstTeamCharacter, battleData, true);
           // secondBattleCharacter.Init(secondTeamCharacter, battleData, false);
           // thirdBattleCharacter.Init(secondButFirstTeamCharacter, battleData, false);

           
        }
    }
}