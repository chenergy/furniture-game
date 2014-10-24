using UnityEngine;

namespace InputFramework
{
	interface ITouchable
	{
		void OnTouchBegan ();
		void OnTouchMoved ();
		void OnTouchStationary ();
		void OnTouchEnd ();
		void OnTouchFinished ();
		void Reset ();
	}
}
