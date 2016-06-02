using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
	[SerializeField]
	private GameObject _Text;
	private State state = State.Prepare;
	// Use this for initialization
	protected override void Init ()
	{
		base.Init ();
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.I.GetTapDown ()) {
			state = State.isPlaying;
			_Text.SetActive(false);
			Time.timeScale = 1;
		}	
	}

	public bool IsPlaying{
		get { return  state == State.isPlaying; }
	}

	public enum State
	{
		Prepare,
		isPlaying
	}
}
