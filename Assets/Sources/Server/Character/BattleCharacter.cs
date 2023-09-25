using Server.BusinessLogic;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Enemy : MonoBehaviour //Просто что бы скомпелировалось
{
    public bool enemyAlive;  //Условная переменная пока нет механики енеми(Вопрос: при смерти они дестроятся, или просто лежат на сцене?)
}
public class BattleCharacter : MonoBehaviour
{
    private float _attackCooldown;
    private float _attackRange;

    private List<Enemy> _enemies; //Список будем  получать  в фабрике и передават его в Boot

    private float _movementSmooth;
    private float _maxSpeed;
    private float _waitTime;

    private CharacterInstance _instance;

    public void Init(CharacterInstance instance, float _movementSmooth, float maxSpeed)
    {

    }
    public void Boot(List<Enemy> enemies)
    {
        _enemies = enemies;
        SearchingEnemy();
    }
    private void SearchingEnemy()
    {
        float distance = 1000;
        Enemy target = null;
        if(_enemies != null)
        {
            foreach (var enemy in _enemies)
            {
                float newDistance = (this.transform.position - enemy.transform.position).sqrMagnitude;
                ;
                if (distance > newDistance)
                {
                    distance = newDistance;
                    target = enemy;
                }
            }
            if (distance <= _attackRange)
            {
                Attack(target);
            }
            else
            {
                Move(target.transform.position);
            }
        }
        else
        {
            Idle();
        }
    }
    private IEnumerator Attack(Enemy enemy)
    {
        // Тут логика атаки

        if (enemy.enemyAlive)
        {
            yield return new WaitForSeconds(_attackCooldown);
            StartCoroutine(Attack(enemy));
        }
        else
        {
            SearchingEnemy();
        }
    }
    private void Move(Vector3 targetPoint)
    {
        transform.position = Vector3.SmoothDamp(transform.position, 
            (transform.position.x - (targetPoint.x + _attackRange), targetPoint.y, transform.position.z),);
        SearchingEnemy();
    }
    public void TakeDamage()
    {

    }
    private void Idle()
    {

    }
}
