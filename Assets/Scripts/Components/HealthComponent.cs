using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour 
{
    [SerializeField] [Header("How much health this object has?")] private int health;
    private bool isInvincible;
    [SerializeField] [Header("Can this entity be invincible?")] private bool canBeInvincible;
    public event EventHandler OnDeath;

    public int Health
    {
        get => health;
        set => health = value;
    }

    private void Start()
    {
          
    }

    public void AddHealth(int value)
    {
        if (value > 0) // If healing
            Health += value;
        else if (value < 0) // If getting damaged
            if (isInvincible)
                return;
            else // If object CAN be damaged
            {
                Health += value;
            }
        if (Health < 0) // If object's Health runs out
        {
            OnDeath?.Invoke(this, EventArgs.Empty);
            return;
        }
        else if (value < 0 && canBeInvincible)
        {
            isInvincible = true;
            StartCoroutine(SetInvincibility(false, 3f));
        }
    }

    public IEnumerator SetInvincibility(bool state, float time)
    {
        yield return new WaitForSeconds(time);
        isInvincible = state;
    }
}
