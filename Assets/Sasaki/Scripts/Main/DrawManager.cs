using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawManager : Singleton<DrawManager>
{
	[SerializeField]
	private GameObject _DrawUnit;
	[SerializeField]
	private LineRenderer _DummyLine;

	private List<GameObject> _UnitList = new List<GameObject>();
	private Plane _DrawPlane;
	private Vector3 _PrevPos;


	protected override void Init ()
	{
		base.Init ();
		_DrawPlane = new Plane (Vector3.back,Vector3.zero);
	}

	void Update() {

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float rayDistance;
		if (_DrawPlane.Raycast (ray, out rayDistance)) {
			Vector3 pos = ray.GetPoint (rayDistance);

			if (Input.GetMouseButtonDown (0)) {
				_DummyLine.enabled = true;
				_PrevPos = pos;
			} else if (Input.GetMouseButton (0)) {
				_DummyLine.SetPosition (0, _PrevPos);
				_DummyLine.SetPosition (1, pos);
			} else if (Input.GetMouseButtonUp(0)) {
			 	_DummyLine.enabled = false;
				for (float t = 0f; t <= 1f; t += 0.1f/Vector3.Distance(pos, _PrevPos)) {
					Vector3 spPos = Vector3.Lerp (_PrevPos, pos, t);
					GameObject unit = Instantiate (_DrawUnit, spPos, _DrawUnit.transform.rotation) as GameObject;
					_UnitList.Add (unit);
					if (_UnitList.Count > 400) {
						var target = _UnitList [0];
						_UnitList.RemoveAt (0);
						Destroy (target);
					}
				}
			}
		}
	}
}
