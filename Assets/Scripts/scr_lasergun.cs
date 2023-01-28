using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_lasergun : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100000000000;
    public Transform laserFirepoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;
    public float timer;
    public float maxtimer;
    public GameObject Player;
    public float margin;
    public float Yoffset;
    private float hitplayer;
    public GameObject particulalaser;
    public bool activado;
    public float activar;
    public float dañolaser;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxtimer && activado)
        {
            Shootlaser();
            if (timer >= maxtimer + Random.Range(1, 2))
            {
                StopShootlaser();
                timer = 0;
                maxtimer = Random.Range(2, 5);
            }
        }

        if (!activado)
        {
            StopShootlaser();
            if (timer >= activar)
            {
                GetComponentInParent<scr_enemy1>().vida = GetComponentInParent<scr_enemy1>().vidaori;
                GetComponentInParent<Animator>().SetBool("activated", true);
                activado = true;
                timer = 0;
                maxtimer = Random.Range(2, 5);
            }
        }
    }

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    public void Shootlaser()
    {
        if(Physics2D.Raycast(m_transform.position, -transform.up))
        {
            RaycastHit2D _hit = Physics2D.Raycast(m_transform.position, -transform.up);
            Draw2DRay(laserFirepoint.position, _hit.point);

            hitplayer = Player.transform.position.y + Yoffset;

            if(_hit.point.y >= hitplayer - margin && _hit.point.y <= hitplayer + margin)
            {
                gameObject.GetComponent<scr_screenshaker>().Shake(0.15f, 0.1f);
                particulalaser.transform.position = new Vector3 (_hit.point.x, _hit.point.y, 0.9700003f);
                Player.GetComponent<scr_hit>().hit(0.1f);
                Player.GetComponent<scr_player>().vida -= dañolaser * Time.deltaTime;
            }
            else
            {
                particulalaser.transform.position = new Vector3(100, 100, 0.9700003f);
            }
        }
        else
        {
            Draw2DRay(laserFirepoint.position, -laserFirepoint.transform.up * defDistanceRay);
            particulalaser.transform.position = new Vector3(100, 100, 0.9700003f);
        }

    }

    public void StopShootlaser()
    {
        Draw2DRay(new Vector2(100, 100), new Vector2(100, 100));
        particulalaser.transform.position = new Vector3(100, 100, 0.9700003f);
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }
}
