using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_screenshaker : MonoBehaviour
{
    public Camera mainCam;
    float shakeAmount = 0;

    void Awake()
    {
        if (mainCam == null)
        {
            mainCam = Camera.main;
        }
    }
    public void Beginshake()
    {
        if (shakeAmount > 0)
        {
            Vector3 camPos = mainCam.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;

            mainCam.transform.position = camPos;
        }
    }

    public void Stopshake()
    {
        CancelInvoke("Beginshake");
        mainCam.transform.localPosition = new Vector3(0, 0, -10);
    }

    public void Shake(float amt, float length)
    {
        shakeAmount = amt;
        InvokeRepeating("Beginshake", 0, 0.01f);
        Invoke("Stopshake", length);
    }
}
