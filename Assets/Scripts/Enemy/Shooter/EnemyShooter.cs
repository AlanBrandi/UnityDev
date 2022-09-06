using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    EnemyScriptableObject EnemyObject;

    //------------EnemyBasics-----------------
    [Header("EnemyBasicsVaribles")]

   [SerializeField] float Speed;
   [SerializeField] float StoppingDistance;
   [SerializeField] float RetreatDistance;
    //---------------ShootVariable-------------------------
    [Header("EnemyBasicsVaribles")]

    AudioSource EnemyAudio;
    public float StartTimeBtwShots = 1;
    float TimeBtwShots;
    GameObject Projectile;
    bool CanShoot = false;
    //-----------------------------------------

    Rigidbody2D MyRb;
    Transform Player;
    Animator EnemyAnimator;
    
    private void Start()
    {
        EnemyObject = GetComponent<EnemyScript>().EnemyBasics;
        EnemyAnimator = GetComponentInParent<Animator>();
        Projectile = EnemyObject.Projectile;
        CanShoot = false;
        EnemyAudio = GetComponentInChildren<AudioSource>();
        TimeBtwShots = StartTimeBtwShots;
        MyRb = GetComponent<Rigidbody2D>();
        ConfigureEnemy();
    }
    private void Update()
    {
        Player = GameObject.Find("Player").transform;

        var directionToPlayer = Player.transform.position - transform.position;
        var projectionOnRight = Vector3.Dot(directionToPlayer, transform.right);
        directionToPlayer.Normalize();

        Vector3 dir = (Player.position - gameObject.transform.position).normalized;

        if (projectionOnRight > 0)
        { 
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (projectionOnRight < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        //----------------------------------------------------------

        if (Vector2.Distance(transform.position, Player.position) > StoppingDistance && Vector2.Distance(transform.position, Player.position) < 20)
        {
            MyRb.velocity = directionToPlayer * Speed * Time.fixedDeltaTime;
            EnemyAnimator.SetBool("IsWalking", true);
        }
        else if(Vector2.Distance(transform.position, Player.position) < StoppingDistance && Vector2.Distance(transform.position, Player.position) > RetreatDistance)
        {
            transform.position = this.transform.position;
            CanShoot = true;
            EnemyAnimator.SetBool("IsWalking", false);
        }
        else if (Vector2.Distance(transform.position, Player.position) < RetreatDistance)
        {
            MyRb.velocity = directionToPlayer * -Speed * Time.fixedDeltaTime;
            EnemyAnimator.SetBool("IsWalking", true);
        }
        else
        {
            transform.position = this.transform.position;
            EnemyAnimator.SetBool("IsWalking", false);
        }

        if(CanShoot == true)
        {
            if (TimeBtwShots <= 0)
            {
                EnemyAudio.Play();
                Instantiate(Projectile, transform.position, Quaternion.identity);
                TimeBtwShots = StartTimeBtwShots;
            }
            else
            {
                TimeBtwShots -= Time.deltaTime;
            }
        }
    }

    //-------------------------Método---------------------------------
    void ConfigureEnemy()
    {
        Speed = EnemyObject.Speed;
        StoppingDistance = EnemyObject.StoppingDistance;
        RetreatDistance = EnemyObject.RetreatDistance;
    }
}
