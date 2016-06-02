using UnityEngine;
using System.Collections;

public class ColorSwitcher : MonoBehaviour 
{

	void Awake () 
	{
		bool isRed = this.gameObject.layer == LayerMask.NameToLayer ("Red");
		GetComponent<Renderer>().material.color = isRed ? Color.red : Color.blue;
	}
	
	void Update () {
		
		if (InputManager.I.GetAnyTapUp ()) {
			bool isRed = this.gameObject.layer == LayerMask.NameToLayer ("Red");
			int layer = isRed ? LayerMask.NameToLayer ("Blue") : LayerMask.NameToLayer ("Red");
			this.gameObject.layer = layer;
			GetComponent<Renderer>().material.color = isRed ? Color.blue : Color.red;
		}

		if (transform.position.y < -70f) {
			Vector3 pos = transform.position;
			pos.y = 20;
			transform.position = pos;

			Vector3 posC = Camera.main.transform.position;
			posC.y = 22;
			Camera.main.transform.position = posC;
		}
	}
}
