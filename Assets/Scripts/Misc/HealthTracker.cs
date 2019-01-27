using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthTracker : MonoBehaviour
{

    GameMan game;
    TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<GameMan>();
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        setHealth(game.currentHealth);
    }

    void setHealth(int health)
    {
        textMesh.text = "x" + health;
    }
}
