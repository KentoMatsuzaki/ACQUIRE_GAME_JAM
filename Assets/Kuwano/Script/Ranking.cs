using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Ranking : MonoBehaviour
{

    public InputField inputField;

    private float fanfry = 10.0f;
    private int diccount = 0;
    private bool is_ingame;

    public static string myname = "you";

    public string MyName
    {
        get => myname;
        set => myname = value;
    }
    

    private float scoreCount;
    public float ScoreCount
    {
        get => scoreCount;
        set => scoreCount = value;
    }

    public float[] highscore = {1, 2, 3, 0};
    public float[] HighScore => highscore ;

    public static string[] highscorename = { "��", "��", "��", "��" };

    public string[] HighScoreName => highscorename;

    public static Ranking instance;

    public static Ranking Instance => instance;



    // Start is called before the first frame update
    void Start()
    {
        scoreCount = 0;
        
    }
    public void InputText()
    {
        myname = inputField.text;
        if (myname.Length <= 6)           //�e�L�X�g���ő咷�ȉ��ł���ꍇ�̓e�L�X�g�����̂܂�
        {
             
        }
        else                                    //�e�L�X�g���ő咷���傫���ꍇ�͍ő咷����ȗ��L�����̕��������炵������\��
        {
            myname.Substring(0, 6 ) ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //���������
    public void Getfan()
    {
        scoreCount += fanfry;
        
    }
    //�X�R�A�̊m��ƃ\�[�g
    public void Endgamescore()
    {
        Dictionary<float,string> myDictionary = new Dictionary<float, string>() {
           {highscore[0],highscorename[0]},
           {highscore[1] , highscorename[1]},
           {highscore[2] , highscorename[2]}

        };


        myDictionary.Add(scoreCount, myname);
        var sorted = myDictionary.OrderByDescending((x) => x.Key);

        diccount = 0;
        foreach (var v in sorted)
        {
            highscorename[diccount] = v.Value;
            highscore[diccount] = v.Key;
            diccount = diccount + 1;
        }
        
    }
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
