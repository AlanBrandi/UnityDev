using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float InitialSpeed;
    AudioSource FireballSound;
    float Speed;
    [SerializeField] Vector3 foward;
    Rigidbody2D RbBullet;

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

    public void SetSpeed(float speed)
    {
        Speed = speed;
    }
    public float GetSpeed()
    {
        return Speed;
    }

    //-------------------Métodos----------------------

    private void Destroy()
    {
        Destroy(gameObject);
    }
    //Hit Enemy
    //AddForce
    //FX
    //Audio
    //Dano
}
