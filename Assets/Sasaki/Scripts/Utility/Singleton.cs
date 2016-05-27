using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
	protected static T instance;
	public static T I {
		get {
			if (instance == null) {
				instance = (T)FindObjectOfType (typeof(T));

				if (instance == null) {
					Debug.LogWarning (typeof(T) + "is nothing");
				}
			}

			return instance;
		}
	}

	void Awake()
	{
		Init ();
	}

	protected virtual void Init()
	{
		CheckInstance();
	}

	protected bool CheckInstance()
	{
		if( instance == null)
		{
			instance = (T)this;
			return true;
		}else if( I == this )
		{
			return true;
		}

		Destroy(this);
		return false;
	}
}