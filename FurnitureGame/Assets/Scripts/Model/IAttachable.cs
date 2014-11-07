using UnityEngine;
using System.Collections;

public interface IAttachable{
	void AttachToSelf (IAttachable source);
	void AttachToTarget (IAttachable target);
}

