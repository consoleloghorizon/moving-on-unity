using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemEntity : MonoBehaviour, UnityEngine.EventSystems.IPointerClickHandler
{
    GameMan game;
    GameObject itemSelect;
    public void OnPointerClick(PointerEventData eventData)
    {
        game.currentHealth--;
        itemSelect.SetActive(false);
        game.SetPlayerFrozen(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<GameMan>();
        itemSelect = GetComponentInParent<ItemSelectController>().gameObject;
           
    }

}
