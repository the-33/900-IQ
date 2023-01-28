using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_enemy2 : MonoBehaviour
{

    public float empuje;
    public Vector2 velocidadrot;
    public float multiplicadorrot;
    public float velocidadbajada;
    public int vida;
    public GameObject botiquin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -7)
        {
            Destroy(gameObject);
        }

        if (vida <= 0)
        {
            gameObject.GetComponent<scr_explosion>().explotar(0f);
            if (Random.Range(0, 10) < 2)
            {
                Instantiate(botiquin, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.Euler(0, 0, 0));
            }
            Destroy(gameObject);
        }

        velocidadrot = gameObject.GetComponent<Rigidbody2D>().velocity;
        transform.Rotate(0, 0, velocidadrot.x * multiplicadorrot * Time.deltaTime);

        if (transform.position.x < 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(empuje * Time.deltaTime, 0));
        }

        if (transform.position.x > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-empuje * Time.deltaTime, 0));
        }

        transform.position += new Vector3(0, velocidadbajada * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "laser(Clone)")
        {
            vida -= 1;
            gameObject.GetComponent<scr_hit>().hit(0.1f);
        }
    }
}
