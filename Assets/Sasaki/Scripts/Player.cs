using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	[SerializeField]
	float _Offset;
	[SerializeField]
	float _Speed = 10f;
	private Rigidbody2D _Rig;
	// Use this for initialization
	void Start () {
		_Rig = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		_Rig.velocity = new Vector2(_Speed, _Rig.velocity.y);

		Vector3 pos = Camera.main.transform.position;
		pos.x = transform.position.x-_Offset;
		Camera.main.transform.position = pos;

		if(transform.position.x > 310){
			Vector3 myPos = transform.position;
			myPos.x = -20;
			transform.position = myPos;
		}
	}
}
