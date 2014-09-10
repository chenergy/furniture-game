using UnityEngine;
using System.Collections;

namespace InputFramework{
	public class OneTouch_Rotate : A_OneTouch
	{
		public float rotationRate = 1.0f;

		// 1 finger rotation
		private GameObject touchTarget;
		private GameObject rotationParent;
		private Transform oldParent;
		private bool hasTwoTouched = false;

		// 2 finger zoom
		private Vector3 startScale = Vector3.one;
		private Vector2 startVectorDiff = Vector3.zero;
		//private Vector2 curVectorDiff = Vector3.zero;


		public override void OnTouchBegan ()
		{
			if (InGameController.Instance != null){
				if (InGameController.Instance.target != null){
					this.startPosition = this.screenPos;
					this.touchTarget = InGameController.Instance.target;
					this.oldParent = this.touchTarget.transform.parent;
					this.rotationParent = new GameObject();
					this.rotationParent.transform.position = this.touchTarget.transform.position;
					this.touchTarget.transform.parent = this.rotationParent.transform;

					/*
					if (Input.touchCount == 1) {
						this.startPosition = this.screenPos;
						this.touchTarget = InGameController.Instance.target;
						this.oldParent = this.touchTarget.transform.parent;
						this.rotationParent = new GameObject();
						this.rotationParent.transform.position = this.touchTarget.transform.position;
						this.touchTarget.transform.parent = this.rotationParent.transform;
					} else if (Input.touchCount == 2){
						this.startScale = this.transform.localScale;
						this.startVectorDiff = Input.touches[0].position - Input.touches[1].position;
					}*/
				}
			}
		}

		public override void OnTouchMoved ()
		{
			if (this.touchTarget != null){
				Vector3 touchRotation = (this.curPosition - this.startPosition);
				touchRotation = new Vector3 (touchRotation.y, touchRotation.x * -1);
				this.rotationParent.transform.rotation = Quaternion.Euler (touchRotation * this.rotationRate);
				Debug.Log (this.touchTarget.transform.rotation.ToString());
			}
			/*
			if (Input.touchCount == 1) {
				if (this.touchTarget != null){
					Vector3 touchRotation = (this.curPosition - this.startPosition);
					touchRotation = new Vector3 (touchRotation.y, touchRotation.x * -1);
					this.rotationParent.transform.rotation = Quaternion.Euler (touchRotation * this.rotationRate);
					Debug.Log (this.touchTarget.transform.rotation.ToString());
				}
			} else if (Input.touchCount == 2){
				Vector2 curVectorDiff = Input.touches[0].position - Input.touches[1].position;
				this.transform.localScale = this.startScale * (curVectorDiff.magnitude - this.startVectorDiff.magnitude);
			}
			*/
		}

		public override void OnTouchEnd ()
		{
			if (this.touchTarget != null){
				this.touchTarget.transform.parent = this.oldParent;
				GameObject.Destroy(this.rotationParent);
			}

			/*if (this.touchTarget != null){
				this.startRotation = this.touchTarget.transform.localRotation.eulerAngles;
			}*/
		}

		void OnDrawGizmos(){
			Gizmos.DrawLine(this.startPosition, this.curPosition);
		}

		/*
		protected override void Update ()
		{
			base.Update ();

			if (!this.hasTwoTouched){
				if (Input.touchCount == 2){
					if (this.currentObj != null){
						this.hasTwoTouched = true;
					}
					this.OnTouchBegan();
				}
			}
		}*/
	}
}
	