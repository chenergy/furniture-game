using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public abstract class A_Tool : A_AttachablePart
{
	// Model of the tool to be manipulated.
	public Transform model;

	// Set the amount of time it takes for full animation.
	public float duration = 1.0f;


	public void OnClick (Button button) {
		StartCoroutine ("ToolRoutine", button);
	}
		

	public override void InteractBackward (A_AttachablePart interactPart)
	{
		//throw new System.NotImplementedException ();
	}


	public override void InteractForward (A_AttachablePart interactPart)
	{
		// Interact with the fastener.
		interactPart.InteractForward (this);
	}


	protected abstract IEnumerator ToolRoutine (Button button);
}

