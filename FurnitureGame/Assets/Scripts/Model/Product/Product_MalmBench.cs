using UnityEngine;
using System.Collections;

public class Product_MalmBench : A_Product
{
	// Constructor.
	public Product_MalmBench (InGameDirector inGameDirector) 
		: base (inGameDirector) {

		// Create necessary tasks, steps, and instructions.
		AssemblyTask task1 = new AssemblyTask (PartName.NAIL, "00", PartName.NAIL_HOLE, "0", InteractionEvent.INSERT);
		AssemblyTask task2 = new AssemblyTask (PartName.NAIL, "10", PartName.NAIL_HOLE, "1", InteractionEvent.INSERT);
		AssemblyTask task3 = new AssemblyTask (PartName.NAIL, "20", PartName.NAIL_HOLE, "2", InteractionEvent.INSERT);
		AssemblyTask task4 = new AssemblyTask (PartName.NAIL, "30", PartName.NAIL_HOLE, "3", InteractionEvent.INSERT);
		AssemblyStep step1 = new AssemblyStep ();
		AssemblyInstructions instructions = new AssemblyInstructions();

		// Build assembly instructions tree.
		step1.AddTask (task1);
		step1.AddTask (task2);
		step1.AddTask (task3);
		step1.AddTask (task4);

		// Get reference to starting prefab for step 1.
		GameObject startingPrefab = inGameDirector.GetProductPrefab (PartName.PLANK);

		step1.AddStartPart (startingPrefab, Vector3.zero, Quaternion.identity);

		instructions.AddStep (step1);

		// Initialize the starting prefab.
		//this.InitStartingPrefab (startingPrefab);

		// Initizalize the assembly instructions.
		this.InitAssemblyInstructions (instructions);
	}
}

