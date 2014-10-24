/*using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using InputFramework;


[CustomEditor(typeof(AssemblyInstructions))]
public class AssemblyInstructionsEditor : Editor
{
	static string[] methods;
	static string[] ignoreMethods = new string[] { "Start", "Update" };

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI ();

		AssemblyInstructions obj = target as AssemblyInstructions;

		if (obj != null)
		{
			for (int i = 0; i < obj.numSteps; i++){
				EditorGUILayout.LabelField ("Step " + i.ToString ());


			}
		}
	}
}
*/