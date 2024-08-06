using UnityEngine;

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

    /// <summary>プレイヤーの状態を表す列挙型</summary>
    private enum PlayerStatus
    {
        None, // 通常
        LowGravity, // 重力が弱い
        HighGravity, // 重力が強い
        Invincible // 無敵
    }


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();

        // 空気抵抗を設定する
        _rb.drag = _drag;

        // 重力を設定する
        _rb.gravityScale = _gravity;
    }

    void Update()
    {
        // ジャンプキーが入力された場合
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // 上方向の速度をリセットする
            _rb.velocity = new Vector2(_rb.velocity.x, 0);

            // プレイヤーの上方に力を加える
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    /// <summary>アイテムを取得した際にその効果を適用するメソッド</summary>
    public void ApplyItemEffect()
    {

    }
}
