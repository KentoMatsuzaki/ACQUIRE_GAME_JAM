using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _ruleUI;
    [SerializeField] private GameObject _restartUI;
    [SerializeField] private GameObject _startUI;
    [SerializeField] private GameObject _rankingUI;
    [SerializeField] private GameObject _returnUI;
    [SerializeField] private GameObject _rankingbuttonUI;
    [SerializeField] private GameObject _nameUI;
    [SerializeField] private GameObject _rankingtextUI;
    //[SerializeField] private GameObject _backgroundUI;
    //[SerializeField] private GameObject _rankingbackgroundUI;


    AudioSource _audiosourse;
    // Start is called before the first frame update
    void Start()
    {


    }

    public void OnclickStart()
    {
        _ruleUI.SetActive(true);
        _restartUI.SetActive(true);
        _startUI.SetActive(false);
        _rankingbuttonUI.SetActive(false);
        _nameUI.SetActive(false);
    }
    public void OnRoadGameScene()
    {

        SceneManager.LoadScene("GameScene");

    }
    public void OnRoadTitleScene()
    {

        SceneManager.LoadScene("TitleScene");
        Ranking.instance.ScoreCount = 0;
        Ranking.instance.MyName = "you";
        
    }
    public void OnReRoadGameScene()
    {
        SceneManager.LoadScene("GameScene");

    }
    //public void OnRoadResultScene()
    //{
     //   SceneManager.LoadScene("ResultScene");
    //}
    public void OnClickRanking()
    {
        _rankingUI.SetActive(true);
        _startUI.SetActive(false);
        _returnUI.SetActive(true);
        _rankingbuttonUI.SetActive(false);
        _nameUI.SetActive(false);
        _rankingtextUI.SetActive(true);
        //_backgroundUI.SetActive(false);
        //_rankingbackgroundUI.SetActive(true);

    }
    public void OnClickReturn()
    {
        _startUI.SetActive(true);
        _returnUI.SetActive(false);
        _rankingUI.SetActive(false);
        _rankingbuttonUI.SetActive(true);
        _nameUI.SetActive(true);
        _rankingtextUI.SetActive(false);
        //_backgroundUI.SetActive(true);
        //_rankingbackgroundUI.SetActive(false);

    }
}