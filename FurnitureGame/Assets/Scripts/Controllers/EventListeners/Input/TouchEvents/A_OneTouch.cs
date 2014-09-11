using UnityEngine;
using System.Collections;


namespace InputFramework
{
	public abstract class A_OneTouch : MonoBehaviour, ITouchable
	{
		public bool canMoveOutsideTouchArea;
		public Camera inputCamera;
		public GameObject touchArea;

		protected Vector2 startPosition;
		protected Vector2 curPosition;
		protected Vector2 mousePos;
		protected Vector2 screenToWorldPos;
		protected GameObject currentObj;

		private bool ended = true;
		
		void Start(){
			this.startPosition = new Vector2 (this.touchArea.transform.position.x, this.touchArea.transform.position.y);
		}
		
		void Update(){
			this.mousePos = Input.mousePosition;
			
#if UNITY_EDITOR
			if (Input.GetMouseButton(0)){
				this.screenToWorldPos = new Vector2(this.inputCamera.ScreenToWorldPoint(this.mousePos).x, this.inputCamera.ScreenToWorldPoint(this.mousePos).y);
				this.InputUpdate(this.screenToWorldPos);
			} else {
				if (!this.ended) {
					this.ended = true;
					this.currentObj = null;
					this.OnTouchEnd();
				}
			}
#elif UNITY_IOS
			if (Input.touchCount > 0) {
				for (int i = 0; i < Input.touchCount; i++) {
					Touch currentTouch = Input.GetTouch (i);
					this.screenToWorldPos = new Vector2(this.inputCamera.ScreenToWorldPoint(currentTouch.position).x, this.inputCamera.ScreenToWorldPoint(currentTouch.position).y);
					this.InputUpdate(this.screenToWorldPos);
				} 
			} else {
				if (!this.ended) {
					this.ended = true;
					this.currentObj = null;
					this.OnTouchEnd();
				}
			}			
#endif
		}

		private void InputUpdate (Vector2 screenToWorldPos){
			Collider2D c2d = Physics2D.OverlapPoint(this.screenToWorldPos);
			
			if(c2d != null) {
				if (this.touchArea == c2d.gameObject){
					if (this.currentObj == null){
						this.currentObj = c2d.gameObject;
						this.curPosition = screenToWorldPos;
						this.ended = false;
						this.OnTouchBegan();
					} else {
						if ((this.curPosition - screenToWorldPos).sqrMagnitude > 0){
							this.curPosition = screenToWorldPos;
							this.OnTouchMoved();
						}
					}
				}
			} else {
				if (this.canMoveOutsideTouchArea){
					if ((this.curPosition - screenToWorldPos).sqrMagnitude > 0){
						this.curPosition = screenToWorldPos;
						this.OnTouchMoved();
					}
				} else {
					if (!this.ended) {
						this.ended = true;
						this.currentObj = null;
						this.OnTouchEnd();
					}
				}
			}
		}

		public abstract void OnTouchBegan();
		public abstract void OnTouchMoved();
		public abstract void OnTouchEnd();
	}
}
