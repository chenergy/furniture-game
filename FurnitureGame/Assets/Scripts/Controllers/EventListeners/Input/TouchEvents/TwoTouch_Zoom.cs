using UnityEngine;
using System.Collections;

namespace InputFramework{
	public class TwoTouch_Zoom : A_TwoTouch
	{
		private Vector2 startVector;
		private Vector3 startLocalScale;

		public override void OnTouchBegan ()
		{
			if (InGameController.Instance != null){
				if (InGameController.Instance.target != null){
					this.startVector = this.inputTouches[1].position - this.inputTouches[0].position;
					this.startLocalScale = InGameController.Instance.target.transform.localScale;
				}
			}
		}

		public override void OnTouchMoved ()
		{
			if (InGameController.Instance != null){
				if (InGameController.Instance.target != null){
					Vector2 curVector = this.inputTouches[1].position - this.inputTouches[0].position;
					if (curVector != this.startVector){
						InGameController.Instance.target.transform.localScale = this.startLocalScale * (curVector - this.startVector).magnitude;
					}
				}
			}
		}

		public override void OnTouchEnd ()
		{
			this.startVector = Vector2.zero;
		}
	}
}

