using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectController : MonoBehaviour
{
    GameMan game;

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<GameMan>();
    }

    // Update is called once per frame
    void Update()
    {
        if (game.isPlayerFrozen && Input.GetButtonDown("Fire1"))
        {
            game.SetPlayerFrozen(false);
            gameObject.SetActive(false);
        }
    }
}
