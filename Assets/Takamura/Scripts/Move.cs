using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField]Rigidbody2D m_Rigidbody2;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2.AddForce(Vector2.left * 50 );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
