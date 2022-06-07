using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

namespace MF.UI
{
public class UIMainScreenScreenComponents : MonoBehaviour
{
	public TextMeshProUGUI UICurrentTime{ get; protected set; }
	public TextMeshProUGUI UICurrentDay{ get; protected set; }
	public RectTransform UITimeManager{ get; protected set; }
	public Button UITimeManagerStopTime{ get; protected set; }
	public Button UITimeManagerPlayTime{ get; protected set; }
	public RectTransform UIInfoPanelHolder{ get; protected set; }
	public Image UIInfoPanelHolderInfoPanel{ get; protected set; }
	public TextMeshProUGUI UIInfoPanelHolderInfoPanelName{ get; protected set; }
	public TextMeshProUGUI UIInfoPanelHolderInfoPanelAge{ get; protected set; }
	public TextMeshProUGUI UIInfoPanelHolderInfoPanelCurrentActivity{ get; protected set; }
	public TextMeshProUGUI UIInfoPanelHolderInfoPanelMoney{ get; protected set; }
	public TextMeshProUGUI UIInfoPanelHolderInfoPanelHealth{ get; protected set; }
	public TextMeshProUGUI UIInfoPanelHolderInfoPanelEnergy{ get; protected set; }
	public TextMeshProUGUI UIInfoPanelHolderInfoPanelHunger{ get; protected set; }
	public TextMeshProUGUI UIInfoPanelHolderInfoPanelVirusStatus{ get; protected set; }
	public Image UIInfoPanelHolderInfoPanelUp{ get; protected set; }
	public Button UIInfoPanelHolderInfoPanelUpClosePanel{ get; protected set; }
	public RectTransform UIVirusInfoHolder{ get; protected set; }
	public Image UIVirusInfoHolderVirusInfoBackground{ get; protected set; }
	public TextMeshProUGUI UIVirusInfoHolderVirusInfoBackgroundVirusName{ get; protected set; }
	public TextMeshProUGUI UIVirusInfoHolderVirusInfoBackgroundSpreadRate{ get; protected set; }
	public TextMeshProUGUI UIVirusInfoHolderVirusInfoBackgroundDeathRate{ get; protected set; }
	public TextMeshProUGUI UIVirusInfoHolderVirusInfoBackgroundHospitalizationRate{ get; protected set; }
	public TextMeshProUGUI UIVirusInfoHolderVirusInfoBackgroundCurrentCases{ get; protected set; }
	public TextMeshProUGUI UIVirusInfoHolderVirusInfoBackgroundTotalCases{ get; protected set; }
	public TextMeshProUGUI UIVirusInfoHolderVirusInfoBackgroundTotalDeaths{ get; protected set; }
	public TextMeshProUGUI UIVirusInfoHolderVirusInfoBackgroundSevereCases{ get; protected set; }
	public TextMeshProUGUI UIVirusInfoHolderVirusInfoBackgroundMildCases{ get; protected set; }
	public TextMeshProUGUI UIVirusInfoHolderVirusInfoBackgroundRecoverd{ get; protected set; }
	public Toggle UIVirusInfoHolderVirusInfoBackgroundMaskToggle{ get; protected set; }
	public Toggle UIVirusInfoHolderVirusInfoBackgroundVaccineToggle{ get; protected set; }
	public Toggle UIVirusInfoHolderVirusInfoBackgroundQuarantineToggle{ get; protected set; }
	public Button UIMenuButton{ get; protected set; }
	public Image UIMenuButtonImage{ get; protected set; }
	public Button UIExitButton{ get; protected set; }
	public Image UIExitButtonImage{ get; protected set; }

