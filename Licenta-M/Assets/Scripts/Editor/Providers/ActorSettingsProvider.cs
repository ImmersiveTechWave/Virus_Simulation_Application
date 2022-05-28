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
			public static readonly GUIContent HOME_SETTINGS = new GUIContent("Home position", "Contains the current home position of the actor.");
			public static readonly GUIContent JOB_SETTINGS = new GUIContent("Job position", "Contains the current job position of the actor.");
			public static readonly GUIContent SHOP_SETTINGS = new GUIContent("Shop position", "Contains the current shop position of the actor.");
			public static readonly GUIContent HOSPITAL_SETTINGS = new GUIContent("Hospital position", "Contains the current hospital position of the actor.");
			public static readonly GUIContent WORK_HOURS = new GUIContent("Work hours", "Contains the work hours of the actor.");
			public static readonly GUIContent SLEEP_HOURS = new GUIContent("Sleep hours", "Contains the sleep hours of the actor.");

			public static readonly GUIContent ACTIVITY_SETTINGS = new GUIContent("Current Activity", "Contains the current activity of the actor.");
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
					EditorGUILayout.TextField(Styles.HOME_SETTINGS, actor.Model.HomePosition.name.ToString());
					EditorGUILayout.TextField(Styles.JOB_SETTINGS, actor.Model.JobPosition.name.ToString());
					EditorGUILayout.TextField(Styles.SHOP_SETTINGS, actor.Model.ShopPosition.name.ToString());
					EditorGUILayout.TextField(Styles.HOSPITAL_SETTINGS, actor.Model.HospitalPosition.name.ToString());
					EditorGUILayout.TextField(Styles.ACTIVITY_SETTINGS, actor.Model.CurrentActivity.ToString());
					EditorGUILayout.TextField(Styles.WORK_HOURS, actor.Model.StartTimeModelToWork.ToString() + " -> " + actor.Model.EndTimeModelToWork.ToString());
					EditorGUILayout.TextField(Styles.SLEEP_HOURS, actor.Model.StartTimeModelToSleep.ToString() + " -> " + actor.Model.EndTimeModelToSleep.ToString());


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
