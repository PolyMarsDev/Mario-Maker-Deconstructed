using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlock : MonoBehaviour {

	private bool isOn;
	private Collider2D col;
	private SpriteRenderer spriteR;
	public Sprite OnSprite;
	public Sprite OffSprite;
	private Color semiVisible;

	// Use this for initialization
	void Start () {
		col = GetComponent<Collider2D>();
		spriteR = GetComponent<SpriteRenderer> ();
		semiVisible = new Color(1, 1, 1, 0.5f);
	}

	// Update is called once per frame
	void Update () {
		isOn = SwitchController.instance.isOn;

		if (isOn) {
			col.enabled = true;
			spriteR.sprite = OnSprite;
			spriteR.color = Color.white;

		} else if (!isOn) {
			col.enabled = false;
			spriteR.sprite = OffSprite;
			spriteR.color = semiVisible;
		}
	}
}
