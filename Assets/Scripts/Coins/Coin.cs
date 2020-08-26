using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	public enum Amount{ one, ten, thirty, fifty }; 
	public Amount type;
	public CoinCounter coinCounter;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			switch(type){
				case Amount.one:
					coinCounter.AddCoin(1);
					break;
				case Amount.ten:
					coinCounter.AddCoin(10);
					break;
				case Amount.thirty:
					coinCounter.AddCoin(30);
					break;
				case Amount.fifty:
					coinCounter.AddCoin(50);
					break;
			}
			Destroy (this.gameObject);
		}
	}
}
