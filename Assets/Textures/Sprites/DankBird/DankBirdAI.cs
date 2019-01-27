using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DankBirdAI : MonoBehaviour
{

    public float maxPatrolDistance = 10f;
    public float speed = 3f;

    private float distanceTravelled;
    private bool isReverse;
    private Animator _animator;

    private void Awake() {
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        distanceTravelled = 0f;
        isReverse = false;
    }

    void Update()
    {
        Debug.Log("Distance Travelled:" + distanceTravelled);
        if (distanceTravelled < maxPatrolDistance) {
            float distance = (isReverse) ? speed * -1 : speed;
            Debug.Log("Distance:" + distance);
            transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        }
        else {
            isReverse = !isReverse;
            _animator.SetFloat("Blend", (isReverse) ? 1.0f : -1.0f);
            distanceTravelled = 0f;
        }
        distanceTravelled++;


    }
}
