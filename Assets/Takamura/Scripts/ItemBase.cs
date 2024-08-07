using System.Collections;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField] AudioClip _audioClip;

    Item.ItemType _type;

    public abstract void Activate();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("ƒAƒCƒeƒ€Žæ“¾");
            if (_audioClip != null)
            {
                AudioSource.PlayClipAtPoint(_audioClip, transform.position);
            }

            Activate();

            collision.gameObject.GetComponent<Player>().CollectItem(_type);
            Destroy(gameObject);
        }
    }
}
