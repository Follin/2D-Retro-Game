using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mainMixer;
    public AudioClip mainGameTrack;
    public AudioClip gameOverClip; 
    [SerializeField] private AudioSource _audioSourceMainGameTrack;
    [SerializeField] private AudioSource _audioSourceMainGameSFX;
    [SerializeField] private AudioSource _audioSourceMenuTrack;
    [SerializeField] private AudioSource _audioSourceMenuSFX;
    [SerializeField] private float mainTrackLoopTime;
    public bool keepFadingIn;
    public bool keepFadingOut;

    [SerializeField] private AudioClip pickUpClip, abilitySwapClip;
    [SerializeField] private AudioClip[] explosionClip;
    //public AudioClip _audioClip;
    private bool canPlayExplosion;

    private void Awake()
    {
        _audioSourceMainGameTrack.outputAudioMixerGroup = mainMixer.FindMatchingGroups("Music")[0];
        _audioSourceMainGameSFX.outputAudioMixerGroup = mainMixer.FindMatchingGroups("SFX")[0];
    }

    // Start is called before the first frame update
    void Start()
    {
        canPlayExplosion = true;
        StartCoroutine(FadeIn(_audioSourceMainGameTrack, 0.02f, 1));
        PlayInGameMusic();
    }

    // Update is called once per frame
    void Update()
    {
        //DebugInput();
    }

    public void ExplosionPlay()
    {
        if (canPlayExplosion)
        {
            _audioSourceMainGameSFX.volume = 0.8f;
            int r = Random.Range(0, explosionClip.Length - 1);
            _audioSourceMainGameSFX.PlayOneShot(explosionClip[r]);
            Invoke("CanPlayExplosionToTrue", 0.4f);
        }

    }
    private void CanPlayExplosionToTrue()
    {
        canPlayExplosion = true;
    }

    public void PickUpPlay()
    {
        _audioSourceMainGameSFX.volume = 1;
        _audioSourceMainGameSFX.PlayOneShot(pickUpClip);
    }

    public void AbilitySwapPlay()
    {
        _audioSourceMainGameSFX.volume = 1f;
        _audioSourceMainGameSFX.PlayOneShot(abilitySwapClip);
    }

    public void PlayDeathSound()
    {
        _audioSourceMainGameSFX.volume = 0.3f;
        _audioSourceMainGameSFX.PlayOneShot(gameOverClip);
        //print("Death Sound");
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
            StartCoroutine(FadeIn(_audioSourceMainGameTrack, 0.02f, 1));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //death music
            StartCoroutine(FadeOut(_audioSourceMainGameTrack, 0.02f, 0));
            _audioSourceMainGameSFX.PlayOneShot(gameOverClip);
            //play endgame music
        }

    }

    private void LoseMusicTransition()
    {
        //TODO add in transition
    }

    private void PlayInGameMusic()
    {
        StartCoroutine(MusicLoop(mainTrackLoopTime));
    }

    IEnumerator MusicLoop(float seconds)
    {
        _audioSourceMainGameTrack.PlayOneShot(mainGameTrack);
        yield return new WaitForSeconds(seconds);
        PlayInGameMusic();

    }

    IEnumerator FadeIn(AudioSource track, float speed, float maxVolume)
    {
        keepFadingIn = true;
        keepFadingOut = false;
        track.volume = 0;
        float audioVolume = track.volume;
        while(track.volume < maxVolume && keepFadingIn)
        {
            audioVolume += speed;
            track.volume = audioVolume;
            yield return new WaitForSeconds(0.05f);
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
            yield return new WaitForSeconds(0.05f);
        }
        print("Volume minimum reached");
        //track.Stop();
    }

}
