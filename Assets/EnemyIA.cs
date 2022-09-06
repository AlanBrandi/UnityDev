using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{

    EnemyScriptableObject EnemyObject;

    Transform Target;
    float Speed;
    public float NextWaypointDistance = 3f;

    Path path;
    int CurrentWaypoint = 0;
    bool ReachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D MyRb;
    Animator animator;

    private void Start()
    {
        Target = GameObject.FindWithTag("Player").transform;
        MyRb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        EnemyObject = GetComponent<EnemyScript>().EnemyBasics;
        ConfigureEnemy();
        InvokeRepeating("UpdatePath", 0f, .5f);
        animator = GetComponentInParent<Animator>();
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(MyRb.position, Target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            CurrentWaypoint = 0;
        }
    }

    private void Update()
    {
        animator.SetFloat("Speed", MyRb.velocity.magnitude);
    }
    private void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (CurrentWaypoint >= path.vectorPath.Count)
        {
            ReachedEndOfPath = true;
            return;
        }
        else
        {
            ReachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[CurrentWaypoint] - MyRb.position).normalized;
        Vector2 force = direction * Speed * Time.deltaTime;

        MyRb.AddForce(force);

        float distance = Vector2.Distance(MyRb.position, path.vectorPath[CurrentWaypoint]);

        if (distance < NextWaypointDistance)
        {
            CurrentWaypoint++;
        }
    }

    void ConfigureEnemy()
    {
        Speed = EnemyObject.Speed;
    }
}
