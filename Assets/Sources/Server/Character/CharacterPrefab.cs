using System.Collections.Generic;
using UnityEngine;

namespace Server.PlayerLogicTest
{
    /// <summary>
    /// Player Runtime указана атакуемая улица. Мы обращаемся к Player Runtime и говорим что игрок нажал кнопку
    /// и нужно создать префаб персонажа и battleInstance.
    /// 
    /// На сцене создается префаб с помощью специальньго MonoBehaviour класса.
    /// Создает новый экземпляр BattleCharacter и запихивает в него созданный префаб и класс Character.
    /// 
    /// 
    /// </summary>
    /// 

    //*У нас есть фабрика для создания префабом(инстансов )

    /*
    специальный класс обращается к этом фабрике и создает префаб

    после этого в Player Runtime создается экземпляр CharacterBattle

    и в его конструкторе мы как раз назначаем CharacterInstance
        */

    internal sealed class PlayerRuntimeController : MonoBehaviour
    {
        
       // PlayerRuntime.Tick(Time.deltaTime);
    }

    internal sealed class PlayerRuntime
    {
        List<PatrolCharacter> _patrolsInstancies;
        List<CharacterBattle> _battleInstancies;

        public PlayerRuntime()
        {
            _patrolsInstancies = new();
            _battleInstancies = new();
        }

        public void Tick(float delta)
        {
            //_battleInstancies.Foreach(_ => _.Tick());
        }
    }

    internal sealed class PlayerCharactersGate : Player
    {
        public void AddCharacter(Character character)
        {
            _characters.Add(character);
        }
    }

    internal class Player
    {
        protected List<Character> _characters;

        public Player()
        {
            _characters = new();
        }

        public IReadOnlyList<Character> Characters => _characters;
    }

    internal sealed class CharacterInstance : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Animator _animator;

        private void SetWalkParameter(bool walk)
        {
            // Меняем параметр в аниматоре walk на указанный.
        }
    }

    internal sealed class PatrolCharacter : MonoBehaviour
    {
        /*
        Прям тут все поля которые ограничивают движения персонажа в определенной области
        */

        private readonly CharacterInstance _instance;

        public PatrolCharacter(CharacterInstance instance)
        {
            //.. указываем префаб
        }

        // А тут методы которые ищут случайную точку куда пойти
    }

    // Database
    internal sealed class Character
    {
        private readonly int _health;
        private readonly int _damage;

        public int Health => _health;
        public int Damage => _damage;
    }

    internal sealed class CharacterBattle
    {
        private readonly CharacterInstance _instance;

        public CharacterBattle(CharacterInstance instance)
        {
            //... указываем префаб
        }

        public void Tick(float deltaTime)
        {
            //.. Логика боевки
        }

        //.. Вся логика боевки
    }
}
