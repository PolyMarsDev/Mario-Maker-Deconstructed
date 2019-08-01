using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed;
	public float jumpForce;
	private float moveInput;

	private Rigidbody2D rb;
	Animator anim;

	private bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;

	private float jumpTimeCounter;
	public float jumpTime;
	public bool isJumping;

	AudioSource audio;
	public AudioClip jump;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
		audio.clip = jump;
	}

	void FixedUpdate () {
		moveInput = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);

		if (moveInput > 0) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			if (isGrounded) {
				anim.ResetTrigger ("idle");
				anim.ResetTrigger ("jump");
				anim.SetTrigger ("run");
			} else if (!isGrounded) {
				anim.ResetTrigger ("run");
				anim.ResetTrigger ("idle");
				anim.SetTrigger ("jump");
			}
		} else if (moveInput < 0) {
			transform.eulerAngles = new Vector3 (0, 180, 0);
			if (isGrounded) {
				anim.ResetTrigger ("idle");
				anim.ResetTrigger ("jump");
				anim.SetTrigger ("run");
			} else if (!isGrounded) {
				anim.ResetTrigger ("run");
				anim.ResetTrigger ("idle");
				anim.SetTrigger ("jump");
			}
		} else if (moveInput == 0) {
			if (isGrounded) {
				anim.ResetTrigger ("run");
				anim.ResetTrigger ("jump");
				anim.SetTrigger ("idle");
			} else if (!isGrounded) {
				anim.ResetTrigger ("run");
				anim.ResetTrigger ("idle");
				anim.SetTrigger ("jump");
			}
		}
	}

	void Update () {
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, checkRadius, whatIsGround);

		if (isGrounded && Input.GetKeyDown (KeyCode.Space)) {
			audio.Play ();
			isJumping = true;
			jumpTimeCounter = jumpTime;
			rb.velocity = Vector2.up * jumpForce;
		}

		if (Input.GetKey (KeyCode.Space)) {
			if (jumpTimeCounter > 0 && isJumping) {
				rb.velocity = Vector2.up * jumpForce;
				jumpTimeCounter -= Time.deltaTime;
			} else {
				isJumping = false;
			}
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			isJumping = false;
		}
	}
}
