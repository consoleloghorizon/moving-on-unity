using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float dampTime = 0.15f;
    //private Vector3 velocity = Vector3.zero;
    public Transform target;

    void Start() {
        if (target) {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = destination;
        };
    }
	
	void Update () {
        if (target) {
            Renderer renderer = target.gameObject.GetComponent<Renderer>();
            Vector3 position = (renderer != null) ? renderer.bounds.center : target.position;
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(position);
            Vector3 delta = position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            //transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            transform.position = Vector3.Lerp(transform.position, destination, dampTime * Time.deltaTime);
        };
	}

    public void ChangeTarget(GameObject target) {
        this.target = target.transform;
    }
}
