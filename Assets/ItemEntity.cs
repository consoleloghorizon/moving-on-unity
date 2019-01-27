using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemEntity : MonoBehaviour
{
    GameMan game;
    GameObject itemSelect;

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<GameMan>();
        itemSelect = GetComponentInParent<ItemSelectController>().gameObject;
    }

    public void OnClick() {
        Debug.Log("CLICKED");
        game.currentHealth--;
        itemSelect.SetActive(false);
        game.SetPlayerFrozen(false);
    }

}
