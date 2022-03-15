using UnityEditor;
using UnityEngine;

namespace MF
{
	[CustomEditor(typeof(ActorController), true)]
	public class ActorSettingsProvider : Editor
	{
		private static class Styles
		{
			public static readonly GUIContent MODEL_SETTINGS = new GUIContent("Model settings", "Contains settings that are in the Actor's model.");
			public static readonly GUIContent HEALTH_SETTINGS = new GUIContent("Health", "Contains the health value of the actor.");
			public static readonly GUIContent ENERGY_SETTINGS = new GUIContent("Energy", "Contains the energy value of the actor.");
			public static readonly GUIContent MONEY_SETTINGS = new GUIContent("Money", "Contains the money value of the actor.");
			public static readonly GUIContent HUNGER_SETTINGS = new GUIContent("Hunger", "Contains the hunger value of the actor.");
			public static readonly GUIContent CURRENT_VELOCITY_SETTINGS = new GUIContent("Current Velocity", "Contains the current velocity of the actor.");

		}

		private bool showModelSettings = true;
		private ActorController actor;

		public override void OnInspectorGUI()
		{
			actor = (ActorController)target;
			DrawModelSettings();
		}

		private void DrawModelSettings()
		{
			if (showModelSettings = EditorGUILayout.BeginFoldoutHeaderGroup(showModelSettings, Styles.MODEL_SETTINGS))
			{
				++EditorGUI.indentLevel;

				if (actor.Model != null)
				{
					// read-only settings
					GUI.enabled = false;
					EditorGUILayout.TextField(Styles.HEALTH_SETTINGS, actor.Model.Health.Value.ToString());
					EditorGUILayout.TextField(Styles.ENERGY_SETTINGS, actor.Model.Energy.Value.ToString());
					EditorGUILayout.TextField(Styles.MONEY_SETTINGS, actor.Model.Money.Value.ToString());
					EditorGUILayout.TextField(Styles.HUNGER_SETTINGS, actor.Model.Hunger.Value.ToString());
					EditorGUILayout.TextField(Styles.CURRENT_VELOCITY_SETTINGS, actor.Model.CurrentVelocity.ToString());

					// read-write settings
					GUI.enabled = true;
				}
				else
				{
					EditorGUILayout.HelpBox("The actor's model is not yet initialized", MessageType.Info);
				}

				--EditorGUI.indentLevel;
			}

			EditorGUILayout.EndFoldoutHeaderGroup();
		}
	}
}