	private void Awake()
	{
		UICurrentTime = transform.Find("CurrentTime").GetComponent<TextMeshProUGUI>();
		UICurrentDay = transform.Find("CurrentDay").GetComponent<TextMeshProUGUI>();
		UITimeManager = transform.Find("TimeManager").GetComponent<RectTransform>();
		UITimeManagerStopTime = transform.Find("TimeManager/StopTime").GetComponent<Button>();
		UITimeManagerPlayTime = transform.Find("TimeManager/PlayTime").GetComponent<Button>();
		UIInfoPanelHolder = transform.Find("InfoPanelHolder").GetComponent<RectTransform>();
		UIInfoPanelHolderInfoPanel = transform.Find("InfoPanelHolder/InfoPanel").GetComponent<Image>();
		UIInfoPanelHolderInfoPanelName = transform.Find("InfoPanelHolder/InfoPanel/Name").GetComponent<TextMeshProUGUI>();
		UIInfoPanelHolderInfoPanelAge = transform.Find("InfoPanelHolder/InfoPanel/Age").GetComponent<TextMeshProUGUI>();
		UIInfoPanelHolderInfoPanelCurrentActivity = transform.Find("InfoPanelHolder/InfoPanel/CurrentActivity").GetComponent<TextMeshProUGUI>();
		UIInfoPanelHolderInfoPanelMoney = transform.Find("InfoPanelHolder/InfoPanel/Money").GetComponent<TextMeshProUGUI>();
		UIInfoPanelHolderInfoPanelHealth = transform.Find("InfoPanelHolder/InfoPanel/Health").GetComponent<TextMeshProUGUI>();
		UIInfoPanelHolderInfoPanelEnergy = transform.Find("InfoPanelHolder/InfoPanel/Energy").GetComponent<TextMeshProUGUI>();
		UIInfoPanelHolderInfoPanelHunger = transform.Find("InfoPanelHolder/InfoPanel/Hunger").GetComponent<TextMeshProUGUI>();
		UIInfoPanelHolderInfoPanelVirusStatus = transform.Find("InfoPanelHolder/InfoPanel/VirusStatus").GetComponent<TextMeshProUGUI>();
		UIInfoPanelHolderInfoPanelUp = transform.Find("InfoPanelHolder/InfoPanelUp").GetComponent<Image>();
		UIInfoPanelHolderInfoPanelUpClosePanel = transform.Find("InfoPanelHolder/InfoPanelUp/ClosePanel").GetComponent<Button>();
		UIVirusInfoHolder = transform.Find("VirusInfoHolder").GetComponent<RectTransform>();
		UIVirusInfoHolderVirusInfoBackground = transform.Find("VirusInfoHolder/VirusInfoBackground").GetComponent<Image>();
		UIVirusInfoHolderVirusInfoBackgroundVirusName = transform.Find("VirusInfoHolder/VirusInfoBackground/VirusName").GetComponent<TextMeshProUGUI>();
		UIVirusInfoHolderVirusInfoBackgroundSpreadRate = transform.Find("VirusInfoHolder/VirusInfoBackground/SpreadRate").GetComponent<TextMeshProUGUI>();
		UIVirusInfoHolderVirusInfoBackgroundDeathRate = transform.Find("VirusInfoHolder/VirusInfoBackground/DeathRate").GetComponent<TextMeshProUGUI>();
		UIVirusInfoHolderVirusInfoBackgroundHospitalizationRate = transform.Find("VirusInfoHolder/VirusInfoBackground/HospitalizationRate").GetComponent<TextMeshProUGUI>();
		UIVirusInfoHolderVirusInfoBackgroundCurrentCases = transform.Find("VirusInfoHolder/VirusInfoBackground/CurrentCases").GetComponent<TextMeshProUGUI>();
		UIVirusInfoHolderVirusInfoBackgroundTotalCases = transform.Find("VirusInfoHolder/VirusInfoBackground/Total Cases").GetComponent<TextMeshProUGUI>();
		UIVirusInfoHolderVirusInfoBackgroundTotalDeaths = transform.Find("VirusInfoHolder/VirusInfoBackground/TotalDeaths").GetComponent<TextMeshProUGUI>();
		UIVirusInfoHolderVirusInfoBackgroundSevereCases = transform.Find("VirusInfoHolder/VirusInfoBackground/SevereCases").GetComponent<TextMeshProUGUI>();
		UIVirusInfoHolderVirusInfoBackgroundMildCases = transform.Find("VirusInfoHolder/VirusInfoBackground/MildCases").GetComponent<TextMeshProUGUI>();
		UIVirusInfoHolderVirusInfoBackgroundRecoverd = transform.Find("VirusInfoHolder/VirusInfoBackground/Recoverd").GetComponent<TextMeshProUGUI>();
		UIVirusInfoHolderVirusInfoBackgroundMaskToggle = transform.Find("VirusInfoHolder/VirusInfoBackground/MaskToggle").GetComponent<Toggle>();
		UIVirusInfoHolderVirusInfoBackgroundVaccineToggle = transform.Find("VirusInfoHolder/VirusInfoBackground/VaccineToggle").GetComponent<Toggle>();
		UIVirusInfoHolderVirusInfoBackgroundQuarantineToggle = transform.Find("VirusInfoHolder/VirusInfoBackground/QuarantineToggle").GetComponent<Toggle>();
		UIMenuButton = transform.Find("MenuButton").GetComponent<Button>();
		UIMenuButtonImage = transform.Find("MenuButton/Image").GetComponent<Image>();
		UIExitButton = transform.Find("ExitButton").GetComponent<Button>();
		UIExitButtonImage = transform.Find("ExitButton/Image").GetComponent<Image>();
	}
}
}
