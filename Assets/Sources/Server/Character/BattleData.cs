using System.Collections.Generic;
using UnityEngine;

public sealed class BattleData
{
    private List<BattleCharacter> _firstTeam;
    private List<BattleCharacter> _secondTeam;

    public bool FirstTeamLose;
    public bool SecondTeamLose;

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

            if (distance < nearestDistance & character.AliveCheck())
            {
                nearestCharacter = character;
                nearestDistance = distance;
            }
            else if (team.Count >= 1 & character.AliveCheck())
            {
                nearestCharacter = character;
                nearestDistance = distance;
            }
        }

        return nearestCharacter;
    }

    public BattleCharacter GetLineCharacterInFirstTeam(BattleCharacter character, Vector3 worldPosition)
    {
        int index = _secondTeam.IndexOf(character);

        return GetLineCharacter(index, _firstTeam, worldPosition);
    }

    public BattleCharacter GetLineCharacterInSecondTeam(BattleCharacter character, Vector3 worldPosition)
    {
        int index = _firstTeam.IndexOf(character);

        return GetLineCharacter(index, _secondTeam, worldPosition);
    }

    private BattleCharacter GetLineCharacter(int target, List<BattleCharacter> team, Vector3 worldPosition)
    {
        if (team.Count >= target + 1)
        {
           return team[target];
        }

        return GetNearCharacter(worldPosition, team);
    }
    public void FirstTeamLoseCheck()
    {
        bool firstTeamLose = true;
        foreach (BattleCharacter character in _firstTeam)
        {
            if (character.AliveCheck())
            {
                firstTeamLose = false;
            }
        }
        if (firstTeamLose)
        {
            FirstTeamLose = true;
        }
    }

    public void SecondTeamLoseCheck()
    {
        bool secondTeamLose = true;
        foreach (BattleCharacter character in _secondTeam)
        {
            if (character.AliveCheck())
            {
                secondTeamLose = false;
            }
        }
        if (secondTeamLose)
        {
            SecondTeamLose = true;
        }
    }
}
