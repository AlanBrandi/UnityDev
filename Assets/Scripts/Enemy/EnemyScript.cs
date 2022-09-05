using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyScript : MonoBehaviour
{
    [Header("EnemyScriptableObject")]
    public EnemyScriptableObject EnemyBasics;

    //------------EnemyBasics-----------------
    [Header("EnemyBasicsVaribles")]
    [SerializeField]  int Life;
    [SerializeField]  float Speed;
    [SerializeField]  float StoppingDistance;
    [SerializeField]  float RetreatDistance;
    [SerializeField]  int HitDamage;

    Animator EnemyAnimator;

    private void Start()
    {
        ConfigureEnemy();
        EnemyAnimator = GetComponentInParent<Animator>();
        gameObject.tag = "Enemy";
        gameObject.layer = 7;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    private void Update()
    {
        EnemyAnimator.SetFloat("Speed", gameObject.GetComponent<Rigidbody2D>().velocity.magnitude);
    }

    //-----------Encapsulamento-------------------
    public void SetLife(int life)
    {
        Life = life;
    }
    public int GetLife()
    {
        return Life;
    }

    public int GetHitDamage()
    {
        return HitDamage;
    }
    //---------------------------------------------

    void ConfigureEnemy()
    {
        Life = EnemyBasics.Life;
        Speed = EnemyBasics.Speed;
        StoppingDistance = EnemyBasics.StoppingDistance;
        RetreatDistance = EnemyBasics.RetreatDistance;
        HitDamage = EnemyBasics.HitDamage;
    }
}
