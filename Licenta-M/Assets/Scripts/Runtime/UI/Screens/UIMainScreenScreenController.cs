using UnityEngine;
using UnityEngine.SceneManagement;

namespace MF.UI
{
	public class UIMainScreenScreenController : MFScreen
	{
		public UIMainScreenScreenComponents ScreenView { get; private set; }

		private TimeManager timeManager;
		private HumanManager humanManager;

		public override void Awake()
		{
			base.Awake();
			ScreenView = GetComponent<UIMainScreenScreenComponents>();
			timeManager = FindObjectOfType<TimeManager>();
			humanManager = FindObjectOfType<HumanManager>();
		}

		private void Start()
		{
			ScreenManager.ShowScreen<UIMainScreenScreenController>();

			ScreenView.UITimeManagerPlayTime.onClick.AddListener(StartTime);
			ScreenView.UITimeManagerStopTime.onClick.AddListener(StopTime);

			ScreenView.UIInfoPanelHolderInfoPanelUpClosePanel.onClick.AddListener(CloseHumanInfoPanel);
			ScreenView.UIVirusInfoHolderVirusInfoBackgroundMaskToggle.onValueChanged.AddListener(OnMaskStateChanged);
			ScreenView.UIVirusInfoHolderVirusInfoBackgroundVaccineToggle.onValueChanged.AddListener(OnVaccinStateChanged);
			ScreenView.UIVirusInfoHolderVirusInfoBackgroundQuarantineToggle.onValueChanged.AddListener(OnQuarantineStateChanged);
			ScreenView.UIMenuButton.onClick.AddListener(GoToMenu);
			ScreenView.UIExitButton.onClick.AddListener(CloseApplication);
			SetUIElementStartState();
		}

		private void Update()
		{
			UpdateSelectedHumanInfoPanel();
			UpdateTime();
		}

		private void OnQuarantineStateChanged(bool state)
		{
			humanManager.SetHumansQuarantine(state);
		}

		private void UpdateTime()
		{
			ScreenView.UICurrentDay.text = "Day " + timeManager.TimeModel.Day;
			var newTime = string.Format("{0:0}:{1:00}:{2:00}", timeManager.TimeModel.Hours, timeManager.TimeModel.Minutes, timeManager.TimeModel.Seconds);
			ScreenView.UICurrentTime.text = newTime;
		}

		private void CloseApplication()
		{
			Application.Quit();
		}

		private void OnMaskStateChanged(bool state)
		{
			if (state)
			{
				App.CurrentVirus.SpreadRate *= 0.33f;
			}
			else
			{
				App.CurrentVirus.SpreadRate /= 0.33f;
			}
			SetUpVirusInfoPanel();
		}

		private void GoToMenu()
		{
			App.IsTimeStopped = true;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
			ScreenManager.ShowScreen<UICreateVirusScreenScreenController>();
		}

		private void OnVaccinStateChanged(bool state)
		{
			if (state)
			{
				App.CurrentVirus.SpreadRate *= 0.97f;
				App.CurrentVirus.DeathRate *= 0.12f;
				App.CurrentVirus.HospitalizationRate *= 0.17f;
			}
			else
			{
				App.CurrentVirus.SpreadRate /= 0.97f;
				App.CurrentVirus.DeathRate /= 0.12f;
				App.CurrentVirus.HospitalizationRate /= 0.17f;
			}
			SetUpVirusInfoPanel();
		}

		private void UpdateSelectedHumanInfoPanel()
		{
			if (App.SelectedHumanController != null)
			{
				ScreenView.UIInfoPanelHolderInfoPanelMoney.text = "Money: " + App.SelectedHumanController.Model.Money * 10 + "$";
				ScreenView.UIInfoPanelHolderInfoPanelHealth.text = "Health: " + App.SelectedHumanController.Model.Health;
				ScreenView.UIInfoPanelHolderInfoPanelEnergy.text = "Energy: " + App.SelectedHumanController.Model.Energy;
				ScreenView.UIInfoPanelHolderInfoPanelHunger.text = "Hunger: " + App.SelectedHumanController.Model.Hunger;
				ScreenView.UIVirusInfoHolderVirusInfoBackgroundCurrentCases.text = "Current Cases: " + App.CurrentVirus?.CurrentCases.ToString();
				ScreenView.UIVirusInfoHolderVirusInfoBackgroundTotalCases.text = "Total Cases: " + App.CurrentVirus?.TotalCases.ToString();
				ScreenView.UIVirusInfoHolderVirusInfoBackgroundRecoverd.text = "Recoverd: " + App.CurrentVirus?.Recovered.ToString();
				ScreenView.UIVirusInfoHolderVirusInfoBackgroundTotalDeaths.text = "Deaths: " + App.CurrentVirus?.Deaths.ToString();
				ScreenView.UIInfoPanelHolderInfoPanelVirusStatus.text = App.SelectedHumanController.MyModel.IsInfected ? "Virus State: Infected" : "Virus State: Uninfected";
				ScreenView.UIInfoPanelHolderInfoPanelVirusStatus.color = App.SelectedHumanController.MyModel.IsInfected ? Color.red : Color.green;
				ScreenView.UIVirusInfoHolderVirusInfoBackgroundTotalDeaths.text = "Deaths: " + App.CurrentVirus?.Deaths.ToString();
				ScreenView.UIVirusInfoHolderVirusInfoBackgroundSevereCases.text = "Severe Cases: " + App.CurrentVirus?.SevereCases.ToString();
				ScreenView.UIVirusInfoHolderVirusInfoBackgroundMildCases.text = "Mild Cases: " + App.CurrentVirus?.MildCases.ToString();
			}
		}

