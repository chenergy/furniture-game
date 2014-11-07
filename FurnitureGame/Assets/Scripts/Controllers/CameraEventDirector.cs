using UnityEngine;
using System.Collections;

public class CameraEventDirector : MonoBehaviour
{
	// Parent of the target camera. Using the parent guarantees that the camera parent not rotated.
	public GameObject cameraParent;

	// Reference to camera in order to adjust aperture attributes
	public Camera targetCamera;

	// Limits to the range that the fov can extend
	public Vector2 fovRange;




	public float GetFOV (){
		return this.targetCamera.fieldOfView;
	}

	public void SetFOV (float newFOV){
		this.targetCamera.fieldOfView = Mathf.Clamp (newFOV, this.fovRange.x, this.fovRange.y);
	}

	public void Zoom (float amount){
		this.targetCamera.fieldOfView = Mathf.Clamp (this.targetCamera.fieldOfView + amount, this.fovRange.x, this.fovRange.y);
	}

	public Vector3 GetParentRotationEuler (){
		return this.cameraParent.transform.rotation.eulerAngles;
	}

	public void SetRotation (Vector3 rotation) {
		this.cameraParent.transform.rotation = Quaternion.Euler (rotation);
	}
}

