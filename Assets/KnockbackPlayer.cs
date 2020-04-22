using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackPlayer : MonoBehaviour
{
    public float thrust;
    public Rigidbody2D player;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.isKinematic = false;
            Vector2 difference = player.transform.position - transform.position;
            difference = difference.normalized * thrust;
            player.AddForce(difference, ForceMode2D.Impulse);
            player.isKinematic = true;
        }
    }
}
