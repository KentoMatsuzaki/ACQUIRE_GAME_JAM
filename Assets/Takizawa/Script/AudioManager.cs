using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;



public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        Invoke("PlayAudio", 1.3f);
        audioSource = GetComponent<AudioSource>();
        VolumeChange();

    }
    public void VolumeChange()
    {
        StartCoroutine("VolumeUp");
    }
    IEnumerator VolumeUp()
    {
        while(audioSource.volume < 0.2f)
        {
            audioSource.volume += 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
       
    }
    // Update is called once per frame
    public void PlayAudio()
    {
        audioSource.Play();
    }
}
