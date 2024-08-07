using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        Suicide();
    }
   void Suicide()
    {
        if (gameObject.transform.position.x <= -14)
        {
            Destroy(gameObject);
        }
    }


}
