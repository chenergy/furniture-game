using UnityEngine;
using System.Collections;


namespace InputFramework
{
	public abstract class A_TouchListener : MonoBehaviour, ITouchable
	{
		public bool canExitTouchArea = false;
		public bool canEnterTouchArea = false;

		protected Collider2D inputTouchArea;
		protected TouchInfo startingTouch;

		private Collider2D[] colliderResults;


		protected virtual void Start(){
			this.inputTouchArea = this.collider2D;
			this.colliderResults = new Collider2D[2];
		}

		void Update (){
			foreach (TouchInfo t in InputListener.Instance.Touches) {
				if (t.IsStarted) {
					if (t.IsDown) {
						if (this.IsCollidingTouchArea (t.CurScreenPoint)) {
							// Touch started on this touch area, always begin the touch
							this.startingTouch = t;
							this.OnTouchBegan ();
							break;
						}
					} else if (t.IsPressed) {
						if (this.IsCollidingTouchArea (t.CurScreenPoint)) {
							if (this.startingTouch == t) {
								if (t.Phase == TouchPhase.Moved) {
									// Touch is currently colliding with touch area, started inside, and is moving
									this.OnTouchMoved ();
									break;
								} else if (t.Phase == TouchPhase.Stationary) {
									// Touch is currently colliding with touch area, started inside, and is stationary
									this.OnTouchStationary ();
									break;
								}
							} else {
								if (this.canEnterTouchArea) {
									if (this.startingTouch == null) {
										// Touch is currently colliding with touch area, started outside touch area, and this is the first entry
										this.startingTouch = t;
										this.OnTouchBegan ();
										break;
									} else {
										if (t.Phase == TouchPhase.Moved) {
											// Touch is currently colliding with touch area, started outside touch area, and is moving
											this.OnTouchMoved ();
											break;
										} else if (t.Phase == TouchPhase.Stationary) {
											// Touch is currently colliding with touch area, started outside touch area, and is stationary
											this.OnTouchStationary ();
											break;
										}
									}
								}
							}
						} else {
							if (this.canExitTouchArea) {
								if (this.startingTouch == t) {
									if (t.Phase == TouchPhase.Moved) {
										// Touch is not colliding with touch area, started inside touch area, and is moving
										this.OnTouchMoved ();
										break;
									} else if (t.Phase == TouchPhase.Stationary) {
										// Touch is not colliding with touch area, started inside touch area, and is stationary
										this.OnTouchStationary ();
										break;
									}
								}
							} else {
								if (this.startingTouch != null) {
									// Touch cannot exit area, so reset without ending
									this.startingTouch = null;
									//this.OnTouchEnd ();
									this.Reset ();
									break;
								}
							}
						}
					}
				} else {
					if (this.startingTouch != null) {
						if (t.IsEnded) {
							if (t.IsUp) {
								// Touch has ended, if touch started in the touch area, then end
								this.OnTouchEnd ();
								break;
							} else {
								// After touch ended, finish the touch
								this.startingTouch = null;
								this.OnTouchFinished ();
								break;
							}
						}
					}
				}
			}
		}


		protected bool IsCollidingTouchArea (Vector2 screenPoint){
			Vector3 curWorldPoint = InputListener.Instance.ScreenToWorldPoint (screenPoint, CameraType.INPUT);
			int numColliders = Physics2D.OverlapPointNonAlloc (curWorldPoint, this.colliderResults, ~LayerMask.NameToLayer("UI"));

			if (numColliders > 0) {
				foreach (Collider2D c2d in this.colliderResults) {
					if (c2d != null) {
						if (c2d == this.inputTouchArea) {
							return true;
						}
					}
				}
			}
			return false;
		}


		protected TouchInfo GetCollidingTouchInfo (){
			foreach (TouchInfo t in InputListener.Instance.Touches) {
				if (this.IsCollidingTouchArea (t.CurScreenPoint)) {
					return t;
				}
			}
			return null;
		}

		// Required functions to be defined in child classes
		public abstract void OnTouchBegan();
		public abstract void OnTouchMoved();
		public abstract void OnTouchStationary ();
		public abstract void OnTouchEnd();
		public abstract void OnTouchFinished();
		public abstract void Reset();
	}
}