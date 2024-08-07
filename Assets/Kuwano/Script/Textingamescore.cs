using UnityEngine;
using UnityEngine.UI;

public class Textingamescore : MonoBehaviour
{
    [SerializeField] Text myscoreText;

    float score;

    void Start()
    {
        score = 0;
    }

    
    void Update()
    {
        score += ScrollSpeed.Instance.Speed * Time.deltaTime;
        myscoreText.text = score.ToString("F1") + "m";
    }
}
