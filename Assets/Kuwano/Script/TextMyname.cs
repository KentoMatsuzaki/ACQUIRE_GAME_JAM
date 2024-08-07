using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMyname : MonoBehaviour
{
    Ranking _scrText;

    [SerializeField]
    public UnityEngine.UI.Text mynameText;
    // Start is called before the first frame update
    void Start()
    {
        mynameText.text = Ranking.Instance.MyName;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
