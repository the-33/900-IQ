using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_player : MonoBehaviour
{

    public Vector3 movimiento;
    public float velocidad;
    public GameObject bala;
    public GameObject laser;
    public float timerbala;
    public float timerlaser;
    public float esperabala;
    public float esperalaser;
    public float vida;
    public float dañofuera;
    public Text healthnum;
    public float counter;
    public float masvida;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<scr_lifebar>().actualizarlifebar();
        gameObject.GetComponent<scr_timerbala>().actualizartimer();

        if (vida <= 0)
        {
            gameObject.GetComponent<scr_hit>().hit(1f);
            gameObject.GetComponent<scr_screenshaker>().Shake(0.005f, 1f);
            gameObject.GetComponent<scr_explosion>().explotar(1f);
            gameObject.GetComponent<scr_lifebar>().morir();
            gameObject.GetComponent<scr_timerbala>().morir();
            Destroy(gameObject, 1f);
        }
        else
        {

            if (vida > 10)
            {
                vida = 10;
            }

            movimiento = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            movimiento = movimiento.normalized * velocidad;
            gameObject.GetComponent<Rigidbody2D>().AddForce(movimiento * Time.deltaTime);

            if (Input.GetKey(KeyCode.Space) && timerlaser <= 0)
            {
                Instantiate(laser, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.Euler(0, 0, 0));
                timerlaser = esperalaser;
            }

            if (Input.GetKey(KeyCode.Mouse0) && timerbala <= 0)
            {
                Instantiate(bala, new Vector2(transform.position.x, transform.position.y + 0.2f), Quaternion.Euler(0, 0, 0));
                timerbala = esperabala;
            }

            if (transform.position.x >= 2.9 || transform.position.x <= -2.9 || transform.position.y >= 5.2 || transform.position.y <= -5.2)
            {
                gameObject.GetComponent<scr_screenshaker>().Shake(0.15f, 0.1f);
                gameObject.GetComponent<scr_hit>().hit(0.1f);
                vida -= dañofuera * Time.deltaTime;
            }

            timerbala -= Time.deltaTime;
            timerlaser -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy2(Clone)" || collision.gameObject.name == "Enemy1")
        {
            gameObject.GetComponent<scr_screenshaker>().Shake(0.15f, 0.1f);
            gameObject.GetComponent<scr_hit>().hit(0.1f);
            vida -= 1;
        }

        if (collision.gameObject.name == "medikit(Clone)")
        {
            if (vida < 10)
            {
                masvida = Random.Range(1f, 4f);
                vida += masvida;
                gameObject.GetComponent<scr_heal>().heal(0.2f);
                counter += Time.deltaTime;
                subirvida();
            }
        }
    }

    void subirvida()
    {
        Invoke("ponernumvida", 0f);
        Invoke("quitarnumvida", 0.5f);
    }

    void ponernumvida()
    {
        healthnum.text = "+" + masvida;
    }

    void quitarnumvida()
    {
        healthnum.text = "";
    }
}