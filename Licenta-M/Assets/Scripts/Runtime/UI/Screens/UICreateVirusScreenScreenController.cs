using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF.UI
{
	public class UICreateVirusScreenScreenController : MFScreen
	{
		public UICreateVirusScreenScreenComponents ScreenView { get; set; }

		public override void Awake()
		{
			base.Awake();
			ScreenView = GetComponent<UICreateVirusScreenScreenComponents>();
			ScreenManager.FirstScreen = this;
		}

		private void Start()
		{
			ScreenView.UIPreSetHolderNormalFluButton.onClick.AddListener(SetNormalFluValues);
			ScreenView.UIPreSetHolderCovidButton.onClick.AddListener(SetCovidValues);
			ScreenView.UIPreSetHolderSARSButton.onClick.AddListener(SetSARSValues);
			ScreenView.UIPreSetHolderMERS.onClick.AddListener(SetMERSValues);
			ScreenView.UIInputHolderStartButton.onClick.AddListener(StartSimulation);
		}

		private void StartSimulation()
		{
			var isReadyToStart = true;
			var spreadRateValue = ScreenView.UIInputHolderSpreadRateHolderSpreadRateInput.text == "" ?
				-1f : float.Parse(ScreenView.UIInputHolderSpreadRateHolderSpreadRateInput.text);
			var deathRateValue = ScreenView.UIInputHolderDeathRateHolderDeathRateInput.text == "" ?
				-1f : float.Parse(ScreenView.UIInputHolderDeathRateHolderDeathRateInput.text);
			var hospitalizationRateValue = ScreenView.UIInputHolderHospitalizationRateHolderHospitalizationRateInput.text == "" ?
				-1f : float.Parse(ScreenView.UIInputHolderHospitalizationRateHolderHospitalizationRateInput.text);
			var incubationTimeValue = ScreenView.UIInputHolderIncubationTimeHolderIncubationTimeInput.text == "" ?
				-1f : float.Parse(ScreenView.UIInputHolderIncubationTimeHolderIncubationTimeInput.text);

			if (spreadRateValue < 0 || spreadRateValue > 5)
			{
				ScreenView.UIInputHolderSpreadRateHolderWarning.gameObject.SetActive(true);
				isReadyToStart = false;
			}
			else
			{
				ScreenView.UIInputHolderSpreadRateHolderWarning.gameObject.SetActive(false);
			}

			if (deathRateValue < 0 || deathRateValue > 100)
			{
				ScreenView.UIInputHolderDeathRateHolderWarning.gameObject.SetActive(true);
				isReadyToStart = false;
			}
			else
			{
				ScreenView.UIInputHolderDeathRateHolderWarning.gameObject.SetActive(false);
			}

			if (hospitalizationRateValue < 0 || hospitalizationRateValue > 100)
			{
				ScreenView.UIInputHolderHospitalizationRateHolderWarning.gameObject.SetActive(true);
				isReadyToStart = false;
			}
			else
			{
				ScreenView.UIInputHolderHospitalizationRateHolderWarning.gameObject.SetActive(false);
			}

			if (incubationTimeValue < 0 || incubationTimeValue > 20)
			{
				ScreenView.UIInputHolderIncubationTimeHolderWarning.gameObject.SetActive(true);
				isReadyToStart = false;
			}
			else
			{
				ScreenView.UIInputHolderIncubationTimeHolderWarning.gameObject.SetActive(false);
			}

			if (isReadyToStart)
			{
				ScreenManager.ShowScreen<UIMainScreenScreenController>();
			}
		}

		private void SetNormalFluValues()
		{
			ScreenView.UIInputHolderSpreadRateHolderSpreadRateInput.text = "1.3";
			ScreenView.UIInputHolderDeathRateHolderDeathRateInput.text = "0.07";
			ScreenView.UIInputHolderHospitalizationRateHolderHospitalizationRateInput.text = "2";
			ScreenView.UIInputHolderIncubationTimeHolderIncubationTimeInput.text = "2";
		}

		private void SetCovidValues()
		{
			ScreenView.UIInputHolderSpreadRateHolderSpreadRateInput.text = "2.25";
			ScreenView.UIInputHolderDeathRateHolderDeathRateInput.text = "3.4";
			ScreenView.UIInputHolderHospitalizationRateHolderHospitalizationRateInput.text = "19";
			ScreenView.UIInputHolderIncubationTimeHolderIncubationTimeInput.text = "7";
		}

		private void SetSARSValues()
		{
			ScreenView.UIInputHolderSpreadRateHolderSpreadRateInput.text = "3";
			ScreenView.UIInputHolderDeathRateHolderDeathRateInput.text = "10.2";
			ScreenView.UIInputHolderHospitalizationRateHolderHospitalizationRateInput.text = "90";
			ScreenView.UIInputHolderIncubationTimeHolderIncubationTimeInput.text = "5";
		}

		private void SetMERSValues()
		{
			ScreenView.UIInputHolderSpreadRateHolderSpreadRateInput.text = "0.6";
			ScreenView.UIInputHolderDeathRateHolderDeathRateInput.text = "34.4";
			ScreenView.UIInputHolderHospitalizationRateHolderHospitalizationRateInput.text = "90";
			ScreenView.UIInputHolderIncubationTimeHolderIncubationTimeInput.text = "6";
		}
	}
}
