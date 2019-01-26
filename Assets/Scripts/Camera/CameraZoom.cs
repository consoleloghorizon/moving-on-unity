using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera mainCamera;
    public float dampTime = 0.15f;
    public float sizeValue = 4.0f;

    void Start() {
    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("OnCollisionEnter: " + col.gameObject.name);
        //mainCamera.orthographicSize = sizeValue;
        float initialSize = mainCamera.orthographicSize;
        mainCamera.orthographicSize = Mathf.Lerp(initialSize, sizeValue, dampTime * Time.deltaTime);
    }
}
