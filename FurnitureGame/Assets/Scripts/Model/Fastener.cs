using UnityEngine;
using System.Collections;

public class Fastener : MonoBehaviour, IAttachable
{
	public FastenerType type;
	public ToolType[] usableTools;


	public void AttachToSelf (IAttachable source){ }
	public void AttachToTarget (IAttachable target){ }
}

