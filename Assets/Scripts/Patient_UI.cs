using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Patient_UI : MonoBehaviour
{
    public Patient patient;
    public TextMeshProUGUI Text;
    public Image background;

    public void DisplayText(string text){
        Text.text=text;
    }
}
