using UnityEngine;
using System.Collections;

namespace InputFramework
{
	public class OneTouch_DragCreate : A_OneTouch
	{
		public GameObject objectToCreate;
		public GameObject dragSprite;

		private GameObject curSprite;
		private bool isDown = false;
		private bool isPressed = false;


		public bool IsPressed{
			get { return this.isPressed; }
		}
		
		public bool IsDown{
			get { return this.isDown; }
		}
		
		public override void OnTouchBegan() { 
			StartCoroutine ("ButtonDown");
			this.isPressed = true;
			this.isDown = true;

			if (this.dragSprite != null)
				this.curSprite = GameObject.Instantiate (this.dragSprite, this.curPosition, Quaternion.identity) as GameObject;
		}
		
		public override void OnTouchMoved() { 
			if (this.curSprite != null) {
				this.curSprite.transform.position = this.screenToWorldPos;
			}
		}

		public override void OnTouchEnd() { 
			this.isPressed = false;

			if (this.objectToCreate != null) {
				Vector2 screenPos = new Vector2(this.inputCamera.ScreenToWorldPoint(this.mousePos).x, this.inputCamera.ScreenToWorldPoint(this.mousePos).y);
				Collider2D c2d = Physics2D.OverlapPoint(screenPos);

				if (c2d != null){
					A_FurniturePart part = c2d.gameObject.GetComponent<A_FurniturePart>();
					if (part != null){
						GameObject.Instantiate (this.objectToCreate, Vector3.zero, Quaternion.identity);
					}
				}
			}

			GameObject.Destroy (this.curSprite);
		}
		
		IEnumerator ButtonDown(){
			yield return new WaitForEndOfFrame();
			
			this.isDown = false;
		}
	}
}
