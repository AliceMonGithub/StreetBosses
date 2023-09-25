using System.Collections.Generic;
using UnityEngine;

namespace Server.PlayerLogicTest
{
    /// <summary>
    /// Player Runtime ������� ��������� �����. �� ���������� � Player Runtime � ������� ��� ����� ����� ������
    /// � ����� ������� ������ ��������� � battleInstance.
    /// 
    /// �� ����� ��������� ������ � ������� ������������ MonoBehaviour ������.
    /// ������� ����� ��������� BattleCharacter � ���������� � ���� ��������� ������ � ����� Character.
    /// 
    /// 
    /// </summary>
    /// 

    //*� ��� ���� ������� ��� �������� ��������(��������� )

    /*
    ����������� ����� ���������� � ���� ������� � ������� ������

    ����� ����� � Player Runtime ��������� ��������� CharacterBattle

    � � ��� ������������ �� ��� ��� ��������� CharacterInstance
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
            // ������ �������� � ��������� walk �� ���������.
        }
    }

    internal sealed class PatrolCharacter : MonoBehaviour
    {
        /*
        ���� ��� ��� ���� ������� ������������ �������� ��������� � ������������ �������
        */

        private readonly CharacterInstance _instance;

        public PatrolCharacter(CharacterInstance instance)
        {
            //.. ��������� ������
        }

        // � ��� ������ ������� ���� ��������� ����� ���� �����
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
            //... ��������� ������
        }

        public void Tick(float deltaTime)
        {
            //.. ������ ������
        }

        //.. ��� ������ ������
    }
}
