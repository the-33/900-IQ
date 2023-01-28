using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_laser : MonoBehaviour
{

    public float velocidad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, velocidad * Time.deltaTime, 0);

        if (transform.position.y >= 7)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy2(Clone)" || collision.gameObject.name == "Enemy1" || collision.gameObject.name == "Bala(Clone)")
        {
            gameObject.GetComponent<scr_explosion>().explotar(0f);
            Destroy(gameObject);
        }
    }
}
