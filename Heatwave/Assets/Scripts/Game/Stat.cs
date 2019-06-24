using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Stat : IEquatable<Stat>
{
    public string Name;
    public string Description;
    public float Amount;
    public float BaseAmount;
    
    public List<Modifier> Modifiers;
    
    public Stat(string _name, float _amount)
    {
        ChangeBaseAmount(_amount);
        Name = _name;
        Modifiers = new List<Modifier>();
    }
    public int GetCountOfModifier(Modifier modifier)
    {
        int count = 0;
        foreach (Modifier mod in Modifiers)
        {
            if  (mod.Equals(modifier))
            {
                count++;
            }
        }
        return count;
    }
    public void AddModifier(Modifier modifier)
    {
        if (GetCountOfModifier(modifier) < modifier.MaxStacks)
        {
            
            Modifiers.Add(modifier);
        }
        
    }
    public void RemoveModifier(string id)
    {
        
       foreach (Modifier mod in Modifiers)
        {
             if (mod.ID == id )
            {
                Modifiers.Remove(mod);
                break;
                
            }
        }

    }
    public void RemoveModifierAll(string id)
    {
        Modifiers.RemoveAll(mod => mod.ID == id);
        
    }
    public void ChangeBaseAmount(float baseAmount)
    {
        BaseAmount = baseAmount;
        Amount = BaseAmount;
    }
    public float GetAmount()
    {
        float amt = BaseAmount;
        foreach(Modifier mod in Modifiers)
        {
            
            if (mod.IsPercent)
            {
                amt += BaseAmount * ((float)mod.Amount / 100);
            }
            else
            {
                amt += mod.Amount;
            }
        }
        Amount = amt;
        return amt;
    }
        
    
    public bool Equals(Stat other)
    {
        return (this.Name == other.Name); 
    }


}
