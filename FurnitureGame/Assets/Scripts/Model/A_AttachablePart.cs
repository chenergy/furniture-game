using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class A_AttachablePart : MonoBehaviour, IAttachable, IInteractable
{
	// Classification for the part.
	public PartType type;

	// Name of the part.
	public PartName partName;

	// Where objects that want to attach to the part will be attached.
	public Transform attachTransform;

	// List of parts that can be attached to it.
	public List<PartType> attachableToSelf = new List<PartType> ();

	// List of parts that it can attach to.
	public List<PartType> attachableToTarget = new List<PartType> ();

	// If applicable, the parent part that it has been attached from.
	protected A_AttachablePart parentPart;

	// TaskId assigned by the task during each step.
	protected int taskId;



	// Assign a taskId.
	public void AssignTaskId (int taskId){
		this.taskId = taskId;
	}


	// Attach this part to a parent part based on the transform.
	public virtual void AttachTo (A_AttachablePart parentPart) {
		// Retain reference to passed part.
		this.parentPart = parentPart;

		// Parent self to passed transform.
		this.transform.parent = parentPart.transform;

		// Match the position and rotation of the passed part.
		if (parentPart.attachTransform != null) {
			this.transform.position = parentPart.attachTransform.position;
			this.transform.rotation = parentPart.attachTransform.rotation;
		}

		// Prevent other targets from colliding with it.
		this.parentPart.collider.enabled = false;
	}


	public void Remove (){
		// Re-enable the parent's collider because child has been removed.
		// This assumes 1 parent 1 child, which will need to be revised.
		if (this.parentPart != null)
			this.parentPart.collider.enabled = true;

		GameObject.Destroy (this.gameObject);
	}


	public abstract void InteractForward (A_AttachablePart interactPart);
	public abstract void InteractBackward (A_AttachablePart interactPart);
}

