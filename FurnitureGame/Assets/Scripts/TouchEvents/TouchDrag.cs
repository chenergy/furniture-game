using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public abstract class TouchDrag : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{ 
	// Prefab object to show when dragged
	public GameObject prefabToDrag;

	// Reference to the instantiated drag object
	private GameObject draggedPrefab;



	//private Collider[] colliderResults;


	// Show that the player is interacting by creating an image.
	public void OnPointerDown (PointerEventData eventData) {
		// Create the object image that shows when dragging.
		this.draggedPrefab = GameObject.Instantiate (this.prefabToDrag, eventData.position, Quaternion.identity) as GameObject;

		// Parent it to this object (displays on the canvas).
		this.draggedPrefab.transform.parent = this.transform;
	}


	// On release, what does the player want to interact with?
	public void OnPointerUp (PointerEventData eventData) {
		// Destroy the dragged prefab.
		GameObject.Destroy (this.draggedPrefab);

		// Convert pointer screen point to ray.
		Ray ray = Camera.main.ScreenPointToRay (eventData.position);
		RaycastHit hit;

		// Check to see if a collider was hit.
		bool colliderHit = false;

		// Cast a ray to the world at the current pointer location.
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.gameObject != null) {
				// Log the name of the hit object.
				Debug.Log (hit.collider.gameObject.name);

				// Callback defined in concrete classes.
				this.OnHitCallback ();

				// A collider has been hit.
				colliderHit = true;
			}
		}

		if (!colliderHit)
			Debug.Log ("Cannot find c3d");
	}


	// Drag image with the pointer position.
	public void OnDrag (PointerEventData eventData) {
		// Reposition the dragged image to the position of the pointer.
		if (this.draggedPrefab != null)
			this.draggedPrefab.transform.position = eventData.position;
	}

	protected abstract void OnHitCallback ();
}

