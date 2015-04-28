using UnityEngine;
using System.Collections;


public enum PartType {
	NONE,
	TOOL,
	BASE,
	FASTENER,
	INSERTION_POINT,
	JOINT
};

public enum PartName {
	NONE,
	PLANK,
	NAIL,
	HOLE_NAIL,
	HAMMER
};

public enum ProductName {
	NONE,
	MALM_BENCH
};


public enum InteractionEvent {
	NONE,
	ATTACH,
	INSERT
};

