using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_bala : MonoBehaviour
{

    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10f));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 1)
        {
            Vector3 mouseworldposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseworldposition.z = 0;

            Vector3 lookatdirection = mouseworldposition - transform.position;
            transform.up = lookatdirection;

            gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, 40f * Time.deltaTime));
            gameObject.GetComponent<Animator>().SetBool("propulsor", true);
        }

        if (transform.position.y >= 7 || transform.position.y <= -7 || transform.position.x >= 4 || transform.position.x <= -4)
        {
            gameObject.GetComponent<scr_screenshaker>().Stopshake();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bala(Clone)")
        {
            gameObject.GetComponent<scr_explosion>().explotar(0f);
            Destroy(gameObject, 0.1f);
        }

        if (timer >= 1)
        {
            if (collision.gameObject.name == "Player")
            {
                gameObject.GetComponent<scr_screenshaker>().Shake(0.15f, 0.1f);
                gameObject.GetComponent<scr_explosion>().explotar(0f);
                Destroy(gameObject, 0.1f);
                collision.GetComponent<scr_hit>().hit(0.1f);
                collision.GetComponent<scr_player>().vida -= 3.4f;
            }

            if (collision.gameObject.name == "Enemy1")
            {
                gameObject.GetComponent<scr_screenshaker>().Shake(0.1f, 0.1f);
                gameObject.GetComponent<scr_explosion>().explotar(0f);
                Destroy(gameObject, 0.1f);
                collision.GetComponent<scr_enemy1>().vida = 0;
            }

            if (collision.gameObject.name == "Enemy2(Clone)")
            {
                gameObject.GetComponent<scr_screenshaker>().Shake(0.1f, 0.1f);
                gameObject.GetComponent<scr_explosion>().explotar(0f);
                Destroy(gameObject, 0.1f);
                collision.GetComponent<scr_enemy2>().vida = 0;
            }
        }
    }
}
