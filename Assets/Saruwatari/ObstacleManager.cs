using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    //public List<TreeChildList> _treeList = new List<TreeChildList>();

    public List<GameObject> _treeList = new List<GameObject>();

    [SerializeField]
    GameObject _pos;

    [SerializeField,Header("player‚Ì–¼‘O")] 
    public string _playerName;

    public bool _isOver;

    public static ObstacleManager Instance;

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
        _isOver = false;

        SpawnObstacles();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpawnObstacles()
    {
        int x = Random.Range(0, _treeList.Count - 1);
        Instantiate(_treeList[x], _pos.transform.position, Quaternion.identity);
    }

}
