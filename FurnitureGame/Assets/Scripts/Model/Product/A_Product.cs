using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class A_Product
{
	// Name of the product.
	public ProductName productName;

	// Instructions that the product will follow in order to be completed.
	public AssemblyInstructions instructions;

	// Reference to InGameDirector.
	public InGameDirector inGameDirector;

	// List of each base part that has been attached.
	protected List<A_Base> attachedBases = new List<A_Base>();


	// Constructor.
	public A_Product (InGameDirector inGameDirector)
	{
		// Reference to InGameDirector.
		this.inGameDirector = inGameDirector;
	}


	// Transition to the next step.
	public void StartStep (){
		this.instructions.StartCurrentStep ();
	}


	// Assign reference to given instructions created.
	protected virtual void InitAssemblyInstructions (AssemblyInstructions instructions){
		// Store the instruction set.
		this.instructions = instructions;
	}


	// Set a task as completed.
	public void CheckTaskCompletion (PartName sourcePart, string sourceId, PartName targetPart, string targetId, InteractionEvent iEvent) {
		if (this.instructions.HasCompletedTask (sourcePart, sourceId, targetPart, targetId, iEvent)) {
			Debug.Log ("Completed Task!");
		}
	}
}

