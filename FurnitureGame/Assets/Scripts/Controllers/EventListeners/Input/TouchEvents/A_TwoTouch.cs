using UnityEngine;
using System.Collections;

namespace InputFramework
{
	public abstract class A_TwoTouch : MonoBehaviour, ITouchable
	{
		public Camera inputCamera;
		public GameObject touchArea;

		//protected Touch inputTouch0;
		//protected Touch inputTouch1;
		protected Touch[] inputTouches;


		// Use this for initialization
		void Start ()
		{
			//this.inputTouches = new Touch[2];
		}
		
		// Update is called once per frame
		void Update ()
		{
			if (Input.touchCount == 2) {
				if (this.inputTouches == null){
					this.inputTouches = new Touch[2];
					this.inputTouches[0] = Input.touches[0];
					this.inputTouches[1] = Input.touches[1];
					this.OnTouchBegan();
				} else {
					if (this.inputTouches[0].phase == TouchPhase.Moved || this.inputTouches[1].phase == TouchPhase.Moved){
						this.OnTouchMoved();
					}
				}
			} else if (Input.touchCount == 0 && this.inputTouches != null) {
				this.inputTouches = null;
				this.OnTouchEnd ();
			}
		}

		public abstract void OnTouchBegan();
		public abstract void OnTouchMoved();
		public abstract void OnTouchEnd();
	}
}

