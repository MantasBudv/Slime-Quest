using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 500f;
    public float nextWaypointDistance = 3f;
    public Animator animator;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    bool aggresive = false;

    Seeker seeker;
    Rigidbody2D rb;

    public Transform waypoint1;
    public Transform waypoint2;



    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
 
        InvokeRepeating("UpdatePath", 0f, .5f);

        
    }


    void UpdatePath()
    {
        if ((seeker.IsDone()) && (aggresive)) 
        seeker.StartPath(rb.position, target.position, OnPathComplete);

        if (((seeker.IsDone()) && (!aggresive)) && (rb.transform.position.x >= waypoint1.transform.position.x))
            seeker.StartPath(rb.position, waypoint2.position, OnPathComplete);

        if (((seeker.IsDone()) && (!aggresive)) && (rb.transform.position.x <= waypoint2.transform.position.x))
            seeker.StartPath(rb.position, waypoint1.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            aggresive = true;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }


        if (force.x != 0 || force.y != 0)
        {
            animator.SetFloat("Horizontal", rb.velocity.x);
            animator.SetFloat("Vertical", rb.velocity.y);
        }


    }
}
