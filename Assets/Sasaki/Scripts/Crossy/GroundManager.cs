using UnityEngine;
using System.Collections;

public class GroundManager : Singleton<GroundManager>
{
	public const float PADDING = 0.1f;

	[SerializeField]
	private GameObject _Box;
	[SerializeField]
	private int _Width = 10;
	[SerializeField]
	private int _Height = 50;

	private int _Count{
		get { return _Width*_Height; }
	}

	private GroundBox[] _GroundBoxList;

	protected override void Init ()
	{
		base.Init ();
		_GroundBoxList = new GroundBox[_Count];
		for (int j = 0; j < _Height; j++) {
			for (int i = 0; i < _Width; i++) {
				GameObject box = Instantiate (_Box, new Vector3(i+i*PADDING, 0, j+j*PADDING), Quaternion.identity) as GameObject;
				box.transform.SetParent (this.transform);
				var gbox = box.GetComponent<GroundBox> ();
				int rand = Random.Range (0, 3);
				if (rand == 0) {
					gbox.SetState (State.BLACK);
				} else if (rand == 1) {
					gbox.SetState (State.GRAY);
				} else {
					gbox.SetState (State.WHITE);
				}
				_GroundBoxList [i + j * _Width] = gbox;
			}
		}

	}

	public bool CanMove(int curI, int curJ, int nextI, int nextJ)
	{
		if (curI < 0 || curI >= _Width || curJ < 0 || curJ >= _Height)
			return false;
			
		var curBox = _GroundBoxList[curI+curJ*_Width];
		var nextBox = _GroundBoxList[nextI+nextJ*_Width];
		if (nextBox.GetState () == State.EMPTY) {
			return false;
		}
		if (nextBox.GetState () == curBox.GetState()) {
			return false;
		}
		return true;
	}

	public enum State
	{
		EMPTY,
		BLACK,
		GRAY,
		WHITE,
	}
}
