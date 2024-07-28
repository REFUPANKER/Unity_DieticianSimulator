using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NotificationManager : MonoBehaviour
{
    public Animation anim;
    public TextMeshProUGUI contentLabel;
    public float showtime=3;

    public void ShowNotification(string message)
    {
        NotificationManager newMessage = Instantiate(this, transform.parent);
        newMessage.contentLabel.text = message;
        newMessage.anim.Play("NotificationShow");
        StartCoroutine(HideBack(newMessage, showtime));
    }
    
    public IEnumerator HideBack(NotificationManager newMsg, float showtime)
    {
        yield return new WaitForSeconds(showtime);
        newMsg.anim.Play("NotificationHide");
        yield return new WaitForSeconds(1);
        Destroy(newMsg.gameObject);
    }
}
