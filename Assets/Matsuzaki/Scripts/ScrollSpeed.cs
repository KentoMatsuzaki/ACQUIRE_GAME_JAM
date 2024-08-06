using UnityEngine;

public class ScrollSpeed : MonoBehaviour
{
    /// <summary>プロパティ</summary>
    public static ScrollSpeed Instance { get; private set; }

    /// <summary>スクロール速度</summary>
    [SerializeField] private float _speed = 2f;

    public float Speed => _speed;

    /// <summary>スクロールの加速度</summary>
    [SerializeField] private float _acceleration = 0.1f; 

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    void Update()
    {
        _speed += _acceleration * Time.deltaTime;
    }
}
