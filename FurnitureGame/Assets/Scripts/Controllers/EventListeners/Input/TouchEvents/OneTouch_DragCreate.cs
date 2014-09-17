using UnityEngine;
using System.Collections;

namespace InputFramework
{
	public class OneTouch_DragCreate : OneTouch_Button
	{
		//public Camera mainCamera;
		public GameObject objectToCreate;
		public GameObject dragSprite;

		private GameObject curSprite;
		//private Vector3 mainCurWorldPoint;

		/*
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
		}*/

		public override void OnTouchBegan ()
		{
			base.OnTouchBegan ();

			if (this.dragSprite != null)
				this.curSprite = GameObject.Instantiate (this.dragSprite, this.curWorldPoint, Quaternion.identity) as GameObject;

		}

		public override void OnTouchMoved() { 
			if (this.curSprite != null) {
				this.curSprite.transform.position = this.curWorldPoint;
			}

			//this.mainCurWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(100, 100, Camera.main.nearClipPlane));
			//Debug.Log(this.mainCurWorldPoint);
		}

		public override void OnTouchEnd ()
		{
			base.OnTouchEnd ();

			if (this.objectToCreate != null) {
#if UNITY_EDITOR
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
#elif UNITY_IOS
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch (0).position);
#endif
				RaycastHit hit;
				bool created = false;

				if (Physics.Raycast(ray, out hit)) {
					// Test colliders hitting the raycast
					A_FurniturePart part = hit.collider.gameObject.GetComponent<A_FurniturePart>();
					if (part != null){
						GameObject.Instantiate (this.objectToCreate, Vector3.zero, Quaternion.identity);
						created = true;
					}
				}

				/*foreach (Collider c3d in colliders){
					A_FurniturePart part = c3d.gameObject.GetComponent<A_FurniturePart>();
					if (part != null){
						GameObject.Instantiate (this.objectToCreate, Vector3.zero, Quaternion.identity);
						created = true;
					}
				}*/

				if (!created)
					Debug.Log ("Cannot find c3d");
			}

			GameObject.Destroy (this.curSprite);
		}

		protected override void OnDrawGizmos ()
		{
			base.OnDrawGizmos ();

			//Gizmos.DrawSphere (this.worldTouchPoint, 1.0f);
			Gizmos.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition));
			//Gizmos.DrawSphere (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5.0f)), 1.0f);
		}
	}
}
