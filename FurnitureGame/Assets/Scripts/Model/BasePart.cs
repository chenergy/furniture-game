using UnityEngine;
using System.Collections;

public class BasePart : MonoBehaviour, IAttachable
{
	//public float weightKg = 1.0f;
	//public Vector3 dimensions;
	public BasePartType type;
	public GameObject holePrefab;
	public Transform[] holePoints;


	// Use this for initialization
	void Start ()
	{
		foreach (Transform t in this.holePoints) {
			GameObject newHole = GameObject.Instantiate (this.holePrefab) as GameObject;
			newHole.transform.parent = t;
			newHole.transform.localPosition = Vector3.zero;
			newHole.transform.localRotation = Quaternion.identity;
		}
	}
	
	public void AttachToSelf (IAttachable source){ }
	public void AttachToTarget (IAttachable target){ }
}

