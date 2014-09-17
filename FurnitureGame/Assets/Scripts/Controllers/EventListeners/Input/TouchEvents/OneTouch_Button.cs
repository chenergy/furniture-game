using UnityEngine;
using System.Collections;


namespace InputFramework
{
	public class OneTouch_Button : A_OneTouch
	{
		private bool isDown = false;
		private bool isPressed = false;
		private bool downToggle = false;
		
		public bool IsPressed{
			get { return this.isPressed; }
		}
		
		public bool IsDown{
			get { return this.isDown; }
		}
		
		/*public Vector2 TouchPosition {
			get { return this.curScreenPoint; }
		}*/
		
		public override void OnTouchBegan() { 
			this.isPressed = true;
			this.isDown = true;
			this.downToggle = true;
		}
		
		public override void OnTouchMoved() { 
			/*if (this.currentObj != null) {
				Vector3 p = this.inputCamera.ScreenToWorldPoint(this.mousePos);
				this.screenToWorldPos = new Vector2(p.x, p.y);
				Collider2D c2d = Physics2D.OverlapPoint(this.screenToWorldPos);
				
				if (c2d == null){
					this.currentObj = null;
				}
			}*/
		}
		
		public override void OnTouchEnd() { 
			this.isPressed = false;
			this.isDown = false;
			this.downToggle = false;
		}
		
		protected override void Update ()
		{
			base.Update ();
			
			if (this.isDown) {
				if (this.downToggle){
					this.downToggle = false;
				} else {
					this.isDown = false;
				}
			}
		}
	}
}
