using UnityEngine;
using System.Collections;

[System.Serializable]
public class AssemblyInstructions
{
	// Total steps that are in the instructions
	public AssemblyStep[] steps;

	// Current step
	private int currentStepNum = 0;


	public AssemblyStep CurrentStep { 
		get { return this.steps[this.currentStepNum]; }
	}


	public void SetTaskCompletedInCurrentStep (int taskNum){
		this.CurrentStep.SetTaskCompleted (taskNum);
	}
}

