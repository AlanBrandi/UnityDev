using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    GameObject Player;


    private void Awake()
    {
        Player = GetComponentInParent<Rigidbody2D>().gameObject;
    }

    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        if (rotationZ < -90 || rotationZ > 90)
        {
            if (Player.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
            }
            else if (Player.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }
        }
        if (Player.GetComponent<Rigidbody2D>().velocity.magnitude == 0)
        {
            if (difference.x > 0)
            {
                Player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (difference.x < 0)
            {
                Player.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
        }
    }

}
