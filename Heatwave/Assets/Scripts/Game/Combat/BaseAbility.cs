using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAbility : ScriptableObject
{
    public string Name;
    public Utility.AbilityTypes AbilityType;
    public int SkillPoints;
    public List<BaseAbility> RequiredAbilities;
}
