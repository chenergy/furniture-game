using UnityEngine;
using System.Collections;


[System.Serializable]
public class AssemblyTask {
	// The part that needs to be attached to the collider
	public FastenerType fastenerTypeNeeded;

	// The target collider that needs to be interacted with
	private Collider targetCollider;
	public Collider TargetCollider { 
		get { return this.targetCollider; } 
		set { this.targetCollider = value; } 
	}

	// Assigned number of task in the parent step list of steps
	private int taskNum;
	public int TaskNum { get { return this.taskNum; } }

	// Is the task completed?
	private bool isCompleted = false;
	public bool IsCompleted { get { return this.isCompleted; } }

	// Set task number by parent step
	public void SetTaskNum (int num) {
		this.taskNum = num;
	}

	// When task is finished, set it as completed
	public void SetTaskAsCompleted () {
		this.isCompleted = true;
	}
}

