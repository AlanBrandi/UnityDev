using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float SpawnRate = 2f;
    public int MaxEnemy;
    
    float randX;
    float randY;
    float NextSpawn;
    Vector2 WhereToSpawn;
    Transform where;

    float ScaleX;
    float ScaleY;
    [SerializeField] int EnemyCount = 0;
    private void Start()
    {
        where = gameObject.transform;
        ScaleX = transform.localScale.x;
        ScaleY = transform.localScale.y;
    }
    private void Update()
    {
        if (Time.time > NextSpawn && EnemyCount < MaxEnemy)
        {
            NextSpawn = Time.time + SpawnRate;
            randX = Random.Range(-0.5f, (ScaleX - 4));
            randY = Random.Range(-2, (ScaleY - 4));
            WhereToSpawn = new Vector2((where.position.x + randX), (where.position.y + randY));
            Instantiate(Enemy, WhereToSpawn, Quaternion.identity);
            EnemyCount++;
        }
        if(EnemyCount == MaxEnemy)
        {
            //Destroy(gameObject);
        }
    }
}
