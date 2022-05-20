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

	private void Awake()
	{
		UICurrentTime = transform.Find("CurrentTime").GetComponent<TextMeshProUGUI>();
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
	}
}
}
