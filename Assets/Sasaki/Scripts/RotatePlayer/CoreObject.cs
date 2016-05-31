using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CoreObject : MonoBehaviour 
{

	void OnTriggerEnter2D(Collider2D coll) {
		SceneManager.LoadScene ("RotatePlayer");
	}
}
