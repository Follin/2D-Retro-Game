using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mainMixer;
    public AudioClip mainGameTrack;
    public AudioClip gameOverClip; 
    [SerializeField] private AudioSource audioSourceMainGameTrack;
    [SerializeField] private AudioSource audioSourceMainGameSFX;
    [SerializeField] private AudioSource audioSourceMenuTrack;
    [SerializeField] private AudioSource audioSourceMenuSFX; 
    public bool keepFadingIn;
    public bool keepFadingOut;

    private void Awake()
    {
        audioSourceMainGameTrack.outputAudioMixerGroup = mainMixer.FindMatchingGroups("Music")[0];
        audioSourceMainGameSFX.outputAudioMixerGroup = mainMixer.FindMatchingGroups("SFX")[0];
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DebugInput();
    }

    private void DebugInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //start menu music
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //start in-game music
            StartCoroutine(FadeIn(audioSourceMainGameTrack, 0.08f, 1));
            PlayInGameMusic();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //death music
            StartCoroutine(FadeOut(audioSourceMainGameTrack, 0.2f, 0.001f));
            audioSourceMainGameSFX.PlayOneShot(gameOverClip);
            //play endgame music
        }

    }

    private void PlayInGameMusic()
    {
        StartCoroutine(MusicLoop(mainGameTrack.length));
    }

    IEnumerator MusicLoop(float seconds)
    {
        audioSourceMainGameTrack.PlayOneShot(mainGameTrack);
        yield return new WaitForSeconds(seconds);
        PlayInGameMusic();

    }

    IEnumerator FadeIn(AudioSource track, float speed, float maxVolume)
    {
        keepFadingIn = true;
        keepFadingOut = false;
        track.volume = 0;
        float audioVolume = audioSourceMainGameTrack.volume;
        while(track.volume < maxVolume && keepFadingIn)
        {
            audioVolume += speed;
            track.volume = audioVolume;
            yield return new WaitForSeconds(0.1f);
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
            yield return new WaitForSeconds(0.1f);
        }
        print("Volume minimum reached");
        track.Stop();
    }

}
