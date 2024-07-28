using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Patient : MonoBehaviour
{
    public PatientsManager patientsManager;

    public string Name { get { return p_ui.Name.text; } set { p_ui.Name.text = value; } }
    public int Gender { get; set; }
    public int Weight { get; set; }
    public string WantsTo { get; set; }

    public Patient_UI p_ui;

    void Start()
    {
        p_ui.patient = this;
        p_ui.DeletePatient.onClick.AddListener(()=>DestroyPatient());
        
        for (int i = 0; i < 6; i++)
        {
            Name += Convert.ToChar(UnityEngine.Random.Range(65, 91));
        }
    }
    
    public void DestroyPatient()
    {
        Destroy(p_ui.gameObject);
        Destroy(gameObject);
    }
}
