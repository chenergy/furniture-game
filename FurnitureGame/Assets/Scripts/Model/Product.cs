using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Product : MonoBehaviour
{
	//public PartName partName;
	//public PartType type;
	public ProductName name;
	public GameObject startingPartPrefab;
	public AssemblyInstructions instructions;

	protected List<BasePart> attachedParts = new List<BasePart>();


	// Use this for initialization
	void Start ()
	{
		if (this.startingPartPrefab != null) {
			this.attachedParts.Add (
				(GameObject.Instantiate (this.startingPartPrefab, Vector3.zero, Quaternion.identity) as GameObject)
				.GetComponent<BasePart> ());
		}

		// Set of instructions for constructing this object
		foreach (AssemblyStep step in this.instructions.steps) {
			for (int i = 0; i < step.tasks.Length; i++) {
				AssemblyTask task = step.tasks [i];

				// Assign an int value to the task num
				task.SetTaskNum (i);
			}
		}
	}


	public void AddAttachedBasePart (BasePart basePart){
		this.attachedParts.Add (basePart);
	}


	public void AttachToSelf (IAttachable source){ }
	public void AttachToTarget (IAttachable target){ }
}

