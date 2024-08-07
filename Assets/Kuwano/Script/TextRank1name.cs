using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRank1name : MonoBehaviour
{
    Ranking _scrText;

    [SerializeField]
    public UnityEngine.UI.Text runknameText1;
    // Start is called before the first frame update
    void Start()
    {
        runknameText1.text = Ranking.Instance.HighScoreName[0];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
