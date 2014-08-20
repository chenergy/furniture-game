using UnityEngine;
using System.Collections;

public class InGameController : MonoBehaviour
{
	public GameObject target;

	private static InGameController instance = null;

	void Awake (){
		if (instance == null){
			DontDestroyOnLoad(this);
			instance = this;
		} else {
			Destroy(this.gameObject);
		}
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public static InGameController Instance {
		get { return InGameController.instance; }
	}
}

