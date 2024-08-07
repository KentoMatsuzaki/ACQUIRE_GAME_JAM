using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrigamiSpawner : MonoBehaviour
{
    /// <summary>��������܂莆�̃v���n�u</summary>
    [SerializeField] GameObject _origami;
    /// <summary>�ŏ��̐܂莆�̑ҋ@����</summary>
    [SerializeField] int _waitseconds = 5;
    void Start()
    {
        StartCoroutine("FirstOrigami");
    }
    /// <summary>�܂莆�������_���ȉ�ʉE�̈ʒu�ɐ������郁�\�b�h</summary>
    public void RandomSpawn()
    {
        float y = Random.Range(4.2f, -4.2f);

        Vector2 pos = new Vector2(10, y);

        Instantiate(_origami, pos, transform.rotation);
    }
    /// <summary>
    /// �ŏ��̐܂莆�̑ҋ@���Ԃ��w�肷�郁�\�b�h
    /// </summary>

    IEnumerator FirstOrigami()
    {
        yield return new WaitForSeconds(_waitseconds);
        RandomSpawn();
    }
}
