using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]List<GameObject> _spawner = new List<GameObject>();

    float  _time;

    int num;
    void Start()
    {
         num = Random.Range(0, _spawner.Count);
        Instantiate(_spawner[num], transform.position, transform.rotation);
    }

    private void Update()
    {
       _time += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        RoopItems();
    }
    

    void RoopItems()
    {
        if (_time >= 10 )
        {
            var num2 = Random.Range(0, _spawner.Count);
            Instantiate(_spawner[num2],transform.position,transform.rotation);
            _time = 0;
        }
    }   
}
