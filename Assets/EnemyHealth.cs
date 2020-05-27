using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 2;
    public int currentHealth;
    public int transformInd;

    public Rigidbody2D rb;

    public HealthBar healthBar;
    public GameObject GooPref;
    public Mole AIscript;
    public GameObject spawner;

    public GameObject HP;
    void Start()
    {
        Debug.Log(Quest.isActive);
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
        FindObjectOfType<AudioManager>().Play("MoleHit");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            AIscript.aggressive = true;
            //AIscript.moveSpeed++;
            TakeDamage();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
        if (Shapeshifting.Transformations[transformInd] == false)
            Instantiate(GooPref, rb.position, Quaternion.Euler(Vector3.zero));

        //Spawner.counter--;
        spawner.GetComponent<Spawner>().counter--;

        //Spawner otherScript = GameObject.FindObjectOfType(typeof(Spawner)) as Spawner;
        //otherScript.RestartTimer();
        spawner.GetComponent<Spawner>().RestartTimer();
        if (Quest.isActive)
            QuestGoal.currentAmount++;
    }
}
