using UnityEngine;
using System.Collections;

[System.Serializable]
public class AssemblyTask {
	// The target collider that needs to be interacted with
	public Collider2D targetCollider;

	// The part that needs to be attached to the collider
	public GameObject partToAttachPrefab;
}


[System.Serializable]
public class AssemblyStep {
	// Tasks that need to be completed in this step
	public AssemblyTask[] tasks;

	/*private int currentTaskNum = 0;

	public AssemblyTask CurrentTask {
		get { return this.tasks[this.currentTaskNum]; }
	}*/
}

public class AssemblyInstructions : MonoBehaviour
{
	// Total steps that are in the instructions
	public AssemblyStep[] steps;

	// Current step
	private int currentStepNum = 0;

	public AssemblyStep CurrentStep {
		get { return this.steps[this.currentStepNum]; }
	}
}

