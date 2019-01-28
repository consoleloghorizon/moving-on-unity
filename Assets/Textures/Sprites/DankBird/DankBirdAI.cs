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
    SpriteRenderer spriteRenderer;

    public static DankBirdAI instance;

    Vector3 initialPos;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        instance = this;
    }

    void Start()
    {
        initialPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        spriteRenderer = GetComponent<SpriteRenderer>();

        distanceTravelled = 0f;
        isReverse = false;
    }

    void FixedUpdate()
    {
        if (distanceTravelled < maxPatrolDistance)
        {
            float distance = (isReverse) ? speed * -1 : speed;
            transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        }
        else
        {
            isReverse = !isReverse;
            _animator.SetFloat("Blend", (isReverse) ? 1.0f : -1.0f);
            distanceTravelled = 0f;
        }
        distanceTravelled++;
    }
    public void KillBird()
    {
        Debug.Log("I AM KILL");
        spriteRenderer.enabled = false;
    }
    public void ResetBirds()
    {
        transform.position = initialPos;
    }
}
