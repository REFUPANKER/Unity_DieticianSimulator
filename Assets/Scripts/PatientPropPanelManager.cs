using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PatientPropPanelManager : MonoBehaviour
{
    public TextMeshProUGUI Label_Name;
    public TextMeshProUGUI Label_Gender;
    public TextMeshProUGUI Label_Weight;
    public TextMeshProUGUI Label_WantsTo;

    public void FillLabels(Patient data)
    {
        Label_Name.text = data.name;
        Label_Gender.text = data.Gender.ToString();
        Label_Weight.text = data.Weight.ToString();
        Label_WantsTo.text = data.WantsTo;
    }
}
