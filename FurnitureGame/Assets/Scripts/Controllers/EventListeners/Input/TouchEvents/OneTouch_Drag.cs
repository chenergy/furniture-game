using UnityEngine;
using System.Collections;

namespace InputFramework{
	public class OneTouch_Drag : A_OneTouch
	{
		public override void OnTouchBegan ()
		{
			this.touchArea.rigidbody.useGravity = false;
		}
		
		public override void OnTouchMoved ()
		{
			this.touchArea.transform.position = this.inputCamera.ScreenToWorldPoint (this.curPosition);
		}
		
		public override void OnTouchEnd ()
		{
			this.touchArea.rigidbody.useGravity = false;
		}
		
		void OnDrawGizmos(){
			Gizmos.DrawLine(this.startPosition, this.curPosition);
		}
	}
}
