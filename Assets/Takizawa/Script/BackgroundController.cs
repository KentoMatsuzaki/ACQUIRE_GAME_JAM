using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 背景をスクロールするためのコンポーネント。
/// 適当なオブジェクトにアタッチして使う。
/// 背景を指定すると、それをもう一つ複製する。元と複製したものを下にスクロールし、画面下に消えると上から出てくるようになる。
/// 従って、背景画像は上下に繋げてもよいものでなくてはならない。
/// </summary>
public class BackgroundController : MonoBehaviour
{
    /// <summary>背景</summary>
    [SerializeField] SpriteRenderer m_backgroundSprite = null;

    /// <summary>背景をクローンしたものを入れておく変数</summary>
    SpriteRenderer m_backgroundSpriteClone;

    /// <summary>背景座標の初期値</summary>
    float m_initialPositionX;

    private static BackgroundController _instance;
    public static BackgroundController Instance => _instance;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        m_initialPositionX = m_backgroundSprite.transform.position.x;   // 座標の初期値を保存しておく

        // 背景画像を複製して上に並べる
        m_backgroundSpriteClone = Instantiate(m_backgroundSprite);
        m_backgroundSpriteClone.transform.Translate(m_backgroundSprite.bounds.size.x, 0f, 0f);
    }

    void Update()
    {
        // 背景画像をスクロールする
        m_backgroundSprite.transform.Translate(-ScrollSpeed.Instance.Speed * Time.deltaTime, 0f, 0f);
        m_backgroundSpriteClone.transform.Translate(-ScrollSpeed.Instance.Speed * Time.deltaTime, 0f, 0f);

        // 背景画像がある程度左に行ったら、右に戻す
        if (m_backgroundSprite.transform.position.x < m_initialPositionX - m_backgroundSprite.bounds.size.x)
        {
            m_backgroundSprite.transform.Translate(m_backgroundSprite.bounds.size.x * 2, 0f, 0);
        }

        // 背景画像のクローンがある程度左に行ったら、右に戻す
        if (m_backgroundSpriteClone.transform.position.x < m_initialPositionX - m_backgroundSpriteClone.bounds.size.x)
        {
            m_backgroundSpriteClone.transform.Translate(m_backgroundSpriteClone.bounds.size.x * 2, 0f, 0);
        }
    }
}