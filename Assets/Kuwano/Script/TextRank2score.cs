using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRank2score : MonoBehaviour
{
    private float _scrText;

    [SerializeField]
    public UnityEngine.UI.Text runkscoreText2;
    // Start is called before the first frame update
    void Start()
    {
        runkscoreText2.text = Ranking.Instance.HighScore[1].ToString("f1") ;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
