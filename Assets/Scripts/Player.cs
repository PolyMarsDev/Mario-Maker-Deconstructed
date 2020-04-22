using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Constants
    const string HorizontalAxis = "Horizontal";
    /// <summary>
    /// List of animation trigger names
    /// </summary>
    private class AnimationTriggers
    {
        internal const string Idle = "idle";
        internal const string Jump = "jump";
        internal const string Run = "run";
    }
    #endregion
    #region Private variables
    private float moveInput;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    private float jumpTimeCounter;
    // Use <see langword="new" /> keyword to indicate we want to hide the depreciated <see cref="Component.audio" /> property.
    private new AudioSource audio;
    #endregion
    #region Public variables
    public float speed;
	public float jumpForce;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpTime;
    public bool isJumping;
    public AudioClip jump;
    #endregion

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
		audio.clip = jump;
	}

    void FixedUpdate()
    {
        moveInput = Input.GetAxis(HorizontalAxis);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        bool moving = moveInput != 0;
        string 
            resetTrigger = moving ? AnimationTriggers.Idle : AnimationTriggers.Run,
            setTrigger = moving ?  AnimationTriggers.Run : AnimationTriggers.Idle;
        if(moving) transform.eulerAngles = new Vector3(0, moveInput > 0 ? 0 : 180, 0);
        anim.ResetTrigger(resetTrigger);
        anim.ResetTrigger(isGrounded ? AnimationTriggers.Jump : setTrigger);
        anim.SetTrigger(isGrounded ? setTrigger : AnimationTriggers.Jump);
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