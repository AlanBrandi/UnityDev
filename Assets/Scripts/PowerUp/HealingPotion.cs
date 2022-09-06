using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    public int HealingAmount = 50;
    public GameObject FX;
    AudioSource audioSource;
    SpriteRenderer spriteRenderer;

    HealthSystem PlayerHealthSystem;

    private void Start()
    {
        PlayerHealthSystem = GameObject.FindWithTag("Player").GetComponentInParent<HealthSystem>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(GameManager.Instance.playerLives.Lives < 100)
            {
                audioSource.Play();
                PlayerHealthSystem.Healing(HealingAmount);
                Instantiate(FX, transform.position, Quaternion.identity);
                spriteRenderer.enabled = false;
                Invoke("DestroyObject", 3);
            }
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
