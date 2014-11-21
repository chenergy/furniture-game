using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TouchCameraRotate : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	// Reference to CameraEventDirection
	public CameraEventDirector cameraEventDirector;

	// Amount of rotation depending on delta of new and old points
	public float rotationRate = 1.0f;

	// Amount of zoom depending on delta of current simultaneous points
	public float zoomRate = 1.0f;

	// Initial touch screen point
	private Vector3 startScreenPoint;

	// Initial rotation on initial touch
	private Vector3 startRotationEuler;

	// Initial difference between 2 touches
	private Vector2 startTouchDelta;

	// Initial fov saved on initial touch
	private float startFOV;


	public void OnPointerDown (PointerEventData eventData){
		if (this.cameraEventDirector != null){
			// Set the first touch down position.
			this.startScreenPoint = eventData.position;

			// Set the initial rotation of the camera parent.
			this.startRotationEuler = this.cameraEventDirector.GetParentRotationEuler ();
		}
	}


	public void OnPointerUp (PointerEventData eventData){
		// Init delta between 2 touches as zero
		this.startTouchDelta = Vector2.zero;

		// Init FOV as zero
		this.startFOV = 0.0f;
	}


	public void OnDrag (PointerEventData eventData){
		// If two touch, pinch to zoom
		if (Input.touchCount > 1) {
			if (this.startTouchDelta == Vector2.zero) {
				// If not yet set (0,0,0), set delta to the difference between 2 touches
				this.startTouchDelta = Input.touches [1].position - Input.touches [0].position;

				// If not yet set (0), set fov to the camera fov
				this.startFOV = this.cameraEventDirector.GetFOV ();
			} else {
				// Get the new delta between two touches
				Vector2 newTouchDelta = Input.touches [1].position - Input.touches [0].position;

				// Set new fov as the difference between new and start deltas
				this.cameraEventDirector.SetFOV (this.startFOV - (newTouchDelta.magnitude - this.startTouchDelta.magnitude) * this.zoomRate);
			}
		} 

		// Otherwise rotate the camera
		else {
			if (this.cameraEventDirector != null) {
				// Get the amount of rotation.
				Vector3 touchRotation = new Vector3 (eventData.position.x - this.startScreenPoint.x, 
					                       eventData.position.y - this.startScreenPoint.y);

				// Get normal.
				touchRotation = new Vector3 (touchRotation.y * -1, touchRotation.x);

				// Rotate based on amount of rotation.
				Vector3 newRotation = new Vector3 (touchRotation.x * this.rotationRate, touchRotation.y * this.rotationRate, 0);

				// Rotate the camera based on the new rotation.
				this.cameraEventDirector.SetRotation (this.startRotationEuler + newRotation);

				//Debug.Log (this.cameraEventDirector.cameraParent.transform.rotation.ToString ());
			}
		}
	}
}

