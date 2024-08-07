using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRank3name : MonoBehaviour
{
    Ranking _scrText;

    [SerializeField]
    public UnityEngine.UI.Text runknameText3;
    // Start is called before the first frame update
    void Start()
    {
        runknameText3.text = Ranking.Instance.HighScoreName[2];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
