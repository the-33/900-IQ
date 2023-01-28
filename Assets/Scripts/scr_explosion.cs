using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_explosion : MonoBehaviour
{

    public GameObject explosion;

    public void explotar(float tiempo)
    {
        Invoke("explo", tiempo);
    }

    private void explo()
    {
        Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 0));
    }
}
