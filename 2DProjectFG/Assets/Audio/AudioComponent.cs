using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioComponent : MonoBehaviour
{

    bool keepFadingIn;
    bool keepFadingOut;
    private AudioSource _audioSource;
    //public AudioClip _audioClip;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //_audioSource.PlayOneShot(_audioClip);
        _audioSource.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            EngineFades(true);

        if (Input.GetKey(KeyCode.Alpha2))
            EngineFades(false);

    }

    public void EngineFades(bool fadeIn)
    { 
        if (fadeIn)
            StartCoroutine(FadeIn(_audioSource, 0.4f, 1));
        else
            StartCoroutine(FadeOut(_audioSource, 0.4f, 0));
    }

    IEnumerator FadeIn(AudioSource track, float speed, float maxVolume)
    {
        keepFadingIn = true;
        keepFadingOut = false;
        track.volume = track.volume;
        float audioVolume = _audioSource.volume;
        while (track.volume < maxVolume && keepFadingIn)
        {
            audioVolume += speed;
            track.volume = audioVolume;
            yield return new WaitForSeconds(0.0001f);
        }
    }

    IEnumerator FadeOut(AudioSource track, float speed, float minVolume)
    {
        keepFadingIn = false;
        keepFadingOut = true; 
        float audioVolume = track.volume;
        while (track.volume >= minVolume && keepFadingOut)
        {
            audioVolume -= speed;
            track.volume = audioVolume;
            yield return new WaitForSeconds(0.0001f);
        }
        print("Volume minimum reached");
      
    }
}
