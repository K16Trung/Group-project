using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    private float horizontal;
    private bool isFacingRight = true;
    Rigidbody2D rb;
    private float speed = 8f;

    [Range(1, 10)]
    [SerializeField] float acceleration;

    bool btnPressed;

    bool isWallTouch;
    public LayerMask wallLayer;
    public Transform wallCheckPoint;

    float moveInput;
    Vector2 relativeTransform;

    public bool isOnPlatform;
    public Rigidbody2D platformRb;

    public ParticleController particleController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        UpdateRelativeTransform();
    }
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (isOnPlatform && platformRb != null)
        {
            targetVelocity += platformRb.velocity;
        }

        rb.velocity = targetVelocity;

        isWallTouch = Physics2D.OverlapBox(wallCheckPoint.position, new Vector2(0.06f, 0.55f), 0, wallLayer);

        if (isWallTouch)
        {
            particleController.PlayParticle(ParticleController.Particles.touch, wallCheckPoint.position);
/*            Flip();*/
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
            UpdateRelativeTransform();
        }
    }
    public void UpdateRelativeTransform()
    {
        relativeTransform = transform.InverseTransformVector(Vector2.one);
    }
}
