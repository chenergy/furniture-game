using UnityEngine;
using System.Collections;

namespace InputFramework{
	public class OneTouch_CameraRotate : A_OneTouch
	{
		// 1 finger rotation
		public GameObject cameraParent;
		public float rotationRate = 1.0f;

		private Vector3 startRotationEuler;
		private Transform focusTarget;
		
		public override void OnTouchBegan ()
		{
			if (this.cameraParent != null){
				this.startPosition = this.screenToWorldPos;
				this.startRotationEuler = this.cameraParent.transform.rotation.eulerAngles;
			}
		}
		
		public override void OnTouchMoved ()
		{
			if (this.cameraParent != null) {
				Vector3 touchRotation = (this.curPosition - this.startPosition);
				touchRotation = new Vector3 (touchRotation.y * -1, touchRotation.x);
				Vector3 newRotation = new Vector3 (touchRotation.x * this.rotationRate, touchRotation.y * this.rotationRate, 0);
				this.cameraParent.transform.rotation = Quaternion.Euler (this.startRotationEuler + newRotation);
				Debug.Log (this.cameraParent.transform.rotation.ToString ());
			}
		}
		
		public override void OnTouchEnd ()
		{

		}
	}
}
