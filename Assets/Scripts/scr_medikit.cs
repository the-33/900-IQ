using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_medikit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
