using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Patient : MonoBehaviour
{
    public PatientsManager patientsManager;

    public string Name { get { return p_ui.Name.text; } set { p_ui.Name.text = value; } }
    public int Gender { get; set; }
    public int Weight { get; set; }
    public string WantsTo { get; set; }

    public Patient_UI p_ui;
    public PatientAi pAi;

    public PatientPropPanelManager pppm;

    void Start()
    {
        pAi.patient = this;
        p_ui.patient = this;
        p_ui.DeletePatient.onClick.AddListener(() => DestroyPatient());

        for (int i = 0; i < 6; i++)
        {
            Name += Convert.ToChar(UnityEngine.Random.Range(65, 91));
        }
        Gender = UnityEngine.Random.Range(0, 10);
        Weight = UnityEngine.Random.Range(50, 180);
        WantsTo = (Weight > 100) ? "Get Fit" : "Get Muscles";
    }

    public void DestroyPatient()
    {
        Destroy(p_ui.gameObject);
        Destroy(gameObject);
    }
}
