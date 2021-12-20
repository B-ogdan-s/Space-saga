using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerTrafic : MonoBehaviour
{
    public int time=0;

    /*
     * ����� ����� ������
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
     * �������� �� ������
     */
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            Destroy(gameObject);
        }
    }
}
