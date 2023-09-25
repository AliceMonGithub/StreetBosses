using Server.BusinessLogic;
using Server.CharacterLogic;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Enemy : MonoBehaviour //Просто что бы скомпелировалось
{
    public bool enemyAlive;  //Условная переменная пока нет механики енеми(Вопрос: при смерти они дестроятся, или просто лежат на сцене?)
}

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

    // private CharacterInstance _instance;

    //public void Init(CharacterInstance instance, float _movementSmooth, float maxSpeed)
    //{

    //}

    public void Init(Character character, BattleData battleData, bool isFirstTeam)
    {
        _attackDistance = character.AttackDistance;
        _smoothTime = character.SmoothTime;
        _maxSpeed = character.MaxSpeed;

        _battleData = battleData;
        _inFirstTeam = isFirstTeam;

        GoToNearTarget();
    }

    public Vector3 WorldPosition => transform.position;

    public void Boot()//(List<Enemy> enemies)
    {
        GoToNearTarget();

        //_enemies = enemies;
        //SearchingEnemy();
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
        Debug.Log("Puk");

        if(_target != null)
        {
            Debug.Log("asss");

            transform.position = Vector3.SmoothDamp(transform.position, _target.WorldPosition, ref _velosity, _smoothTime, _maxSpeed);
            float distance = Vector3.Distance(transform.position, _target.WorldPosition);

            if(distance <= _attackDistance)
            {
                _target = null;
            }

            //_instance.Transform.position = Vector3.SmoothDamp(_instance.Transform.position, target, ref _velosity, _movementSmooth, _maxSpeed);
        }
    }

    //private IEnumerator Attack(Enemy enemy)
    //{
    //    // Тут логика атаки

    //    if (enemy.enemyAlive)
    //    {
    //        yield return new WaitForSeconds(_attackCooldown);
    //        StartCoroutine(Attack(enemy));
    //    }
    //    else
    //    {
    //        SearchingEnemy();
    //    }
    //}
    //private void Move(Vector3 targetPoint)
    //{
    //    //transform.position = Vector3.SmoothDamp(transform.position, 
    //    //    (transform.position.x - (targetPoint.x + _attackRange), targetPoint.y, transform.position.z), r, _movementSmooth);
    //    SearchingEnemy();
    //}
    //public void TakeDamage()
    //{

    //}
    //private void Idle()
    //{

    //}
}
