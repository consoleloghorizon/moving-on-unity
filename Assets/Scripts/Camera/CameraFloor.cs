using UnityEngine;

public class CameraFloor : MonoBehaviour
{
    public float resetThreshold = -10f;
    public Transform RespawnPoint;
    public Transform target;

    void Update()
    {
        if (target && target.position.y <= resetThreshold)
        {
            target.position = new Vector3(RespawnPoint.position.x, RespawnPoint.position.y);
            ContactHazard.isDefeated = false;
        };
    }

}
