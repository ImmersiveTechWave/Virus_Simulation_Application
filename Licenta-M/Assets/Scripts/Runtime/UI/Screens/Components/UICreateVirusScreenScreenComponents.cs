using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

namespace MF.UI
{
public class UICreateVirusScreenScreenComponents : MonoBehaviour
{
	public TextMeshProUGUI UITitle{ get; protected set; }
	public RectTransform UIInputHolder{ get; protected set; }
	public RectTransform UIInputHolderSpreadRateHolder{ get; protected set; }
	public TextMeshProUGUI UIInputHolderSpreadRateHolderText{ get; protected set; }
	public TMP_InputField UIInputHolderSpreadRateHolderSpreadRateInput{ get; protected set; }
	public RectTransform UIInputHolderSpreadRateHolderSpreadRateInputTextArea{ get; protected set; }
	public TextMeshProUGUI UIInputHolderSpreadRateHolderSpreadRateInputTextAreaPlaceholder{ get; protected set; }
	public TextMeshProUGUI UIInputHolderSpreadRateHolderSpreadRateInputTextAreaText{ get; protected set; }
	public TextMeshProUGUI UIInputHolderSpreadRateHolderWarning{ get; protected set; }
	public RectTransform UIInputHolderDeathRateHolder{ get; protected set; }
	public TextMeshProUGUI UIInputHolderDeathRateHolderWarning{ get; protected set; }
	public TextMeshProUGUI UIInputHolderDeathRateHolderText{ get; protected set; }
	public TMP_InputField UIInputHolderDeathRateHolderDeathRateInput{ get; protected set; }
	public RectTransform UIInputHolderDeathRateHolderDeathRateInputTextArea{ get; protected set; }
	public TextMeshProUGUI UIInputHolderDeathRateHolderDeathRateInputTextAreaPlaceholder{ get; protected set; }
	public TextMeshProUGUI UIInputHolderDeathRateHolderDeathRateInputTextAreaText{ get; protected set; }
	public RectTransform UIInputHolderHospitalizationRateHolder{ get; protected set; }
	public TextMeshProUGUI UIInputHolderHospitalizationRateHolderWarning{ get; protected set; }
	public TextMeshProUGUI UIInputHolderHospitalizationRateHolderText{ get; protected set; }
	public TMP_InputField UIInputHolderHospitalizationRateHolderHospitalizationRateInput{ get; protected set; }
	public RectTransform UIInputHolderHospitalizationRateHolderHospitalizationRateInputTextArea{ get; protected set; }
	public TextMeshProUGUI UIInputHolderHospitalizationRateHolderHospitalizationRateInputTextAreaPlaceholder{ get; protected set; }
	public TextMeshProUGUI UIInputHolderHospitalizationRateHolderHospitalizationRateInputTextAreaText{ get; protected set; }
	public RectTransform UIInputHolderIncubationTimeHolder{ get; protected set; }
	public TextMeshProUGUI UIInputHolderIncubationTimeHolderWarning{ get; protected set; }
	public TextMeshProUGUI UIInputHolderIncubationTimeHolderText{ get; protected set; }
	public TMP_InputField UIInputHolderIncubationTimeHolderIncubationTimeInput{ get; protected set; }
	public RectTransform UIInputHolderIncubationTimeHolderIncubationTimeInputTextArea{ get; protected set; }
	public TextMeshProUGUI UIInputHolderIncubationTimeHolderIncubationTimeInputTextAreaPlaceholder{ get; protected set; }
	public TextMeshProUGUI UIInputHolderIncubationTimeHolderIncubationTimeInputTextAreaText{ get; protected set; }
	public Button UIInputHolderStartButton{ get; protected set; }
	public TextMeshProUGUI UIInputHolderStartButtonText{ get; protected set; }
	public RectTransform UIPreSetHolder{ get; protected set; }
	public Button UIPreSetHolderNormalFluButton{ get; protected set; }
	public TextMeshProUGUI UIPreSetHolderNormalFluButtonText{ get; protected set; }
	public Button UIPreSetHolderCovidButton{ get; protected set; }
	public TextMeshProUGUI UIPreSetHolderCovidButtonText{ get; protected set; }
	public Button UIPreSetHolderSARSButton{ get; protected set; }
	public TextMeshProUGUI UIPreSetHolderSARSButtonText{ get; protected set; }
	public Button UIPreSetHolderMERS{ get; protected set; }
	public TextMeshProUGUI UIPreSetHolderMERSText{ get; protected set; }

