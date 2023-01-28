using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scr_reseteador : MonoBehaviour
{
    private float flicker;
    public Text reset;
    public bool active;

    void Update()
    {
        if (active)
        {
            flicker += Time.deltaTime;
            if (flicker >= 0.5)
            {
                reset.text = "[Pulsa R para reiniciar]";
                if (flicker >= 1)
                {
                    flicker = 0;
                }
            }
            else
            {
                reset.text = "";
            }

            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("Juego");
            }
        }
    }
}
