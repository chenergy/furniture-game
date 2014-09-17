using UnityEngine;
using System.Collections;

public abstract class A_FurniturePart : MonoBehaviour
{
	public string partName;
	public float weightKg;
	public Vector3 dimensions;
	public Transform[] attachmentPoints;

	protected A_FurniturePart[] attachedParts;

	// Use this for initialization
	void Start ()
	{
		this.attachedParts = new A_FurniturePart[this.attachmentPoints.Length];
	}
}

