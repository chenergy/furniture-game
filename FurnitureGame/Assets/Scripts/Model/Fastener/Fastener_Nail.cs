using UnityEngine;
using System.Collections;

public class Fastener_Nail : A_Fastener
{
	public int maxHits = 3;

	private int curHits = 0;


	public override void InteractBackward (A_AttachablePart interactPart)
	{
		//throw new System.NotImplementedException ();
	}

	public override void InteractForward (A_AttachablePart interactPart)
	{
		//A_Tool tool = (A_Tool)interactPart;

		this.curHits++;

		this.transform.position = Vector3.Lerp (
			this.transform.position, 
			this.parentPart.transform.position, 
			(this.curHits * 1.0f / this.maxHits));

		if (this.curHits >= this.maxHits) {
			this.parentPart.InteractForward (this);
		}
	}
}

