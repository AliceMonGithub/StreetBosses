using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FightTargetAbility : Ability
{
    protected abstract void UseOnTarget(BattleCharacter target);
}
