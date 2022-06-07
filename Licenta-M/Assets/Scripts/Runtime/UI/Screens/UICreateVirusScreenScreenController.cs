using UnityEngine;
using UnityEngine.SceneManagement;

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
			ScreenView.UIExitButton.onClick.AddListener(CloseApplication);
		}

		private void CloseApplication()
		{
			Application.Quit();
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
			var nameValue = ScreenView.UIInputHolderNameHolderNameInput.text;

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

			if (string.IsNullOrEmpty(nameValue))
			{
				ScreenView.UIInputHolderNameHolderWarning.gameObject.SetActive(true);
				isReadyToStart = false;
			}
			else
			{
				ScreenView.UIInputHolderNameHolderWarning.gameObject.SetActive(false);
			}

			if (isReadyToStart)
			{
				App.CurrentVirus = new VirusModel(nameValue, spreadRateValue, deathRateValue, hospitalizationRateValue);
				ScreenManager.ShowScreen<UIMainScreenScreenController>();
				App.CurrentVirus.TotalCases = HumanManager.NUMBER_INFECTED_PEOPLE;
				App.CurrentVirus.CurrentCases = HumanManager.NUMBER_INFECTED_PEOPLE;
				App.CurrentVirus.MildCases = HumanManager.NUMBER_INFECTED_PEOPLE;
				App.TimeManager.SetTime();
			}
		}

		public override void OnExit()
		{
			base.OnExit();
			ScreenView.UIInputHolderSpreadRateHolderSpreadRateInput.text = "";
			ScreenView.UIInputHolderDeathRateHolderDeathRateInput.text = "";
			ScreenView.UIInputHolderHospitalizationRateHolderHospitalizationRateInput.text = "";
			ScreenView.UIInputHolderNameHolderNameInput.text = "";
		}

		private void SetNormalFluValues()
		{
			ScreenView.UIInputHolderSpreadRateHolderSpreadRateInput.text = "1.3";
			ScreenView.UIInputHolderDeathRateHolderDeathRateInput.text = "0.07";
			ScreenView.UIInputHolderHospitalizationRateHolderHospitalizationRateInput.text = "2";
			ScreenView.UIInputHolderNameHolderNameInput.text = "Normal Flu";
		}

		private void SetCovidValues()
		{
			ScreenView.UIInputHolderSpreadRateHolderSpreadRateInput.text = "2.25";
			ScreenView.UIInputHolderDeathRateHolderDeathRateInput.text = "3.4";
			ScreenView.UIInputHolderHospitalizationRateHolderHospitalizationRateInput.text = "19";
			ScreenView.UIInputHolderNameHolderNameInput.text = "COVID-19";
		}

		private void SetSARSValues()
		{
			ScreenView.UIInputHolderSpreadRateHolderSpreadRateInput.text = "3";
			ScreenView.UIInputHolderDeathRateHolderDeathRateInput.text = "10.2";
			ScreenView.UIInputHolderHospitalizationRateHolderHospitalizationRateInput.text = "90";
			ScreenView.UIInputHolderNameHolderNameInput.text = "SARS";
		}

		private void SetMERSValues()
		{
			ScreenView.UIInputHolderSpreadRateHolderSpreadRateInput.text = "0.6";
			ScreenView.UIInputHolderDeathRateHolderDeathRateInput.text = "34.4";
			ScreenView.UIInputHolderHospitalizationRateHolderHospitalizationRateInput.text = "90";
			ScreenView.UIInputHolderNameHolderNameInput.text = "MERS";
		}
	}
}
