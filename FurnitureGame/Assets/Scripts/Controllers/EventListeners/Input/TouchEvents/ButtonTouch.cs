using UnityEngine;
using System.Collections;
//using System.Reflection;

namespace InputFramework{
	public class ButtonTouch : A_TouchListener
	{
		public bool firesOnBegan = false;
		public Color pressedColor = Color.blue;

		/*
		[SerializeField]
		private MonoBehaviour target;
		[SerializeField][HideInInspector]
		private string callback;*/

		private Color startingColor;
		private bool isDown = false;
		private bool isPressed = false;
		private bool isUp = false;


		public bool IsDown {
			get { return this.isDown; }
		}

		public bool IsPressed {
			get { return this.isPressed; }
		}

		public bool IsUp {
			get { return this.isUp; }
		}

		/*public MonoBehaviour Target {
			get { return this.target; }
			set { this.target = value; }
		}

		public string Callback {
			get { return this.callback; }
			set { this.callback = value; }
		}*/


		protected override void Start(){
			base.Start ();
			this.startingColor = this.GetComponent<SpriteRenderer> ().color;
		}

		public override void OnTouchBegan (){
			this.GetComponent<SpriteRenderer> ().color = this.pressedColor;
			this.isDown = true;
			this.isPressed = true;
			//Debug.Log ("button began");

			if (this.firesOnBegan) 
				InGameController.Instance.TouchEvent (this.name);
				//if (this.target != null)
					//this.target.SendMessage (this.callback, this.name);
		}

		public override void OnTouchMoved (){ 
			this.isDown = false;
			//Debug.Log ("button moved");
		}

		public override void OnTouchStationary (){
			this.isDown = false;
			//Debug.Log ("button stationary");
		}

		public override void OnTouchEnd (){ 
			this.isUp = true;
			//Debug.Log ("button ended");
		}

		public override void OnTouchFinished ()
		{
			this.Reset ();
			//Debug.Log ("button finished");

			if (!this.firesOnBegan)
				InGameController.Instance.TouchEvent (this.name);
				//if (this.target != null)
					//this.target.SendMessage (this.callback, this.name);
		}

		public override void Reset ()
		{
			this.GetComponent<SpriteRenderer> ().color = this.startingColor;
			this.isDown = false;
			this.isPressed = false;
			this.isUp = false;
			//Debug.Log ("reset");
		}
	}
}
