using UnityEngine;
using System.Collections;

namespace InputFramework{
	public class Touch_Object : A_Touch
	{
		private GameObject touchTarget;

		protected override void OnTouchBegan ()
		{
			if (InGameController.Instance != null){
				if (InGameController.Instance.target != null){
					this.startPosition = this.screenPos;
					this.touchTarget = InGameController.Instance.target;
				}
			}
		}

		protected override void OnTouchMoved ()
		{
			if (this.touchTarget != null){
				this.touchTarget.transform.rotation = Quaternion.Euler (this.curPosition - this.startPosition);
				Debug.Log (this.touchTarget.transform.rotation.ToString());
			}
		}

		protected override void OnTouchEnd ()
		{
			//throw new System.NotImplementedException ();
		}
	}
}
	