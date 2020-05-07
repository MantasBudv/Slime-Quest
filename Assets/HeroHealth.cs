using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHealth : MonoBehaviour
{
    static public int maxHealth = 5;
    static public int currentHealth;
    static public float regenerationTime = 3f;
    public GameObject OverText;
    public GameObject RestartButton;

    public Rigidbody2D rb;

    public float KnockDur;
    public float KnockPwr;

    public HealthBar healthBar;

    public GameObject HP;
    void Start()
    {
        Time.timeScale = 1f;
        PlayerMovement.frozen = false;
        OverText.SetActive(false);
        RestartButton.SetActive(false);

        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

        InvokeRepeating("Regenerate", regenerationTime, regenerationTime);
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
        if (currentHealth == 0)
        {
            GameOver();
        }
    }

    void UpdateEverySecond()
    {

    }

    public void TakeDamage()
    {
        setHealth(--currentHealth);
    }

    void Regenerate()
    {
        if (currentHealth != maxHealth)
        {
            setHealth(++currentHealth);
        }
    }

    void setHealth(int hp)
    {
        healthBar.setHealth(hp);
        currentHealth = hp;
    }

    void GameOver()
    {
        OverText.SetActive(true);
        RestartButton.SetActive(true);
        Time.timeScale = 0f;
        PlayerMovement.frozen = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            TakeDamage();
            StartCoroutine(Knockback(KnockDur, KnockPwr,  rb.transform.position - collision.transform.position ));
        }
    }


    public IEnumerator Knockback(float duration, float power, Vector2 direction)
    {
        float timer = 0;

        while (duration > timer)
        {
            timer += Time.deltaTime;
            rb.AddForce(direction.normalized * power, ForceMode2D.Force);

        }

        yield return 0;
    }

}
