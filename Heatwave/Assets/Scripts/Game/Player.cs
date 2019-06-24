using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Dictionary<string, Stat> Stats;
   
    public float CurrentHp;
    public int AutoAttackCounter = 0;
    public List<PassiveAbility> PassiveAbilities;

    public static Player Instance;
    public float ResetCounterTime = 2;
    public void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Stats = new Dictionary<string, Stat>();
        Stats.Add("GunDamage", new Stat("GunDamage", 5));
        Stats.Add("TrapDamage", new Stat("TrapDamage", 5));
        Stats.Add("BombDamage", new Stat("BombDamage", 5));
        Stats.Add("MovementSpeed", new Stat("MovementSpeed", 5));
        Stats.Add("MaxHp", new Stat("MaxHp", 100));

        CurrentHp = GetStat("MaxHp").BaseAmount;
        AutoAttackCounter = 0;
        CheckPassives();
}

    public void Attack()
    {
        AutoAttackCounter++;
        if  (AutoAttackCounter > 100)
        {
            AutoAttackCounter = 0;
        }

       
    }
    public void CheckPassives()
    {
        foreach(PassiveAbility p in PassiveAbilities)
        {
            p.CheckAbilityCondition();
        }
        Debug.Log(GetStat("GunDamage").GetAmount());
    }
    public Stat GetStat(string stat)
    {
        if (Stats.ContainsKey(stat) != true) return null;
        return Stats[stat];
    }
   
    
    private void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Attack();
            ResetCounterTime = 2;
        }
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            GetStat("MaxHp").BaseAmount -= 10;
            Debug.Log(GetStat("MaxHp").GetAmount());
        }
       if (AutoAttackCounter != 0)
        {
            ResetCounterTime -= Time.deltaTime;
            if (ResetCounterTime < 0) 
            {
                AutoAttackCounter = 0;
                
            }
        }
       

        foreach (PassiveAbility p in PassiveAbilities)
        {
           
                switch (p.AbilityActive.Option)
                {
                    case Utility.StatOptions.Add:
                        
                        foreach(Modifier m in p.AbilityActive.modifier)
                        {
                            if (p.AbilityCondition.IsActive)
                            {
                                GetStat(p.AbilityActive.PlayerStatKey).AddModifier(m);
                            }
                             else
                            {
                                GetStat(p.AbilityActive.PlayerStatKey).RemoveModifier(m.ID);
                            }
                         }
                     
                        break;
                case Utility.StatOptions.Remove:
                    foreach (Modifier m in p.AbilityActive.modifier)
                    {
                        if (p.AbilityCondition.IsActive)
                        {
                            GetStat(p.AbilityActive.PlayerStatKey).RemoveModifier(m.ID);
                        }
                        else
                        {
                            GetStat(p.AbilityActive.PlayerStatKey).AddModifier(m);
                        }
                    }
                    break;
            }

            CheckPassives();

            
        }
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * GetStat("MovementSpeed").GetAmount() * Time.deltaTime;

        this.transform.position += tempVect;
    }
}
