using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRank2name : MonoBehaviour
{
    Ranking _scrText;

    [SerializeField]
    public UnityEngine.UI.Text runknameText2;
    // Start is called before the first frame update
    void Start()
    {
        runknameText2.text = Ranking.Instance.HighScoreName[1];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
