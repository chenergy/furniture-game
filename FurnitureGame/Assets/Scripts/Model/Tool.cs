using UnityEngine;
using System.Collections;

public class Tool : MonoBehaviour, IAttachable
{
	public ToolType type;
	public FastenerType[] usableFasteners;

	public void AttachToSelf (IAttachable source){ }
	public void AttachToTarget (IAttachable target){ }
}

