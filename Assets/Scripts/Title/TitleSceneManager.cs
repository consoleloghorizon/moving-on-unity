using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    public AudioClip sceneMusic;

    private void Start() {
        SoundMan.Instance.PlayMusic(sceneMusic);
    }

    void Update()
    {
        if (Input.anyKeyDown) {
            int currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("almas1");
        }
    }
}
