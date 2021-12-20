using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBol : MonoBehaviour
{

    public int time = 0;

    /*
     * время жизни лазера
     */
    void Update()
    {
        time++;

        if (time >= 4)
        {
            Destroy(gameObject);
        }
    }
}
