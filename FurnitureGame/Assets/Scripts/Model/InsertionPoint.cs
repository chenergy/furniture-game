using UnityEngine;
using System.Collections;

public class InsertionPoint : MonoBehaviour, IAttachable
{
	public InsertionType type;

	//public float diameter;
	public FastenerType[] usableFasteners;


	public void AttachToSelf (IAttachable source){ }
	public void AttachToTarget (IAttachable target){ }
}