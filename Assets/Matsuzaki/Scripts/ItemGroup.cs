using UnityEngine;

public class ItemGroup : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector2.left * ScrollSpeed.Instance.Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            ItemGenerator.Instance.GenerateItemGroup();
            Destroy(gameObject);
        }
    }
}
