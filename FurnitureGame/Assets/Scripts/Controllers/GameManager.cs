using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	private static GameManager instance = null;

	void Awake (){
		if (instance == null){
			DontDestroyOnLoad (this.gameObject);
			instance = this;
		} else {
			Destroy (this.gameObject);
		}
	}

	public static GameManager Instance {
		get { return GameManager.instance; }
	}
}

