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
        float initialSize = mainCamera.orthographicSize;
        StartCoroutine(LerpCameraSize(initialSize, sizeValue, dampTime));
    }

    private IEnumerator LerpCameraSize(float initialSize, float finalSize, float time) {
        float elapsedTime = 0;
        mainCamera.orthographicSize = initialSize;

        while (elapsedTime < time) {
            mainCamera.orthographicSize = Mathf.Lerp(initialSize, sizeValue, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
