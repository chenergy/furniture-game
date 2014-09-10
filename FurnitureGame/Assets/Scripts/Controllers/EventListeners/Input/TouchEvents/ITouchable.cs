using UnityEngine;

namespace InputFramework
{
	interface ITouchable
	{
		void OnTouchBegan();
		void OnTouchMoved();
		void OnTouchEnd();
	}
}

