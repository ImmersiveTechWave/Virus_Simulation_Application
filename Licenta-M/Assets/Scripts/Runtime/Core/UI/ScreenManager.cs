using System;
using System.Collections.Generic;
using UnityEngine;

namespace MF.UI
{
	public class ScreenManager : MonoBehaviour
	{
		public Dictionary<Type, MFScreen> Screens = new Dictionary<Type, MFScreen>();
		public MFScreen ActiveScreen { get; set; } = null;
		public MFScreen PreviousScreen { get; set; } = null;
		public MFScreen FirstScreen { get; set; } = null;

		private void Awake()
		{
			foreach (var screen in GetComponentsInChildren<MFScreen>())
			{
				Screens[screen.GetType()] = screen;
			}

			foreach (var keys in Screens.Keys)
			{
				Screens[keys].gameObject.GetComponent<RectTransform>().offsetMin = Vector3.zero;
				Screens[keys].gameObject.GetComponent<RectTransform>().offsetMax = Vector3.zero;
				Screens[keys].gameObject.SetActive(false);
			}
			SetFirstScreen<UICreateVirusScreenScreenController>();
		}

		private void Start()
		{
			if (FirstScreen != null)
				ShowScreen(FirstScreen.GetType());
		}

		public void ShowScreen<T>() where T : MFScreen
		{
			ShowScreen(typeof(T));
		}

		public void ShowPanel<T>() where T : MFScreen
		{
			ShowPanel(typeof(T));
		}

		public void ShowPanel(Type type)
		{
			Screens[type].gameObject.SetActive(true);
		}

		public void ClosePanel<T>() where T : MFScreen
		{
			ClosePanel(typeof(T));
		}

		public void ClosePanel(Type type)
		{
			Screens[type].gameObject.SetActive(false);
		}

		public void ShowScreen(Type type)
		{
			PreviousScreen = ActiveScreen;
			ActiveScreen = Screens[type];

			PreviousScreen?.gameObject.SetActive(false);
			ActiveScreen.gameObject.SetActive(true);
		}

		public void SetFirstScreen<T>()
		{
			SetFirstScreen(typeof(T));
		}

		public void SetFirstScreen(Type type)
		{
			FirstScreen = Screens[type];
		}
	}
}
