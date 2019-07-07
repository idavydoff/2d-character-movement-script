using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
  public float runSpeed = 0.6f; // Running speed.
  public float jumpForce = 2.6f; // Jump height.

  public Sprite jumpSprite; // Sprite that shows up when the character is not on the ground. [OPTIONAL]

  private Rigidbody2D body; // Variable for the RigidBody2D component.
  private SpriteRenderer sr; // Variable for the SpriteRenderer component.
  private Animator animator; // Variable for the Animator component. [OPTIONAL]

  private bool isGrounded; // Variable that will check if character is on the ground.
  public GameObject groundCheckPoint; // The object through which the isGrounded check is performed.
  public float groundCheckRadius; // isGrounded check radius.
  public LayerMask groundLayer; // Layer wich the character can jump on.

  private bool jumpPressed = false; // Variable that will check is "Space" key is pressed.
  private bool APressed = false; // Variable that will check is "A" key is pressed.
  private bool DPressed = false; // Variable that will check is "D" key is pressed.

  void Awake() {
    body = GetComponent<Rigidbody2D>(); // Setting the RigidBody2D component.
    sr = GetComponent<SpriteRenderer>(); // Setting the SpriteRenderer component.
    animator = GetComponent<Animator>(); // Setting the Animator component. [OPTIONAL]
  }

  // Update() is called every frame.
  void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) jumpPressed = true; // Checking on "Space" key pressed.
    if (Input.GetKey(KeyCode.A)) APressed = true; // Checking on "A" key pressed.
    if (Input.GetKey(KeyCode.D)) DPressed = true; // Checking on "D" key pressed.
  }

  // Update using for physics calculations.
  void FixedUpdate() {
      isGrounded = Physics2D.OverlapCircle(groundCheckPoint.transform.position, groundCheckRadius, groundLayer); // Checking if character is on the ground.
      
      // Left/Right movement.
      if (APressed) {
          body.velocity = new Vector2(-runSpeed, body.velocity.y); // Move left physics.
          transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z); // Rotating the character object to the left.
          APressed = false; // Returning initial value.
      }
      else if (DPressed) {
          body.velocity = new Vector2(runSpeed, body.velocity.y); // Move right physics.
          transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z); // Rotating the character object to the right.
          DPressed = false; // Returning initial value.
      }
      else body.velocity = new Vector2(0, body.velocity.y);

      // Jumps.
      if (jumpPressed && isGrounded) {
          body.velocity = new Vector2(0, jumpForce); // Jump physics.
          jumpPressed = false; // Returning initial value.
      }

      // Setting jump sprite. [OPTIONAL]
      if (!isGrounded) {
        animator.enabled = false; // Turning off animation.
        sr.sprite = jumpSprite; // Setting the sprite.
      }
      else animator.enabled = true; // Turning on animation.
  }
}