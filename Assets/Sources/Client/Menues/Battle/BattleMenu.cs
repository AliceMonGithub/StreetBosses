using UnityEngine;
using Server.CharacterLogic;
using Server.PlayerLogic;
using UnityEngine.UI;

public sealed class BattleMenu : MonoBehaviour
{

    [SerializeField] private Button _startFightButton;

    [Space]

    [SerializeField] private CharacterData[] _secondTeam;
    [SerializeField] private FightCharacterBox _boxPrefab;

    [SerializeField] private Transform _root;

    private Player _player;
    private BattleTeamSelector _battleData;

    public void Init(Player player, BattleTeamSelector battleData)
    {
        _player = player;
        _battleData = battleData;

        _startFightButton.onClick.AddListener(StartFightEvent);
    }

    public void Boot()
    {
        CreateBoxes();
        CreateSecondTeam();
    }

    private void CreateBoxes()    // Для первой команды
    {
        foreach (var characterPair in _player.CharactersList.Characters)
        {
            Character character = characterPair.Value;

            FightCharacterBox instance = Instantiate(_boxPrefab, _root);
            instance.Init(character, _battleData);
        }
    }

    private void CreateSecondTeam()
    {
        foreach (CharacterData characterData in _secondTeam)
        {
            _battleData.AddCharacterSecondTeam(new(characterData));
        }
    }

    public void StartFightEvent()
    {
        _battleData.BootAll();
    }
}
