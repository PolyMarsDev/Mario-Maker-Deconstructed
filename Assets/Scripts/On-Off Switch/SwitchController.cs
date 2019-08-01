using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour {
	
	public bool isOn;

	public void FlipSwitch () {
		isOn = !isOn;
	}
}
