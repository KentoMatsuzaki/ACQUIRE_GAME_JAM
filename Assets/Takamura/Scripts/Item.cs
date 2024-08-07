using UnityEngine;

public class Item : MonoBehaviour
{
    ItemType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Player>().CollectItem(type);
    }

    public enum ItemType
    {
        Fan, Feather, Crow, Origami
    }
    ItemType itemType;

}
