using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 2;
    public int currentHealth;

    public Rigidbody2D rb;

    public HealthBar healthBar;
    public GameObject GooPref;

    public GameObject HP;
    void Start()
    {

        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == maxHealth)
        {
           // HP.SetActive(false);
        }
        else //HP.SetActive(true);
        if (currentHealth == 0)
        {
            Die();
        }
    }


    void TakeDamage()
    {
        currentHealth--;
        healthBar.setHealth(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            TakeDamage();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
        GameObject goo = Instantiate(GooPref, rb.position, Quaternion.Euler(Vector3.zero));
        goo.GetComponent<GooScript>().TranformIndex = 1;
    }
}
