using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTrigger : MonoBehaviour
{
    public string nextScene;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(nextScene);
        }
    }
}
