using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AssemblyStep {
	// Step-internal class that creates an object at a given transform.
	private class StartAction
	{
		public GameObject prefabToCreate;
		public Vector3 targetPosition;
		public Quaternion targetRotation;

		public StartAction (GameObject prefabToCreate, Vector3 targetPosition, Quaternion targetRotation) {
			this.prefabToCreate = prefabToCreate;
			this.targetPosition = targetPosition;
			this.targetRotation = targetRotation;
		}
	}

	// GameObjects to instantiate at the beginning of the step.
	private List<StartAction> startActions = new List<StartAction> ();

	// Tasks that need to be completed in this step
	private List<AssemblyTask> tasks = new List<AssemblyTask> ();


	// Constructor.
	public AssemblyStep () { }


	// Startup actions when beginning a new step.
	public void StartStep (){
		// Create all starting objects assigned to this step.
		foreach (StartAction action in this.startActions) {
			GameObject.Instantiate (action.prefabToCreate, action.targetPosition, action.targetRotation);
		}
	}


	// Add a task to list of tasks.
	public void AddTask (AssemblyTask task){
		this.tasks.Add (task);
	}
		

	// Add a start action to be done at the beginning of the step.
	public void AddStartPart (GameObject prefabToCreate, Vector3 targetPosition, Quaternion targetRotation){
		this.startActions.Add (new StartAction (prefabToCreate, targetPosition, targetRotation));
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

