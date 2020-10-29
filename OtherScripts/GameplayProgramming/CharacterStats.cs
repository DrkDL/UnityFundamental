using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // region allows to fold the codes within the region for easy navigating
    #region Singleton
    public static CharacterStats instance; // static means it cannot be changed

    void Awake() // called when script is loaded
    {
        instance = this;
    }
    #endregion

    public int maxHealth = 100;
    public int currentHealth { get; private set; } // allow other scripts to get this variable but cannot set it (only the current script can)

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage) // allow other scripts to call this method too by setting it public
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void ModifyHealth(int healthModifier)
    {
        currentHealth += healthModifier;
        print(currentHealth);
    }

    public void Death()
    {
        print("You are dead.");
    }
}
