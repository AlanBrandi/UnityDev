using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayer : MonoBehaviour
{
    int PlayerSortingLayerNum;
    int BengalaSortingLayerNum;
    GameObject Bengala;

    private void Start()
    {
        PlayerSortingLayerNum = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        Bengala = GameObject.Find("bengala_lava");
        BengalaSortingLayerNum = Bengala.GetComponent<SpriteRenderer>().sortingOrder;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Object"))
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = collision.GetComponent<SpriteRenderer>().sortingOrder - 2;
            Bengala.GetComponent<SpriteRenderer>().sortingOrder = collision.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Object"))
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = PlayerSortingLayerNum;
            Bengala.GetComponent<SpriteRenderer>().sortingOrder = BengalaSortingLayerNum;
        }
    }
}
