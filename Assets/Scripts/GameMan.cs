using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMan : MonoBehaviour
{
    public bool isPaused;
    public bool isPlayerFrozen;
    public Player player;

    public static GameMan Instance
    {
        get
        {
            return s_Instance;
        }
    }

    protected static GameMan s_Instance;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this )
        {
            Destroy(Instance);
        }

        s_Instance = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void SetPaused(bool paused)
    {
        this.isPaused = paused;

        // if the game is paused, the player should also be frozen
        // but if the game is unpaused and we happen to be in a frozen state, don't change the frozen state
        if (this.isPaused && !this.isPlayerFrozen)
        {
            SetPlayerFrozen(true);
        }
    }

    public void SetPlayerFrozen(bool playerFrozen)
    {
        this.isPlayerFrozen = true;
    }
}
