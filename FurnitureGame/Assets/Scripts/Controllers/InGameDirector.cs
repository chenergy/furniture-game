using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InGameDirector : MonoBehaviour
{
	// List of prefab parts that can be accessed.
	public GameObject[] partPrefabs;

	// Reference to product to be created.
	private A_Product product;
	public A_Product Product {
		get { return this.product; }
	}

	// Dictionary reference to assigned part prefabs by part name.
	private Dictionary <PartName, GameObject> nameToPartPrefab = new Dictionary<PartName, GameObject> ();


	void Start (){
		// Assign this to reference in GameDirector.
		GameDirector.Instance.InGameDirector = this;

		// Init the dictionary based on partName of objects (string).
		foreach (GameObject partPrefab in this.partPrefabs) {
			// Ensure that the prefab has a attachable part script.
			A_AttachablePart part = partPrefab.GetComponent<A_AttachablePart> ();
			if (part != null) {
				// Create a reference to the prefab based on a part name.
				this.nameToPartPrefab.Add (part.partName, partPrefab);
			}
		}

		// Reference to the starting product based on GameDirector.
		this.product = this.CreateProduct (GameDirector.Instance.ProductToCreate);
	}


	// Return a prefab given a PartName.
	public GameObject GetProductPrefab (PartName part) {
		/*foreach (KeyValuePair<PartName,GameObject> kvp in this.nameToPartPrefab) {
			Debug.Log (kvp.Key.ToString ());
		}*/

		if (this.nameToPartPrefab.ContainsKey (part))
			return this.nameToPartPrefab [part];
		return null;
	}


	// Construct a product based on the product name.
	private A_Product CreateProduct (ProductName productName) {
		switch (productName) {
		case ProductName.MALM_BENCH:
			return new Product_MalmBench (this);
			break;
		default:
			break;
		}

		// Product was not found.
		Debug.Log ("Product not found.");
		return null;
	}
}

