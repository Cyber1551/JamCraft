using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Ability/New Passive")]
public class PassiveAbility : BaseAbility
{
    
    [System.Serializable]
    public struct AbilityConditionStruct
    {
        public Utility.AbilityConditions Condition;
        public Utility.Operators Operator;
        public string StatType;
        public float Amount;
        public bool IsActive;
    }

    public AbilityConditionStruct AbilityCondition;

    [System.Serializable]
    public struct AbilityActivateStruct
    {
        public string PlayerStatKey;
        public Modifier[] modifier;
        public Utility.StatOptions Option;
    }

    public AbilityActivateStruct AbilityActive;
    private void OnEnable()
    {
        AbilityCondition.IsActive = false;
    }
    public void CheckAbilityCondition()
    {
        if (AbilityCondition.Condition == Utility.AbilityConditions.Always && AbilityCondition.IsActive != true)
        {
            AbilityCondition.IsActive = true;
        }
        else
        {
            float Var1 = 0;
            switch (AbilityCondition.Condition)
            {
                case Utility.AbilityConditions.Stat:
                     Var1 = Player.Instance.GetStat(AbilityCondition.StatType).GetAmount();
                     
                    break;
                case Utility.AbilityConditions.EnemyStat:

                    break;
                case Utility.AbilityConditions.AutoAttackCounter:
                    Var1 = Player.Instance.AutoAttackCounter;
                    break;
            }

            switch (AbilityCondition.Operator)
            {
                case Utility.Operators.E:
                    Debug.Log("E");
                    AbilityCondition.IsActive = (Var1 == AbilityCondition.Amount);

                    break;
                case Utility.Operators.Mod:
                    Debug.Log("Mod");
                    AbilityCondition.IsActive = (Var1 % AbilityCondition.Amount == 0);
                    break;
                case Utility.Operators.GT:
                    Debug.Log("E");
                    AbilityCondition.IsActive = (Var1 > AbilityCondition.Amount);

                    break;
                case Utility.Operators.LT:
                    Debug.Log("Mod");
                    AbilityCondition.IsActive = (Var1 < AbilityCondition.Amount);
                    break;
                case Utility.Operators.GTE:
                    Debug.Log("E");
                    AbilityCondition.IsActive = (Var1 >= AbilityCondition.Amount);

                    break;
                case Utility.Operators.LTE:
                    Debug.Log("Mod");
                    AbilityCondition.IsActive = (Var1 <= AbilityCondition.Amount);
                    break;
                case Utility.Operators.NE:
                    AbilityCondition.IsActive = (Var1 != AbilityCondition.Amount);
                    break;
            }
        }
    }

}
