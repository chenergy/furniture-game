using UnityEngine;
using System.Collections;

public class GameDirector : MonoBehaviour
{
	// Reference to InGameDirector when in game.
	private InGameDirector inGameDirector = null;
	public InGameDirector InGameDirector {
		get { return instance.inGameDirector; }
		set { instance.inGameDirector = value; }
	}

	// Name of the product to create.
	private ProductName productToCreate;
	public ProductName ProductToCreate {
		get { return instance.productToCreate; }
		set { instance.productToCreate = value; }
	}

	// Static instance.
	private static GameDirector instance = null;
	public static GameDirector Instance {
		get { return instance; }
	}


	void Awake (){
		// Previous reference to static instance has not been create.
		if (instance == null) {
			// Do not destroy this gameobject between scene changes.
			DontDestroyOnLoad (this.gameObject);

			// Temp product to create.
			this.productToCreate = ProductName.MALM_BENCH;

			// Static reference points to this script.
			instance = this;
		} else {
			// Make GameDirector a singleton.
			Destroy (this.gameObject);
		}
	}
}

