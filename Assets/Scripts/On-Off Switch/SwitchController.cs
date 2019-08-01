using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour {
	public static SwitchController instance = null;
	public bool isOn;
	
        void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
        }

	public void FlipSwitch () {
		isOn = !isOn;
	}
}
