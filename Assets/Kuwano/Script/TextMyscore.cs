using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMyscore : MonoBehaviour
{
    Ranking _scrText;

    [SerializeField]
    public UnityEngine.UI.Text myscoreText;
    // Start is called before the first frame update
    void Start()
    {
        myscoreText.text = Ranking.Instance.ScoreCount.ToString("f1");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
