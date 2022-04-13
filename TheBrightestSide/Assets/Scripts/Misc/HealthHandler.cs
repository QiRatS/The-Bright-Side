using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public int maxHealth = 1;
    private int health;

    // Invincibility Stuff
    private bool isInvincible = false;
    private float? invincibilityLimit;
    private float invincibilityCounter = 0f;

    public int Health { get => health; }

    protected void Start()
    {
        health = maxHealth;
        VariableCheck();
    }

    private void Update()
    {
        if (isInvincible)
        {
            invincibilityCounter += Time.deltaTime;
            if (invincibilityCounter >= invincibilityLimit)
            {
                invincibilityCounter = 0f;
                isInvincible = false;
            }
        }
    }

    // Returns the new value of health
    public virtual int TakeDamage(int damage_)
    {
        if (isInvincible) return health;

        health -= Mathf.Abs(damage_);

        if (health <= 0)
        {
            BroadcastMessage("Death");
        }

        return health;
    }
    public virtual int HealDamage(int amount_)
    {
        if (isInvincible) return health;

        health += Mathf.Abs(amount_);

        return health;
    }

    public void BecomeInvincible()
    {
        isInvincible = true;
        // Maybe do a particle thing or something
    }

    private void VariableCheck()
    {
        if (invincibilityLimit == null) invincibilityLimit = 1f;
    }
}