using UnityEngine;
using System.Collections;

public class Product_MalmBench : A_Product
{
	// Constructor.
	public Product_MalmBench (InGameDirector inGameDirector) 
		: base (inGameDirector) {

		// Get reference to starting prefab.
		GameObject startingPrefab = inGameDirector.GetProductPrefab (PartName.PLANK);

		// Create necessary tasks, steps, and instructions.
		AssemblyTask task1 = new AssemblyTask (PartType.FASTENER);
		AssemblyStep step1 = new AssemblyStep ();
		AssemblyInstructions instructions = new AssemblyInstructions();

		// Build assembly instructions tree.
		step1.AddTask (task1);
		instructions.AddStep (step1);

		// Initialize the starting prefab.
		this.InitStartingPrefab (startingPrefab);

		// Initizalize the assembly instructions.
		this.InitAssemblyInstructions (instructions);
	}
}

