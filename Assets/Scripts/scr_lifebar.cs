using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_lifebar : MonoBehaviour
{
    public Image background;
    public Image lifebar;

    public void actualizarlifebar()
    {
        lifebar.fillAmount = GetComponent<scr_player>().vida / 10;
    }

    public void morir()
    {
        background.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 515f * Time.deltaTime));
        background.GetComponent<Rigidbody2D>().gravityScale = 1f;
    }
}
