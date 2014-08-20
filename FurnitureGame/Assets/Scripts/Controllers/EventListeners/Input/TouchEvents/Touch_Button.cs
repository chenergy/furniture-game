using UnityEngine;
using System.Collections;


namespace InputFramework{
	public class Touch_Button : A_Touch
	{
		private bool isDown = false;
		private bool isPressed = false;
		
		public bool IsPressed{
			get { return this.isPressed; }
		}
		
		public bool IsDown{
			get { return this.isDown; }
		}
		
		protected override void OnTouchBegan() { 
			StartCoroutine ("ButtonDown");
			this.isPressed = true;
			//Debug.Log ("Touched");
		}
		
		protected override void OnTouchMoved() { 
			if (this.currentObj != null) {
				//this.screenPos = new Vector2(Camera.main.ScreenToWorldPoint(this.mousePos).x, Camera.main.ScreenToWorldPoint(this.mousePos).y);
				this.screenPos = new Vector2(this.inputCamera.ScreenToWorldPoint(this.mousePos).x, this.inputCamera.ScreenToWorldPoint(this.mousePos).y);
				Collider2D c2d = Physics2D.OverlapPoint(screenPos);
				
				if (c2d == null){
					this.currentObj = null;
				}
			}
		}
		
		protected override void OnTouchEnd() { 
			this.isPressed = false;
		}
		
		IEnumerator ButtonDown(){
			this.isDown = true;
			int count = 0;
			
			while (count < 1) {
				yield return new WaitForEndOfFrame();
				count++;
			}
			
			this.isDown = false;
		}
	}
}
