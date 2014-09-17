using UnityEngine;
using System.Collections;


namespace InputFramework
{
	public abstract class A_OneTouch : MonoBehaviour, ITouchable
	{
		public 		bool 		canMoveOutsideTouchArea;
		public 		Camera 		inputCamera;
		public 		GameObject 	inputTouchArea;

		protected 	Vector2 	firstScreenPoint;
		protected 	Vector2 	lastScreenPoint;
		protected 	Vector2 	curScreenPoint;
		protected 	Vector3 	curWorldPoint;

		private 	bool 		started = false;
		private 	bool 		ended = true;

		
		protected virtual void Start(){
			// Set initial positions to zero
			this.firstScreenPoint = this.lastScreenPoint = this.curScreenPoint = Vector3.zero;
		}
		
		protected virtual void Update(){
#if UNITY_EDITOR
			if (Input.GetMouseButton(0)){
				// Call for an input update using mouse position
				this.InputUpdate(Input.mousePosition);
			} 
#elif UNITY_IOS
			if (Input.touchCount > 0) {
				// Call for an input update using the first touch position
				this.InputUpdate(Input.GetTouch (0).position);
			}		
#endif
			// If no input...
			else {
				// Call OnTouchEnd if touch has not yet been ended
				if (!this.ended) {
					this._OnTouchEnd();
				}
			}
		}

		protected virtual void OnDrawGizmos(){
			Gizmos.DrawLine (this.lastScreenPoint, this.curScreenPoint);
		}



		private void InputUpdate (Vector3 inputPoint){
			// Update the current input on the screen
			this.curScreenPoint = new Vector2(inputPoint.x, inputPoint.y);

			// Find the world position from the screen position based on the input camera
			this.curWorldPoint = this.inputCamera.ScreenToWorldPoint(inputPoint);

			// Get a collider2D at the world point
			Collider2D c2d = Physics2D.OverlapPoint(this.curWorldPoint);

			// If world point overlaps with a collider2D...
			if(c2d != null) {
				// If the assigned touch area is the same as the collider2D...
				if (this.inputTouchArea == c2d.gameObject){
					// If OnTouchBegan has not yet been called...
					if (!this.started){
						this._OnTouchBegan();
					} else {
						this._OnTouchMoved();
					}
				}
			} 

			// If world point does not overlap with a collider2D...
			else {
				// If the touch has already started...
				if (this.started){
					// If the touch can move outside of the designated collision area...
					if (this.canMoveOutsideTouchArea){
						this._OnTouchMoved();
					} else {
						// Call OnTouchEnd if touch has not yet been ended
						if (!this.ended) {
							this._OnTouchEnd();
						}
					}
				}
			}
		}



		// Private helper functions for touch events
		private void _OnTouchBegan() {
			this.started = true;
			this.ended = false;
			this.firstScreenPoint = this.lastScreenPoint = this.curScreenPoint;
			this.OnTouchBegan();
		}

		private void _OnTouchMoved(){
			// Call OnTouchMove if touch location is different from last saved point
			if ((this.curScreenPoint - this.lastScreenPoint).sqrMagnitude > 0){
				this.lastScreenPoint = this.curScreenPoint;
				this.OnTouchMoved();
			}
		}

		private void _OnTouchEnd(){
			this.started = false;
			this.ended = true;
			this.firstScreenPoint = this.lastScreenPoint = this.curScreenPoint = Vector3.zero;
			this.OnTouchEnd();
		}


		public abstract void OnTouchBegan();
		public abstract void OnTouchMoved();
		public abstract void OnTouchEnd();
	}
}
