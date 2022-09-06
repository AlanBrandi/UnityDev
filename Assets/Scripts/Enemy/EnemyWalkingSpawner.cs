using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkingSpawner : MonoBehaviour
{
    public float MinDistance;
    public GameObject EnemyPrefab;
    public GameObject Effect;

    float Distance;
    Transform Player;

    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Distance = Vector2.Distance(transform.position, Player.position);

        if(Distance <= MinDistance)
        {
            Ativar();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Ativar();
        }
    }

    //------------------------Métodos----------------------
    void Ativar()
    {
        Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        Instantiate(Effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
