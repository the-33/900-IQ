using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_timerbala : MonoBehaviour
{
    public Image timerbackground;
    public Image timer;
    public Text counter;

    public void actualizartimer()
    {
        if (GetComponent<scr_player>().timerbala <= 0)
        {
            counter.text = "";
        }
        else
        {
            counter.text = (GetComponent<scr_player>().timerbala).ToString("");
        }
        timer.fillAmount = 1 - GetComponent<scr_player>().timerbala / GetComponent<scr_player>().esperabala;
    }

    public void morir()
    {
        timerbackground.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 515f * Time.deltaTime));
        timerbackground.GetComponent<Rigidbody2D>().gravityScale = 1f;
    }
}