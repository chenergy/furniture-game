using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class Touch_Drag : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{ 
	// Prefab object to show when dragged
	public GameObject prefabToDrag;

	// Reference to the instantiated drag object
	private GameObject draggedPrefab;

	//private Collider[] colliderResults;


	public void OnPointerDown (PointerEventData eventData) {
		// Create the object image that shows when dragging
		this.draggedPrefab = GameObject.Instantiate (this.prefabToDrag, eventData.position, Quaternion.identity) as GameObject;

		// Parent it to this object (displays on the canvas)
		this.draggedPrefab.transform.parent = this.transform;
	}

	public void OnPointerUp (PointerEventData eventData) {
		// Destroy the dragged prefab
		GameObject.Destroy (this.draggedPrefab);

		// Cast a ray to the world at the current pointer location
		Ray ray = Camera.main.ScreenPointToRay (eventData.position);
		RaycastHit hit;

		// Check to see if a collider was hit
		bool colliderHit = false;

		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.gameObject != null) {
				// Log the name of the hit object
				this.LogObjectName (hit.collider.gameObject.name);

				// A collider has been hit
				colliderHit = true;
			}
		}

		if (!colliderHit)
			Debug.Log ("Cannot find c3d");
	}

	public void OnDrag (PointerEventData eventData) {
		// Reposition the dragged image to the position of the pointer
		if (this.draggedPrefab != null)
			this.draggedPrefab.transform.position = eventData.position;
	}

	private void LogObjectName (string name){
		Debug.Log (name);
	}
}

