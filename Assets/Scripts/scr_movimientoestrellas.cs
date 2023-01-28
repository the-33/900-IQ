using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_movimientoestrellas : MonoBehaviour
{

    public GameObject follow;
    private Transform playertransform;
    private Vector3 previousplayerposition;

    // Start is called before the first frame update
    void Start()
    {
        playertransform = follow.transform;
        previousplayerposition = playertransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = (playertransform.position.x - previousplayerposition.x) * 20f * Time.deltaTime;
        float deltaY = (playertransform.position.y - previousplayerposition.y) * 20f * Time.deltaTime;
        transform.Translate(new Vector3(-deltaY, deltaX, 0));
        previousplayerposition = playertransform.position;
    }
}
