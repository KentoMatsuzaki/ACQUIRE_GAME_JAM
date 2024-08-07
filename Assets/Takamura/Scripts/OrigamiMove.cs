using UnityEngine;

public class OrigamiMove : MonoBehaviour
{
    Rigidbody2D rb;

    float speed = 1;

    OrigamiSpawner _spawner;

    private static bool isQuitting = false; //ÉQÅ[ÉÄÇÃèIóπîªíË
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left * 50 * speed);
        
    }


    void Update()
    {
        if (this.transform.position.x <= -10)
        {
            Destroy(gameObject);
        }

    }
    private void OnApplicationQuit()
    {
        isQuitting = true;
    }
    private void OnDestroy()
    {

    }

}
