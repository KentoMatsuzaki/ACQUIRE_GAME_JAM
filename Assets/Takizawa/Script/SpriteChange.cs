using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChange: MonoBehaviour
{

    public Sprite _targetsprite;
    public Sprite _sprite;
   

    Image _image;
    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        Debug.Log("a");
    }
    public void Onclick()
    {
        _image.sprite = _targetsprite;
        
    }
    public void OnClickEnd()
    {
        _image.sprite = _sprite;
    }

}
