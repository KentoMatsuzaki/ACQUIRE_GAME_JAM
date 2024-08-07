using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextRank1score : MonoBehaviour
{
    Ranking _scrText;

   [SerializeField]
    public UnityEngine.UI.Text runkscoreText1;
    // Start is called before the first frame update
    void Start()
    {
        runkscoreText1.text = Ranking.Instance.HighScore[0].ToString("f1") ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowRank1Score()
    {
        runkscoreText1.text = Ranking.Instance.HighScore[0].ToString("f1") ;
    }
}
