using UnityEngine;
using System.Collections;

public abstract class A_Base : A_AttachablePart
{
	public float weightKg = 1.0f;
	public Vector3 dimensions;
	public GameObject holePrefab;
	public Transform[] holePoints;


	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < this.holePoints.Length; i++) {
			Transform t = this.holePoints [i];

			GameObject newHole = GameObject.Instantiate (this.holePrefab) as GameObject;
			newHole.transform.parent = t;
			newHole.transform.localPosition = Vector3.zero;
			newHole.transform.localRotation = Quaternion.identity;

			A_AttachablePart part = newHole.GetComponent<A_AttachablePart> ();
			if (part != null) {
				part.AssignTaskId (i.ToString ());
			}
		}
	}
}