		public void CloseHumanInfoPanel()
		{
			ScreenView.UIInfoPanelHolder.gameObject.SetActive(false);
		}

		private void SetUIElementStartState()
		{
			ScreenView.UITimeManagerPlayTime.gameObject.SetActive(true);
			ScreenView.UITimeManagerStopTime.gameObject.SetActive(false);
			ScreenView.UIInfoPanelHolder.gameObject.SetActive(false);
		}

		private void StopTime()
		{
			App.IsTimeStopped = true;
			ScreenView.UITimeManagerStopTime.gameObject.SetActive(false);
			ScreenView.UITimeManagerPlayTime.gameObject.SetActive(true);
		}

		private void StartTime()
		{
			App.IsTimeStopped = false;
			ScreenView.UITimeManagerStopTime.gameObject.SetActive(true);
			ScreenView.UITimeManagerPlayTime.gameObject.SetActive(false);
		}

		public void HumanWasSelected()
		{
			if (App.SelectedHumanController != null)
			{
				ScreenView.UIInfoPanelHolder.gameObject.SetActive(true);
				ScreenView.UIInfoPanelHolderInfoPanelName.text = "Name: " + App.SelectedHumanController.Model.Name;
				ScreenView.UIInfoPanelHolderInfoPanelAge.text = "Age: " + App.SelectedHumanController.Model.Age;
				ScreenView.UIInfoPanelHolderInfoPanelCurrentActivity.text = "Current Activity: " + App.SelectedHumanController.Model.CurrentActivity.ToString();
				ScreenView.UIInfoPanelHolderInfoPanelMoney.text = "Money: " + App.SelectedHumanController.Model.Money;
				ScreenView.UIInfoPanelHolderInfoPanelHealth.text = "Health: " + App.SelectedHumanController.Model.Health;
				ScreenView.UIInfoPanelHolderInfoPanelEnergy.text = "Energy: " + App.SelectedHumanController.Model.Energy;
				ScreenView.UIInfoPanelHolderInfoPanelHunger.text = "Hunger: " + App.SelectedHumanController.Model.Hunger;
			}
		}

		public override void OnEnter()
		{
			base.OnEnter();
			SetUIElementStartState();
			SetUpVirusInfoPanel();
		}

		private void SetUpVirusInfoPanel()
		{
			ScreenView.UIVirusInfoHolderVirusInfoBackgroundVirusName.text = App.CurrentVirus?.Name;
			ScreenView.UIVirusInfoHolderVirusInfoBackgroundSpreadRate.text = "Spread Rate: " + App.CurrentVirus?.SpreadRate.ToString();
			ScreenView.UIVirusInfoHolderVirusInfoBackgroundDeathRate.text = " Death Rate: " + App.CurrentVirus?.DeathRate.ToString() + "%";
			ScreenView.UIVirusInfoHolderVirusInfoBackgroundHospitalizationRate.text = "Hospitalization Rate: " + App.CurrentVirus?.HospitalizationRate.ToString() + "%";
			ScreenView.UIVirusInfoHolderVirusInfoBackgroundIncubationTime.text = "Incubation Time:\n" + App.CurrentVirus?.IncubationTime.ToString() + " Days";
			ScreenView.UIVirusInfoHolderVirusInfoBackgroundCurrentCases.text = "Current Cases: " + App.CurrentVirus?.CurrentCases.ToString();
			ScreenView.UIVirusInfoHolderVirusInfoBackgroundTotalCases.text = "Total Cases: " + App.CurrentVirus?.TotalCases.ToString();
			ScreenView.UIVirusInfoHolderVirusInfoBackgroundRecoverd.text = "Recoverd: " + App.CurrentVirus?.Recovered.ToString();
			ScreenView.UIVirusInfoHolderVirusInfoBackgroundTotalDeaths.text = "Deaths: " + App.CurrentVirus?.Deaths.ToString();
			ScreenView.UIVirusInfoHolderVirusInfoBackgroundSevereCases.text = "Severe Cases: " + App.CurrentVirus?.SevereCases.ToString();
			ScreenView.UIVirusInfoHolderVirusInfoBackgroundMildCases.text = "Mild Cases: " + App.CurrentVirus?.MildCases.ToString();
		}
	}
}
