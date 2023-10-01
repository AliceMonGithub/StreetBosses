using Server.CharacterLogic;
using System.Collections;
using UnityEngine;

public sealed class BattleCharacter : MonoBehaviour
{
    private float _attackCooldown;
    private float _attackDistance;

    private float _health;
    private float _damage;

    private CharacterInstance _characterInstance;
    private BattleData _battleData;
    private BattleCharacter _target;
    private bool _inFirstTeam;
    private bool _alive;
    private bool _attacking;
    private float _distance;

    private Vector3 _velosity;

    public void Init(Character character, BattleData battleData, bool isFirstTeam, CharacterInstance instance)
    {
        _characterInstance = instance;
        _attackDistance = character.AttackDistance;
        _alive = true;
        _attacking = false;
        _health = character.Health;
        _damage = character.Damage;
        _attackCooldown = character.AttackCooldown;

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

    private IEnumerator Attack(BattleCharacter target)
    {

       if (!_attacking & target.AliveCheck() & _alive)
       {
            _characterInstance.Animator.SetBool("Attacking", true);
            _attacking = true;
            target.TakeDamage(_damage);
            yield return new WaitForSeconds(_attackCooldown);
            _attacking = false;
       }
       else if(!_attacking & !target.AliveCheck() & _alive)
       {
            _characterInstance.Animator.SetBool("Attacking", false);
            GoToNearTarget();
       }

    }

    private void TakeDamage(float damage)
    {
        _health -= damage;
    }

    public bool AliveCheck()
    {
        return _alive;
    }
    private void Death()
    {
        _characterInstance.Animator.SetTrigger("Death");
        _alive = false;
        if (_inFirstTeam)
        {
            _battleData.FirstTeamLoseCheck();
        }
        else if(!_inFirstTeam)
        {
            _battleData.SecondTeamLoseCheck();
        }
    }

    private void Update()
    {
        if (_health <= 0 && _alive)
        {
            Death();
        }

        if(_target != null)
        {
            _distance = Vector3.Distance(transform.position, _target.WorldPosition);
        }

        if (_target != null & _distance > _attackDistance & _alive)
        {
            _characterInstance.Animator.SetBool("Moving", true);
            transform.position = Vector3.SmoothDamp(transform.position, _target.WorldPosition,
                ref _velosity, CharacterData.SmoothTime, CharacterData.MaxSpeed);

        }
        else if (_target != null & _distance <= _attackDistance & _alive)
        {
            _characterInstance.Animator.SetBool("Moving", false);
           StartCoroutine(Attack(_target));
        }
    }
}
