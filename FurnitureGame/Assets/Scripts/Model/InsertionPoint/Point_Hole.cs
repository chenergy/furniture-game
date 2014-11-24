using UnityEngine;
using System.Collections;

public class Point_Hole : A_InsertionPoint
{
	public override void InteractForward (A_AttachablePart interactPart)
	{
		//base.InteractForward (interactPart);
		GameDirector.Instance.InGameDirector.OnInteractionEvent (interactPart.partName, interactPart.TaskId, this.partName, this.taskId, InteractionEvent.INSERT);
	}

	public override void InteractBackward (A_AttachablePart interactPart)
	{
		//base.InteractBackward (interactPart);
	}
}

