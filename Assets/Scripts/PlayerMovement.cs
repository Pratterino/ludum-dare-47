using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Public
    public CharacterController2D controller;

    // Consts
    private const float MOVEMENT_SPEED = 30f;
    private const float JUMPFORCE = 80f;

    private bool isMovementEnabled = false;

    private Rigidbody2D rb;
    private CharacterController2D cc;
    private float horizontalMove = 0f;
    private bool jump;

    void Start()
    {
        EnableMovement(true);
        rb = gameObject.GetComponent<Rigidbody2D>();
        cc = gameObject.GetComponent<CharacterController2D>();
    }

    void Update()
    {
        if (isMovementEnabled)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * MOVEMENT_SPEED;

            if (Input.GetKeyDown(KeyCode.Space) && cc.IsGrounded())
            {
                jump = true;
            }
        } 
        else
        {
            horizontalMove = 0;
        }
    }

    void FixedUpdate()
    {
        // Movement
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 20); // Stop player from falling too fast and clip through platforms.
    }

    void LateUpdate()
    {
        Vector2 direction = transform.forward;
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, direction, 2);
        Debug.DrawRay(gameObject.transform.position, direction, Color.red, 2);

        //If something was hit.
        if (hit.collider != null && hit.distance <= 2) 
        {

        }
    }

    public void EnableMovement(bool movementEnabled, bool gameDone = false)
    {
        isMovementEnabled = movementEnabled;
    }
}