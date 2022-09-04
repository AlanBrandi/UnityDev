using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float AttackRate = 2f;
    [SerializeField] float NextAttackTime = 0f;

    GameObject PrefabBullet;
    Transform WhereToSpawn;

    AudioSource audioSource;

    private void Start()
    {
        if (PrefabBullet == null)
        {
            PrefabBullet = Resources.Load("Bullet") as GameObject;
        }

        audioSource = GetComponentInChildren<AudioSource>();
        WhereToSpawn = GameObject.Find("ShootPoint").transform;
    }

    private void Update()
    {
        if (Time.time >= NextAttackTime)
        {
            if (Input.GetMouseButton(0))
            {
                audioSource.Play();
                Instantiate(PrefabBullet, WhereToSpawn.position, WhereToSpawn.rotation);
                NextAttackTime = Time.time + 1f / AttackRate;
            }
        }
    }
}
