using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public Stat Attack;
    public Stat MagicPower;
    public Stat MaxHp;
    public float CurrentHp;
    // Start is called before the first frame update
    void Start()
    {
        Attack = new Stat("Attack", 5);
        MagicPower = new Stat("Magic Power", 0);
        MaxHp = new Stat("MaxHp", 100);
        CurrentHp = MaxHp.BaseAmount;
        
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Attack.AddModifier(new Modifier("sf1", "self", 10, false, 1));
            Debug.Log("Added self Modifier 10 Attack");
            Debug.Log(Attack.GetAmount());
        } 
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Attack.AddModifier(new Modifier("sp1", "self", 25, true, 3));
            Debug.Log("Added self Modifier 25% Attack");
            Debug.Log(Attack.GetAmount());
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            Attack.RemoveModifier("sf1");
            Debug.Log("Removed self Modifier 10 Attack");
            Debug.Log(Attack.GetAmount());
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            Attack.RemoveModifier("sp1");
            Debug.Log("Removed self Modifier 25% Attack");
            Debug.Log(Attack.GetAmount());
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            Attack.RemoveModifierAll("sp1");
            Debug.Log("Removed All self Modifier 25% Attack");
            Debug.Log(Attack.GetAmount());
        }
    }
}
