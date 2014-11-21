using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tool_Hammer : A_Tool
{
	// Move the target model like a hammer.
	protected override IEnumerator ToolRoutine (Button button){
		// Make the button unable to be interacted with.
		button.interactable = false;

		// Set initial rotation to 0.
		this.model.localRotation = Quaternion.Euler (Vector3.zero);

		// Cause interaction halfway through.
		bool hasActivated = false;

		// Rotate the hammer in z from it's initial rotation to 90, and back up again.
		float timer = 0.0f;
		while (timer < this.duration){
			yield return new WaitForEndOfFrame ();

			// Lerp from -90 to 90.
			float lerpValue = Mathf.Lerp (-90.0f, 90.0f, (timer / this.duration));

			// Z-rotation based on the lerp value.
			float targetZ = 90.0f - Mathf.Abs (lerpValue);

			// Assign the rotation.
			this.model.localRotation = Quaternion.Euler (0, 0, targetZ);

			// When lerp passes 0, make the hammer interact with the nail once.
			if (lerpValue > 0 && !hasActivated) {
				hasActivated = true;

				if (this.parentPart != null)
					this.InteractForward (this.parentPart);
			}

			timer += Time.deltaTime;
		}

		// Reset initial rotation.
		this.model.localRotation = Quaternion.Euler (Vector3.zero);

		// Make the button interactable again.
		button.interactable = true;
	}
}

