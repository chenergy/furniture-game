using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InGameController : MonoBehaviour
{
	public GameObject target;
	public AssemblyInstructions instructions;

	private static InGameController instance = null;


	public static InGameController Instance {
		get { return InGameController.instance; }
	}

	void Awake (){
		if (instance == null){
			DontDestroyOnLoad(this);
			instance = this;
		} else {
			Destroy(this.gameObject);
		}
	}

	public void DragInstantiate (GameObject objectToCreate, Collider targetCollider){
		//Debug.Log ("drag instantiate");
		//GameObject.Instantiate (gobj, Vector3.zero, Quaternion.identity);
		A_Part part = objectToCreate.GetComponent<A_Part> ();

		if (part != null) {
			foreach (AssemblyTask task in this.instructions.CurrentStep.tasks) {
				if (task.targetCollider == targetCollider && task.partToAttach.partName == part.partName) {
					GameObject gobj = GameObject.Instantiate (objectToCreate, Vector3.zero, Quaternion.identity) as GameObject;
					gobj.collider.enabled = false;
					gobj.transform.Rotate (0f, 0f, 90f);
					gobj.transform.parent = target.transform;
					Debug.Log ("object creation successful");
				} else {
					Debug.Log (task.targetCollider);
					Debug.Log (targetCollider);
					Debug.Log (task.partToAttach.partName);
					Debug.Log (part.partName);
					Debug.Log ("object creation failed");
				}
			}
		}
	}

	public void TouchEvent (string name){
		//Debug.Log ("touch event");
	}
}

