using UnityEngine;
using System.Collections;

namespace InputFramework{
	public class OneTouch_Drag : A_OneTouch
	{
		public override void OnTouchBegan ()
		{
			this.inputTouchArea.rigidbody.useGravity = false;
		}
		
		public override void OnTouchMoved ()
		{
			this.inputTouchArea.transform.position = this.curWorldPoint;
		}
		
		public override void OnTouchEnd ()
		{
			this.inputTouchArea.rigidbody.useGravity = false;
		}
	}
}
