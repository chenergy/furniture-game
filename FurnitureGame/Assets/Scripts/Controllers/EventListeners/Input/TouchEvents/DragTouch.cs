using UnityEngine;
using System.Collections;
//using System.Reflection;

namespace InputFramework{
	public class DragTouch : A_TouchListener
	{
		public GameObject objectToCreate;
		public GameObject dragSprite;

		private GameObject curSprite;

		/*[SerializeField]
		private MonoBehaviour target;
		[SerializeField][HideInInspector]
		private string callback;

		public MonoBehaviour Target {
			get { return this.target; }
			set { this.target = value; }
		}

		public string Callback {
			get { return this.callback; }
			set { this.callback = value; }
		}*/


		public override void OnTouchBegan (){
			if (this.dragSprite != null) {
				TouchInfo touch = this.GetCollidingTouchInfo ();
				if (touch != null) {
					Vector3 location = InputListener.Instance.ScreenToWorldPoint (touch.CurScreenPoint, CameraType.INPUT);
					this.curSprite = GameObject.Instantiate (this.dragSprite, location, Quaternion.identity) as GameObject;
				}
			}
			//Debug.Log ("button began");
		}

		public override void OnTouchMoved (){ 
			if (this.curSprite != null) {
				foreach (TouchInfo touch in InputListener.Instance.Touches) {
					if (touch == this.startingTouch) {
						Vector3 location = InputListener.Instance.ScreenToWorldPoint (touch.CurScreenPoint, CameraType.INPUT);
						this.curSprite.transform.position = location;
						break;
					}
				}
			}
			//Debug.Log ("button moved");
		}

		public override void OnTouchStationary (){
			//Debug.Log ("button stationary");
		}

		public override void OnTouchEnd (){ 
			if (this.objectToCreate != null) {
				#if UNITY_EDITOR
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				#elif UNITY_IOS
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch (0).position);
				#endif
				RaycastHit hit;
				bool created = false;

				if (Physics.Raycast (ray, out hit)) {
					// Test colliders hitting the raycast
					//A_FurniturePart part = hit.collider.gameObject.GetComponent<A_FurniturePart> ();
					//if (part != null) {
					if (hit.collider.gameObject != null) {
						//GameObject.Instantiate (this.objectToCreate, Vector3.zero, Quaternion.identity);
						/*if (this.target != null) {
							Debug.Log ("drag instantiate");
							//this.target.SendMessage (this.callback, this.name);
						}*/
						InGameController.Instance.DragInstantiate (this.objectToCreate, hit.collider);

						created = true;
					}
				}

				if (!created)
					Debug.Log ("Cannot find c3d");
			}


			//Debug.Log ("button ended");
		}

		public override void OnTouchFinished ()
		{
			this.Reset ();
			//Debug.Log ("button finished");
		}

		public override void Reset ()
		{
			if (this.curSprite != null)
				GameObject.Destroy (this.curSprite);
			//Debug.Log ("reset");
		}
	}
}

