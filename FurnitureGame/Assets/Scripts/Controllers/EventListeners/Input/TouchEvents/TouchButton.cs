using UnityEngine;
using System.Collections;


namespace InputFramework {
	public class TouchButton : MonoBehaviour {
		public Camera inputCamera;
		
		private GameObject touchArea;
		private Vector2 startPosition;
		private Vector2 curPosition;
		private Vector2 mousePos;
		private Vector2 screenPos;
		private GameObject currentObj;

		private bool isDown = false;
		private bool isPressed = false;
		
		void Start(){
			this.touchArea = this.gameObject;
			this.startPosition = new Vector2 (this.touchArea.transform.position.x, this.touchArea.transform.position.y);
		}
		
		void Update(){
			this.mousePos = Input.mousePosition;
			
			#if UNITY_EDITOR
			if (Input.GetMouseButton(0)){
				this.screenPos = new Vector2(this.inputCamera.ScreenToWorldPoint(this.mousePos).x, this.inputCamera.ScreenToWorldPoint(this.mousePos).y);
				Collider2D c2d = Physics2D.OverlapPoint(screenPos);
				
				if(c2d != null)
				{
					if (this.touchArea == c2d.gameObject){
						if (this.currentObj == null){
							this.currentObj = c2d.gameObject;
							this.curPosition = screenPos;
							this.OnTouchBegan();
						} else {
							if ((this.curPosition - screenPos).sqrMagnitude > 0){
								this.curPosition = screenPos;
								this.OnTouchMoved();
							}
						}
					}
				} else {
					if (this.currentObj != null){
						this.curPosition = screenPos;
						this.OnTouchMoved();
					}
				}
			} else {
				this.currentObj = null;
				this.OnTouchEnd();
			}
			#else
			if (Input.touchCount == 1) {
				for (int i = 0; i < Input.touchCount; i++) {
					Touch currentTouch = Input.GetTouch (i);
					this.screenPos = new Vector2(this.inputCamera.ScreenToWorldPoint(currentTouch.position).x, this.inputCamera.ScreenToWorldPoint(currentTouch.position).y);
					Collider2D c2d = Physics2D.OverlapPoint(screenPos);
					
					if(c2d != null)
					{
						if (this.touchObject == c2d.gameObject){
							if (this.currentObj == null){
								this.currentObj = c2d.gameObject;
								this.curPosition = screenPos;
								this.OnTouchBegan();
							} else {
								if ((this.curPosition - screenPos).sqrMagnitude > 0){
									this.curPosition = screenPos;
									this.OnTouchMoved();
								}
							}
						}
					} else {
						if (this.currentObj != null){
							this.curPosition = screenPos;
							this.OnTouchMoved();
						}
					}
				} 
			} else if (Input.touchCount == 0) {
				this.currentObj = null;
				this.OnTouchEnd();
			}
			
			#endif
		}
		
		public bool IsPressed{
			get { return this.isPressed; }
		}
		
		public bool IsDown{
			get { return this.isDown; }
		}
		
		private void OnTouchBegan() { 
			StartCoroutine ("ButtonDown");
			this.isPressed = true;
			//Debug.Log ("Touched");
		}
		
		private void OnTouchMoved() { 
			if (this.currentObj != null) {
				//this.screenPos = new Vector2(Camera.main.ScreenToWorldPoint(this.mousePos).x, Camera.main.ScreenToWorldPoint(this.mousePos).y);
				this.screenPos = new Vector2(this.inputCamera.ScreenToWorldPoint(this.mousePos).x, this.inputCamera.ScreenToWorldPoint(this.mousePos).y);
				Collider2D c2d = Physics2D.OverlapPoint(screenPos);
				
				if (c2d == null){
					this.currentObj = null;
				}
			}
		}
		
		private void OnTouchEnd() { 
			this.isPressed = false;
		}
		
		private IEnumerator ButtonDown(){
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

