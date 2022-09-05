using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalking : MonoBehaviour
{
    EnemyScriptableObject EnemyObject;

    //------------EnemyBasics-----------------
    [Header("EnemyBasicsVaribles")]

   [SerializeField] float Speed;
   [SerializeField] float StoppingDistance;
   [SerializeField] float RetreatDistance;
    //----------------------------------------

    Transform Player;
    Animator EnemyAnimator;

    
    private void Start()
    {
        EnemyObject = GetComponent<EnemyScript>().EnemyBasics;
        EnemyAnimator = GetComponentInParent<Animator>();
        ConfigureEnemy();
    }
    private void Update()
    {
        Player = GameObject.Find("Player").transform;

        if (Vector2.Distance(transform.position, Player.position) > StoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
            EnemyAnimator.SetBool("IsWalking", true);
        }
        else if (Vector2.Distance(transform.position, Player.position) < StoppingDistance && Vector2.Distance(transform.position, Player.position) > RetreatDistance)
        {
            transform.position = this.transform.position;
            EnemyAnimator.SetBool("IsWalking", false);
        }
        else
        {
            transform.position = this.transform.position;
            EnemyAnimator.SetBool("IsWalking", false);
        }
    }

    //-------------------------Método---------------------------------
    
    void ConfigureEnemy()
    {
        Speed = EnemyObject.Speed;
        StoppingDistance = EnemyObject.StoppingDistance;
        RetreatDistance = EnemyObject.RetreatDistance;
    }

    //-------------------Colisão-------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<EnemyHealthSystem>().Die();
        }
    }
}
