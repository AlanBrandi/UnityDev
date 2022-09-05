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
    [SerializeField]  int HitDamage;

    

    private void Start()
    {
        ConfigureEnemy();
        gameObject.tag = "Enemy";
        gameObject.layer = 7;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
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
        HitDamage = EnemyBasics.HitDamage;
    }
}
