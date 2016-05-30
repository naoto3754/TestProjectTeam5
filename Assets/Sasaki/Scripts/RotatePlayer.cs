using UnityEngine;
using System.Collections;

public class RotatePlayer : MonoBehaviour
{
	[SerializeField]
	private float _RotateSpeed = 50f;
	[SerializeField]
	private float _MoveSpeed = 20f;
	[SerializeField]
	private float _AutoMoveSpeed = 20f;
	
	// Update is called once per frame
	void Update () 
	{
		float movex = Time.deltaTime * _MoveSpeed * Input.GetAxis("Horizontal");
		float movey = Time.deltaTime * _MoveSpeed * Input.GetAxis("Vertical");
		transform.position += new Vector3(movex, movey, 0);
		Vector3 automove = new Vector3(0, Time.deltaTime*_AutoMoveSpeed, 0);
		transform.position += automove;
		Camera.main.transform.position += automove;
		transform.Rotate (0, 0, Time.deltaTime*_RotateSpeed);
	}
}
