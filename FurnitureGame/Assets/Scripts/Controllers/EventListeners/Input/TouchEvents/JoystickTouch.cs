using UnityEngine;
using System.Collections;
//using System.Reflection;

namespace InputFramework
{
	public class JoystickTouch : A_TouchListener
	{
		public Color 		pressedColor = Color.blue;
		public 	float 		maxDistance;
		public 	float 		sqrSnapDistance;
		public 	GameObject 	snapObject;
		public 	Transform[] snapTransforms;

		private Color 		startingColor;
		private int 		curSnapNum = 0;
		private Transform 	curSnapTransform;
		private Vector3 	startWorldPosition;
		private bool		isSnapped = false;

		protected override void Start(){
			base.Start ();
			this.startingColor = this.GetComponent<SpriteRenderer> ().color;
			this.startWorldPosition = this.snapObject.transform.position;
		}

		public override void OnTouchBegan (){
			this.GetComponent<SpriteRenderer> ().color = this.pressedColor;
			this.OnTouchSnapLocation ();
			//Debug.Log ("button began");
		}

		public override void OnTouchMoved (){ 
			this.OnTouchSnapLocation ();
			//Debug.Log ("button moved");
		}

		public override void OnTouchStationary (){
			this.OnTouchSnapLocation ();
			//Debug.Log ("button stationary");
		}

		public override void OnTouchEnd (){ 
			//Debug.Log ("button ended");
		}

		public override void OnTouchFinished ()
		{
			this.Reset ();
			//Debug.Log ("button finished");
		}

		public override void Reset ()
		{
			this.GetComponent<SpriteRenderer> ().color = this.startingColor;
			this.curSnapTransform = null;
			this.curSnapNum = 0;
			this.snapObject.transform.position = this.startWorldPosition;
			//Debug.Log ("reset");
		}


		public void OnSnapTransform (int num){
			this.curSnapNum = num;
			this.curSnapTransform = this.snapTransforms [num];
			this.snapObject.transform.position = this.curSnapTransform.position;
		}


		private void OnTouchSnapLocation(){
			foreach (TouchInfo touch in InputListener.Instance.Touches) {
				if (touch == this.startingTouch) {
					// Get click position and clamp to maxdistance
					Vector3 curWorldPoint = InputListener.Instance.ScreenToWorldPoint (touch.CurScreenPoint, CameraType.INPUT);
					curWorldPoint = this.startWorldPosition + Vector3.ClampMagnitude ((curWorldPoint - this.startWorldPosition), this.maxDistance);

					// Assign the touch object's position to the target position
					this.snapObject.transform.position = curWorldPoint;

					// Clear the current snap transform
					this.curSnapTransform = null;

					for (int i = 0; i < this.snapTransforms.Length; i++) {
						// Get position of each snap transform
						Vector3 p = this.snapTransforms [i].position;

						// Snap if close enough to a transform, assign a number
						if ((curWorldPoint - p).sqrMagnitude < sqrSnapDistance) {
							this.isSnapped = true;
							this.OnSnapTransform (i);
							break;
						}
					}

					// Clear number if not set to a transform
					if (this.curSnapTransform == null) {
						this.isSnapped = false;
						this.curSnapNum = 0;
					}
				}
			}
		}
	}
}
