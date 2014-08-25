using UnityEngine;
using System.Collections;


namespace InputFramework{
	public abstract class A_Touch : MonoBehaviour
	{
		public Camera inputCamera;

		protected GameObject touchArea;
		protected Vector2 startPosition;
		protected Vector2 curPosition;
		protected Vector2 mousePos;
		protected Vector2 screenPos;
		protected GameObject currentObj;
		
		protected virtual void Start(){
			this.touchArea = this.gameObject;
			this.startPosition = new Vector2 (this.touchArea.transform.position.x, this.touchArea.transform.position.y);
		}
		
		protected virtual void Update(){
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
		
		protected abstract void OnTouchBegan();
		protected abstract void OnTouchMoved();
		protected abstract void OnTouchEnd();
	}
}
