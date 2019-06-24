using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility 
{
    public enum AbilityTypes
    {
       Stat, //Permantent passive stat
       ActiveStat, //Temporary stat
       Active, //Active abiltity like shield,
       CustomPassive, //Like every 5 auto attacks deal 10 bonus damage
    }
    public enum AbilityConditions
    {
        Always,
        Stat, 
        EnemyStat,
        AutoAttackCounter
    }
    public enum Operators
    {
       GT,
       LT,
       GTE,
       LTE,
       E,
       NE,
       Mod
    }
    public enum StatOptions
    {
        Add,
        Remove
    }




}
