using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Runking : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Text runkscoreText1;
    public UnityEngine.UI.Text runkscoreText2;
    public UnityEngine.UI.Text runkscoreText3;
    

    public UnityEngine.UI.Text highscorenameText1;
    public UnityEngine.UI.Text highscorenameText2;
    public UnityEngine.UI.Text highscorenameText3;
    public UnityEngine.UI.Text playernameText;

    public InputField inputField;

    private float fanfry = 10.0f;
    private float scoreCount;
    private int diccount = 0;
    private bool is_ingame;

    private float[] highscore = { 300, 400, 100, 0 };
    private string[] highscorename = { "ひ", "ふ", "み", "よ" };
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        scoreCount = 0;
        scoreText.text = scoreCount + "m";
        inputField = inputField.GetComponent<InputField>();

        runkscoreText1.text = highscore[0] + "m";
        runkscoreText2.text = highscore[1] + "m";
        runkscoreText3.text = highscore[2] + "m";

        playernameText.text = "you";
        highscorenameText1.text = highscorename[0];
        highscorenameText2.text = highscorename[1];
        highscorenameText3.text = highscorename[2];
    }
    public void InputText()
    {
        playernameText.text = inputField.text;
    }

        // Update is called once per frame
    void Update()
    {
        //if (is_ingame == true)
        scoreCount += 1000.2f * Time.deltaTime;
        //scoreCount += 0.1f * Time.deltaTime * ScrollSpeed.Instance.Speed;
        scoreText.text = scoreCount.ToString("f1") + "m";

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Endgamescore();
            Debug.Log("a");
        }
        
    }
    
    //うちわ入手
    void Getfan()
    {
        scoreCount += fanfry;
        scoreText.text = scoreCount.ToString("f1") + "m";
    }
    //スコアの確定とソート
    void Endgamescore()
    {
        Dictionary<float,string> myDictionary = new Dictionary<float, string>() {
           {highscore[0],highscorename[0]},
           {highscore[1] , highscorename[1]},
           {highscore[2] , highscorename[2]}

        };


        myDictionary.Add(scoreCount, playernameText.text);
        var sorted = myDictionary.OrderByDescending((x) => x.Key);

        diccount = 0;
        foreach (var v in sorted)
        {
            highscorename[diccount] = v.Value;
            highscore[diccount] = v.Key;
            diccount = diccount + 1;
        }

        //list.AddRange(highscore);
        //list.Add(scoreCount);
        //list.Sort((a, b) => b - a);
        //list.RemoveAt(list.Count - 1);
        //highscore = list.ToArray();
        runkscoreText1.text = highscore[0].ToString("f1") + "m";
        runkscoreText2.text = highscore[1].ToString("f1") + "m";
        runkscoreText3.text = highscore[2].ToString("f1") + "m";
        scoreText.text = scoreCount.ToString("f1") + "m";

        highscorenameText1.text = highscorename[0];
        highscorenameText2.text = highscorename[1];
        highscorenameText3.text = highscorename[2];
        
    }
    //初期化
    void initializescore()
    {
        scoreCount = 0.0f;
        scoreText.text = scoreCount.ToString("f1") + "m";
        playernameText.text = "you";
    }
}
