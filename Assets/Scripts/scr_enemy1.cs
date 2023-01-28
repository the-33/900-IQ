using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_enemy1 : MonoBehaviour
{

    public float empuje;
    public Vector2 velocidadrot;
    public int vida;
    public int vidaori;

    // Start is called before the first frame update
    void Start()
    {
        vidaori = vida;
}

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0 && GetComponentInChildren<scr_lasergun>().activado)
        {
            gameObject.GetComponent<Animator>().SetBool("activated", false);
            GetComponentInChildren<scr_lasergun>().activado = false;
            GetComponentInChildren<scr_lasergun>().activar = Random.Range(7, 15);
            GetComponentInChildren<scr_lasergun>().timer = 0;
        }

        if (transform.position.x < 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(empuje * Time.deltaTime, 0));
        }

        if (transform.position.x > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-empuje * Time.deltaTime, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "laser(Clone)")
        {
            vida -= 1;
            gameObject.GetComponent<scr_hit>().hit(0.1f);
        }

        if (collision.gameObject.name == "Bala(Clone)")
        {
            gameObject.GetComponent<scr_hit>().hit(0.1f);
        }
    }
}
