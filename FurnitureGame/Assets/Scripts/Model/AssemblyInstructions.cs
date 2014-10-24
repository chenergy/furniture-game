using UnityEngine;
using System.Collections;

[System.Serializable]
public class AssemblyTask {
	public Collider targetCollider;
	public A_Part partToAttach;
}


[System.Serializable]
public class AssemblyStep {
	public AssemblyTask[] tasks;
	private int currentTaskNum = 0;

	public AssemblyTask CurrentTask {
		get { return this.tasks[this.currentTaskNum]; }
	}
}

public class AssemblyInstructions : MonoBehaviour
{
	public AssemblyStep[] steps;
	private int currentStepNum = 0;

	public AssemblyStep CurrentStep {
		get { return this.steps[this.currentStepNum]; }
	}
}

