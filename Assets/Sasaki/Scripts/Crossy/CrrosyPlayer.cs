using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CrrosyPlayer : MonoBehaviour 
{
	public bool canMove {
		get; set;
	}
	public int posI {
		get; set;
	}
	public int posJ {
		get; set;
	}

	void Awake()
	{
		canMove = true;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			SetPosition(posI+1, posJ);
		}else if(Input.GetKeyDown(KeyCode.LeftArrow)){
			SetPosition(posI-1, posJ);
		}else if(Input.GetKeyDown(KeyCode.UpArrow)){
			SetPosition(posI, posJ+1);
		}else if(Input.GetKeyDown(KeyCode.DownArrow)){
			SetPosition(posI, posJ-1);
		}

	}

	private void SetPosition(int i, int j)
	{
		if (canMove == false)
			return;

		if (GroundManager.I.CanMove (posI, posJ, i, j) == false) {
			return;
		}

		canMove = false;
		posI = i;
		posJ = j;
//		transform.position = new Vector3 (i + i * GroundManager.PADDING, 1, j + j * GroundManager.PADDING);
		transform.DOJump(new Vector3 (i + i * GroundManager.PADDING, 1, j + j * GroundManager.PADDING),1f,1,0.15f).OnComplete(()=>{
			canMove = true;
		});
	}
}
