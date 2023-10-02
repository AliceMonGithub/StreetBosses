using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected float _cooldown;

    [HideInInspector] public bool _inFirstTeam;

    protected bool _reload;
    protected bool _active;
    public string _name;
    public Image _icon;

    public bool Active => _active;

    public abstract void UseAbility();
    protected abstract IEnumerator Reload();
    
}
