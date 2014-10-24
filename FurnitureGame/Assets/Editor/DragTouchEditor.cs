/*
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;
using System.Reflection;
using System;
using InputFramework;


[CustomEditor(typeof(DragTouch))]
public class DragTouchEditor : Editor
{
	static string[] methods;
	static string[] ignoreMethods = new string[] { "Start", "Update", "Awake" };


	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI ();

		DragTouch obj = target as DragTouch;

		if (obj != null)
		{
			if (obj.Target != null) {
				Type type = obj.Target.GetType ();

				methods =
					type
						.GetMethods (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public) // Instance methods, both public and private/protected
						.Where (x => x.DeclaringType == type) // Only list methods defined in our own class
						.Where (x => x.GetParameters ().Length <= 1) // Make sure we only get methods with zero argumenrts
						.Where (x => !ignoreMethods.Any (n => n == x.Name)) // Don't list methods in the ignoreMethods array (so we can exclude Unity specific methods, etc.)
						.Select (x => x.Name)
						.ToArray ();

				int index;

				try {
					index = methods
						.Select ((v, i) => new { Name = v, Index = i })
						.First (x => x.Name == obj.Callback)
						.Index;
				} catch {
					index = 0;
				}

				obj.Callback = methods [EditorGUILayout.Popup ("Callback", index, methods)];
			}
		}
	}
}
*/

