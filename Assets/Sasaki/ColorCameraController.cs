using UnityEngine;
using System.Collections;

public class ColorCameraController : MonoBehaviour 
{
	[SerializeField]
	Transform _Player; 

	void Update () {
		if (_Player.position.y - transform.position.y < -2) {
			Vector3 pos = transform.position;
			pos.y = _Player.position.y+2;
			transform.position = pos;
		} else {
			transform.position += Time.deltaTime * 5* Vector3.down;
		}
	}
}
