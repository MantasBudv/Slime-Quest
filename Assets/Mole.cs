using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Animator animator;
    bool chasing = false;
    public bool aggressive = false;
    public float moveSpeed;

    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        animator.SetBool("Moving", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
        if (animator.GetBool("Moving")) 
        {
            if (chasing)
            {
                animator.SetFloat("Horizontal", target.transform.position.x - transform.position.x);
                animator.SetFloat("Vertical", target.transform.position.y - transform.position.y);
            }
            else
            {
                animator.SetFloat("Horizontal", currentGoal.position.x - transform.position.x);
                animator.SetFloat("Vertical", currentGoal.position.y - transform.position.y);
            }
            
        }
    }

    void CheckDistance()
    {
        if ((Vector3.Distance(target.position, transform.position) <= chaseRadius) || (aggressive)
            /*&& (Vector3.Distance(target.position, transform.position) > attackRadius)*/)
        {
            Vector2 temp = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            rb.MovePosition(temp);

            chasing = true;

        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            chasing = false;
            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                Vector2 temp = Vector2.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);
                rb.MovePosition(temp);
            }
            else ChangeGoal();
        }

    }

    void ChangeGoal()
    {
        if (currentPoint == path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}
