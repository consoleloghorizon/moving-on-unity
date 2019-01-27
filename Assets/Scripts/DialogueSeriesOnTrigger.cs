﻿using System.Collections;
using System.Collections.Generic;
using Gamekit2D;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class DialogueSeriesOnTrigger : MonoBehaviour
{
    public DialogueController dialogueController;

    public LayerMask layers;
    public UnityEvent OnEnter, OnExit;
    public InventoryController.InventoryChecker[] inventoryChecks;

    protected Collider2D m_Collider;

    void Reset()
    {
        layers = LayerMask.NameToLayer("Everything");
        m_Collider = GetComponent<Collider2D>();
        m_Collider.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled)
            return;

        if (layers.Contains(other.gameObject))
        {
            ExecuteOnEnter(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!enabled)
            return;

        if (layers.Contains(other.gameObject))
        {
            ExecuteOnExit(other);
        }
    }

    public virtual void ExecuteOnEnter(Collider2D other)
    {
        OnEnter.Invoke();

        DialogueController.Dialoggo[] dialoggos = {
            new DialogueController.Dialoggo(GameCharacter.PASTEMAN, "its me pasteman 1"),
            new DialogueController.Dialoggo(GameCharacter.MONDO, "its me karie mondo"),
            new DialogueController.Dialoggo(GameCharacter.PASTEMAN, "its me pasteman 2")
        };

        dialogueController.QueueDialog(dialoggos);

        for (int i = 0; i < inventoryChecks.Length; i++)
        {
            inventoryChecks[i].CheckInventory(other.GetComponentInChildren<InventoryController>());
        }
    }

    protected virtual void ExecuteOnExit(Collider2D other)
    {
        OnExit.Invoke();
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "InteractionTrigger", false);
    }
}