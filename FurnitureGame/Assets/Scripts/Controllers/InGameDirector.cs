using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InGameDirector : MonoBehaviour
{
	// Current target
	//public GameObject target;
	public ProductName productToCreate;
	public GameObject[] productPrefabs;

	private Product productInstance;
	private Dictionary <ProductName, GameObject> productDictionary;


	void Start (){
		GameDirector.Instance.InGameController = this;

		this.productDictionary = new Dictionary<ProductName, GameObject> ();

		foreach (GameObject prefab in this.productPrefabs) {
			this.productDictionary.Add ((ProductName)System.Enum.Parse (typeof(ProductName), prefab.name), prefab);
		}

		if (this.productDictionary.ContainsKey (this.productToCreate)) {
			this.productInstance = (GameObject.Instantiate (this.productDictionary [this.productToCreate], Vector3.zero, Quaternion.identity) as GameObject)
			.GetComponent<Product> ();
		}
	}


	/*public void BuildPart (GameObject part){

	}*/


	/*public void DragInstantiate (GameObject objectToCreate, Collider targetCollider){
		A_Part partToCreate = objectToCreate.GetComponent<A_Part> ();

		if (partToCreate != null) {
			foreach (AssemblyTask task in this.instructions.CurrentStep.tasks) {
				if (task.targetCollider == targetCollider && task.partToAttachName == partToCreate.partName) {
					GameObject gobj = GameObject.Instantiate (objectToCreate, Vector3.zero, Quaternion.identity) as GameObject;
					gobj.collider.enabled = false;
					gobj.transform.Rotate (0f, 0f, 90f);
					gobj.transform.parent = target.transform;
					Debug.Log ("object creation successful");
				} else {
					Debug.Log (task.targetCollider);
					Debug.Log (targetCollider);
					Debug.Log (task.partToAttachName);
					Debug.Log (partToCreate.partName);
					Debug.Log ("object creation failed");
				}
			}
		}
	}*/


	/*public void SelectedPart (GameObject part){
		this.partToCreatePrefab = part;
	}*/
}

