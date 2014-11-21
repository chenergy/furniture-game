using UnityEngine;
using System.Collections;

interface IInteractable
{
	void InteractForward (A_AttachablePart interactPart);
	void InteractBackward (A_AttachablePart interactPart);
}

