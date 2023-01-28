using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_hit : MonoBehaviour
{
    public Material hitmaterial;
    public Material defaultmaterial;

    public void hit(float tiempo)
    {
        Invoke("hitteado", 0);
        Invoke("unhitteado", tiempo);
    }
    public void hitteado()
    {
        gameObject.GetComponent<SpriteRenderer>().material = hitmaterial;
    }

    public void unhitteado()
    {
        gameObject.GetComponent<SpriteRenderer>().material = defaultmaterial;
    }
}
