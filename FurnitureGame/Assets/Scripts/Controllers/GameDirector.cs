using UnityEngine;
using System.Collections;

public class GameDirector : MonoBehaviour
{
	private InGameDirector inGameController = null;

	private static GameDirector instance = null;


	void Awake (){
		if (instance == null){
			DontDestroyOnLoad (this.gameObject);
			instance = this;
		} else {
			Destroy (this.gameObject);
		}
	}

	public static GameDirector Instance {
		get { return instance; }
	}

	public InGameDirector InGameController {
		get { return instance.inGameController; }
		set { instance.inGameController = value; }
	}
}

