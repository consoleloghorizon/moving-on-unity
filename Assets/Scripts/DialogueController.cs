using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Gamekit2D;

public class DialogueController : MonoBehaviour
{
    public struct Dialoggo
    {
        public GameCharacter character;
        public string text;
        public Dialoggo(GameCharacter c, string t)
        {
            character = c;
            text = t;
        }
    }

    private Queue<Dialoggo> dialogueQueue;
    private bool dialogueVisible;
    private GameMan game;

    public DialogueCanvasController playerController;
    public DialogueCanvasController mondoController;

    private DialogueCanvasController lastDialogueController;

    // Start is called before the first frame update
    void Start()
    {
        dialogueQueue = new Queue<Dialoggo>();
        game = FindObjectOfType<GameMan>();

    }

    // Update is called once per frame
    void Update()
    {
        while (dialogueQueue.Count != 0 && !this.dialogueVisible)
        {
            Dialoggo dialogue = dialogueQueue.Dequeue();
            GameCharacter character = dialogue.character;
            string text = dialogue.text;

            ShowDialog(character, text);
        }

        if (dialogueVisible && Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(CloseDialog());
        }
    }

    private void ShowDialog(GameCharacter c, string text)
    {
        game.isPlayerFrozen = true;
        this.dialogueVisible = true;
        Debug.Log(c + " " + text);

        DialogueCanvasController canvasController = playerController;
        switch (c)
        {
            case GameCharacter.PASTEMAN:
                canvasController = playerController;
                break;
            case GameCharacter.MONDO:
                canvasController = mondoController;
                break;
        }
        this.lastDialogueController = canvasController;
        this.lastDialogueController.ActivateCanvasWithText(text);
    }

    private IEnumerator CloseDialog()
    {
        yield return null;
        this.lastDialogueController.DeactivateCanvasWithDelay(0);
        this.dialogueVisible = false;
        this.lastDialogueController = null;

        if (this.dialogueQueue.Count == 0)
        {
            game.isPlayerFrozen = false;
        }
    }

    public void QueueDialog(Dialoggo[] dialoggos)
    {

        this.dialogueQueue = new Queue<Dialoggo>(dialoggos);
    }
}
