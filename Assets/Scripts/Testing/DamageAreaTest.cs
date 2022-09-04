using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAreaTest : MonoBehaviour
{
    public int DamageValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HealthSystem>().Damage(DamageValue);
        }
    }
}
