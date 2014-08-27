using UnityEngine;
using System.Collections;

namespace InputFramework{
	public class TouchObject : MonoBehaviour
	{
		public Camera inputCamera;

		protected GameObject touchArea;
		protected Vector2 startPosition;
		protected Vector2 curPosition;
		protected Vector2 mousePos;
		protected Vector2 screenPos;
		protected GameObject currentObj;

		// Use this for initialization
		void Start ()
		{
		
		}
		
		// Update is called once per frame
		void Update ()
		{
		
		}
	}
}
