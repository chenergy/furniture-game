using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using InputFramework;

public class InputListener : MonoBehaviour {
	public 		Camera			inputCamera;
	public 		GameObject 		inputTouchArea;
	public 		A_OneTouch[] 	touchElements;
	
	protected 	Vector2 		firstScreenPoint;
	protected 	Vector2 		lastScreenPoint;
	protected 	Vector2 		curScreenPoint;
	
	private 	bool 			started = false;
	private 	bool 			ended 	= true;
	private		ITouchable 		curTouchElement;

	private static InputListener instance = null;


	public Vector2 CurScreenPoint {
		get { return this.curScreenPoint; }
	}
	
	public Vector3 CurInputWorldPoint {
		get { return this.inputCamera.ScreenToWorldPoint(this.curScreenPoint); }
	}
	
	public Camera InputCamera{
		get { return instance.inputCamera; }
	}
	
	public static InputListener Instance{
		get { return InputListener.instance; }
	}


	void Awake (){
		if (instance != null) {
			GameObject.Destroy (this.gameObject);
		} else {
			instance = this;
		}
	}

	void Start (){
		// Set initial positions to zero
		this.firstScreenPoint = this.lastScreenPoint = this.curScreenPoint = Vector3.zero;
	}
	
	void Update (){
		#if UNITY_EDITOR
		if (Input.GetMouseButton(0)){
			// Call for an input update using mouse position
			this.InputUpdate (Input.mousePosition);
		} 
		#elif UNITY_IOS
		if (Input.touchCount > 0) {
			// Call for an input update using the first touch position
			foreach (Touch t in Input.touches) {
				this.InputUpdate(t.position);
			}
		}        
		#endif
		// If no input...
		else {
			// Call OnTouchEnd if touch has not yet been ended
			if (!this.ended) {
				this._OnTouchEnd (this.curTouchElement);
			}
		}
	}
	
	protected virtual void OnDrawGizmos (){
		if (Application.isEditor)
			if (Camera.current == this.inputCamera)
				Gizmos.DrawLine (this.inputCamera.ScreenToWorldPoint(this.firstScreenPoint) + Vector3.forward, this.CurInputWorldPoint + Vector3.forward);
		
		//Debug.Log (Camera.current.name);
	}
	
	
	// Call to check/update based on input values
	private void InputUpdate (Vector3 inputPoint){
		// Update the current input on the screen
		this.curScreenPoint = new Vector2 (inputPoint.x, inputPoint.y);

		// Get a collider2D at the world point
		Collider2D c2d = Physics2D.OverlapPoint (this.CurInputWorldPoint);
		
		// If world point overlaps with a collider2D...
		if (c2d != null) {
			foreach (A_OneTouch t in this.touchElements) {
				// If the assigned touch area is the same as the collider2D...
				if (t.inputTouchArea == c2d.gameObject) {
					// If OnTouchBegan has not yet been called...
					if (!this.started) {
						// Call OnTouchBegan
						this._OnTouchBegan (t);
					} else {
						// Call OnTouchMove if touch location is different from last saved point
						if ((this.curScreenPoint - this.lastScreenPoint).sqrMagnitude > 0) {
							// Call OnTouchMoved
							this._OnTouchMoved (t);
						}
					}
				}
			}
		}
		
		// If world point does not overlap with a collider2D...
		else {
			// If the touch has already started...
			if (this.started) {
				// Call OnTouchMove if touch location is different from last saved point
				if ((this.curScreenPoint - this.lastScreenPoint).sqrMagnitude > 0) {
					// Call OnTouchMoved
					this._OnTouchMoved (this.curTouchElement);
				}
			} else {
				// Call OnTouchEnd if touch has not yet been ended
				if (!this.ended) {
					this._OnTouchEnd (this.curTouchElement);
				}
			}
		}
	}
	
	
	// Private helper functions for touch events
	private void _OnTouchBegan(ITouchable target) {
		this.started = true;
		this.ended = false;
		this.firstScreenPoint = this.lastScreenPoint = this.curScreenPoint;
		this.curTouchElement = target;
		target.OnTouchBegan();
	}
	
	private void _OnTouchMoved(ITouchable target){
		this.lastScreenPoint = this.curScreenPoint;
		target.OnTouchMoved();
	}
	
	private void _OnTouchEnd(ITouchable target){
		this.started = false;
		this.ended = true;
		this.firstScreenPoint = this.lastScreenPoint = this.curScreenPoint = Vector3.zero;
		this.curTouchElement = null;
		if (target != null) target.OnTouchEnd();
	}

	/*
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
	}*/
}