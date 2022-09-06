using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerMonsters : MonoBehaviour
{
    int SortingLayerNum;

    private void Start()
    {
        SortingLayerNum = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Object"))
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = collision.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Object"))
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = SortingLayerNum;
        }
    }
}
