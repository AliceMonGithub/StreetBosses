using Server.CharacterLogic;
using UnityEngine;

public sealed class BattleCharacter : MonoBehaviour
{
    private float _attackCooldown;
    private float _attackDistance;

    private float _smoothTime;
    private float _maxSpeed;
    private float _waitTime;
    
    private BattleData _battleData;
    private BattleCharacter _target;
    private bool _inFirstTeam;

    private Vector3 _velosity;

    public void Init(Character character, BattleData battleData, bool isFirstTeam)
    {
        _attackDistance = character.AttackDistance;
        _smoothTime = character.SmoothTime;
        _maxSpeed = character.MaxSpeed;

        _battleData = battleData;
        _inFirstTeam = isFirstTeam;
    }

    public Vector3 WorldPosition => transform.position;

    public void Boot()
    {
        GoToFirstTarger();
    }
    private void GoToFirstTarger()
    {
        _target = GetFirstTarger();
    }

    private BattleCharacter GetFirstTarger()
    {
        if (_inFirstTeam)
        {
            return _battleData.GetLineCharacterInSecondTeam(this, WorldPosition);
        }

        return _battleData.GetLineCharacterInFirstTeam(this, WorldPosition);
    }

    private void GoToNearTarget()
    {
        _target = GetNearTarget();
    }
    
    private BattleCharacter GetNearTarget()
    {
        if(_inFirstTeam)
        {
            return _battleData.GetNearCharacterInSecondTeam(WorldPosition);
        }

        return _battleData.GetNearCharacterInFirstTeam(WorldPosition);
    }

    private void Update()
    {
        if (_target != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, _target.WorldPosition, ref _velosity, _smoothTime, _maxSpeed);
            float distance = Vector3.Distance(transform.position, _target.WorldPosition);

            if(distance <= _attackDistance)
            {
                _target = null;
            }
        }
    }
}
