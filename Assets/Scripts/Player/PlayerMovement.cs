using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Váriaveis
    [SerializeField] float Speed;
   
    Rigidbody2D MyRb;
    Vector2 Movement;

    private void Awake()
    {
        if(MyRb == null)
        {
            MyRb = GetComponent<Rigidbody2D>();
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
    }

    private void FixedUpdate()
    {
      MyRb.velocity = Movement * Speed * Time.fixedDeltaTime;
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
