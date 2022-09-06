using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    int Damage = 20;
    float Speed = 650;
    Transform Player;
    Vector2 Target;
    Rigidbody2D MyRb;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        MyRb = GetComponent<Rigidbody2D>();
        Target = Player.position - transform.position;
    }

    private void Update()
    {
        MyRb.velocity = Target * Speed * Time.deltaTime;
        Invoke("DestroyProjectile", 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponentInParent<HealthSystem>().Damage(Damage);
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
