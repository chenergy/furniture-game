using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class Touch_Drag : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
	public GameObject prefab;

	private GameObject draggedPrefab;
	private Collider[] colliderResults;


	public void OnPointerDown (PointerEventData eventData) {
		this.draggedPrefab = GameObject.Instantiate (this.prefab, eventData.position, Quaternion.identity) as GameObject;
		this.draggedPrefab.transform.parent = this.transform;
	}

	public void OnPointerUp (PointerEventData eventData) {
		GameObject.Destroy (this.draggedPrefab);

		Ray ray = Camera.main.ScreenPointToRay (eventData.position);
		RaycastHit hit;
		bool created = false;

		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.gameObject != null) {
				Debug.Log (hit.collider.gameObject.name);
				created = true;
			}
		}

		if (!created)
			Debug.Log ("Cannot find c3d");
	}

	public void OnDrag (PointerEventData eventData) {
		if (this.draggedPrefab != null)
			this.draggedPrefab.transform.position = eventData.position;
	}
}

