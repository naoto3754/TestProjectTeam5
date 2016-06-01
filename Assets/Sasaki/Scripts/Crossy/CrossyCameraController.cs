using UnityEngine;
using System.Collections;

public class CrossyCameraController : MonoBehaviour 
{
	[SerializeField]
	private float _Speed = 20f;

	void Update () {
		transform.position +=  Time.deltaTime * _Speed*Vector3.forward;
	}
}
