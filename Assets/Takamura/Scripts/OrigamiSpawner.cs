using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrigamiSpawner : MonoBehaviour
{
    /// <summary>生成する折り紙のプレハブ</summary>
    [SerializeField] GameObject _origami;
    /// <summary>最初の折り紙の待機時間</summary>
    [SerializeField] int _waitseconds = 5;
    void Start()
    {
        StartCoroutine("FirstOrigami");
    }
    /// <summary>折り紙をランダムな画面右の位置に生成するメソッド</summary>
    public void RandomSpawn()
    {
        float y = Random.Range(4.2f, -4.2f);

        Vector2 pos = new Vector2(10, y);

        Instantiate(_origami, pos, transform.rotation);
    }
    /// <summary>
    /// 最初の折り紙の待機時間を指定するメソッド
    /// </summary>

    IEnumerator FirstOrigami()
    {
        yield return new WaitForSeconds(_waitseconds);
        RandomSpawn();
    }
}
