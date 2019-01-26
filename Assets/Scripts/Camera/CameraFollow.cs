using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float dampTime = 0.15f;
    public float xOffset = 0.5f;
    public float yOffset = 0.5f;
    //private Vector3 velocity = Vector3.zero;
    public Transform target;

    void Start() {
        if (target) {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(xOffset, yOffset, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = new Vector3(transform.position.x + delta.x, transform.position.y, transform.position.z + delta.z);;
        };
    }

    void OnEnable() {
        
    }

    void Update () {
        if (target) {
            Renderer renderer = target.gameObject.GetComponent<Renderer>();
            Vector3 position = (renderer != null) ? renderer.bounds.center : target.position;
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(position);
            Vector3 delta = position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(xOffset, yOffset, point.z));
            Vector3 destination = new Vector3(transform.position.x + delta.x, transform.position.y, transform.position.z + delta.z);
            //Vector3 destination = transform.position + delta;
            //transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            transform.position = Vector3.Lerp(transform.position, destination, dampTime * Time.deltaTime);
        };
	}

    private void SetPosition(Vector2 position) {
        transform.position = position;
    }

    public void ChangeTarget(GameObject target) {
        this.target = target.transform;
    }
}
