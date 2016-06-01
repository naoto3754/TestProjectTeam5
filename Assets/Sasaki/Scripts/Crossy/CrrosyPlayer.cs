using UnityEngine;
using UnityEngine.SceneManagement;
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
		SetPosition (5,0);
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow) || InputManager.I.GetDistanceFromInitPos(0).x > 0.1f) {
			SetPosition(posI+1, posJ);
		}else if(Input.GetKeyDown(KeyCode.LeftArrow) || InputManager.I.GetDistanceFromInitPos(0).x < -0.1f){
			SetPosition(posI-1, posJ);
		}else if(Input.GetKeyDown(KeyCode.UpArrow) || InputManager.I.GetDistanceFromInitPos(0).y > 0.05f){
			SetPosition(posI, posJ+1);
		}else if(Input.GetKeyDown(KeyCode.DownArrow) || InputManager.I.GetDistanceFromInitPos(0).y < -0.05f){
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
		transform.DOJump(new Vector3 (i + i * GroundManager.PADDING, 1, j + j * GroundManager.PADDING),1f,1,0.15f).OnComplete(()=>{
			canMove = true;
		});
	}

	public void OnRestart()
	{
		SceneManager.LoadScene ("Crossy");
	}
}
