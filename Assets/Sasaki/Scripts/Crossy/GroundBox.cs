using UnityEngine;
using System.Collections;

public class GroundBox : MonoBehaviour 
{
	private GroundManager.State _State;

	public GroundManager.State GetState()
	{
		return _State;
	}

	public void SetState(GroundManager.State state)
	{
		_State = state;
		switch (_State) {
		case GroundManager.State.BLACK:
			GetComponent<Renderer>().material.color = new Color(0.2f,0.2f,0.2f);
			break;
		case GroundManager.State.GRAY:
			GetComponent<Renderer>().material.color = new Color(0.6f,0.6f,0.6f);
			break;
		case GroundManager.State.WHITE:
			GetComponent<Renderer>().material.color = new Color(1,1,1);
			break;
		case GroundManager.State.EMPTY:
			break;
		}
	}
}
