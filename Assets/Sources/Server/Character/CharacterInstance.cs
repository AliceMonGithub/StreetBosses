﻿using UnityEngine;

namespace Server.CharacterLogic
{
    public sealed class CharacterInstance : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Animator _animator;

        public Transform Transform => _transform;
        public Animator Animator => _animator;
    }
}