using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    [SerializeField]
    GameObject _cloud;

    [SerializeField]
    GameObject _pos;

    public static CloudManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCloud()
    {
        Instantiate(_cloud, _pos.transform.position, Quaternion.identity);
    }
}
