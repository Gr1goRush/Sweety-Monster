using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthBehaviour : MonoBehaviour
{
    public event Action<int> OnHealthChange;
    public UnityEvent OnDead;
    public UnityEvent OnTakeDamage;
    [SerializeField, Min(1)] private int _startHealth = 3;
    public int health { get; private set; }

    private void Start()
    {
        RestoreFullHealth();
    }
    public void TakeDamage()
    {
        //Debug.Log("TAKE DAMAGE");
        health--;

        OnHealthChange?.Invoke(health);
        OnTakeDamage?.Invoke();

        if (health <= 0) Death();
    }

    public void Heal()
    {
        if (health + 1 > _startHealth) return;
        health++;

        OnHealthChange?.Invoke(health);
    }

    public void Death()
    {
        OnDead?.Invoke();
        health = _startHealth;
    }

    public void RestoreFullHealth()
    {
        health = _startHealth;
        OnHealthChange?.Invoke(health);
    }
}
