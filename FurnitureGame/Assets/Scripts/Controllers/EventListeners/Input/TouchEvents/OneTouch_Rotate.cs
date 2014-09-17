using UnityEngine;
using System.Collections;

namespace InputFramework{
	/*
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
					this.startScreenPoint = this.screenToWorldPos;
					this.touchTarget = InGameController.Instance.target;
					this.oldParent = this.touchTarget.transform.parent;
					this.rotationParent = new GameObject();
					this.rotationParent.transform.position = this.touchTarget.transform.position;
					this.touchTarget.transform.parent = this.rotationParent.transform;
				}
			}
		}

		public override void OnTouchMoved ()
		{
			if (this.touchTarget != null){
				Vector3 touchRotation = (this.curPosition - this.startScreenPoint);
				touchRotation = new Vector3 (touchRotation.y, touchRotation.x * -1);
				this.rotationParent.transform.rotation = Quaternion.Euler (touchRotation * this.rotationRate);
				Debug.Log (this.touchTarget.transform.rotation.ToString());
			}
		}

		public override void OnTouchEnd ()
		{
			if (this.touchTarget != null){
				this.touchTarget.transform.parent = this.oldParent;
				GameObject.Destroy(this.rotationParent);
			}
		}
	}*/
}
	