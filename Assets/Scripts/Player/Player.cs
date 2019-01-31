using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{

    public float maxJumpHeight = 3f;
    public float minJumpHeight = 1.5f;
    public float timeToJumpApex = .4f;
    public float accelerationTimeGrounded = .1f;
    public float accelerationTimeAirborneMultiplier = 2f;

    public Transform RespawnPoint;

    public float timeInvincible = 2.0f;
    private float hitAnimation = 0.5f;

    private readonly float IDLE_STATE = 0.0f;
    private readonly float WALK_STATE = 0.33f;
    private readonly float HIT_STATE = 0.66f;
    private readonly float JUMP_STATE = 1.0f;

    bool invincible;
    bool forceApplied;

    float moveSpeed = 6f;
    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector3 velocity;
    Vector2 movementInput;
    float velocityXSmoothing;

    Direction direction;
    bool facingRight;
    bool isDamaged;

    Animator animator;
    SpriteRenderer spriteRenderer;
    Controller2D controller;

    public static Player instance;

    // Publics

    public bool IsFacingRight()
    {
        return facingRight;
    }

    public Direction GetDirection()
    {
        return direction;
    }

    public void ApplyDamage(int damage)
    {
        game = FindObjectOfType<GameMan>();
        enemies = FindObjectOfType<DankBirdAI>();

        isDamaged = true;
        if (!invincible)
        {
            game.currentHealth -= damage;

            if (game.currentHealth < 1)
            {
                this.transform.position = new Vector3(RespawnPoint.position.x, RespawnPoint.position.y);
                game.currentHealth = 5;
                isDamaged = false;
                enemies.ResetBirds();
                spriteRenderer.enabled = true;
                return;
            }

            SetVelocity(Vector2.up * 8.0f);
            StartCoroutine(SetInvincible());
        }

    }

    // Privates

    private GameMan game;
    private DankBirdAI enemies;


    private void Awake()
    {
        instance = this;

        game = FindObjectOfType<GameMan>();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<Controller2D>();
        //Initialize Vertical Values
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
    }

    private void Update()
    {
        if (!game.isPlayerFrozen)
        {
            GetInput();
            Animation();
            Horizontal();
            Vertical();
            ApplyMovement();
        }

    }

    private void GetInput()
    {
        direction = facingRight ? Direction.RIGHT : Direction.LEFT;

        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // If Moving
        if (movementInput.x != 0)
        {
            direction = movementInput.x > 0 ? Direction.RIGHT : Direction.LEFT;
            facingRight = movementInput.x > 0;
        }

        float verticalAimFactor = movementInput.y;

        if (controller.collisions.below)
        {
            verticalAimFactor = Mathf.Clamp01(verticalAimFactor);
        }

        if (verticalAimFactor != 0)
        {
            direction = verticalAimFactor > 0 ? Direction.UP : Direction.DOWN;
        }

        if (isDamaged)
        {
            animator.SetFloat("Blend", HIT_STATE);
        }
        else if (movementInput.x != 0 & verticalAimFactor == 0)
        {
            animator.SetFloat("Blend", WALK_STATE);
        }
        else if (movementInput.x == 0 && verticalAimFactor == 0)
        {
            animator.SetFloat("Blend", IDLE_STATE);
        }
        else
        {
            animator.SetFloat("Blend", JUMP_STATE);
        }
    }

    private void Animation()
    {
        spriteRenderer.flipX = !facingRight;
        animator.SetFloat("VelocityX", Mathf.Abs(movementInput.x));
        animator.SetFloat("VelocityY", Mathf.Sign(velocity.y));
        animator.SetFloat("Looking", General.Direction2Vector(direction).y);
        animator.SetBool("Grounded", controller.collisions.below);
    }

    private void Vertical()
    {
        if (forceApplied)
        {
            forceApplied = false;
        }
        else if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        if (Input.GetButtonDown("Fire1") && controller.collisions.below)
        {
            velocity.y = maxJumpVelocity;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            if (velocity.y > minJumpVelocity)
            {
                velocity.y = minJumpVelocity;
            }
        }

        velocity.y += gravity * Time.deltaTime;

    }

    private void Horizontal()
    {
        float targetVelocityX = movementInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing,
            accelerationTimeGrounded * (controller.collisions.below ? 1.0f : accelerationTimeAirborneMultiplier));
    }

    private void ApplyMovement()
    {
        controller.Move(velocity * Time.deltaTime);
    }

    private void SetVelocity(Vector2 v)
    {
        velocity = v;
        forceApplied = true;
    }

    private IEnumerator SetInvincible()
    {
        invincible = true;
        float elapsedTime = 0f;
        while (elapsedTime < timeInvincible)
        {
            if (elapsedTime > hitAnimation)
            {
                isDamaged = false;
            }
            spriteRenderer.enabled = !spriteRenderer.enabled;
            elapsedTime += .04f;
            yield return new WaitForSeconds(.04f);
        }

        spriteRenderer.enabled = true;
        invincible = false;
    }

}
