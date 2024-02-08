using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float regenHealth = 20f;


    private float maxHealth;

    public void DealDamage(float damageAmount)
    {
        if (health <= 20f )
        {
            health += regenHealth;
            Mathf.Clamp(health, health, maxHealth);
        }

        health -= damageAmount * Time.deltaTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
