using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTraffic : MonoBehaviour
{
    public EnemyAI enemyAI;

    public float speedRot, speedTraf;

    public float acceleration, accelerationRotZ = 0f, accelerationRotX = 0f;

    void FixedUpdate()
    {
        enemyAI.AI();

        AccelerationRotate();

        transform.Rotate(accelerationRotX *  (1f / speedRot), 0f, -accelerationRotZ *  (1f / speedRot));

        if ((enemyAI.output[0] * 500) < acceleration)
        {
            Acceleration(-6f);
        }
        else if ((enemyAI.output[0] * 500) > acceleration)
        {
            Acceleration(6f);
        }

        transform.Translate(0f, 0f, Time.deltaTime * speedTraf * (acceleration / 500f));


    }

    public void Acceleration(float accel)
    {
        acceleration += accel;

        if (Mathf.Abs(acceleration - (enemyAI.output[0] * 500)) <= 1f)
        {
            acceleration = (enemyAI.output[0] * 500);
        }
    }

    public void AccelerationRotate()
    {
        if (accelerationRotX < (enemyAI.output[1] - enemyAI.output[2]) * 300)
            accelerationRotX += 6f;
        else if (accelerationRotX > (enemyAI.output[1] - enemyAI.output[2]) * 300)
            accelerationRotX -= 6f;

        if (accelerationRotZ < (enemyAI.output[3] - enemyAI.output[4]) * 300)
            accelerationRotZ += 6f;
        else if (accelerationRotZ > (enemyAI.output[3] - enemyAI.output[4]) * 300)
            accelerationRotZ -= 6f;

        if (Mathf.Abs(accelerationRotX - (enemyAI.output[1] - enemyAI.output[2]) * 300) <= 0.5f)
        {
            accelerationRotX = (enemyAI.output[1] - enemyAI.output[2]) * 300;
        }
        if (Mathf.Abs(accelerationRotZ - (enemyAI.output[3] - enemyAI.output[4]) * 300) <= 0.5f)
        {
            accelerationRotZ = (enemyAI.output[3] - enemyAI.output[4]) * 300;
        }
    }
}
