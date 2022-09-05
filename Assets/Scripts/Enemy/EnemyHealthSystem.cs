using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthSystem : MonoBehaviour
{
    EnemyScript Enemy;
    EnemyScriptableObject EnemyObject;
    Material DefaultMaterial;
    GameObject DeathEffect;
    Slider HealthBar;
    Canvas EnemyCanvas;

    private void Start()
    {
        if(Enemy == null)
        {
            Enemy = GetComponent<EnemyScript>();
        }
        EnemyObject = GetComponent<EnemyScript>().EnemyBasics;
        DefaultMaterial = gameObject.GetComponent<SpriteRenderer>().material;
        DeathEffect = EnemyObject.DeathEffect;
        HealthBar = GetComponentInChildren<Transform>().GetComponentInChildren<Transform>().GetComponentInChildren<Slider>();
        EnemyCanvas = GetComponentInChildren<Canvas>();
        EnemyCanvas.enabled = false;
    }

    private void Update()
    {
        HealthBar.value = Enemy.GetLife();
        if (Enemy.GetLife() <= 0)
        {
            Die();
        }
    }
    //-----------------Método-------------------------
    public void Damage(int damage)
    {
        EnemyCanvas.enabled = true;
        Enemy.SetLife(Enemy.GetLife() - damage);
        gameObject.GetComponent<SpriteRenderer>().material = EnemyObject.FlashMaterial;
        Invoke("SetBackMaterial", .25f);
    }

    void SetBackMaterial()
    {
        gameObject.GetComponent<SpriteRenderer>().material = DefaultMaterial;
    }

    public void Die()
    {
        Instantiate(DeathEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    //-----------------Colisão------------------------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponentInParent<HealthSystem>().Damage(Enemy.GetHitDamage());
        }
    }
}
