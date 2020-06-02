using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroHealth : MonoBehaviour
{
    static public int maxHealth = 5;
    static public int currentHealth = maxHealth;
    static public float regenerationTime = 3f;
    public GameObject OverText;
    public GameObject RestartButton;

    public Rigidbody2D rb;

    public float KnockDur;
    public float KnockPwr;
    bool touching = false;
    float DamageRate = 0.5f;
    float NextDamage;

    public HealthBar healthBar;

    private static Scene newScene;

    public GameObject HP;
    void Start()
    {
        Time.timeScale = 1f;
        PlayerMovement.frozen = false;
        OverText.SetActive(false);
        RestartButton.SetActive(false);
        setHealth(currentHealth);

        InvokeRepeating("Regenerate", regenerationTime, regenerationTime);
    }

    // Update is called once per frame
    void Update()
    {
        if ((touching) && (Time.time > NextDamage))
        {
            NextDamage = Time.time + DamageRate;
            TakeDamage();

        }

        if (healthBar.slider.maxValue != maxHealth)
        {
            healthBar.slider.maxValue = maxHealth; // this line doesnt heal to full hp
                                                   //healthBar.setMaxHealth(maxHealth); // this line heals to full hp
        }
        if (!newScene.Equals(SceneManager.GetActiveScene()))
        {
            newScene = SceneManager.GetActiveScene();
            if (currentHealth != maxHealth)
            {
                healthBar.setHealth(currentHealth);
            }
        }
        if (currentHealth == maxHealth)
        {
            if (HP.activeInHierarchy == true)
                HP.SetActive(false);
        }
        else HP.SetActive(true);
        if (currentHealth == 0)
        {
            GameOver();
        }
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
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            //TakeDamage();
            touching = true;
            StartCoroutine(Knockback(KnockDur, KnockPwr,  rb.transform.position - collision.transform.position ));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touching = false;
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
