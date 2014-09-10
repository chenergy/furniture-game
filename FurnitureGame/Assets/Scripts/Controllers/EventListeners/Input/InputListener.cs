using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using InputFramework;

public class InputListener : MonoBehaviour {
	public Camera inputCamera;
	public OneTouch_Button[] instantiateBtns;

	private static InputListener instance = null;
	
	
	void Awake(){
		if (instance != null) {
			GameObject.Destroy (this.gameObject);
		} else {
			instance = this;
		}
	}

	void Update (){
		/*if (this.GetButtonDown (0)) {
			Debug.Log ("button pressed");
			GameObject.Instantiate(this.spawn, Vector3.up, Quaternion.identity);
		}*/


	}

	public bool GetButton(int button){
		if (instance.instantiateBtns.Length > button) {
			return instance.instantiateBtns[button].IsPressed;
		}
		return false;
	}
	
	
	public bool GetButtonDown(int button){
		if (instance.instantiateBtns.Length > button) {
			return instance.instantiateBtns[button].IsDown;
		}
		return false;
	}
	
	public Camera InputCamera{
		get { return instance.inputCamera; }
	}
	
	public static InputListener Instance{
		get { return InputListener.instance; }
	}
}