	private void Awake()
	{
		UITitle = transform.Find("Title").GetComponent<TextMeshProUGUI>();
		UIInputHolder = transform.Find("InputHolder").GetComponent<RectTransform>();
		UIInputHolderSpreadRateHolder = transform.Find("InputHolder/SpreadRateHolder").GetComponent<RectTransform>();
		UIInputHolderSpreadRateHolderText = transform.Find("InputHolder/SpreadRateHolder/Text").GetComponent<TextMeshProUGUI>();
		UIInputHolderSpreadRateHolderSpreadRateInput = transform.Find("InputHolder/SpreadRateHolder/SpreadRateInput").GetComponent<TMP_InputField>();
		UIInputHolderSpreadRateHolderSpreadRateInputTextArea = transform.Find("InputHolder/SpreadRateHolder/SpreadRateInput/Text Area").GetComponent<RectTransform>();
		UIInputHolderSpreadRateHolderSpreadRateInputTextAreaPlaceholder = transform.Find("InputHolder/SpreadRateHolder/SpreadRateInput/Text Area/Placeholder").GetComponent<TextMeshProUGUI>();
		UIInputHolderSpreadRateHolderSpreadRateInputTextAreaText = transform.Find("InputHolder/SpreadRateHolder/SpreadRateInput/Text Area/Text").GetComponent<TextMeshProUGUI>();
		UIInputHolderSpreadRateHolderWarning = transform.Find("InputHolder/SpreadRateHolder/Warning").GetComponent<TextMeshProUGUI>();
		UIInputHolderDeathRateHolder = transform.Find("InputHolder/DeathRateHolder").GetComponent<RectTransform>();
		UIInputHolderDeathRateHolderWarning = transform.Find("InputHolder/DeathRateHolder/Warning").GetComponent<TextMeshProUGUI>();
		UIInputHolderDeathRateHolderText = transform.Find("InputHolder/DeathRateHolder/Text").GetComponent<TextMeshProUGUI>();
		UIInputHolderDeathRateHolderDeathRateInput = transform.Find("InputHolder/DeathRateHolder/DeathRateInput").GetComponent<TMP_InputField>();
		UIInputHolderDeathRateHolderDeathRateInputTextArea = transform.Find("InputHolder/DeathRateHolder/DeathRateInput/Text Area").GetComponent<RectTransform>();
		UIInputHolderDeathRateHolderDeathRateInputTextAreaPlaceholder = transform.Find("InputHolder/DeathRateHolder/DeathRateInput/Text Area/Placeholder").GetComponent<TextMeshProUGUI>();
		UIInputHolderDeathRateHolderDeathRateInputTextAreaText = transform.Find("InputHolder/DeathRateHolder/DeathRateInput/Text Area/Text").GetComponent<TextMeshProUGUI>();
		UIInputHolderHospitalizationRateHolder = transform.Find("InputHolder/HospitalizationRateHolder").GetComponent<RectTransform>();
		UIInputHolderHospitalizationRateHolderWarning = transform.Find("InputHolder/HospitalizationRateHolder/Warning").GetComponent<TextMeshProUGUI>();
		UIInputHolderHospitalizationRateHolderText = transform.Find("InputHolder/HospitalizationRateHolder/Text").GetComponent<TextMeshProUGUI>();
		UIInputHolderHospitalizationRateHolderHospitalizationRateInput = transform.Find("InputHolder/HospitalizationRateHolder/HospitalizationRateInput").GetComponent<TMP_InputField>();
		UIInputHolderHospitalizationRateHolderHospitalizationRateInputTextArea = transform.Find("InputHolder/HospitalizationRateHolder/HospitalizationRateInput/Text Area").GetComponent<RectTransform>();
		UIInputHolderHospitalizationRateHolderHospitalizationRateInputTextAreaPlaceholder = transform.Find("InputHolder/HospitalizationRateHolder/HospitalizationRateInput/Text Area/Placeholder").GetComponent<TextMeshProUGUI>();
		UIInputHolderHospitalizationRateHolderHospitalizationRateInputTextAreaText = transform.Find("InputHolder/HospitalizationRateHolder/HospitalizationRateInput/Text Area/Text").GetComponent<TextMeshProUGUI>();
		UIInputHolderIncubationTimeHolder = transform.Find("InputHolder/IncubationTimeHolder").GetComponent<RectTransform>();
		UIInputHolderIncubationTimeHolderWarning = transform.Find("InputHolder/IncubationTimeHolder/Warning").GetComponent<TextMeshProUGUI>();
		UIInputHolderIncubationTimeHolderText = transform.Find("InputHolder/IncubationTimeHolder/Text").GetComponent<TextMeshProUGUI>();
		UIInputHolderIncubationTimeHolderIncubationTimeInput = transform.Find("InputHolder/IncubationTimeHolder/IncubationTimeInput").GetComponent<TMP_InputField>();
		UIInputHolderIncubationTimeHolderIncubationTimeInputTextArea = transform.Find("InputHolder/IncubationTimeHolder/IncubationTimeInput/Text Area").GetComponent<RectTransform>();
		UIInputHolderIncubationTimeHolderIncubationTimeInputTextAreaPlaceholder = transform.Find("InputHolder/IncubationTimeHolder/IncubationTimeInput/Text Area/Placeholder").GetComponent<TextMeshProUGUI>();
		UIInputHolderIncubationTimeHolderIncubationTimeInputTextAreaText = transform.Find("InputHolder/IncubationTimeHolder/IncubationTimeInput/Text Area/Text").GetComponent<TextMeshProUGUI>();
		UIInputHolderStartButton = transform.Find("InputHolder/StartButton").GetComponent<Button>();
		UIInputHolderStartButtonText = transform.Find("InputHolder/StartButton/Text").GetComponent<TextMeshProUGUI>();
		UIPreSetHolder = transform.Find("PreSetHolder").GetComponent<RectTransform>();
		UIPreSetHolderNormalFluButton = transform.Find("PreSetHolder/NormalFluButton").GetComponent<Button>();
		UIPreSetHolderNormalFluButtonText = transform.Find("PreSetHolder/NormalFluButton/Text").GetComponent<TextMeshProUGUI>();
		UIPreSetHolderCovidButton = transform.Find("PreSetHolder/CovidButton").GetComponent<Button>();
		UIPreSetHolderCovidButtonText = transform.Find("PreSetHolder/CovidButton/Text").GetComponent<TextMeshProUGUI>();
		UIPreSetHolderSARSButton = transform.Find("PreSetHolder/SARSButton").GetComponent<Button>();
		UIPreSetHolderSARSButtonText = transform.Find("PreSetHolder/SARSButton/Text").GetComponent<TextMeshProUGUI>();
		UIPreSetHolderMERS = transform.Find("PreSetHolder/MERS").GetComponent<Button>();
		UIPreSetHolderMERSText = transform.Find("PreSetHolder/MERS/Text").GetComponent<TextMeshProUGUI>();
	}
}
}
