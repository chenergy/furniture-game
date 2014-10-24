using UnityEngine;
using System.Collections;

public class FurniturePart : A_Part
{
	public float weightKg;
	public Vector3 dimensions;
	public Transform[] attachmentPoints;

	protected FurniturePart[] attachedParts;

	// Use this for initialization
	protected override void Start ()
	{
		this.attachedParts = new FurniturePart[this.attachmentPoints.Length];
	}
}

