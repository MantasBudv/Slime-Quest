﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPref;

    public HeroHealth heroHealth;

    public float bulletForce = 20f;

    float FireRate = 0.3f;
    float NextFire;


    // Update is called once per frame

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!PlayerMovement.frozen)
        {
            if ((Input.GetButtonDown("Fire1")) && (Shapeshifting.CurrentForm == 0) && Time.time > NextFire)
            {
                NextFire = Time.time + FireRate;
                Shoot();
                FindObjectOfType<AudioManager>().Play("BlobAttack");
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPref, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        heroHealth.TakeDamage();
    }
}
