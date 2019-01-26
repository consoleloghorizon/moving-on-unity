using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera mainCamera;
    public float dampTime = 0.15f;
    public float sizeValue = 4.0f;
    public float yValue = 3.0f;

    void Start() {
    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("OnCollisionEnter: " + col.gameObject.name);
        float initialSize = mainCamera.orthographicSize;
        float initialHeight = mainCamera.transform.position.y;
        StartCoroutine(LerpCamera(initialSize, initialHeight, dampTime));
    }

    private IEnumerator LerpCamera(float initialSize, float initialHeight, float time) {
        float elapsedTime = 0;
        mainCamera.orthographicSize = initialSize;
        while (elapsedTime < time) {
            mainCamera.orthographicSize = Mathf.Lerp(initialSize, sizeValue, elapsedTime / time);
            Vector3 startPosition = new Vector3(mainCamera.transform.position.x, initialHeight, mainCamera.transform.position.z);
            Vector3 endPosition = new Vector3(mainCamera.transform.position.x, yValue, mainCamera.transform.position.z);
            mainCamera.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
