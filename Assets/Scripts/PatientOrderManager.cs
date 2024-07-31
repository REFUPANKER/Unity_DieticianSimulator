using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PatientOrderManager : MonoBehaviour
{
    [Header("Patients manager")]
    public PatientsManager pmgr;
    [Header("Notifications manager")]
    public NotificationManager nfmgr;

    Patient ActivePatient;


    [Header("Monitor")]
    public PatientPropPanelManager PatientDetailsPanel;

    public void CallNext()
    {
        if (ActivePatient == null)
        {
            if (pmgr.transform.childCount > 0)
            {
                Transform child = pmgr.transform.GetChild(0);
                child.GetComponent<PatientAi>().RoomEnter();
                ActivePatient = child.GetComponent<Patient>();
                ActivePatient.pppm = PatientDetailsPanel;
                nfmgr.ShowNotification("Patient " + ActivePatient.Name + " called in");
            }
            else
            {
                nfmgr.ShowNotification("No more patients existing");
            }
        }
        else
        {
            nfmgr.ShowNotification("Patient already existing");
        }
    }

    [Description("it means patient can leave the room")]
    public void PatientHealed()
    {
        if (ActivePatient != null)
        {
            ActivePatient.pAi.RoomLeave();
        }
        else
        {
            nfmgr.ShowNotification("Patient not existing");
        }
    }
}
