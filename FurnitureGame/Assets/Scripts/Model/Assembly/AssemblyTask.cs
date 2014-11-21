using UnityEngine;
using System.Collections;


public class AssemblyTask {
	// Stored part to create, instantiated at beginning of new step.
	private PartName partToCreate;

	// The part that needs to be attached to the collider.
	private PartType partTypeRequired;

	// Assigned id (element in list of steps) assigned to the part
	private int taskId;

	// The target collider that needs to be interacted with.
	private A_AttachablePart partInstance;
		
	// Is the task completed?
	private bool isCompleted = false;
	public bool IsCompleted { 
		get { return this.isCompleted; }
	}




	// Constructor.
	/*public AssemblyTask (PartName partToCreate, PartType partTypeRequired, int taskId) {
		this.partToCreate = partToCreate;
		this.partTypeRequired = partTypeRequired;
		this.taskId = taskId;
	}*/

	public AssemblyTask (PartType partTypeRequired) {
		this.partTypeRequired = partTypeRequired;
	}


	// When task is finished, set it as completed.
	public void SetTaskAsCompleted () {
		this.isCompleted = true;
	}
}

