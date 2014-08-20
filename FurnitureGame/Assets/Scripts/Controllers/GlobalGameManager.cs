using UnityEngine;
using System.Collections;

public class GlobalGameManager : MonoBehaviour
{
	private static GlobalGameManager instance = null;

	void Awake (){
		if (instance == null){
			DontDestroyOnLoad (this.gameObject);
			instance = this;
		} else {
			Destroy (this.gameObject);
		}
	}

	public static GlobalGameManager Instance {
		get { return GlobalGameManager.instance; }
	}
}

