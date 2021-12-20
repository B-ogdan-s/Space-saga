using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerTrafic : MonoBehaviour
{
    public int time=0;

    /*
     * время жизни лазера
     */
    void Update()
    {
        time++;

        if(time>=400)
        {
            Destroy(gameObject);
        }
    }

    /*
     * проверка на тригер
     */
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            Destroy(gameObject);
        }
    }
}
