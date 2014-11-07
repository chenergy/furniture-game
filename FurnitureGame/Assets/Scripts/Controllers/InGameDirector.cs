using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InGameDirector : MonoBehaviour
{
	// Current target
	public GameObject target;

	// Set of instructions for constructing this object
	public AssemblyInstructions instructions;


	//private GameObject partToCreatePrefab;

	void Start (){
		GameDirector.Instance.InGameController = this;
	}


	public void DragInstantiate (GameObject objectToCreate, Collider targetCollider){
		//Debug.Log ("drag instantiate");
		//GameObject.Instantiate (gobj, Vector3.zero, Quaternion.identity);
		A_Part partToCreate = objectToCreate.GetComponent<A_Part> ();

		if (partToCreate != null) {
			foreach (AssemblyTask task in this.instructions.CurrentStep.tasks) {
				A_Part taskPart = task.partToAttachPrefab.GetComponent<A_Part> ();

				if (task.targetCollider == targetCollider && taskPart.partName == partToCreate.partName) {
					GameObject gobj = GameObject.Instantiate (objectToCreate, Vector3.zero, Quaternion.identity) as GameObject;
					gobj.collider.enabled = false;
					gobj.transform.Rotate (0f, 0f, 90f);
					gobj.transform.parent = target.transform;
					Debug.Log ("object creation successful");
				} else {
					Debug.Log (task.targetCollider);
					Debug.Log (targetCollider);
					Debug.Log (taskPart.partName);
					Debug.Log (partToCreate.partName);
					Debug.Log ("object creation failed");
				}
			}
		}
	}


	public void TouchEvent (string name){
		//Debug.Log ("touch event");
	}


	/*public void SelectedPart (GameObject part){
		this.partToCreatePrefab = part;
	}*/
}

