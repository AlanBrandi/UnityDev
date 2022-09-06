using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushAnimation : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("IsInside", true);
            audioSource.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("IsInside", false);
            audioSource.Stop();
        }
    }
}
