using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public float regenerationTime = 30f;

    public HealthBar healthBar;

    public GameObject HP;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

        InvokeRepeating("Regenerate", 30.0f, 30.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
        }
        if (currentHealth == maxHealth)
        {
            HP.SetActive(false);
        }
        else HP.SetActive(true);
    }

    void UpdateEverySecond()
    {

    }

    void TakeDamage()
    {
        currentHealth--;
        healthBar.setHealth(currentHealth);
    }

    void Regenerate()
    {
        if (currentHealth != maxHealth)
        {
            currentHealth++;
            healthBar.setHealth(currentHealth);
        }
    }
}
