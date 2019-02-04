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
    BoxCollider2D objectCollider;

    public static DankBirdAI instance;

    public int damageOnHit;

    private Player player;

    Vector3 initialPos;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        instance = this;
    }

    public void Start()
    {
        initialPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        spriteRenderer = GetComponent<SpriteRenderer>();
        objectCollider = GetComponent<BoxCollider2D>();
        spriteRenderer.enabled = true;
        objectCollider.enabled = true;
        player = Player.instance;

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
        spriteRenderer.enabled = false;
        objectCollider.enabled = false;
    }
    public void ResetBirds()
    {
        Debug.Log("BirdRender" + spriteRenderer.enabled);
        spriteRenderer.enabled = true;
        objectCollider.enabled = true;
        transform.position = initialPos;
        Debug.Log("BirdRender1" + spriteRenderer.enabled);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Vector3 dir = (col.transform.position - gameObject.transform.position).normalized;

        Debug.Log("HELLO" + col);

        if (col.name == "Player")
        {
            if (dir.y > 0.5)
            {
                player.ApplyDamage(0); //Trigger invincibility for a moment and bounce the player
                this.KillBird();
            }
            else
            {
                player.ApplyDamage(damageOnHit);
            }
        }
    }
}
