using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_enemyspawner : MonoBehaviour
{
    public GameObject enemy2;
    public float ratio2;
    float timer2;

    // Update is called once per frame
    void Update()
    {
        timer2 += Time.deltaTime;

        if (timer2 >= ratio2)
        {
            Instantiate(enemy2, new Vector3(Random.Range(-2.5f, -1.16f), 6, -2), Quaternion.Euler(0, 0, 0));
            timer2 = 0;
        }
    }
}
