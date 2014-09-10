using UnityEngine;
using System.Collections;


namespace InputFramework
{
	public class OneTouch_Button : A_OneTouch
	{
		private bool isDown = false;
		private bool isPressed = false;
		
		public bool IsPressed{
			get { return this.isPressed; }
		}
		
		public bool IsDown{
			get { return this.isDown; }
		}
		
		public override void OnTouchBegan() { 
			this.isPressed = true;
			this.isDown = true;

			StartCoroutine ("ButtonDown");
		}
		
		public override void OnTouchMoved() { 
			if (this.currentObj != null) {
				this.screenPos = new Vector2(this.inputCamera.ScreenToWorldPoint(this.mousePos).x, this.inputCamera.ScreenToWorldPoint(this.mousePos).y);
				Collider2D c2d = Physics2D.OverlapPoint(screenPos);
				
				if (c2d == null){
					this.currentObj = null;
				}
			}
		}
		
		public override void OnTouchEnd() { 
			this.isPressed = false;
		}
		
		IEnumerator ButtonDown(){
			yield return new WaitForEndOfFrame();
			
			this.isDown = false;
		}
	}
}
