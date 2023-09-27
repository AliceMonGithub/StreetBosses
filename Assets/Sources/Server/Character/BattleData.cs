using System.Collections.Generic;
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

    public BattleCharacter GetLineCharacterInFirstTeam(int target, Vector3 worldPosition)
    {
        return GetLineCharacter(target, _firstTeam, worldPosition);
    }

    public BattleCharacter GetLineCharacterInSecondTeam(int target, Vector3 worldPosition)
    {
        return GetLineCharacter(target, _secondTeam, worldPosition);
    }

    private BattleCharacter GetLineCharacter(int target, List<BattleCharacter> team, Vector3 worldPosition)
    {
        BattleCharacter lineCharacter = null;
        if (team.Count >= target + 1)
        {
           lineCharacter = team[target];
           return lineCharacter;
        }        
        lineCharacter = GetNearCharacter(worldPosition, team);
        return lineCharacter;
    }
}
