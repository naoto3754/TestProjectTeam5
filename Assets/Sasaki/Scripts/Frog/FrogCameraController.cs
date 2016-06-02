using UnityEngine;
using System.Collections;

public class FrogCameraController : MonoBehaviour 
{
	[SerializeField]
	private float _Speed = 5f;
	[SerializeField]
	private Transform _Frog;

	void Update () {
		Vector3 pos = transform.position;
		pos.y = _Frog.position.y;
		transform.position = pos;
	}
}
