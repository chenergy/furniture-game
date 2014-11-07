using UnityEngine;
using System.Collections;


[System.Serializable]
public class AssemblyStep {
	// Tasks that need to be completed in this step
	public AssemblyTask[] tasks;

	// Given a task number, set it as completed
	public void SetTaskCompleted (int taskNum){
		this.tasks [taskNum].SetTaskAsCompleted ();
	}
}

