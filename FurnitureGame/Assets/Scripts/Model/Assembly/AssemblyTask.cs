using UnityEngine;
using System.Collections;


public class AssemblyTask {
	// Stored part that has been instantiated. Target part will interact with it.
	private PartName sourcePart;

	// Assigned id (element in list of steps) assigned to the source part.
	private string sourceId;

	// The part (typically a new one) that needs to interact with the source part.
	private PartName targetPart;

	// Assigned id (element in list of steps) assigned to the target part.
	private string targetId;

	// Interaction that needs to occur;
	private InteractionEvent interactionEvent = InteractionEvent.NONE;

	// The target collider that needs to be interacted with.
	private A_AttachablePart partInstance;
		
	// Is the task completed?
	private bool isCompleted = false;
	public bool IsCompleted { 
		get { return this.isCompleted; }
	}



	// Constructor.
	public AssemblyTask (PartName sourcePart, string sourceId, PartName targetPart, string targetId, InteractionEvent iEvent) {
		this.sourcePart = sourcePart;
		this.targetPart = targetPart;
		this.sourceId = sourceId;
		this.targetId = targetId;
		this.interactionEvent = iEvent;
	}


	public bool HasCompletedTask (PartName sourcePart, string sourceId, PartName targetPart, string targetId, InteractionEvent iEvent) {
		if (this.sourcePart == sourcePart
		    && this.sourceId == sourceId
		    && this.targetPart == targetPart
		    && this.targetId == targetId
		    && this.interactionEvent == iEvent) {
			this.isCompleted = true;
			return true;
		}

		return false;
	}

	// When task is finished, set it as completed.
	/*public void SetTaskAsCompleted () {
		this.isCompleted = true;
	}*/
}

