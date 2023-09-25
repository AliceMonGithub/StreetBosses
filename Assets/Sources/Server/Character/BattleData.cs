﻿using System.Collections.Generic;
using UnityEngine;

public sealed class BattleData
{
    private List<BattleCharacter> _firstTeam;
    private List<BattleCharacter> _secondTeam;

    public BattleData(List<BattleCharacter> firstTeam, List<BattleCharacter> secondTeam)
    {
        _firstTeam = firstTeam;
        _secondTeam = secondTeam;
    }

    public BattleCharacter GetNearCharacterInFirstTeam(Vector3 target)
    {
        return GetNearCharacter(target, _firstTeam);
    }

    public BattleCharacter GetNearCharacterInSecondTeam(Vector3 target)
    {
        return GetNearCharacter(target, _secondTeam);
    }

    private BattleCharacter GetNearCharacter(Vector3 target, List<BattleCharacter> team)
    {
        BattleCharacter nearestCharacter = team[0];
        float nearestDistance = Vector3.Distance(nearestCharacter.WorldPosition, target);

        foreach (BattleCharacter character in team)
        {
            float distance = Vector3.Distance(character.WorldPosition, target);

            if (distance < nearestDistance)
            {
                nearestCharacter = character;
                nearestDistance = distance;
            }
        }

        return nearestCharacter;
    }
}
