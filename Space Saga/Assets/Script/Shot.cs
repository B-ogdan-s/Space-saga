using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public ShotButton shotButt;

    public Transform start;
    public GameObject lazer, spa, goal;

    public float speed;
    public int time = 0;

    void Start()
    {
        shotButt = GameObject.Find("Shot").GetComponent<ShotButton>();
        goal = GameObject.Find("Goal");
    }

    void FixedUpdate()
    {
        transform.LookAt(goal.transform);

        time++;

        if (shotButt.shot == true)
        {
            if (time >= 25)
            {
                spa = Instantiate(lazer, start.position, start.rotation) as GameObject;
                spa.GetComponent<Rigidbody>().velocity = start.forward * speed;

                time = 0;
            }
        }
    }
}