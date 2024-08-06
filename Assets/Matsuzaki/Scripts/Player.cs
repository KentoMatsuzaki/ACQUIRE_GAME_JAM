using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/// <summary>プレイヤーの紙飛行機</summary>
public class Player : MonoBehaviour
{
    /// <summary>空気抵抗</summary>
    [SerializeField, Range(0f, 1f)] float _drag = 0.5f;

    /// <summary>重力</summary>
    [SerializeField, Range(0f, 1f)] float _gravity = 0.75f;

    /// <summary>ジャンプ力</summary>
    [SerializeField] float _jumpPower = 7.5f;

    // 剛体
    private Rigidbody2D _rb;

    // スプライト
    private SpriteRenderer _sprite;

    // 各アイテムの効果時間
    private Dictionary<Item.ItemType, float> _itemEffectDurations = new Dictionary<Item.ItemType, float>();

    // 各アイテムの効果フラグ
    private Dictionary<Item.ItemType, bool> _itemEffectFlags = new Dictionary<Item.ItemType, bool>();

    // 現在の重力
    private float _currentGravity;

    // ゲームオーバーのフラグ
    private bool _isGameOver;

    private bool _isDropping;

    // プレイヤーのインスタンス
    public static Player Instance { get; private set; }

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

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();

        // 空気抵抗を設定する
        _rb.drag = _drag;

        // 重力を設定する
        _rb.gravityScale = _gravity;

        _currentGravity = _gravity;

        // 各アイテムの効果時間を初期化
        for(int i = 1; i <= 3; i++)
        {
            _itemEffectDurations[(Item.ItemType)i] = 0f;
            _itemEffectFlags[(Item.ItemType)i] = false;
        }
    }

    void Update()
    {
        if(_isDropping)
        {
            var current = transform.position;
            current.y -= Time.deltaTime * 2f;
            transform.position = current;
        }

        // ゲームオーバーなら処理を抜ける
        if (_isGameOver)
        {
            return;
        }

        // ジャンプキーが入力された場合
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // 上方向の速度をリセットする
            _rb.velocity = new Vector2(_rb.velocity.x, 0);

            // プレイヤーの上方に力を加える
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);

            StartCoroutine(Rotate());
        }

        for (int i = 1; i <= 3; i++)
        {
            if(_itemEffectFlags[(Item.ItemType)i])
            {
                _itemEffectDurations[(Item.ItemType)(i)] -= Time.deltaTime;

                if(_itemEffectDurations[(Item.ItemType)(i)] <= 0f)
                {
                    _itemEffectDurations[(Item.ItemType)(i)] = 0f;
                    _itemEffectFlags[(Item.ItemType)(i)] = false;
                    DeactivateItemEffect((Item.ItemType)(i));
                }
            }
        }
    }

    /// <summary>アイテムを取得した際に呼ばれる処理</summary>
    public void CollectItem(Item.ItemType item)
    {
        // 既にアイテムを取得している場合は効果時間を延長する
        if (_itemEffectFlags[item] == true)
        {
            _itemEffectDurations[item] += 3f;
        }
        // 初めて取得する場合は効果時間を3秒に設定する
        else
        {
            _itemEffectDurations[item] = 3f;
            _itemEffectFlags[item] = true;
            ActivateItemEffect(item);
        }  
    }

    private void ActivateItemEffect(Item.ItemType item)
    {
        switch (item)
        {
            case Item.ItemType.Feather:

                DecreaseGravity(); break;

            case Item.ItemType.Crow:

                IncreaseGravity(); break;

            case Item.ItemType.Origami:

                EnableInvincibility(); break;
        }
    }

    private void DeactivateItemEffect(Item.ItemType item)
    {
        switch (item)
        {
            case Item.ItemType.Feather:

                IncreaseGravity(); break;

            case Item.ItemType.Crow:

                DecreaseGravity(); break;

            case Item.ItemType.Origami:

                DisableInvincibility(); break;
        }
    }

    /// <summary>重力を弱める</summary>
    private void DecreaseGravity()
    {
        float newGravity = _currentGravity / 2;
        _currentGravity = newGravity;
        _rb.gravityScale = newGravity;
    }

    /// <summary>重力を強める</summary>
    private void IncreaseGravity()
    {
        float newGravity = _currentGravity * 2;
        _currentGravity = newGravity;
        _rb.gravityScale = newGravity;
    }

    /// <summary>無敵状態にする</summary>
    private void EnableInvincibility()
    {
        _itemEffectFlags[Item.ItemType.Origami] = true;
    }

    /// <summary>無敵状態を解除する</summary>
    private void DisableInvincibility()
    {
        _itemEffectFlags[Item.ItemType.Origami] = false;
    }

    /// <summary>プレイヤーが無敵状態であるか</summary>
    public bool IsInvincible()
    {
        return _itemEffectFlags[Item.ItemType.Origami];
    }

    /// <summary>プレイヤーを回転させるコルーチン</summary>
    private IEnumerator Rotate()
    {
        transform.rotation = Quaternion.Euler(0, 0, 55f);

        yield return new WaitForSeconds(1f);

        transform.rotation = Quaternion.Euler(0, 0, 15f);
    }

    /// <summary>ゲームオーバー時の処理</summary>
    public void OnGameOver()
    {
        // ゲームオーバーフラグをオン
        _isGameOver = true;

        // 落下しないようにする
        _rb.gravityScale = 0;

        var newPos = transform.position;
        newPos.x += 5f;
        transform.position = new Vector3(newPos.x, newPos.y, newPos.z);

        BackgroundController.Instance.enabled = false;
    }

    public void SetIsDroppingTrue()
    {
        _isDropping = true;
    }
}
