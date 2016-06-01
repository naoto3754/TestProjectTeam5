using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Frog : MonoBehaviour
{
	[SerializeField]
	private State _State;
	[SerializeField]
	private Transform _JumpMarker; 

	private bool _IsPowerUp;
	private Rigidbody2D _Rig;

	void Awake ()
	{
		_Rig = GetComponent<Rigidbody2D> ();
	}
	 
	void FixedUpdate ()
	{
		switch(_State)
		{
		case State.InAir:
			break;
		case State.Direction:
			break;
		case State.Power:
			break;
		}
	}

	void Update ()
	{
		switch(_State)
		{
		case State.InAir:
			break;
		case State.Direction:
			_JumpMarker.RotateAround (transform.position, Vector3.forward, Time.deltaTime*300);
			if (InputManager.I.GetTapDown (0)) {
				_State = State.Power;
			}
			break;
		case State.Power:
			Vector3 diff = _JumpMarker.position - transform.position;
			float magni = diff.magnitude;
			if (magni < 0.5f)
				_IsPowerUp = true;
			else if (magni > 3f)
				_IsPowerUp = false;
			float inc = Time.deltaTime*5f*(_IsPowerUp ? 1 : -1);
			_JumpMarker.position += diff.normalized * inc;
			if (InputManager.I.GetTapUp (0)) {
				_State = State.InAir;
				Jump (diff.normalized, 10*diff.magnitude);
			}
			break;
		}
	}

	void Jump(Vector3 direction, float power)
	{
		_Rig.constraints = RigidbodyConstraints2D.None;
		_Rig.velocity = power * direction;
	}

	public enum State
	{
		InAir,
		Direction,
		Power,
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (_State == State.InAir) {
			_IsPowerUp = true;
			_JumpMarker.position = transform.position + 1f * Vector3.up;
			_State = State.Direction;
			_Rig.constraints = RigidbodyConstraints2D.FreezeAll;
		}
	}

	public void OnRestart()
	{
		SceneManager.LoadScene ("Frog");	
	}
}
