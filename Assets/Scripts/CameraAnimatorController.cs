using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimatorController : MonoBehaviour
{
    public Animation anim;
    bool zoom = false;
    public void SwitchZoom()
    {
        if (!anim.isPlaying)
        {
            anim.Play("CameraZoom" + (zoom ? "Out" : "In"));
            zoom = !zoom;
        }
    }
}
