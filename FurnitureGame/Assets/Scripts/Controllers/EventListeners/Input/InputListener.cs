using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using InputFramework;

public class InputListener : MonoBehaviour {
	public delegate void InputAction(int direction);
	public static event InputAction OnDirection;
	
	//public delegate void AttackAction(string attack);
	//public static event AttackAction OnAttack;
	
	public Camera inputCamera;
	//public JoystickTouch joystickTouch;
	public Touch_Button[] buttonTouches;

	/*
	private A_Fighter target;
	private string inputQueue = "";
	private float lastHitTimer = 0.0f;
	private float lastHitDelay = 1.0f;
	private bool canAddDash = true;
	*/
	
	private static InputListener instance = null;
	
	
	void Awake(){
		if (instance != null) {
			GameObject.Destroy (this.gameObject);
		} else {
			instance = this;
		}
	}

	void Update (){
		if (this.GetButtonDown (0)) {
			Debug.Log ("button pressed");
		}
	}

	/*
	void Update(){
		if (OnDirection != null) {
			if (InputListener.GetInputDirection () != FightInput.NONE) {
				OnDirection ((int)InputListener.GetInputDirection ());
				AddDirectionToQueue (InputListener.GetInputDirection ());
			} else {
				OnDirection (0);
				this.canAddDash = true;
				//AddDirectionToQueue (FightInput.NEUTRAL);
			}
		} 
		
		if (InputListener.GetButtonDown (0)) {
			if (OnAttack != null) {
				this.AddButtonToQueue (FightInput.A);
			}
		} else if (InputListener.GetButtonDown (1)) {
			if (OnAttack != null) {
				this.AddButtonToQueue (FightInput.B);
			}
		}
		
		// Check and reset queue
		this.lastHitTimer += Time.deltaTime;
		if (this.lastHitTimer >= this.lastHitDelay) {
			if (this.inputQueue != ""){
				this.inputQueue = "";
			}
			this.lastHitTimer = 0.0f;
		}
		
		if (this.inputQueue != "") {
			this.inputQueue = this.inputQueue.Substring (Mathf.Max (0, this.inputQueue.Length - 12));
		}

		Debug.Log (this.inputQueue);
	}
	*/

	/*
	private void AddDirectionToQueue (FightInput direction){
		if (this.inputQueue.Length > 0) {
			if (char.GetNumericValue(this.inputQueue [this.inputQueue.Length - 1]) != (int)direction) {
				this.inputQueue += "_" + ((int)direction).ToString();
				
				if (direction == FightInput.LEFT || direction == FightInput.RIGHT) {
					this.canAddDash = false;
				}
			} else {
				if (direction == FightInput.LEFT || direction == FightInput.RIGHT) {
					if (this.canAddDash){
						this.canAddDash = false;
						this.inputQueue += "_" + ((int)direction).ToString();
					}
				}
			}
		} else {
			this.inputQueue += "_" + ((int)direction).ToString();
			
			if (direction == FightInput.LEFT || direction == FightInput.RIGHT) {
				this.canAddDash = false;
			}
		}
		
		this.ProcessDash ();
		this.lastHitTimer = 0.0f;
	}
	
	
	private void AddButtonToQueue (FightInput button){
		this.inputQueue += "_" + button.ToString();
		this.lastHitTimer = 0.0f;
		this.ProcessQueue ();
	}
	
	
	private void ProcessDash(){
		for (int i = 8; i > 0; i -= 2) {
			string sub = this.inputQueue.Substring (this.inputQueue.Length - Mathf.Min (this.inputQueue.Length, i), Mathf.Min (this.inputQueue.Length, i));
			
			if (this.target != null){
				if (sub == "_6_6"){
					this.target.DashMove (FightInput.RIGHT);
				} else if (sub == "_4_4"){
					this.target.DashMove (FightInput.LEFT);
				}
			}
		}
	}
	
	
	private void ProcessQueue(){
		string directionInputQueue = this.ConvertQueueByDirection (this.inputQueue);
		
		for (int i = 8; i > 0; i -= 2) {
			string sub = directionInputQueue.Substring (directionInputQueue.Length - Mathf.Min (directionInputQueue.Length, i), Mathf.Min (directionInputQueue.Length, i));
			
			if (this.target != null){
				InputListener.OnAttack(sub);
			}
		}
	}
	
	
	private string ConvertQueueByDirection (string input){
		string newInput = input;
		
		// Get only P1 input temp
		if (GameManager.P1.Fighter.FacingDirection == FightInput.LEFT) {
			char[] charArray = newInput.ToCharArray();
			
			// if the fighter is facing left, switch the input directions for left and right
			for (int i = 0; i < charArray.Length; i++){
				if (charArray[i] == 55 || charArray[i] == 52 || charArray[i] == 49){
					charArray[i] = (char)((int)charArray[i] + 2);
				} else if (charArray[i] == 57 || charArray[i] == 54 || charArray[i] == 51){
					charArray[i] = (char)((int)charArray[i] - 2);
				}
			}
			newInput = new string(charArray);
		}
		return newInput;
	}
	
	
	public static void SetTarget (A_Fighter fighter){
		instance.target = fighter;
	}
	
	
	public static float GetAxis(FightAxis axis){
		if (instance.joystickTouch != null) {
			return instance.joystickTouch.GetAxis (axis);
		}
		return 0.0f;
	}
	
	
	public static FightInput GetInputDirection(){
		if (instance.joystickTouch != null) {
			return instance.joystickTouch.GetInputDirection();
		}
		return FightInput.NONE;
	}
	*/
	
	public bool GetButton(int button){
		if (instance.buttonTouches.Length > button) {
			return instance.buttonTouches[button].IsPressed;
		}
		return false;
	}
	
	
	public bool GetButtonDown(int button){
		if (instance.buttonTouches.Length > button) {
			return instance.buttonTouches[button].IsDown;
		}
		return false;
	}
	
	/*
	public static void ClearInput(){
		instance.inputQueue = "";
	}
	*/
	
	public Camera InputCamera{
		get { return instance.inputCamera; }
	}
	
	
	public static InputListener Instance{
		get { return InputListener.instance; }
	}
}