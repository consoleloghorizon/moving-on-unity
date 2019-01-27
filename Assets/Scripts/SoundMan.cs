using System.Collections;
using UnityEngine;

public class SoundMan : MonoBehaviour {

    public static SoundMan Instance = null;
    public AudioSource effectSource;
    public AudioSource musicSource;


    void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else if (Instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayEffect(AudioClip clip) {
        effectSource.clip = clip;
        effectSource.Play();
    }

    public void PlayMusic(AudioClip clip) {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic(float fadeTime) {
        StartCoroutine(FadeOut(musicSource, fadeTime));
    }

    IEnumerator FadeOut(AudioSource audioSource, float fadeTime) {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0) {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public void RandomizeSfx(params AudioClip[] clips) {
        int randomIndex = Random.Range(0, clips.Length);
        effectSource.clip = clips[randomIndex];
        effectSource.Play();
    }
}