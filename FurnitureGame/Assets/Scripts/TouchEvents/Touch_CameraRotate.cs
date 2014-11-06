using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Touch_CameraRotate : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	// Parent of the target camera. Using the parent guarantees that the camera parent not rotated
	public GameObject cameraParent;

	// Reference to camera in order to adjust aperture attributes
	public Camera targetCamera;

	// Amount of rotation depending on delta of new and old points
	public float rotationRate = 1.0f;

	// Amount of zoom depending on delta of current simultaneous points
	public float zoomRate = 1.0f;

	// Initial touch screen point
	private Vector3 startScreenPoint;

	// Initial rotation on initial touch
	private Vector3 startRotationEuler;

	private Vector2 touch1;
	private Vector2 touch2;
	private Vector2 startTouchDelta;
	private float startFOV;


	public void OnPointerDown (PointerEventData eventData){
		if (this.cameraParent != null){
			// Set the first touch down position
			this.startScreenPoint = eventData.position;

			// Set the initial rotation of the camera parent
			this.startRotationEuler = this.cameraParent.transform.rotation.eulerAngles;
		}
	}

	public void OnPointerUp (PointerEventData eventData){
		this.touch1 = this.touch2 = this.startTouchDelta = Vector2.zero;
		this.startFOV = 0.0f;
	}

	public void OnDrag (PointerEventData eventData){
		// If two touch, pinch to zoom
		if (Input.touchCount > 1) {
			if (this.startTouchDelta == Vector2.zero) {
				this.startTouchDelta = this.touch2 - this.touch1;
				this.startFOV = this.targetCamera.fieldOfView;
			} else {
				Vector2 newTouchDelta = Input.touches [1].position - Input.touches [0].position;
				this.targetCamera.fieldOfView = this.startFOV + (newTouchDelta.magnitude - this.startTouchDelta.magnitude) * this.zoomRate;
			}
		} 

		// Otherwise rotate the camera
		else {
			if (this.cameraParent != null) {
				// Get the amount of rotation
				Vector3 touchRotation = new Vector3 (eventData.position.x - this.startScreenPoint.x, 
					                       eventData.position.y - this.startScreenPoint.y);

				// Get normal
				touchRotation = new Vector3 (touchRotation.y * -1, touchRotation.x);

				// Rotate based on amount of rotation
				Vector3 newRotation = new Vector3 (touchRotation.x * this.rotationRate, touchRotation.y * this.rotationRate, 0);

				// Rotate the camera based on the new rotation
				this.cameraParent.transform.rotation = Quaternion.Euler (this.startRotationEuler + newRotation);

				Debug.Log (this.cameraParent.transform.rotation.ToString ());
			}
		}
	}
}

