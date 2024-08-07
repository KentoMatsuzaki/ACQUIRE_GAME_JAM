using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Origami : MonoBehaviour
{
    Item.ItemType type;

    void Start()
    {
        type = Item.ItemType.Origami;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().CollectItem(type);
            Destroy(gameObject);
        }
    }
}
