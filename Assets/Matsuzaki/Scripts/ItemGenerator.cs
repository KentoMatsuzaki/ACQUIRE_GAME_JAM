using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _itemGroupList = new List<GameObject>();

    private static ItemGenerator _instance;
    public static ItemGenerator Instance => _instance;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        GenerateItemGroup();
    }

    public void GenerateItemGroup()
    {
        Instantiate(_itemGroupList[GetRandomIndex()], transform.position, Quaternion.identity, transform);
    }

    private int GetRandomIndex()
    {
        return Random.Range(0, _itemGroupList.Count);
    }
}
