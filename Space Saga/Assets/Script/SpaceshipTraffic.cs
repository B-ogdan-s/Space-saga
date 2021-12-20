using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipTraffic : MonoBehaviour
{
    public Collision coll;
    public Over over;

    public GamePanelCoordinat GPL;
    public Save save;
    public SaveUp saveUp;

    public Transform start;
    public GameObject[] spaceship;
    public GameObject spa, cam;

    public float speedRot, speedTraf, speed, r;

    public float z = 0f, x = 0f, acceleration, accelerationRotZ = 0f, accelerationRotX = 0f;

    public Vector3 vector;

    void Start()
    {

        int i = save.OutputInfoStartLevel();
        spa = Instantiate(spaceship[i]) as GameObject;

        spa.transform.SetParent(start);

        coll = spa.GetComponent<Collision>();

        speedTraf = save.SpeedSpac();

        acceleration = GPL.controlRight.transform.localPosition.y + 250f;
    }

    void FixedUpdate()
    {
        vector = GPL.controlCoordinatLeft;
        speed = GPL.controlRight.transform.localPosition.y + 250f;

        r = (vector.x * vector.x) + (vector.y * vector.y);

        AccelerationRotate();

        transform.Rotate(accelerationRotX * (1f / speedRot), 0f, -accelerationRotZ * (1f / speedRot));

        if(speed < acceleration)
        {
            Acceleration(-(3f + saveUp.OutputAccelerationSpeed()));
        }
        else if(speed > acceleration)
        {
            Acceleration((3f + saveUp.OutputAccelerationSpeed()));
        }

        transform.Translate(0f, 0f, Time.deltaTime * speedTraf * (acceleration / 500f));

        if(coll.coll==true)
        {
            over.GameOver();
        }
    }

    public void Acceleration(float accel)
    {
        acceleration += accel;

        if(Mathf.Abs(acceleration - speed) <= 1f)
        {
            acceleration = speed;
        }
    }

    public void AccelerationRotate()
    {
        if(accelerationRotX < vector.y)
            accelerationRotX += 3f + saveUp.OutputAccelerationRotat();
        else if(accelerationRotX > vector.y)
            accelerationRotX -= 3f + saveUp.OutputAccelerationRotat();

        if (accelerationRotZ < vector.x)
            accelerationRotZ += 3f + saveUp.OutputAccelerationRotat();
        else if (accelerationRotZ > vector.x)
            accelerationRotZ -= 3f + saveUp.OutputAccelerationRotat();

        if (Mathf.Abs(accelerationRotX - vector.y) <= 0.5f)
        {
            accelerationRotX = vector.y;
        }
        if (Mathf.Abs(accelerationRotZ - vector.x) <= 0.5f)
        {
            accelerationRotZ = vector.x;
        }
    }
}
