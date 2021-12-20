using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipPrezent : MonoBehaviour
{
    public Data data;
    public SpaceshipInfo spacInfo;

    static GameObject cam;
    static float interval, speedJ, speedR;

    public float posX, posY, randStart;

    void Start()
    {
        cam = data.cam;

        interval = data.interval;
        speedJ = data.speedJ;
        speedR = data.speedR;

        transform.position = new Vector3(spacInfo.num * interval ,0.8f ,0f);

        randStart = Random.Range(0f, 1f);
        posX = transform.position.x;
        posY = transform.position.y;
    }

    void FixedUpdate()
    {
        if(cam.transform.position.x > posX - interval && cam.transform.position.x < posX + interval)
        {
            transform.position = new Vector3(posX, posY + Mathf.Sin(Time.fixedTime / speedJ + randStart) * 0.15f, 0f);
            transform.Rotate (0f, speedR, 0f);
        }
        else
        {
            transform.Rotate (0f, 0f, 0f);
        }
    }
}
