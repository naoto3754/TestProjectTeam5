using UnityEngine;
using System.Collections;

public class FrogCameraController : MonoBehaviour 
{
	[SerializeField]
	private float _Speed = 5f;

	void Update () {
		transform.position += Time.deltaTime * _Speed * Vector3.up;
	}
}
