using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health Potion", menuName = "Inventory/Potion")]
public class HealthPotion : Item // this script will inherit the Item script
{
    public int healthModifier;
    //CharacterStats charStats;

    void Start()
    {
        //charStats = CharacterStats.instance; // .instance is obtained from the CharacterStats script (region)
    }

    public override void Use()
    {
        base.Use(); // automatically typed cuz its also calling the Use method from the base script
        ApplyEffect();
    }

    public void ApplyEffect()
    {
        //charStats.ModifyHealth(healthModifier);
        CharacterStats.instance.ModifyHealth(healthModifier); // this is correct
    }
}

// the commentted lines of code above is the incorrect method of getting/modifying the characterstat instance.