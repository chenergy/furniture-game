using UnityEngine;
using System.Collections;

public class Product_MalmBench : A_Product
{
	// Constructor.
	public Product_MalmBench (InGameDirector inGameDirector) 
		: base (inGameDirector) {

		// Create necessary tasks, steps, and instructions.
		AssemblyTask task1 = new AssemblyTask (PartName.NAIL, "00", PartName.HOLE_NAIL, "0", InteractionEvent.INSERT);
		AssemblyTask task2 = new AssemblyTask (PartName.NAIL, "10", PartName.HOLE_NAIL, "1", InteractionEvent.INSERT);
		AssemblyTask task3 = new AssemblyTask (PartName.NAIL, "20", PartName.HOLE_NAIL, "2", InteractionEvent.INSERT);
		AssemblyTask task4 = new AssemblyTask (PartName.NAIL, "30", PartName.HOLE_NAIL, "3", InteractionEvent.INSERT);
		AssemblyStep step1 = new AssemblyStep ();
		AssemblyInstructions instructions = new AssemblyInstructions();

		// Build assembly instructions tree.
		step1.AddTask (task1);
		step1.AddTask (task2);
		step1.AddTask (task3);
		step1.AddTask (task4);

		// Get reference to starting prefab for step 1.
		GameObject startingPrefab = inGameDirector.GetProductPrefab (PartName.PLANK);

		// Tell step to create it.
		step1.AddStartPart (startingPrefab, Vector3.zero, Quaternion.identity);

		// Add step to set of instructions.
		instructions.AddStep (step1);

		// Initizalize the assembly instructions.
		this.InitAssemblyInstructions (instructions);
	}
}

