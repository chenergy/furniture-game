using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AssemblyInstructions
{
	// List of steps that are in the instructions.
	public List<AssemblyStep> steps = new List<AssemblyStep> ();

	// Current step being checked.
	private int currentStepNum = 0;
	public int CurrentStepNum { 
		get { return this.currentStepNum; }
	}

	// Get current step based on step number.
	/*public AssemblyStep CurrentStep { 
		get { return this.steps[this.currentStepNum]; }
	}*/


	// Constructor.
	public AssemblyInstructions (){ }


	// Add step to list of steps.
	public void AddStep (AssemblyStep step){
		this.steps.Add (step);
	}


	// Perform the startup actions of the current step.
	public void StartCurrentStep (){
		this.steps [this.currentStepNum].StartStep ();
	}


	// Check if the task with the given criteria has been completed.
	public bool HasCompletedTask (PartName sourcePart, string sourceId, PartName targetPart, string targetId, InteractionEvent iEvent) {
		return this.steps[this.currentStepNum].HasCompletedTask (sourcePart, sourceId, targetPart, targetId, iEvent);
	}

	// Set a task as completed given a task number.
	/*public void SetTaskCompletedInCurrentStep (int taskNum){
		// Find and set the task as completed in the current step.
		this.CurrentStep.SetTaskCompleted (taskNum);

		// Test for step completion.
	}*/
}

