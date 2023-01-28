using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scr_temporizadortotal : MonoBehaviour
{
    public float timer;
    public Text texto;
    public Text textogrande;
    private float flicker;
    public Text subtexto;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject reseteador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<scr_player>().vida <= 0)
        {
            texto.text = "";
            textogrande.fontSize = 250;
            textogrande.text = "LOSE";
            subtexto.text = timer.ToString("");
            Enemy1.GetComponent<scr_enemy1>().vida = 0;
            Enemy1.GetComponent<scr_explosion>().explotar(0.45f);
            Destroy(Enemy1, 0.5f);
            Destroy(Enemy2);
            GameObject.Find("Enemy2(Clone)").GetComponent<scr_enemy2>().vida = 0;
            reseteador.GetComponent<scr_reseteador>().active = true;
        }

        timer += Time.deltaTime;
        if (timer <1000)
        {
            texto.text = timer.ToString("");
        }
        else
        {
            texto.text = "";
            flicker += Time.deltaTime;
            if (flicker >= 0.5)
            {
                subtexto.text = "999";
                if (flicker >= 1)
                {
                    flicker = 0;
                }
            }
            else
            {
                subtexto.text = "";
            }
            textogrande.text = "WIN";
            Enemy1.GetComponent<scr_enemy1>().vida = 0;
            Enemy1.GetComponent<scr_explosion>().explotar(0.45f);
            Destroy(Enemy1, 0.5f);
            Destroy(Enemy2);
            GameObject.Find("Enemy2(Clone)").GetComponent<scr_enemy2>().vida = 0;
            reseteador.GetComponent<scr_reseteador>().active = true;
        }
    }
}
