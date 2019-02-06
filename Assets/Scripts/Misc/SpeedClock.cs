using System.Collections;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Threading;
using TMPro;
using UnityEngine;

public class SpeedClock : MonoBehaviour
{
    public static SpeedClock Instance = null;

    private Stopwatch stopwatch;
    public TimeSpan timeElapsed { get; private set; }
    TextMeshProUGUI textMesh;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    private void Update()
    {
        timeElapsed = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds);
        setClock(timeElapsed);
    }

    void setClock(TimeSpan time)
    {
        textMesh.text = time.ToString();
    }
}
