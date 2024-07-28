using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PatientsManager : MonoBehaviour
{
    public GameObject Monitor_PatientsHolder;
    public Patient ExamplePatient;

    public Patient_UI ExampleUiPatient;
    public Color[] ItemColors = new Color[2];

    int TrackTransform = 0;
    int ExamplePatientsCount = 5;
    void Start()
    {
        for (int i = 0; i < ExamplePatientsCount; i++, TrackTransform++)
        {
            Patient pt = Instantiate(ExamplePatient, transform);
            pt.p_ui = Instantiate(ExampleUiPatient, Monitor_PatientsHolder.transform);
            pt.patientsManager = this;
        }
        ColorizePatientMonitorItems();
    }

    public void ColorizePatientMonitorItems()
    {
        for (int i = 0; i < Monitor_PatientsHolder.transform.childCount; i++)
        {
            Patient_UI p = Monitor_PatientsHolder.transform.GetChild(i).GetComponent<Patient_UI>();
            p.background.color = ItemColors[i % 2];
        }
    }
    void OnTransformChildrenChanged()
    {
        if (TrackTransform >= ExamplePatientsCount)
        {
            ColorizePatientMonitorItems();
        }
    }
}
