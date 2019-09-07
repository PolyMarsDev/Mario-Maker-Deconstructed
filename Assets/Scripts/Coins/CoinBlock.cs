using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlock : MonoBehaviour {
	private Animator spriteAnim;
	private GameObject child;
	public int totalCoins;
	public Sprite disabled;
	public CoinCounter coinCounter;
	private AudioSource audioS;
	public AudioClip hit;

	// Use this for initialization
	void Start () {
		child = transform.GetChild (0).gameObject;
		spriteAnim = child.GetComponent<Animator> ();
		audioS = GetComponent<AudioSource> ();
		audioS.clip = hit;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D col) {

		if (col.collider.bounds.max.y < transform.position.y
			&& col.collider.bounds.min.x < transform.position.x + 0.5f
			&& col.collider.bounds.max.x > transform.position.x -0.5f
			&& col.collider.tag == "Player") {
				if (totalCoins > 0) {
					spriteAnim.Play ("coinblock_hit");
					audioS.Play();
					coinCounter.AddCoin ();
					totalCoins -= 1;
					if (totalCoins == 0) {
						GetComponent<Animator> ().enabled = false;
						child.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
						child.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = disabled;
					}
				}

			}
		}
	}
