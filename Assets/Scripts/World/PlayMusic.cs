using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioClip sceneMusic;

    private void Start() {
        SoundMan.Instance.PlayMusic(sceneMusic);
    }
}
