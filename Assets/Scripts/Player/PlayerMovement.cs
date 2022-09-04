using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Váriaveis
    [SerializeField] float Speed;
   
    Vector2 Movement;

    Rigidbody2D MyRb;
    Animator MyAnimator;

    private void Awake()
    {
        if(MyRb == null)
        {
            MyRb = GetComponentInChildren<Rigidbody2D>();
        }
        if (MyAnimator == null)
        {
            MyAnimator = GetComponentInChildren<Animator>();
        }
    }

    private void Start()
    {
        SetSpeed(350);
    }
    private void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
        MyAnimator.SetFloat("Speed", MyRb.velocity.magnitude);
    }

    private void FixedUpdate()
    {
       MyRb.velocity = Movement * Speed * Time.fixedDeltaTime;

        if (Movement.x > 0)
        {
            MyRb.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Movement.x < 0)
        {
            MyRb.gameObject.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
    }

    //Métodos
    public void SetSpeed(float speed)
    {
       Speed = speed;
    }
    public float GetSpeed()
    {
        return Speed;
    }
}
