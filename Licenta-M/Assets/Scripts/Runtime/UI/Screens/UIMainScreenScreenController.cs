namespace MF.UI
{
	public class UIMainScreenScreenController : MFScreen
	{
		public UIMainScreenScreenComponents ScreenView { get; private set; }

		private TimeManager timeManager;

		public override void Awake()
		{
			base.Awake();
			ScreenView = GetComponent<UIMainScreenScreenComponents>();
			timeManager = FindObjectOfType<TimeManager>();
		}

		private void Start()
		{
			ScreenManager.ShowScreen<UIMainScreenScreenController>();
			timeManager.TimeText = ScreenView.UICurrentTime;

			ScreenView.UITimeManagerPlayTime.onClick.AddListener(StartTime);
			ScreenView.UITimeManagerStopTime.onClick.AddListener(StopTime);

			ScreenView.UIInfoPanelHolderInfoPanelUpClosePanel.onClick.AddListener(CloseHumanInfoPanel);

			SetUIElementStartState();
		}

		private void Update()
		{
			UpdateSelectedHumanInfoPanel();
		}

		private void UpdateSelectedHumanInfoPanel()
		{
			if (App.SelectedHumanController != null)
			{
				ScreenView.UIInfoPanelHolderInfoPanelMoney.text = "Money: " + App.SelectedHumanController.Model.Money * 10 + "$";
				ScreenView.UIInfoPanelHolderInfoPanelHealth.text = "Health: " + App.SelectedHumanController.Model.Health;
				ScreenView.UIInfoPanelHolderInfoPanelEnergy.text = "Energy: " + App.SelectedHumanController.Model.Energy;
				ScreenView.UIInfoPanelHolderInfoPanelHunger.text = "Hunger: " + App.SelectedHumanController.Model.Hunger;
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
	}
}
