using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AssemblyStep {
	// Tasks that need to be completed in this step
	private List<AssemblyTask> tasks = new List<AssemblyTask> ();


	// Constructor.
	public AssemblyStep () { }



	// Startup actions when beginning a new step.
	public void StartStep (){

	}


	// Add a task to list of tasks.
	public void AddTask (AssemblyTask task){
		this.tasks.Add (task);
	}
		

	// Check tasks to see if completed.
	public bool HasCompletedTask (PartName sourcePart, string sourceId, PartName targetPart, string targetId, InteractionEvent iEvent) {
		foreach (AssemblyTask task in this.tasks) {
			if (task.HasCompletedTask (sourcePart, sourceId, targetPart, targetId, iEvent)) {
				return true;
			}
		}

		return false;
	}


	// Given a task number, set it as completed.
	/*public void SetTaskCompleted (int taskId){
		this.tasks [taskId].SetTaskAsCompleted ();
	}*/


	// Check if all tasks have been completed in step.
	private bool IsStepCompleted (){
		// Check each task for completion.
		foreach (AssemblyTask task in this.tasks) {
			// Return false if one task is not completed.
			if (!task.IsCompleted) 
				return false;
		}

		// Return true if all tasks have passed.
		return true;
	}
}

