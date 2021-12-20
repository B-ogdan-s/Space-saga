using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastEnemy : MonoBehaviour
{
    public GameObject goal;

    public int x, y;
    public float grad;

    public EnemyAI input;

    void FixedUpdate()
    {
        RaycastHit hit;

        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) + new Vector3(0f, -Math(grad) + Math(i * grad * 2 / (y - 1)), 
                                                                                                                    -Math(grad) + Math(j * grad*2/(x - 1))), out hit, 300))
                {
                    input.input[i * 15 + j] = hit.distance;
                }
            }
        }
        input.input[225] = Vector3.Distance(transform.position, goal.transform.position);
    }

    public float Math(float r)
    {
        return r * (Mathf.PI / 180f);
    }
}
