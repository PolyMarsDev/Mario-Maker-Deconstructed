using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	private GameObject child;
	private SpriteRenderer spriteR;
	private Animator anim;
	public Sprite onSprite;
	public Sprite offSprite;
	private bool isOn;
	public SwitchController switchController;
	AudioSource audio;
	public AudioClip hit;
	private bool setOn;
	private bool setOff;

	// Use this for initialization
	void Start () {
		child = transform.GetChild (0).gameObject;
		spriteR = child.GetComponent<SpriteRenderer> ();
		anim = child.GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
		audio.clip = hit;
		setOn = false;
		setOff = false;
	}
	
	// Update is called once per frame
	void Update () {
		isOn = SwitchController.instance.isOn;

		if (!setOn) {
			if (isOn) {
				spriteR.sprite = onSprite;
				setOn = true;
				setOff = false;
			}
		} if (!setOff) {
			if (!isOn) {
				spriteR.sprite = offSprite;
				setOff = true;
				setOn = false;
			}
		}

	}

	void OnCollisionEnter2D(Collision2D col) {
		
		if (col.collider.bounds.max.y < transform.position.y
			&& col.collider.bounds.min.x < transform.position.x + 0.5f
			&& col.collider.bounds.max.x > transform.position.x -0.5f
			&& col.collider.tag == "Player") {
			audio.Play ();
			switchController.FlipSwitch ();
			anim.Play ("switch");
		}
	}
}
