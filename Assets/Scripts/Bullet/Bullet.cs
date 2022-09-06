using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float InitialSpeed;
    public int DamageHit = 20;
    float Speed;

    Rigidbody2D RbBullet;
    AudioSource FireballSound;

    private void Start()
    {
        FireballSound = GetComponent<AudioSource>();
        FireballSound.Play();
        SetSpeed(InitialSpeed);
        RbBullet = GetComponent<Rigidbody2D>();
        Invoke("Destroy", 6);
        //Sound Effect
    }
    private void FixedUpdate()
    {
        RbBullet.velocity = transform.right * Speed;
    }
    //-------------------Encapsulamento----------------
    public void SetSpeed(float speed)
    {
        Speed = speed;
    }
    public float GetSpeed()
    {
        return Speed;
    }
    //-------------------------------------------------


    private void OnTriggerEnter2D(Collider2D collision)
    {
       string HitTag = collision.tag;

        switch (HitTag)
        {
            case "Enemy":
                collision.GetComponent<EnemyHealthSystem>().Damage(DamageHit);
                Destroy(gameObject);
                break;
            case "Wall":
                //efeito
                //som
                break;
        }
    }


    //-------------------Métodos----------------------

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
