using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRank3score : MonoBehaviour
{
    private float _scrText;

    [SerializeField]
    public UnityEngine.UI.Text runkscoreText3;
    // Start is called before the first frame update
    void Start()
    {
        runkscoreText3.text = Ranking.Instance.HighScore[2].ToString("f1");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
